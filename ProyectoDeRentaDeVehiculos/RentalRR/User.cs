using System;
using System.Collections.Generic;

namespace RentalRR;

public partial class User
{
    public int Id { get; set; }

    public int? PersonalDataId { get; set; }

    public string? Username { get; set; }

    public byte[]? PasswordHash { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual Employee? Employee { get; set; }

    public virtual PersonalDatum? PersonalData { get; set; }
}
