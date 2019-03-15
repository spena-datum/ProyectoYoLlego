using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AsistenciaAdmin.Models
{
    public class Clases
    {
        [Key]
        public int ClaseId { get; set; }
        public int EstadoClaseId { get; set; }
        public virtual EstadosClase EstadosClase { get; set; }
        public int AulaId { get; set; }
        public virtual Aulas Aulas { get; set; }
        public string UsuarioId { get; set; }
        public virtual Usuarios Usuarios { get; set; }
        public int CargaId { get; set; }
        public virtual Cargas Cargas  { get; set; }
        public DateTime? FechaHoraAsistencia { get; set; }
        public string IMEI { get; set; }
        public double? Latitud { get; set; }
        public double? Longitud { get; set; }
        public DateTime? FechaHoraInicio { get; set; }
        public int MateriaId { get; set; }
        public virtual Materias Materias { get; set; }
    }
}