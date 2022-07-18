using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult GetAll()
        {
            //ML.Result result = new ML.Result();
            ML.Usuario usuario = new ML.Usuario();
            usuario.Estado = new ML.Estado();
            usuario.Estatus = new ML.Estatus();

            ML.Result result = BL.Usuario.GetAll();

            result.Objects = new List<object>();
            //result.Objects.Add(new ML.Usuario
            //{
            //    IdUsuario = 1,
            //    Nombre = "Estefania",
            //    ApellidoPaterno = "Tellez",
            //    ApellidoMaterno = "Delgado",
            //    Email = "estefania@gmail.com",
            //    Contraseña = "password",
            //    Imagen = new byte[0],
            //    UserName = "Fany",
            //    Estado = new ML.Estado { Nombre = "Conectado" },
            //    Estatus = new ML.Estatus { Nombre = "Ocupado" },
            //}
            //    );

            result.Objects.Add(new ML.Usuario
            {
                IdUsuario = 2,
                Nombre = "Luis",
                ApellidoPaterno = "Gonzalez",
                ApellidoMaterno = "Flores",
                Email = "luis@gmail.com",
                Contraseña = "pass@word",
                Imagen = new byte[0],
                UserName = "LuisGon",
                Estado = new ML.Estado { Nombre = "Desconectado" },
                Estatus = new ML.Estatus { Nombre = "Disponible" }
            });

            result.Correct = true;

            //ML.Result resultEstado = BL.Estado.GetAll();
            //ML.Result resultEstatus = BL.Estatus.GetAll();

            if (result.Correct /*&& resultEstado.Correct && resultEstatus.Correct*/)
            {
                usuario.Usuarios = result.Objects;
                //usuario.Estado.Estados = resultEstado.Objects;
                //usuario.Estatus.Status = resultEstatus.Objects;
            }
            return View(usuario);
        }
        [HttpGet]
        public ActionResult Form()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Form(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();

            if (usuario.IdUsuario == 0)
            {
                result = BL.Usuario.Add(usuario);
                if (result.Correct)
                {
                    ViewBag.Message = "El usuario se ha agregado";
                }
                else
                {

                    ViewBag.Message = "El usuario no se agrego";
                }
            }
            return PartialView("Modal");
        }
    }
}