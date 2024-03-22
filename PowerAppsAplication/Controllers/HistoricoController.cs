using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using PowerAppsAplication.Context;
using PowerAppsAplication.Models;

namespace PowerAppsAplication.Controllers
{
    public class HistoricoController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;
        public HistoricoController(ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;

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
                //string fotoEquipoFileName = null;
                //string certificadoCalibracionFileName = null;

                //if (requestHistorico.FotoEquipo != null)
                //{
                //    string uploadsFolder = Path.Combine(_hostEnvironment.WebRootPath, "images");
                //    fotoEquipoFileName = Guid.NewGuid().ToString() + "_" + requestHistorico.FotoEquipo.FileName;
                //    string filePath = Path.Combine(uploadsFolder, fotoEquipoFileName);
                //    using (var fileStream = new FileStream(filePath, FileMode.Create))
                //    {
                //        await requestHistorico.FotoEquipo.CopyToAsync(fileStream);
                //    }
                //}

                //if (requestHistorico.CertificadoCalibracion != null)
                //{
                //    string uploadsFolder = Path.Combine(_hostEnvironment.WebRootPath, "documents");
                //    certificadoCalibracionFileName = Guid.NewGuid().ToString() + "_" + requestHistorico.CertificadoCalibracion.FileName;
                //    string filePath = Path.Combine(uploadsFolder, certificadoCalibracionFileName);
                //    using var fileStream = new FileStream(filePath, FileMode.Create);
                //    await requestHistorico.CertificadoCalibracion.CopyToAsync(fileStream);
                //}
                HistoricoEquipos historicoEquipo = new()
                {
                  FkEquipo = requestHistorico.FkEquipo,
                  Motivo = requestHistorico.Motivo,
                  Fecha = requestHistorico.Fecha,
                  Descripcion = requestHistorico.Descripcion,
                  Comentarios = requestHistorico.Comentarios,
                  //FotoEquipo = fotoEquipoFileName,
                  //CertificadoCalibracion = certificadoCalibracionFileName,
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
                //hequipo.FechaMantenimiento = requestHistorico.FechaMantenimiento;
                //hequipo.Calibracion = requestHistorico.Calibracion;
                //hequipo.Reparacion = requestHistorico.Reparacion;
                //hequipo.FechaReparacion = requestHistorico.FechaReparacion;
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
