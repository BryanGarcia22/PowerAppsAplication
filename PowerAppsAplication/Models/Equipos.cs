using System.ComponentModel.DataAnnotations;

namespace PowerAppsAplication.Models
{
    public class Equipos
    {
        [Key]
        public int PkEquipo { get; set; }
        public string Region { get; set; }
        public string Ciudad { get; set; }
        public string Departamento { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string NoSerie { get; set; }    
        public string Descripcion { get; set;}
        public string Responsable { get; set; } 
        public string Estado { get; set;}
        public string PeriodoCalibracion { get; set;}
        public DateTime UltimaCalibracion { get; set;}
        public DateTime ProximaCalibracion { get; set;}
        public DateTime UltimoMantenimiento { get; set; }
        public DateTime ProximaMantenimiento { get; set;}
        public ICollection<HistoricoEquipos> HistoricoEquipos { get; set; }


    }
}