using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportActivityTracking.Domain.Entities
{
    public class ActividadDeportiva
    {
        public int Id { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        public DateTime Fecha { get; set; }
        public int DuracionMinutos { get; set; }
        public string TipoDeporte { get; set; } = string.Empty;  
        public string Usuario { get; set; } = string.Empty;  
    }
}
