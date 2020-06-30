using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace trackingCoronaVirusBackEnd2.models
{
    public class Niveau
    {
        [Key]
        [Column(TypeName = "varchar(150)")]

        public string codeNiveau {get;set;}
        [Required]
        public string typeNiveau{get;set;}
    }
}