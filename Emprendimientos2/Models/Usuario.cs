using System;
using System.Collections.Generic;

namespace Emprendimientos2.Models;

public partial class Usuario
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Contrasena { get; set; } = null!;

    public string CodigoAcceso { get; set; } = null!;

    public virtual Emprendimiento CodigoAccesoNavigation { get; set; } = null!;
}
