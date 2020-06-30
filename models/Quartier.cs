using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace trackingCoronaVirusBackEnd2.models
{
    public class Quartier
    {
         [Key]
         [Column(TypeName = "varchar(150)")]

        public string codeQuartier {get;set;}
        [Required]
        public string nomQuartier {get;set;}
        [Required]
        public double lng {get;set;}
        [Required]
        public double lat {get;set;}
    }
}