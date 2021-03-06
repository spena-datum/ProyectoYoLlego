﻿namespace AsistenciaAdmin.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class Materias
    {
        [Key]
        public int MateriaId { get; set; }
        public virtual ICollection<Clases> Clases { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Facultad { get; set; }
    }
}