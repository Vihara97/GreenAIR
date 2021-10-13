using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GreenAIR.REPOSITORY.Models
{
    [Table("AirContentRecord")]
    public class AirContentRecord
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RecordID { get; set; }

        [Column(Order = 1)]
        [StringLength(14)]
        public DateTime Date { get; set; }

        [Column(Order = 2)]
        [StringLength(14)]
        public DateTime Time { get; set; }

        [Column(Order = 3)]
        [StringLength(100)]
        public string RecognizedGases { get; set; }

        [Column(Order = 4)]
        public decimal PollutionLevel { get; set; }
    }
}
