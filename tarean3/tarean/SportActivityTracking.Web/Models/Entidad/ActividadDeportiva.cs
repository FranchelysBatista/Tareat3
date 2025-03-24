namespace SportActivityTracking.Web.Models.Entidad
{
    public class ActividadDeportiva
    {
        public int Id { get; set; }
        public string NombreActividad { get; set; }
        public DateTime Fecha { get; set; }
        public int DuracionMinutos { get; set; }
    }

}