using System.ComponentModel.DataAnnotations;


namespace TestCore
{
    public class Produit:BaseClass
    {
        [Required]
        [DataType(DataType.Text)]
        [MaxLength(100)]
        public string r_Nom { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [MaxLength(500)]
        public string r_description { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        [MaxLength(255)]
        public string r_prix { get; set; }
    }
}
