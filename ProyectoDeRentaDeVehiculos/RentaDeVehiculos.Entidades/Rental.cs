using System;
using System.Collections.Generic;

namespace RentaDeVehiculos.Entidades;

public partial class Rental
{
    public int Id { get; set; }

    public int? CustomerId { get; set; }

    public int? VehicleId { get; set; }

    public int? RentalDays { get; set; }

    public decimal? StartMileage { get; set; }

    public decimal? FinalPrice { get; set; }

    public DateTime? RentalDate { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual Return? Return { get; set; }

    public virtual Vehicle? Vehicle { get; set; }
}
