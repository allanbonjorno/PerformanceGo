
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FarmaciaPerformanceGo.Model
{
    public class Categoria
    {
        [Key] // PRIMARY kEY (Id)
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // IDENTITY(1,1)
        public long Id { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(255)]
        public string Tipo { get; set; } = string.Empty;

        [Column(TypeName = "BIT")]
        public Boolean IsValid { get; set; }


    }
}