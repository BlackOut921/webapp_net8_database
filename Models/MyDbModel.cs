using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapp_net8_database.Models
{
	public class MyDbModel
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		[Required]
		public string Name { get; set; } = string.Empty;

		[Required]
		public DateTime TimeStamp { get; set; } = DateTime.Now;
	}
}
