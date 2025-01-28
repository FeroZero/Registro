using System.ComponentModel.DataAnnotations;

namespace Registro.Models
{
	public class Ciudades
	{
		[Key]
		public int CiudadId { get; set; }

		[Required(ErrorMessage = "Campo Obligatorio")]
		[RegularExpression(@"^[a-zA-Z\s]+$",ErrorMessage = "Solo Caracteres alfabeticos.")]
		public string? Nombre { get; set; }
	}
}
