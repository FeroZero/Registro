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

		public DbSet<Sistemas> Sistemas { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Tickets>()
				.HasOne(t => t.Tecnicos)
				.WithMany()
				.HasForeignKey(t => t.TecnicoId)
				.OnDelete(DeleteBehavior.NoAction);
		}
	}
}
