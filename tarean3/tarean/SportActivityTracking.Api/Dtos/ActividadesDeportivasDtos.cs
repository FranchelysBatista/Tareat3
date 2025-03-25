namespace SportActivityTracking.Api.Dtos

{
    public class ActividadesDeportivasDtos
    {
        public int Id { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        public DateTime Fecha { get; set; }
        public int DuracionMinutos { get; set; }
        public string TipoDeporte { get; set; } = string.Empty;
        public string Usuario { get; set; } = string.Empty;
    }
}
