using System.ComponentModel.DataAnnotations;

namespace Registro.Models
{
	public class Sistemas
	{
		[Key]
		public int SistemaId { get; set; }

		[Required(ErrorMessage = "Este Campo es Requerido.")]
		public string Descripcion { get; set; }

		[Required(ErrorMessage = "Este Campo es Requerido.")]
		[Range(1, 100, ErrorMessage = "Solo Caracteres Numericos del 1 al 100.")]
		public decimal Complejidad { get; set; }
	}
}
