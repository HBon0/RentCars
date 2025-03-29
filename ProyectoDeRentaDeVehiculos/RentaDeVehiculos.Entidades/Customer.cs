using System;
using System.Collections.Generic;

namespace RentaDeVehiculos.Entidades;

public partial class Customer
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public int? PersonalDataId { get; set; }

    public DateTime? RegistrationDate { get; set; }

    public virtual PersonalDatum? PersonalData { get; set; }

    public virtual ICollection<Rental> Rentals { get; set; } = new List<Rental>();

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();

    public virtual User? User { get; set; }
}
