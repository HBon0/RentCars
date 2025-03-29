namespace RentaDeVehiculos.LogicaDeNegocio.DTOs
{
    public class CreateUserRequest
    {
        public int PersonalDataId { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty; // Se enviará en texto plano y luego se encripta
        public int RoleId { get; set; } // Si manejas roles, puedes incluirlo aquí
    }

    public class UpdateUserRequest
    {
        public int Id { get; set; }
        public int PersonalDataId { get; set; }
        public string Username { get; set; } = string.Empty;
        public int RoleId { get; set; } // Si el usuario puede cambiar de rol
    }

    public class UserResponse
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public int PersonalDataId { get; set; }
        public string RoleName { get; set; } = string.Empty; // Se puede incluir el nombre del rol
    }
}
