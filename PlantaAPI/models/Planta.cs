using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public class Planta
    {
        [Key]
        public int IdPlanta { get; set; }
        public string? Nome { get; set; } 
        public DateTime CriadoEm { get; set; } = DateTime.Now;

        public int OrigemId { get; set; }
        public int TipoId { get; set; }

        [ForeignKey("OrigemId")]
        public Origem? Origem { get; set; } 

        [ForeignKey("TipoId")]
        public Tipo? Tipo { get; set; } 
    }
}
