using System.ComponentModel.DataAnnotations;

namespace PowerAppsAplication.Models
{
    public class EPPTorres
    {
        [Key]
        public int PkEPPTorres { get; set; }
        public string NombreUsuario { get; set; }
        public string JefeDirecto { get; set; }
        public string Gerencia { get; set; }
        public string Ciudad { get; set; }
        public bool Arnes5Posiciones { get; set; }
        public string MarcaArnes { get; set; }
        public DateTime FechaFabricacionArnes { get; set; }
        public string ComentariosStatusArnes { get; set; }
        public string BotasSeguridad { get; set; }
        public string CuerdaPosicionamiento { get; set; }
        public DateTime FechaFabricacionCuerda { get; set; }
        public string Guantes { get; set; }
        public string LentesSeguridad { get; set; }
        public string Mosqueton { get; set; }
        public string ShockAbsorbente { get; set; }
        public DateTime FechaFabricacionShock { get; set; }
        public string SujetadorLineaVida { get; set; }
        public string CascoSeguridadBarbiquejo { get; set; }
        public string Comentario { get; set; }
        public string Imagen1 { get;set; }
        public string Imagen2 { get;set; }
        public string ImagenFirma { get; set; }   

    }
}

