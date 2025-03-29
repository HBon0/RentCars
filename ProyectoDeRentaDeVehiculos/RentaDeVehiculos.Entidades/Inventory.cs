using System;
using System.Collections.Generic;

namespace RentaDeVehiculos.Entidades;

public partial class Inventory
{
    public int Id { get; set; }

    public int? VehicleId { get; set; }

    public int? VehicleQuantity { get; set; }

    public string? VehicleStatus { get; set; }

    public DateTime? RegistrationDate { get; set; }

    public virtual Vehicle? Vehicle { get; set; }
}
