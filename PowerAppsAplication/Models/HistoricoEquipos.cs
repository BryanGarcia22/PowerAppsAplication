using System.ComponentModel.DataAnnotations;

namespace PowerAppsAplication.Models
{
    public class HistoricoEquipos
    {
        [Key]
        public int  PKHistoricoEquipos{ get; set; }
        public int FkEquipo{ get; set; }
        public DateTime FechaMantenimiento { get; set; }
        public string Motivo { get; set; }
        public string Calibracion { get; set; }
        public string Reparacion { get; set; }
        public DateTime FechaReparacion { get; set; }
        public int MontoGastado { get; set; }
        public Equipos Equipos { get; set; }
    }
}
