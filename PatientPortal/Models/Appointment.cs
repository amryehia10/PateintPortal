using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PatientPortal.Models
{
    [Table("Appointment")]
    public class Appointment
    {
        public Appointment()
        {
        }
        [Key]
        public int AppID { get; set; }

        public string Notes { get; set; }

        [Required]
        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime AppFrom { get; set; }
        
        [Required]
        public DateTime AppTo { get; set; }

        [Required]
        public bool Check_in { get; set; }

        [Required]
        public string Status { get; set; }

        public int? PID { get; set; }
        [ForeignKey("PID")]
        public virtual Patientvm patient { get; set; }

        public int? SID { get; set; }
        [ForeignKey("SID")] 
        public virtual Service service { get; set; }


    }

    public class AppointmentVM
    {
        [Key]
        public int AppID { get; set; }

        public string Notes { get; set; }

        [Required]
        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime AppFrom { get; set; }

        [Required]
        public DateTime AppTo { get; set; }

        [Required]
        public bool Check_in { get; set; }

        [Required]
        public string Status { get; set; }

        public string ServiceName { get; set; }
        public string PatientName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BirthDate { get; set; }
        public string Address { get; set; }
        public string CountryName { get; set; }
        public string Gender { get; set; }
        public string Phone { get; set; }


        public int? PID { get; set; }


        public int? SID { get; set; }

        public Patientvm patient { get; set; }
        public Service service { get; set; }


    }
}