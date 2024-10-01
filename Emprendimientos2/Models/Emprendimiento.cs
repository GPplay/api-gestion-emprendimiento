using System;
using System.Collections.Generic;

namespace Emprendimientos2.Models;

public partial class Emprendimiento
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();

    public virtual ICollection<TransaccionFinanciera> TransaccionFinancieras { get; set; } = new List<TransaccionFinanciera>();

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
