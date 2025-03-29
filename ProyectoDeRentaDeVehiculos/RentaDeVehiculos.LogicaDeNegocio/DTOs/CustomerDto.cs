using RentaDeVehiculos.Entidades;

namespace RentaDeVehiculos.LogicaDeNegocio.DTOs
{
    public class CreateCustomerRequest
    {
        public int? UserId { get; set; }
        public int? PersonalDataId { get; set; }
        public DateTime? RegistrationDate { get; set; } = DateTime.Now;
    }

    public class UpdateCustomerRequest
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? PersonalDataId { get; set; }
        public DateTime? RegistrationDate { get; set; }
    }

    public class CustomerResponse
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public string? UserName { get; set; }
        public int? PersonalDataId { get; set; }
        public DateTime? RegistrationDate { get; set; }
    }

    public class RoleResponse
    {
        public int Id { get; set; }

        public string? Name { get; set; }

    }

}
