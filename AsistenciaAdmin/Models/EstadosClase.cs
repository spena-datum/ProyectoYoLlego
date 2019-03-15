namespace AsistenciaAdmin.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class EstadosClase
    {
        [Key]
        public int EstadoClaseId { get; set; }
        public virtual ICollection<Clases> Clases { get; set; }
        public string Estado { get; set; }
    }
}