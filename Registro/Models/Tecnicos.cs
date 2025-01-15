using System.ComponentModel.DataAnnotations;

namespace Registro.Models
{
	public class Tecnicos
	{
		[Key]
		public int TecnicoId { get; set; }

		[Required(ErrorMessage = "Este Campo es Requerido.")]
		[RegularExpression(@"^(a-zA-Z\s)+$",ErrorMessage = "Solo Caracteres Alfabeticos.")]
		public string Nombres { get; set; }

		[Required(ErrorMessage = "Este Campo es Requerido.")]
		[Range(1, double.MaxValue, ErrorMessage = "Solo Caracteres Numericos.")]
		public decimal SueldoHora { get; set; }
	}
}
