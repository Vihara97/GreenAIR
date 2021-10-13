using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GreenAIR.REPOSITORY.Models
{
    [Table("Vegitation")]
    public class Vegitation
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Column(Order = 1)]
        [StringLength(50)]
        public string Name { get; set; }

        [Column(Order = 2)]
        [StringLength(50)]
        public string Species { get; set; }

        [Column(Order = 3)]
        public int HowManyPerUnit { get; set; }
    }
}
