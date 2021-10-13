using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GreenAIR.REPOSITORY.Models
{
    [Table("MonitoringCenter")]
    public class MonitoringCenter
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CenterID { get; set; }

        [Column(Order = 1)]
        [StringLength(50)]
        public string Name { get; set; }

        [Column(Order = 2)]
        [StringLength(100)]
        public string Location { get; set; }
    }
}
