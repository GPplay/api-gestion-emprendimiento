using System;
using System.Collections.Generic;

namespace Emprendimientos2.Models;

public partial class Producto
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public int CantidadInventario { get; set; }

    public decimal PrecioUnitario { get; set; }

    public int EmprendimientoId { get; set; }

    public decimal? CostoFabricacion { get; set; }

    public virtual Emprendimiento Emprendimiento { get; set; } = null!;
}
