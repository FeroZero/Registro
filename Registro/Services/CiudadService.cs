using Microsoft.EntityFrameworkCore;
using Registro.DAL;
using Registro.Models;
using System.Linq.Expressions;

namespace Registro.Services
{
	public class CiudadService(IDbContextFactory<Contexto> DbFactory)
	{
		public async Task<bool> Guardar(Ciudades cliente)
		{
			if (!await Existe(cliente.CiudadId))
				return await Insertar(cliente);
			else
				return await Modificar(cliente);
		}

		private async Task<bool> Modificar(Ciudades cliente)
		{
			await using var contexto = await DbFactory.CreateDbContextAsync();
			contexto.Update(cliente);
			return await contexto.SaveChangesAsync() > 0;
		}

		private async Task<bool> Insertar(Ciudades cliente)
		{
			await using var contexto = await DbFactory.CreateDbContextAsync();
			contexto.Ciudades.Add(cliente);
			return await contexto.SaveChangesAsync() > 0;
		}

		private async Task<bool> Existe(int id)
		{
			await using var contexto = await DbFactory.CreateDbContextAsync();
			return await contexto.Ciudades
				.AnyAsync(p => p.CiudadId == id);
		}

		public async Task<bool> Eliminar(int id)
		{
			await using var contexto = await DbFactory.CreateDbContextAsync();
			return await contexto.Ciudades
				.Where(p => p.CiudadId == id)
				.ExecuteDeleteAsync() > 0;
		}

		public async Task<Ciudades?> Buscar(int id)
		{
			await using var contexo = await DbFactory.CreateDbContextAsync();
			return await contexo.Ciudades
				.FirstOrDefaultAsync(p => p.CiudadId == id);
		}

		public async Task<List<Ciudades>> Listar(Expression<Func<Ciudades, bool>> criterio)
		{
			await using var contexto = await DbFactory.CreateDbContextAsync();
			return await contexto.Ciudades
				.Where(criterio)
				.ToListAsync();
		}

		public async Task<bool> ExisteCiudad(string nombre, int id)
		{
			await using var contexto = await DbFactory.CreateDbContextAsync();
			return await contexto.Ciudades
				.AnyAsync(t => t.Nombre.ToLower().Equals(nombre.ToLower()) && t.CiudadId != id);
		}
	}
}
