namespace AsistenciaAdmin.Models    
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Usuarios
    {
        [Key]
        public string UsuarioId { get; set; }
        public virtual ICollection<Clases> Clases { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Foto { get; set; }
        public string Direccion { get; set; }
        public string Contraseña { get; set; }
    }
}