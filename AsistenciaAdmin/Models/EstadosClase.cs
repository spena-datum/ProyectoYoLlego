namespace AsistenciaAdmin.Models
{
    using System.ComponentModel.DataAnnotations;
    public class EstadosClase
    {
        [Key]
        public int EstadoClaseId { get; set; }
        public string Estado { get; set; }
    }
}