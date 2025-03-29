using System;
using System.Collections.Generic;

namespace RentaDeVehiculos.Entidades;

public partial class Vehicle
{
    public int Id { get; set; }

    public string? Brand { get; set; }

    public string? Model { get; set; }

    public int? Year { get; set; }

    public decimal? Price { get; set; }

    public string? LicensePlate { get; set; }

    public string? ImageUrl { get; set; }

    public virtual Inventory? Inventory { get; set; }

    public virtual ICollection<Rental> Rentals { get; set; } = new List<Rental>();

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();

    public static T Adapt<T>()
    {
        throw new NotImplementedException();
    }
}
