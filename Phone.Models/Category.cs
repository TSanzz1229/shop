using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phone.Models
{
	public class Category
	{
		[Key]
		public int ID { get; set; }

		[Required]
		public string Name { get; set; }
		[DisplayName("Display order")]
		public int DisplayOrder { get; set; }
		public DateTime Creadatetime { get; set; } = DateTime.Now;
	}
}
