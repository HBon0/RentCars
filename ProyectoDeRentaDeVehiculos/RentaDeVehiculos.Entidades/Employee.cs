using System;
using System.Collections.Generic;

namespace RentaDeVehiculos.Entidades;

public partial class Employee
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public int? PersonalDataId { get; set; }

    public int? RoleId { get; set; }

    public DateTime? RegistrationDate { get; set; }

    public virtual PersonalDatum? PersonalData { get; set; }

    public virtual required Role Role { get; set; }

    public virtual User? User { get; set; }
}
