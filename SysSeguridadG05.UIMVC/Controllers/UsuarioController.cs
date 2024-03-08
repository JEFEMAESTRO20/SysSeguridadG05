using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
//****************************
using SysSeguridadG05.EN;
using SysSeguridadG05.BL;

namespace SysSeguridadG05.UIMVC.Controllers
{
    public class UsuarioController : Controller
    {
        UsuarioBL usuarioBl = new UsuarioBL();
        RolBL rolBl = new RolBL();
        // GET: UsuarioController
        public async Task<ActionResult> Index(Usuario pUsuario= null)
        {
            if (pUsuario == null)
                pUsuario = new Usuario();
            if (pUsuario.Top_Aux == 0)
                pUsuario.Top_Aux = 10;
            else
                if (pUsuario.Top_Aux == -1)
                pUsuario.Top_Aux = 0;
            var tasBuscar = usuarioBl.BuscarIncluirRolAsync(pUsuario);
            var tasObtenerRoles = rolBl.ObtenerTodosAsync();
            var usuarios = await tasBuscar;
            ViewBag.Top = pUsuario.Top_Aux;
            ViewBag.Roles = await tasObtenerRoles;
            return View(usuarios);
        }

        // GET: UsuarioController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UsuarioController/Create
        public async Task<IActionResult> Create(IFormCollection collection)
        {
            ViewBag.Roles = await rolBl.ObtenerTodosAsync();
            ViewBag.Error = "";
            return View();
        }

        // POST: UsuarioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Usuario pUsuario)
        {
            try
            {
                int result = await usuarioBl.CrearAsync(pUsuario);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                ViewBag.Error = ex.Message;
                ViewBag.Roles = await rolBl.ObtenerTodosAsync();
                return View(pUsuario);
            }
        }

        // GET: UsuarioController/Edit/5
        public async Task<IActionResult> Edit(Usuario pUsuario)
        {
            var usuario = await usuarioBl.ObtenerPorIdAsync(pUsuario);
            ViewBag.Roles = await rolBl.ObtenerTodosAsync();
            ViewBag.Error = "" ;
            return View(usuario);
        }

        // POST: UsuarioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Usuario pUsuario)
        {
            try
            {
                int result = await usuarioBl.ModificarAsync(pUsuario);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                ViewBag.Error = ex.Message;
                ViewBag.Roles = await rolBl.ObtenerTodosAsync();
                return View(pUsuario);
            }
        }

        // GET: UsuarioController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UsuarioController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
