using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SportActivityTracking.Domain.Entities;
using SportActivityTracking.Domain.Data;


namespace SportActivityTracking.Infrastructure.Repositories
{
    public class ActividadesDeportivasRepository
    {
        private readonly ActividadDeportivaContext _context;

        public ActividadesDeportivasRepository(ActividadDeportivaContext context)
        {
            _context = context;
        }

        public async Task<List<ActividadDeportiva>> ObtenerTodas()
        {
            return await _context.ActividadesDeportivas.ToListAsync();
        }

        public async Task<ActividadDeportiva> ObtenerPorId(int id)
        {
            return await _context.ActividadesDeportivas.FindAsync(id);
        }

        public async Task Agregar(ActividadDeportiva actividadDeportiva)
        {
            await _context.ActividadesDeportivas.AddAsync(actividadDeportiva);
            await _context.SaveChangesAsync();
        }

        public async Task Actualizar(ActividadDeportiva actividadDeportiva)
        {
            _context.ActividadesDeportivas.Update(actividadDeportiva);
            await _context.SaveChangesAsync();
        }

        public async Task Eliminar(int id)
        {
            var actividadDeportiva = await _context.ActividadesDeportivas.FindAsync(id);
            if (actividadDeportiva != null)
            {
                _context.ActividadesDeportivas.Remove(actividadDeportiva);
                await _context.SaveChangesAsync();
            }
        }
    }
}
