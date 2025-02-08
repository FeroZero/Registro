using Microsoft.EntityFrameworkCore;
using Registro.DAL;
using Registro.Models;
using System.Linq.Expressions;

namespace Registro.Services
{
	public class SistemasService(IDbContextFactory<Contexto> DbFactory)
	{
		public async Task<bool> Guardar(Sistemas sistema)
		{
			if (!await Existe(sistema.SistemaId))
				return await Insertar(sistema);
			else
				return await Modificar(sistema);
		}

		private async Task<bool> Modificar(Sistemas sistema)
		{
			await using var contexto = await DbFactory.CreateDbContextAsync();
			contexto.Update(sistema);
			return await contexto.SaveChangesAsync() > 0;
		}

		private async Task<bool> Insertar(Sistemas sistema)
		{
			await using var contexto = await DbFactory.CreateDbContextAsync();
			contexto.Sistemas.Add(sistema);
			return await contexto.SaveChangesAsync() > 0;
		}

		private async Task<bool> Existe(int sistema)
		{
			await using var contexto = await DbFactory.CreateDbContextAsync();
			return await contexto.Sistemas
				.AnyAsync(t => t.SistemaId == sistema);
		}

		public async Task<bool> Eliminar(int sistemaId)
		{
			await using var contexto = await DbFactory.CreateDbContextAsync();
			return await contexto.Sistemas
				.Where(t => t.SistemaId == sistemaId)
				.ExecuteDeleteAsync() > 0;
		}

		public async Task<Sistemas?> Buscar(int sistemaId)
		{
			await using var contexto = await DbFactory.CreateDbContextAsync();
			return await contexto.Sistemas
				.FirstOrDefaultAsync(t => t.SistemaId == sistemaId);
		}

		public async Task<List<Sistemas>> Listar(Expression<Func<Sistemas, bool>> criterio)
		{
			await using var contexto = await DbFactory.CreateDbContextAsync();
			return await contexto.Sistemas
				.Where(criterio)
				.ToListAsync();
		}
	}
}
