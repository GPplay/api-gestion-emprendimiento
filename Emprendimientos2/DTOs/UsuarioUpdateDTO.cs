namespace Emprendimientos2.DTOs
{
    public class UsuarioUpdateDTO
    {
        public int Id { get; set; }
        public string Email { get; set; } = null!;

        public string Contrasena { get; set; } = null!;

        public int? EmprendimientoId { get; set; }
    }
}
