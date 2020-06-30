using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace trackingCoronaVirusBackEnd2.models
{
    public class Client
    {
       
        [Key]
         [Column(TypeName = "varchar(150)")]

        public string  codeClient {get;set;}
        [Required]
        public string nomClient{get;set;}
        [Required]
        public string prenomClient{get;set;}
        [Required]
        public string age {get;set;}
        [Required]
        public string sexeClient {get;set;}
        [Required]
        public string phoneClient{get;set;}
         public string codeQuartier {get;set;}

          [ForeignKey("codeQuartier")]
          public Quartier Quartier {get;set;}
        
    }
}