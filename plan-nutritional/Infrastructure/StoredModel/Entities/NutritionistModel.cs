using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.StoredModel.Entities
{
    [Table("Nutritionist")]
    internal class NutritionistModel
    {
        [Key]
        [Column("NutritionistId")]
        public Guid Id { get; set; }

        [Column("FullName")]
        [StringLength(100)]
        public string FullName { get; set; }

        [Column("Specialization")]
        public string Specialization { get; set; }

        [Column("Status")]
        public string Status { get; set; } 
    }
}
