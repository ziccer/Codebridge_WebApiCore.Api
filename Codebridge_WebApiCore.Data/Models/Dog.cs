using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Codebridge_WebApiCore.Data.Models
{
    public class Dog
    {
        [Key]
        [Column("name")]
        [Required]
        public string Name { get; set; }
        [Required]
        [Column("color")]
        public string Color { get; set; }
        [Column("tail_length")]
        [Required]
        public int Tail_Length { get; set; }
        [Column("weight")]
        [Required]
        public int Weight { get; set; }

    }
}
