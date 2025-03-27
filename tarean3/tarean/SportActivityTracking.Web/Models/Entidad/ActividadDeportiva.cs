namespace SportActivityTracking.Web.Models.Entidad
{
    public class ActividadDeportiva
    {
        public int Id { get; set; }
        public string Nombre { get; set; } 
        public string Descripcion { get; set; } 
        public DateTime Fecha { get; set; }
        public int DuracionMinutos { get; set; }
    }
}
