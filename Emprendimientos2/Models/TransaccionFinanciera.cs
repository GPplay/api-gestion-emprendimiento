using System;
using System.Collections.Generic;

namespace Emprendimientos2.Models;

public partial class TransaccionFinanciera
{
    public int Id { get; set; }

    public DateOnly Fecha { get; set; }

    public string Tipo { get; set; } = null!;

    public decimal Monto { get; set; }

    public string? Descripcion { get; set; }

    public int EmprendimientoId { get; set; }

    public virtual Emprendimiento Emprendimiento { get; set; } = null!;
}
