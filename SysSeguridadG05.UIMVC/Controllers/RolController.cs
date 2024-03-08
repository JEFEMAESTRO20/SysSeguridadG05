using Microsoft.AspNetCore.Mvc;
//*************************
using SysSeguridadG05.EN;
using SysSeguridadG05.BL;

namespace SysSeguridadG05.UIMVC.Controllers
{
    public class RolController : Controller
    {
        RolBL rolBl = new RolBL();
        public async Task<IActionResult> Index(Rol pRol = null)
        {
            if (pRol == null)
                pRol = new Rol();
            if (pRol.Top_Aux == 0)//Permite controlar el numero de registros en la DB
                pRol.Top_Aux = 10;
            else 
                if(pRol.Top_Aux == -1)
                pRol.Top_Aux = 0;
            var roles = await new RolBL().BuscarAsync(pRol);//Busque en la DB y se guarden en la variable roles
            ViewBag.Top = pRol.Top_Aux;
            return View(roles);
        }

        public async Task<IActionResult> Datails(int pId)
        {
            var rol = await rolBl.ObtenerPorIdAsync(new Rol { Id = pId });
            return View(rol);
        }

        public IActionResult Create(int pId)//clic derecho crear vista..colocar Crear
        {
            ViewBag.Error = "";
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create (Rol pRol)
        {
            try
            {
                int result = await rolBl.CrearAsync(pRol);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(pRol);
            }
        }
        public async Task<IActionResult> Delete(Rol pRol)
        {
            ViewBag.Error = "";
            var rol = await rolBl.ObtenerPorIdAsync(pRol);
            return View(rol);
        }
        public async Task<IActionResult> Edit(Rol pRol)//metodo para llamar la vista de editar
        {
            var rol = await rolBl.ObtenerPorIdAsync(pRol);//Guardar el error
            ViewBag.Error = "";
            return View(rol);//Retornar a la vista
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int pId, Rol pRol)//metodo para guardar el registro modificado
        {
            try
            {
                int result = await rolBl.ModificarAsync(pRol);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(pRol);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, Rol pRol)
        {
            try
            {
                int result = await rolBl.DeleteAsync(pRol);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error =ex.Message;
                return View(pRol);
            }
        }
    }
}
