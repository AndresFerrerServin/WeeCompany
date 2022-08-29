using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult GetAll()
        {
            ML.Cliente cliente = new ML.Cliente();
            ML.Result result = BL.Cliente.GetAll();
            if (result.Correct)
            {
                cliente.Clientes = result.Objects.ToList();
                return View(cliente);

            }
            else
            {
                ViewBag.Message = "Ocurrió un error al obtener la información" + result.ErrorMessage;
                return PartialView("Modal");
            }
        }

        [HttpGet]
        public JsonResult Form(int? IdCliente)

        {
            ML.Cliente cliente = new ML.Cliente();
            

            if (IdCliente == null)
            {
                ViewBag.Titulo = "Agregar un Cliente";
                ViewBag.Accion = "Agregar";

                return Json( cliente,  JsonRequestBehavior.AllowGet);
            }
            else
            {
                ViewBag.Titulo = "Actualizar un Usuario";
                ViewBag.Accion = "Actualizar";

                ML.Result result = BL.Cliente.GetById(IdCliente.Value);
                if (result.Correct)
                {
                    cliente = (ML.Cliente)result.Object;
                    return Json(cliente,  JsonRequestBehavior.AllowGet);
                }

                else
                {
                    ViewBag.Message = result.ErrorMessage;
                    return Json(null, JsonRequestBehavior.AllowGet);
                }

            }
        }

        [HttpPost]
        public ActionResult Form(ML.Cliente cliente)
        {
            if (cliente.IdCliente == 0)
            {
                ML.Result result = BL.Cliente.Add(cliente);

                if (result.Correct)
                {

                    ViewBag.Message = "Se ha agregado correctamente";
                    return PartialView("Modal");

                }

                else
                {

                    ViewBag.Message = result.ErrorMessage;
                    return PartialView("Modal");

                }

            }
            else
            {
                ML.Result result = BL.Cliente.Update(cliente);

                if (result.Correct)
                {
                    ViewBag.Message = " se actualizo Correctamente";
                    return PartialView("Modal");
                }

                else
                {
                    ViewBag.Message = " No se ha podido actualizar";
                    return PartialView("Modal");


                }


            }
        }

        [HttpGet]
        public ActionResult Delete(int IdCliente)
        {

            ML.Cliente cliente = new ML.Cliente();
            cliente.IdCliente = IdCliente;


            ML.Result result = BL.Cliente.Delete(cliente);
            if (result.Correct)
            {
                ViewBag.Message = "se ha eliminado correctamente";
            }
            else
            {
                ViewBag.Message = "Error al eliminar ";

            }
            return PartialView("Modal");

        }
    }

}