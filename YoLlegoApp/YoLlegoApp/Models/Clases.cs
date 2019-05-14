using System;
using System.Collections.Generic;
using System.Text;

namespace YoLlegoApp.Models
{
    class Clases
    {
        public int ClaseId { get; set; }
        public int EstadoClaseId { get; set; }
        public int AulaId { get; set; }
        public int UsuarioId { get; set; }
        public int CargaId { get; set; }
        public DateTime FechaHoraAsistencia { get; set; }
        public string IMEI { get; set; }
        public string Latitud { get; set; }
        public string Longitud { get; set; }
        public DateTime FechaHoraInicio { get; set; }
        public int MateriaId { get; set; }
    }
}
