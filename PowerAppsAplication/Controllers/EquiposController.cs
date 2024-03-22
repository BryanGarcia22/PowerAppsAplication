using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PowerAppsAplication.Context;
using PowerAppsAplication.Models;
using System.Text.RegularExpressions;
using OfficeOpenXml;  
using OfficeOpenXml.Table;

namespace PowerAppsAplication.Controllers
{
    public class EquiposController : Controller
    {

        private readonly ApplicationDbContext _context;
        public EquiposController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Equipos> listEquipos = _context.Equipos.ToList();

            return View(listEquipos);
        }
        public ActionResult Details(int id)
        {
            return View(id);
        }


        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Crear(Equipos requestEquipos)
        {
            try
            {
                Equipos equipo = new()
                {
                    Region = requestEquipos.Region,
                    Ciudad = requestEquipos.Ciudad,
                    Marca = requestEquipos.Marca,
                    Modelo = requestEquipos.Modelo,
                    NoSerie = requestEquipos.NoSerie,
                    Descripcion = requestEquipos.Descripcion,
                    Responsable = requestEquipos.Responsable,
                    Estado = requestEquipos.Estado,
                    PeriodoCalibracion = requestEquipos.PeriodoCalibracion,
                    UltimaCalibracion = requestEquipos.UltimaCalibracion,
                    ProximaCalibracion = requestEquipos.ProximaCalibracion,
                    UltimoMantenimiento = requestEquipos.UltimoMantenimiento,
                    ProximaMantenimiento = requestEquipos.ProximaMantenimiento,
                    Departamento = requestEquipos.Departamento,
                };
                _context.Equipos.Add(equipo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {

                throw new Exception("Surgio un error " + ex.Message);
            }
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            try
            {
                var equipo = _context.Equipos.Find(id);
                return View(equipo);

            }
            catch (Exception ex)
            {

                throw new Exception("Surgio un error " + ex.Message);
            }

        }
        [HttpPost]
        public async Task<IActionResult> Editar(int id, Equipos requestEquipos)
        {
            try
            {
                Equipos equipo = new();

                equipo = _context.Equipos.Find(id);
                equipo.Region = requestEquipos.Region;
                equipo.Ciudad= requestEquipos.Ciudad;
                equipo.Marca = requestEquipos.Marca;
                equipo.Modelo = requestEquipos.Modelo;
                equipo.NoSerie = requestEquipos.NoSerie;
                equipo.Descripcion = requestEquipos.Descripcion;
                equipo.Responsable = requestEquipos.Responsable;
                equipo.Estado = requestEquipos.Estado;
                equipo.PeriodoCalibracion = requestEquipos.PeriodoCalibracion;
                equipo.UltimaCalibracion = requestEquipos.UltimaCalibracion;
                equipo.ProximaCalibracion = requestEquipos.ProximaCalibracion;
                equipo.UltimoMantenimiento = requestEquipos.UltimoMantenimiento;
                equipo.ProximaMantenimiento = requestEquipos.ProximaMantenimiento;
                equipo.Departamento = requestEquipos.Departamento;

                _context.Equipos.Update(equipo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {

                throw new Exception("Surgio un error " + ex.Message);
            }

        }

        [HttpGet]
        //public IActionResult Eliminar(int id)
        //{
        //    try
        //    {
        //        var equipo = _context.Equipos.Find(id);
        //        return View(equipo);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("Surgio un error " + ex.Message);
        //    }

        //}
        [HttpPost]
        public async Task<IActionResult> Eliminar(int id)
        {
            try
            {
                Equipos equipo = await _context.Equipos.FindAsync(id);
                if (equipo == null)
                {
                    return Json(new { success = false, message = "El equipo no fue encontrado." });
                }

                _context.Equipos.Remove(equipo);
                await _context.SaveChangesAsync();

                return Json(new { success = true, message = "El equipo ha sido eliminado exitosamente." });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Ocurrió un error al intentar eliminar el equipo: " + ex.Message });
            }
        }

    }
}
