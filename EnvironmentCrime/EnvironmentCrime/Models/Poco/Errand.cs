using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EnvironmentCrime.Models
{
    public class Errand
    {
        [Key]
       public int ErrandId { get; set; }

        public string RefNumber { get; set; }

        [Required(ErrorMessage = "Fyll i var brottet skedde"), Display(Name = "Var har brottet skett någonstans ?")]
        public String Place { get; set;}

        [Required(ErrorMessage = "Fyll i vilken typ av brott"), Display(Name = "Vilken typ av brott?")]
        public String TypeOfCrime { get; set;}


        [Required(ErrorMessage = "Fyll i datum när brotten skedde"), DataType(DataType.Date), Display(Name = "När skedde brottet?")]
        [DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}")]
       public DateTime DateOfObservation { get; set;}

        [Display(Name = "Beskriv din observation (ex. namn på misstänkt person):")]
       public String Observation { get; set;}
       public String InvestigatorInfo { get; set;}
       public String InvestigatorAction { get; set;}
        [Required(ErrorMessage = "Fyll i dit namn"), Display(Name = "Ditt namn (för- och efternamn):")]
        public String InformerName { get; set;}

       [DataType(DataType.PhoneNumber), Required(ErrorMessage = "fyll i din telefon"), Display(Name = "Din telefon:")]
       public String InformerPhone { get; set;}
       public String StatusId { get; set;}
       public String DepartmentId { get; set;}
       public String EmployeeId { get; set; }
    }
}
