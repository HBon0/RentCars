using System;
using System.Collections.Generic;

namespace RentalRR;

public partial class Reservation
{
    public int Id { get; set; }

    public int? CustomerId { get; set; }

    public int? VehicleId { get; set; }

    public int? RentalDays { get; set; }

    public DateTime? ReservationDate { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual Vehicle? Vehicle { get; set; }
}
