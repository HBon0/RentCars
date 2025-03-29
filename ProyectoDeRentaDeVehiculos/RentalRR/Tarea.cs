using System;
using System.Collections.Generic;

namespace RentalRR;

public partial class Tarea
{
    public int Id { get; set; }

    public string Titulo { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public bool Completada { get; set; }
}
