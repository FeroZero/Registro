using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Registro.Models
{
	public class Tickets
	{
		[Key]
		public int TicketId { get; set; }

		[Required(ErrorMessage = "Campo Obligatorio.")]
		public DateTime Fecha { get; set; } = DateTime.Now;

		[Required(ErrorMessage = "Campo Obligatorio.")]
		public List<string> Prioridad { get; set; } = new() { "Baja", "Media", "Alta" };

		[Required(ErrorMessage = "Campo Obligatorio.")]
		public string Asunto { get; set; }

		[Required(ErrorMessage = "Campo Obligatorio.")]
		public string Descripcion { get; set; }

		[Required(ErrorMessage = "Campo Obligatorio.")]
		public TimeSpan TiempoInvertido { get; set; }

		[Required(ErrorMessage = "Campo Obligatorio.")]
		[ForeignKey("TecnicosId")]
		public int TecnicoId { get; set; }

		public Tecnicos Tecnicos { get; set; }
	}
}
