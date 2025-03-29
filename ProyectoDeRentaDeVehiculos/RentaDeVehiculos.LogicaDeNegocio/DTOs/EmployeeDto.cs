using RentaDeVehiculos.Entidades;

namespace RentaDeVehiculos.LogicaDeNegocio.DTOs
{
    public class CreateEmployeeRequest
    {
        public int? UserId { get; set; }
        public int? PersonalDataId { get; set; }
        public int? RoleId { get; set; }
        public DateTime? RegistrationDate { get; set; } = DateTime.Now;
    }

    public class UpdateEmployeeRequest
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? PersonalDataId { get; set; }
        public int? RoleId { get; set; }
        public DateTime? RegistrationDate { get; set; }
    }

    public class EmployeeResponse
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public string? UserName { get; set; }
        public int? PersonalDataId { get; set; }
        public string? RoleName { get; set; }
        public DateTime? RegistrationDate { get; set; }

        //public class RoleResponse
        //{
        //    public int Id { get; set; }

        //    public string? Name { get; set; }

        //}

    }
}
