using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ZergScheduler.Models
{
	[MetadataType(typeof(CourseMetaData))]
	public partial class Course
	{
		[Bind(Exclude = "course_id")]
		public class CourseMetaData
		{
			[ScaffoldColumn(false)]
			public object course_id { get; set; }

			[DisplayName("Department")]
			[Required(ErrorMessage = "The department is required")]
			public object dept_id { get; set; }

			[DisplayName("Course Number")]
			[Required(ErrorMessage = "The course number is required")]
			public object course_no { get; set; }

			[DisplayName("Title")]
			public object title { get; set; }

			[DisplayName("Description")]
			public object description { get; set; }

			[DisplayName("Credits")]
			[Range(1, 4, ErrorMessage = "Credits must be between 1 and 4")]
			[Required(ErrorMessage = "Number of credits are required")]
			public object credits { get; set; }

			[DisplayName("Career")]
			public object career { get; set; }

			[DisplayName("GEP")]
			public object gep { get; set; }

			[DisplayName("GFR")]
			public object gfr { get; set; }
		}
	}
}