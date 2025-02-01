using Microsoft.EntityFrameworkCore;
using Registro.DAL;
using Registro.Models;
using System.Linq.Expressions;

namespace Registro.Services
{
	public class TicketsService(IDbContextFactory<Contexto> DbFactory)
	{
		public async Task<bool> Guardar(Tickets ticket)
		{
			if (!await Existe(ticket.TicketId))
				return await Insertar(ticket);
			else
				return await Modificar(ticket);
		}

		private async Task<bool> Modificar(Tickets ticket)
		{
			await using var contexto = await DbFactory.CreateDbContextAsync();
			contexto.Update(ticket);
			return await contexto.SaveChangesAsync() > 0;
		}

		private async Task<bool> Insertar(Tickets ticket)
		{
			await using var contexto = await DbFactory.CreateDbContextAsync();
			contexto.Tickets.Add(ticket);
			return await contexto.SaveChangesAsync() > 0;
		}

		private async Task<bool> Existe(int ticketId)
		{
			await using var contexto = await DbFactory.CreateDbContextAsync();
			return await contexto.Tickets
				.AnyAsync(t => t.TicketId == ticketId);
		}

		public async Task<bool> Eliminar(int ticketId)
		{
			await using var contexto = await DbFactory.CreateDbContextAsync();
			return await contexto.Tickets
				.Where(t => t.TicketId == ticketId)
				.ExecuteDeleteAsync() > 0;
		}

		public async Task<Tickets?> Buscar(int ticketId)
		{
			await using var contexto = await DbFactory.CreateDbContextAsync();
			return await contexto.Tickets
				.FirstOrDefaultAsync(t => t.TicketId == ticketId);
		}
		
		public async Task<List<Tickets>> Listar(Expression<Func<Tickets, bool>> criterio)
		{
			await using var contexto = await DbFactory.CreateDbContextAsync();
			return await contexto.Tickets
				.Include(t => t.Tecnicos)
				.Include(c => c.Clientes)
				.Where(criterio)
				.ToListAsync();
		}
	}
}
