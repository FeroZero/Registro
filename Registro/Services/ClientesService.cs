﻿using Microsoft.EntityFrameworkCore;
using Registro.DAL;
using Registro.Models;
using System.Linq.Expressions;

namespace Registro.Services;

public class ClientesService(IDbContextFactory<Contexto> DbFactory)
{
	public async Task<bool> Guardar(Clientes cliente)
	{
		if (!await Existe(cliente.ClienteId))
			return await Insertar(cliente);
		else
			return await Modificar(cliente);
	}

	private async Task<bool> Modificar(Clientes cliente)
	{
		await using var contexto = await DbFactory.CreateDbContextAsync();
		contexto.Update(cliente);
		return await contexto.SaveChangesAsync() > 0;
	}

	private async Task<bool> Insertar(Clientes cliente)
	{
		await using var contexto = await DbFactory.CreateDbContextAsync();
		contexto.Clientes.Add(cliente);
		return await contexto.SaveChangesAsync() > 0;
	}

	private async Task<bool> Existe(int id)
	{
		await using var contexto = await DbFactory.CreateDbContextAsync();
		return await contexto.Clientes
			.AnyAsync(p => p.ClienteId == id);
	}

	public async Task<bool> Eliminar(int id)
	{
		await using var contexto = await DbFactory.CreateDbContextAsync();
		return await contexto.Clientes
			.Where(p => p.ClienteId == id)
			.ExecuteDeleteAsync() > 0;
	}

	public async Task<Clientes?> Buscar(int id)
	{
		await using var contexo = await DbFactory.CreateDbContextAsync();
		return await contexo.Clientes
			.FirstOrDefaultAsync(p => p.ClienteId == id);
	}

	public async Task<List<Clientes>> Listar(Expression<Func<Clientes, bool>> criterio)
	{
		await using var contexto = await DbFactory.CreateDbContextAsync();
		return await contexto.Clientes
			.Include(t => t.Tecnicos)
			.Include(c => c.Ciudades)
			.Where(criterio)
			.ToListAsync();
	}

	public async Task<bool> ExisteCliente(string nombre, int id, string rnc)
	{
		await using var contexto = await DbFactory.CreateDbContextAsync();
		return await contexto.Clientes
			.AnyAsync(t => t.Nombres.ToLower().Equals(nombre.ToLower()) && t.ClienteId != id || t.Rnc.Equals(rnc) && t.ClienteId != id);
	}
}
