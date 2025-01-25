using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Registro.Models
{
	public class Clientes
	{
		[Key]
		public int ClienteId { get; set; }

		public DateTime FechaIngreso { get; set; } = DateTime.Now;

		public string Nombres { get; set; }

		public string Direccion { get; set; }

		public string Rnc { get; set; }

		public double LimiteCredito { get; set; }

		[ForeignKey("TecnicoId")]
		public int TecnicoId { get; set; }
		public Tecnicos? Tecnicos { get; set; }
	}
}
