using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace PatientPortal.Models
{
    [Table("Patient")]
    public class Patientvm
    {
        [Key]
        public int PID { get; set; }

        [Required]
        public string PName { get; set; }
        
        
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BirthDate { get; set; }
        [NotMapped]
        public string BirthDateString
        { get 
            { return BirthDate.ToShortDateString(); } 
        }

        [Required]
        public string Gender { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public string Addres { get; set; }
        public int? CID { get; set; }

        [NotMapped]
        public string CountryName { get; set; }
        [ForeignKey("CID")]
        public virtual Country Country { get; set; }
    }


    public class PatientVM
    {
        [Key]
        public int PID { get; set; }

        [Required]
        public string PName { get; set; }
        
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BirthDate { get; set; }
        
        [Required]
        public string BirthDateString
        {
            get
            { return BirthDate.ToShortDateString(); }
        }

        [Required]
        public string Gender { get; set; }
        
        [Required]
        public string Phone { get; set; }

        [Required]
        public string Addres { get; set; }
        //[ForeignKey("CID")]

        [Required]
        public int? CID { get; set; }

        public string CountryName { get; set; }
    }

}