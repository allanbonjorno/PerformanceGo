using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FarmaciaPerformanceGo.Model
{
    public class Produto
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        // nome
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string Nome { get; set; } = string.Empty;


        [Column(TypeName = "Varchar")]
        [StringLength(500)]
        public string Descricao { get; set; } = string.Empty;


        [Column(TypeName = " Decimal (7,2) ")]
        public decimal Preco { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(255)]
        public string Foto { get; set; } = string.Empty;

        [Column(TypeName = "Varchar")]
        [StringLength(255)]
        public string Quantidade { get; set; } = string.Empty;
       

      



    }
}



