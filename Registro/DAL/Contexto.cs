﻿using Microsoft.EntityFrameworkCore;
using Registro.Models;

namespace Registro.DAL
{
	public class Contexto : DbContext
	{
		public Contexto(DbContextOptions<Contexto> options) : base(options) { }

		public DbSet<Tecnicos> Tecnicos { get; set; }

		public DbSet<Clientes> Clientes { get; set; }

		public DbSet<Ciudades> Ciudades { get; set; }

		public DbSet<Tickets> Tickets { get; set; }
	}
}
