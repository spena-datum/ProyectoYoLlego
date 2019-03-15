namespace AsistenciaAdmin.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class Aulas
    {
        [Key]
        public int AulaId { get; set; }
        public virtual ICollection<Clases> Clases { get; set; }

        [Display(Name ="Codigo")]
        public string NombreAula { get; set; }
    }
}