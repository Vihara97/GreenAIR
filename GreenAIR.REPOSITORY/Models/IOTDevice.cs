using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GreenAIR.REPOSITORY.Models
{
    [Table("IOTDevice")]
    public class IOTDevice
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DeviceID { get; set; }

        [Column(Order = 1)]
        public int Location { get; set; }

        [Column(Order = 2)]
        public int Status { get; set; }
    }
}
