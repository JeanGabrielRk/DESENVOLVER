using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Tipo 
    {
        [Key]
        public int TipoId { get; set; }
        public string? Nome { get; set; } 
        public DateTime CriadoEm { get; set; } = DateTime.Now;
        public ICollection<Planta> Plantas { get; set; } = new List<Planta>();
    }
}

