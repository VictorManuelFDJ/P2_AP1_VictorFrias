using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using P2_AP1_VictorFrias.DAL;
using P2_AP1_VictorFrias.Models;

namespace P2_AP1_VictorFrias.Services;

public class ModeloService(IDbContextFactory<Contexto> DbFactory)
{











































     public async Task<List<Registro>> Listar(Expression<Func<Registro, bool>> criterio)
    {
        await using var context = await DbFactory.CreateDbContextAsync();
        return await context.Registros
            .Include(e => e.Detalle)
            .ThenInclude(d => d.TipoHuacal)
            .Where(criterio)
            .AsNoTracking()
            .ToListAsync();
    }
}
