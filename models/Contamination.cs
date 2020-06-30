using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace trackingCoronaVirusBackEnd2.models
{
    public class Contamination
    {
        [Key]
         [Column(TypeName = "varchar(150)")]
         

         public string codeContamination{get;set;}
         [Column(TypeName = "varchar(150)")]
        public string dateContamination{get;set;}
            public string codeClient {get;set;}
           [ForeignKey("codeClient")]
           public Client Client {get;set;}
          public string codeHopitale {get;set;}
          [ForeignKey("codeHopitale")]

         public Hopitale Hopitale {get;set;}
           public string codeNiveau {get;set;}

           [ForeignKey("codeNiveau")]
         public Niveau Niveau {get;set;}
    }
}