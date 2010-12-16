using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ZergScheduler.Models
{
    [MetadataType(typeof(SemesterMetadata))]
    public partial class Semester
    {
        class SemesterMetadata
        {
            
            //[StringLength(4, MinimumLength = 4, ErrorMessage = "Semester ID must be 4 characters.")]
            //[Required(ErrorMessage = "Semester ID is required.")]
            //[Unique(ErrorMessage = "Semester ID must be unique.")]
            [DisplayName("Semester ID")]
            public string semester_id { get; set; }

            [DisplayName("Start Date")]
            [Required(ErrorMessage = "Start date is required.")]
            public DateTime start_date { get; set; }

            [DisplayName("Drop Date")]
            [Required(ErrorMessage = "Add/drop date is required.")]
            public DateTime drop_date { get; set; }

            [DisplayName("Withdraw Date")]
            [Required(ErrorMessage = "Withdraw date is required.")]
            public DateTime withdraw_date { get; set; }

            [DisplayName("Registration Start Date")]
            [Required(ErrorMessage = "Registration start date is required.")]
            public DateTime reg_start_date { get; set; }

            [DisplayName("Rolling Registration Credit Step")]
            [Required(ErrorMessage = "Registration credit step is required.")]
            [Range(1, 120, ErrorMessage = "Credit step must be between 1 and 120 credits.")]
            public int credit_step { get; set; }

            [DisplayName("Rolling Registration Day Step")]
            [Required(ErrorMessage = "Registration day step is required.")]
            [Range(1,5, ErrorMessage = "Day step must be between 1 and 5 days.")]
            public int day_step { get; set; }
        }
    }
}