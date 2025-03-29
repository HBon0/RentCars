using System;
using System.Collections.Generic;

namespace RentaDeVehiculos.Entities;

public partial class PersonalDatum
{
    public int Id { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Dui { get; set; }

    public string? Phone { get; set; }

    public DateOnly? BirthDate { get; set; }

    public string? Address { get; set; }

    public string Email { get; set; } = null!;

    public virtual Customer? Customer { get; set; }

    public virtual Employee? Employee { get; set; }

    public virtual User? User { get; set; }
}
