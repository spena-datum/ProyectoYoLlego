namespace AsistenciaAdmin.Models
{
    using System.ComponentModel.DataAnnotations;
    public class Aulas
    {
        [Key]
        public int AulaId { get; set; }

        [Display(Name ="Codigo")]
        public string NombreAula { get; set; }
    }
}