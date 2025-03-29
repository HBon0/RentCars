using MediatR;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentaDeVehiculos.LogicaDeNegocio.DTOs;
using Microsoft.AspNetCore.Mvc.Rendering;
using Mapster;
using RentaDeVehiculos.LogicaDeNegocio.UseCases.Users.Commands.CreateUser;
using RentaDeVehiculos.LogicaDeNegocio.UseCases.Users.Commands.UpdateUser;
using RentaDeVehiculos.LogicaDeNegocio.UseCases.Users.Queries.GetRoles;
using System.Security.Claims;
using RentaDeVehiculos.LogicaDeNegocio.UseCases.Customers.Commands.Queries.GetRoles;
using GetRolesQuery = RentaDeVehiculos.LogicaDeNegocio.UseCases.Customers.Commands.Queries.GetRoles.GetRolesQuery;
using RentaDeVehiculos.LogicaDeNegocio.UseCases.Users.Queries;
using RentaDeVehiculos.LogicaDeNegocio.UseCases.Users.Commands.Queries.GetUserAuthenticated;
using RentaDeVehiculos.LogicaDeNegocio.UseCases.Users.Queries.GetUserAuthenticated;

namespace RentaDeVehiculos.AplicacionWeb.Controllers
{
    [Authorize]

    public class UserController : Controller
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [AllowAnonymous]

        public async Task<IActionResult> CerrarSesion(string? pReturnUrl = null)
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]

        public async Task<IActionResult> Login(GetUserAuthenticatedQuery getUserAuthenticatedQuery)
        {
            try
            {
                var userResponse = await _mediator.Send(getUserAuthenticatedQuery);
                if (userResponse != null && userResponse.Username == getUserAuthenticatedQuery.UserName)
                {
                    var claims = new[]
                    {
                       new Claim(ClaimTypes.Name, userResponse.Username),
                       new Claim("Id", userResponse.Id.ToString())
                    };
                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity), new AuthenticationProperties { IsPersistent = true }); ;
                    return RedirectToAction("Index", "Home");
                }
                else
                    throw new Exception("Credendenciales incorrectas");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(getUserAuthenticatedQuery);
            }

        }
        public async Task<IActionResult> Index()
        {
            var users = await _mediator.Send(new GetUserQuery());
            return View(users);
        }

        public async Task<IActionResult> Create()
        {
            var rols = await _mediator.Send(new GetRolesQuery());
            ViewData["RoleId"] = new SelectList(rols, "RoleId", "RolName");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]


        public async Task<IActionResult> Create(CreateUserRequest createUserRequest)
        {
            try
            {
                var result = await _mediator.Send(new CreateUserCommand(createUserRequest));
                if (result > 0)
                    return RedirectToAction(nameof(Index));
                else
                    throw new Exception("Sucedio un error al intentar guardar el nuevo usuario");
            }
            catch (Exception ex)
            {
                var rols = await _mediator.Send(new GetRolesQuery());
                ViewData["RoleId"] = new SelectList(rols, "RoleId", "RoleName");
                ModelState.AddModelError("", ex.Message);
                return View(createUserRequest);
            }
        }
        public async Task<IActionResult> Edit(int id)
        {
            var user = await _mediator.Send(new GetUserQuery(id));
            var rols = await _mediator.Send(new GetRolesQuery());
            ViewData["RoleId"] = new SelectList(rols, "RoleId", "RoleName", user.Id);
            return View(user.Adapt(new UpdateUserRequest()));
             
       
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Edit(UpdateUserRequest updateUserRequest)
        {
            try
            {
                var result = await _mediator.Send(new UpdateUserCommand(updateUserRequest));
                if (result > 0)
                    return RedirectToAction(nameof(Index));
                else
                    throw new Exception("Sucedio un error al intentar editar el usuario");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                var rols = await _mediator.Send(new GetRolesQuery());
                ViewData["RoleId"] = new SelectList(rols, "RoleId", "RoleName", updateUserRequest.RoleId);
                return View(updateUserRequest);
            }
        }
    }
}