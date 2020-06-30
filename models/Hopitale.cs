using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace trackingCoronaVirusBackEnd2.models
{
    public class Hopitale
    {
        [Key]
         [Column(TypeName = "varchar(150)")]

        public string codeHopitale{get;set;}

        [Column(TypeName = "varchar(150)")]
        public string loginHopitale {get;set;}
        [Required]
        [Column(TypeName = "varchar(150)")]
        public string nomHopitale{get;set;}
        [Required]
        [Column(TypeName = "varchar(150)")]
        public string phoneHopitale {get;set;}
       
        [Column(TypeName = "varchar(150)")]
        public string photoHopitale {get;set;}
        
        [Required]
        [Column(TypeName = "varchar(150)")]
        public string pwdHopitale {get ;set;}
       
         public string codeQuartier {get;set;}

        [ForeignKey("codeQuartier")]
          public Quartier Quartier {get;set;}
    }
}