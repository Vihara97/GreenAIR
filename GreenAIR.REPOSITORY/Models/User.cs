using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GreenAIR.REPOSITORY.Models
{
    [Table("User")]
    public class User
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UserID { get; set; }

        [Column(Order = 1)]
        [StringLength(50)]
        public string Name { get; set; }

        [Column(Order = 2)]
        public int LocationAddress { get; set; }

        [Column(Order = 3)]
        [StringLength(50)]
        public string MobileNoOrEmail { get; set; }

        [Column(Order = 4)]
        [StringLength(50)]
        public string Password { get; set; }

        [Column(Order = 5)]
        public int Status { get; set; }
    }
}
