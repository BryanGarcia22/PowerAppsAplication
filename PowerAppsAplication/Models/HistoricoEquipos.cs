using System.ComponentModel.DataAnnotations;

namespace PowerAppsAplication.Models
{
    public class HistoricoEquipos
    {
        [Key]
        public int  PKHistoricoEquipos{ get; set; }
        public int FkEquipo{ get; set; }
        public DateTime Fecha { get; set; }
        public string Motivo { get; set; }
        public string Descripcion { get; set; }
        public string Comentarios { get; set; }
        public string FotoEquipo { get; set; }
        public string CertificadoCalibracion { get; set; }
        public int MontoGastado { get; set; }
        public Equipos Equipos { get; set; }
    }
}
