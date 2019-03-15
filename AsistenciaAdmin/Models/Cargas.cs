using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AsistenciaAdmin.Models
{
    public class Cargas
    {
        [Key]
        public int CargaId { get; set; }
        public virtual ICollection<Clases> Clases { get; set; }
        public string UsuarioId { get; set; }
        public DateTime? FechaHoraCarga { get; set; }
        public string CodigoMateria { get; set; }
        public string CarnetAlumno { get; set; }
        public string CorreoDocente { get; set; }
        public string CodigoAula { get; set; }
        public string HorarioClase { get; set; }
        public string Dias { get; set; }
        public string Ciclo { get; set; }
    }
}