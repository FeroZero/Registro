using Microsoft.EntityFrameworkCore;
using Registro.DAL;
using Registro.Models;
using System.Linq.Expressions;

namespace Registro.Services
{
	public class TecnicoService(IDbContextFactory<Contexto> DbFactory)
	{
		public async Task<bool> Guardar(Tecnicos tecnico)
		{
			if (!await Existe(tecnico.TecnicoId))
				return await Insertar(tecnico);
			else
				return await Modificar(tecnico);
		}

		private async Task<bool> Modificar(Tecnicos tecnico)
		{
			await using var contexto = await DbFactory.CreateDbContextAsync();
			contexto.Update(tecnico);
			return await contexto.SaveChangesAsync() > 0;
		}

		private async Task<bool> Insertar(Tecnicos tecnico)
		{
			await using var contexto = await DbFactory.CreateDbContextAsync();
			contexto.Tecnicos.Add(tecnico);
			return await contexto.SaveChangesAsync() > 0;
		}

		private async Task<bool> Existe(int id)
		{
			await using var contexto = await DbFactory.CreateDbContextAsync();
			return await contexto.Tecnicos
				.AnyAsync(p => p.TecnicoId == id);
		}

		public async Task<bool> Eliminar(int id)
		{
			await using var contexto = await DbFactory.CreateDbContextAsync();
			return await contexto.Tecnicos
				.Where(p => p.TecnicoId == id)
				.ExecuteDeleteAsync() > 0;
		}

		public async Task<Tecnicos?> Buscar(int id)
		{
			await using var contexo = await DbFactory.CreateDbContextAsync();
			return await contexo.Tecnicos
				.FirstOrDefaultAsync(p => p.TecnicoId == id);
		}

		public async Task<List<Tecnicos>> Listar(Expression<Func<Tecnicos, bool>> criterio)
		{
			await using var contexto = await DbFactory.CreateDbContextAsync();
			return await contexto.Tecnicos
				.Where(criterio)
				.ToListAsync();
		}

		public async Task<bool> ExisteTecnico(string nombre, int id)
		{
			await using var contexto = await DbFactory.CreateDbContextAsync();
			return await contexto.Tecnicos
				.AnyAsync(t => t.Nombres.ToLower().Equals(nombre.ToLower()) && t.TecnicoId != id);
		}

	}
}
