using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Registro.Models
{
	public class Clientes
	{
		[Key]
		public int ClienteId { get; set; }

		[Required(ErrorMessage = "Este Campo es Requerido.")]
		public DateTime FechaIngreso { get; set; } = DateTime.Now;

		[Required(ErrorMessage = "Este Campo es Requerido.")]
		[RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Solo Caracteres Alfabeticos.")]
		public string Nombres { get; set; }

		[Required(ErrorMessage = "Este Campo es Requerido.")]
		[RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Solo Caracteres Alfabeticos.")]
		public string Direccion { get; set; }

		[Required(ErrorMessage = "Este Campo es Requerido.")]
		[StringLength(11,ErrorMessage = "Limite excedido.")]
		[RegularExpression(@"^[0-9]+$", ErrorMessage = "Solo Caracteres Alfabeticos.")]
		public string Rnc { get; set; }

		[Required(ErrorMessage = "Este Campo es Requerido.")]
		[Range(1, double.MaxValue, ErrorMessage = "Solo Caracteres Numericos.")]
		public double LimiteCredito { get; set; }

		[ForeignKey("Tecnicos")]
		public int TecnicoId { get; set; }
		public Tecnicos? Tecnicos { get; set; }

		[ForeignKey("Ciudades")]
		public int CiudadId { get; set; }
		public Ciudades? Ciudades { get; set; }
	}
}
