using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PowerAppsAplication.Context;
using PowerAppsAplication.Models;

namespace PowerAppsAplication.Controllers
{
    public class EPPTorresController : Controller
    {
        private readonly ApplicationDbContext _context;
        public EPPTorresController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<EPPTorres> listaRegistros = _context.EPPTorres.ToList();

            return View(listaRegistros);
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
        public async Task<IActionResult> Crear(EPPTorres requestRegistro)
        {
            try
            {
                EPPTorres eppTorres = new()
                {
                    NombreUsuario = requestRegistro.NombreUsuario,
                    JefeDirecto = requestRegistro.JefeDirecto,  
                    Gerencia = requestRegistro.Gerencia,
                    Ciudad = requestRegistro.Ciudad,
                    Arnes5Posiciones = requestRegistro.Arnes5Posiciones,
                    MarcaArnes = requestRegistro.MarcaArnes,
                    FechaFabricacionArnes = requestRegistro.FechaFabricacionArnes,
                    ComentariosStatusArnes = requestRegistro.ComentariosStatusArnes,
                    BotasSeguridad = requestRegistro.BotasSeguridad,
                    CuerdaPosicionamiento = requestRegistro.CuerdaPosicionamiento,
                    FechaFabricacionCuerda = requestRegistro.FechaFabricacionCuerda,
                    Guantes = requestRegistro.Guantes,
                    LentesSeguridad = requestRegistro.LentesSeguridad,
                    Mosqueton = requestRegistro.Mosqueton,
                    ShockAbsorbente = requestRegistro.ShockAbsorbente,
                    FechaFabricacionShock = requestRegistro.FechaFabricacionShock,
                    SujetadorLineaVida = requestRegistro.SujetadorLineaVida,
                    CascoSeguridadBarbiquejo = requestRegistro.CascoSeguridadBarbiquejo,
                    Comentario = requestRegistro.Comentario,
                    Imagen1 = requestRegistro.Imagen1,
                    Imagen2 = requestRegistro.Imagen2,
                    ImagenFirma = requestRegistro.ImagenFirma
                };
                _context.EPPTorres.Add(eppTorres);
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
                var eppTorres = _context.EPPTorres.Find(id);
                return View(eppTorres);

            }
            catch (Exception ex)
            {

                throw new Exception("Surgio un error " + ex.Message);
            }

        }
        [HttpPost]
        public async Task<IActionResult> Editar(int id, EPPTorres requestRegistro)
        {
            try
            {
                EPPTorres eppTorres = new();
                eppTorres = _context.EPPTorres.Find(id);
                eppTorres.NombreUsuario = requestRegistro.NombreUsuario;
                eppTorres.JefeDirecto = requestRegistro.JefeDirecto;
                eppTorres.Gerencia = requestRegistro.Gerencia;
                eppTorres.Ciudad = requestRegistro.Ciudad;
                eppTorres.Arnes5Posiciones = requestRegistro.Arnes5Posiciones;
                eppTorres.MarcaArnes = requestRegistro.MarcaArnes;
                eppTorres.FechaFabricacionArnes = requestRegistro.FechaFabricacionArnes;
                eppTorres.ComentariosStatusArnes = requestRegistro.ComentariosStatusArnes;
                eppTorres.BotasSeguridad = requestRegistro.BotasSeguridad;
                eppTorres.CuerdaPosicionamiento = requestRegistro.CuerdaPosicionamiento;
                eppTorres.FechaFabricacionCuerda = requestRegistro.FechaFabricacionCuerda;
                eppTorres.Guantes = requestRegistro.Guantes;
                eppTorres.LentesSeguridad = requestRegistro.LentesSeguridad;
                eppTorres.Mosqueton = requestRegistro.Mosqueton;
                eppTorres.ShockAbsorbente = requestRegistro.ShockAbsorbente;
                eppTorres.FechaFabricacionShock = requestRegistro.FechaFabricacionShock;
                eppTorres.SujetadorLineaVida = requestRegistro.SujetadorLineaVida;
                eppTorres.CascoSeguridadBarbiquejo = requestRegistro.CascoSeguridadBarbiquejo;
                eppTorres.Comentario = requestRegistro.Comentario;
                eppTorres.Imagen1 = requestRegistro.Imagen1;
                eppTorres.Imagen2 = requestRegistro.Imagen2;
                eppTorres.ImagenFirma = requestRegistro.ImagenFirma;

                _context.EPPTorres.Update(eppTorres);
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
                EPPTorres eppTorres = await _context.EPPTorres.FindAsync(id);
                if (eppTorres == null)
                {
                    return Json(new { success = false, message = "El registro no fue encontrado." });
                }

                _context.EPPTorres.Remove(eppTorres);
                await _context.SaveChangesAsync();

                return Json(new { success = true, message = "El registro ha sido eliminado exitosamente." });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Ocurrió un error al intentar eliminar el registro: " + ex.Message });
            }
        }
    }
}
