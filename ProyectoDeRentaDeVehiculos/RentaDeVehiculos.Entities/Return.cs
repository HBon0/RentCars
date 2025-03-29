using System;
using System.Collections.Generic;

namespace RentaDeVehiculos.Entities;

public partial class Return
{
    public int Id { get; set; }

    public int? RentalId { get; set; }

    public decimal? ReturnMileage { get; set; }

    public DateTime? RegistrationDate { get; set; }

    public virtual Rental? Rental { get; set; }
}
