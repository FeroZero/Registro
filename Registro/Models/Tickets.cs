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
		public string Prioridad { get; set; }

		[Required(ErrorMessage = "Campo Obligatorio.")]
		public string? Asunto { get; set; }

		[Required(ErrorMessage = "Campo Obligatorio.")]
		public string Descripcion { get; set; }

		[Required(ErrorMessage = "Campo Obligatorio.")]
		[RegularExpression(@"^[0-9]+$",ErrorMessage = "Establezca el tiempo Alfanumericamente.")]
		public string? TiempoInvertido { get; set; }

		[ForeignKey("Tecnicos")]
		public int TecnicoId { get; set; }

		public Tecnicos? Tecnicos { get; set; }

		[ForeignKey("Clientes")]
		public int ClienteId { get; set; }

		public Clientes? Clientes { get; set; }
	}
}
