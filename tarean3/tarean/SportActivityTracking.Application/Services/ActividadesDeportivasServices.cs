using SportActivityTracking.Domain.Entities;
using SportActivityTracking.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportActivityTracking.Application.Services
{
    public class ActividadesDeportivasService
    {
        private readonly ActividadesDeportivasRepository _repository;

        public ActividadesDeportivasService(ActividadesDeportivasRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ActividadDeportiva>> ObtenerTodas()
        {
            return await _repository.ObtenerTodas();
        }

        public async Task<ActividadDeportiva> ObtenerPorId(int id)
        {
            return await _repository.ObtenerPorId(id);
        }

        public async Task Agregar(ActividadDeportiva actividad)
        {
            await _repository.Agregar(actividad);
        }

        public async Task Actualizar(ActividadDeportiva actividad)
        {
            await _repository.Actualizar(actividad);
        }

        public async Task Eliminar(int id)
        {
            await _repository.Eliminar(id);
        }
    }
}
