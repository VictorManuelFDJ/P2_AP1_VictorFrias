using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using P2_AP1_VictorFrias.DAL;
using P2_AP1_VictorFrias.Models;

namespace P2_AP1_VictorFrias.Services;

public class PedidosServices(IDbContextFactory<Contexto> DbFactory)
{
    private async Task<bool> Existe(int id)
    {
        await using var context = await DbFactory.CreateDbContextAsync();
        return await context.Pedidos.AnyAsync(e => e.PedidosId == id);
    }

    private async Task<bool> Insertar(Pedidos pedidos)
    {
        await using var context = await DbFactory.CreateDbContextAsync();

        foreach (var detalle in pedidos.PedidosDetalles)
        {
            var componente = await context.Componentes.FindAsync(detalle.ComponenteId);
            if (componente != null)
            {
                componente.Existencia = Math.Max(0, componente.Existencia - detalle.Cantidad);
            }
            detalle.Componente = null;
        }

        context.Pedidos.Add(pedidos);
        return await context.SaveChangesAsync() > 0;
    }

    private async Task<bool> Modificar(Pedidos pedido)
    {
        await using var context = await DbFactory.CreateDbContextAsync();

        var pedidoExistente = await context.Pedidos
            .Include(p => p.PedidosDetalles)
            .FirstOrDefaultAsync(p => p.PedidosId == pedido.PedidosId);

        if (pedidoExistente == null) return false;

        foreach (var detalleExistente in pedidoExistente.PedidosDetalles)
        {
            var componente = await context.Componentes.FindAsync(detalleExistente.ComponenteId);
            if (componente != null)
            {
                componente.Existencia += detalleExistente.Cantidad;
            }
        }

        context.Entry(pedidoExistente).CurrentValues.SetValues(pedido);
        context.PedidosDetalles.RemoveRange(pedidoExistente.PedidosDetalles);

        foreach (var detalleNuevo in pedido.PedidosDetalles)
        {
            var componente = await context.Componentes.FindAsync(detalleNuevo.ComponenteId);
            if (componente != null)
            {
                componente.Existencia = Math.Max(0, componente.Existencia - detalleNuevo.Cantidad);
            }

            pedidoExistente.PedidosDetalles.Add(new PedidosDetalle
            {
                ComponenteId = detalleNuevo.ComponenteId,
                Cantidad = detalleNuevo.Cantidad,
                Precio = detalleNuevo.Precio
            });
        }

        return await context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Guardar(Pedidos pedidos)
    {
        if (!await Existe(pedidos.PedidosId))
            return await Insertar(pedidos);
        else
            return await Modificar(pedidos);
    }

    public async Task<Pedidos?> Buscar(int id)
    {
        await using var context = await DbFactory.CreateDbContextAsync();
        return await context.Pedidos
            .Include(p => p.PedidosDetalles)
            .ThenInclude(d => d.Componente)
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.PedidosId == id);
    }

    public async Task<bool> Eliminar(int id)
    {
        await using var context = await DbFactory.CreateDbContextAsync();
        var pedido = await context.Pedidos
            .Include(p => p.PedidosDetalles)
            .FirstOrDefaultAsync(p => p.PedidosId == id);

        if (pedido == null) return false;

        foreach (var detalle in pedido.PedidosDetalles)
        {
            var componente = await context.Componentes.FindAsync(detalle.ComponenteId);
            if (componente != null)
            {
                componente.Existencia += detalle.Cantidad;
            }
        }

        context.Pedidos.Remove(pedido);
        return await context.SaveChangesAsync() > 0;
    }

    public async Task<List<Pedidos>> Listar(Expression<Func<Pedidos, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Pedidos
            .Include(p => p.PedidosDetalles)
            .ThenInclude(d => d.Componente)
            .Where(criterio)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<List<Componente>> ListarTodos()
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Componentes
            .AsNoTracking()
            .ToListAsync();
    }
}