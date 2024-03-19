using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PowerAppsAplication.Context;
using PowerAppsAplication.Models;

namespace PowerAppsAplication.Controllers
{
    public class HistoricoController : Controller
    {
        private readonly ApplicationDbContext _context;
        public HistoricoController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(int id)
        {
            List<HistoricoEquipos> listH = _context.HistoricoEquipos.Where(x=> x.FkEquipo == id).ToList();
            ViewBag.Id = id;
            return View(listH);
        }
        public ActionResult Details(int id)
        {
            return View(id);
        }


        [HttpGet]
        public IActionResult Crear(int id)
        {
            ViewBag.Id = id;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Crear(HistoricoEquipos requestHistorico)
        {
            try
            {
                HistoricoEquipos historicoEquipo = new()
                {
                  FkEquipo = requestHistorico.FkEquipo,
                  Motivo = requestHistorico.Motivo,
                  FechaMantenimiento = requestHistorico.FechaMantenimiento,
                  Calibracion = requestHistorico.Calibracion,
                  Reparacion = requestHistorico.Reparacion,
                  FechaReparacion = requestHistorico.FechaReparacion,
                  MontoGastado = requestHistorico.MontoGastado
                  
                };
                _context.HistoricoEquipos.Add(historicoEquipo);
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
                var equipo = _context.HistoricoEquipos.Find(id);
                return View(equipo);

            }
            catch (Exception ex)
            {

                throw new Exception("Surgio un error " + ex.Message);
            }

        }
        [HttpPost]
        public async Task<IActionResult> Editar(int id, HistoricoEquipos requestHistorico)
        {
            try
            {
                HistoricoEquipos hequipo = new();

                hequipo = _context.HistoricoEquipos.Find(id);
                hequipo.FkEquipo = requestHistorico.FkEquipo;
                hequipo.Motivo = requestHistorico.Motivo;
                hequipo.FechaMantenimiento = requestHistorico.FechaMantenimiento;
                hequipo.Calibracion = requestHistorico.Calibracion;
                hequipo.Reparacion = requestHistorico.Reparacion;
                hequipo.FechaReparacion = requestHistorico.FechaReparacion;
                hequipo.MontoGastado = requestHistorico.MontoGastado;
                _context.HistoricoEquipos.Update(hequipo);
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
                HistoricoEquipos hequipo = await _context.HistoricoEquipos.FindAsync(id);
                if (hequipo == null)
                {
                    return Json(new { success = false, message = "El equipo no fue encontrado." });
                }

                _context.HistoricoEquipos.Remove(hequipo);
                await _context.SaveChangesAsync();

                return Json(new { success = true, message = "El mantenimiento ha sido eliminado exitosamente." });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Ocurrió un error al intentar eliminar el equipo: " + ex.Message });
            }
        }
    }
}
