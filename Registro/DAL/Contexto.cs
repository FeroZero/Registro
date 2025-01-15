using Microsoft.EntityFrameworkCore;
using Registro.Models;

namespace Registro.DAL
{
	public class Contexto : DbContext
	{
		public Contexto(DbContextOptions<Contexto> options) : base(options) { }

		public DbSet<Tecnicos> Tecnicos { get; set; }
	}
}
