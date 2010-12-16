using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ZergScheduler.Models
{
    [MetadataType(typeof(ClassMetaData))]
    public partial class Class
    {
        [Bind(Exclude = "class_id")]
        public class ClassMetaData
        {
            [ScaffoldColumn(false)]
            public object class_id { get; set; }

            [DisplayName("Semester ID")]
            [Required(ErrorMessage = "The semester ID is required")]
            public object semster_id { get; set; }

            [DisplayName("Course ID")]
            [Required(ErrorMessage = "The course ID is required")]
            public object course_id { get; set; }

            [DisplayName("Section ID")]
            [Range(1,100,ErrorMessage ="Section ID must be between 1 and 100.")]
            [Required(ErrorMessage = "The section ID is required")]
            public object sect_id { get; set; }

            [DisplayName("Room ID")]
            public object room_id { get; set; }

            [DisplayName("Instructor ID")]
            [Required(ErrorMessage = "An instructor is required.")]
            public object inst_id { get; set; }

            [DisplayName("Capacity")]
            [Range(1,200,ErrorMessage = "Class capacity should be between 1 and 200.")]
            public object capacity { get; set; }

            [DisplayName("Waitlist Capacity")]
            [Range(0, 40, ErrorMessage = "Waitlist capacity should be between 0 and 40.")]
            public object waitlist_capacity { get; set; }

            [DisplayName("Scheduled Days")]
            public object days { get; set; }

            [DisplayName("Time Slot")]
            public object timeslot_id { get; set; }
        }
    }
}