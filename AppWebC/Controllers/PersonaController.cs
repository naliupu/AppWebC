using AppWebC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

namespace AppWebC.Controllers
{
    [Authorize]
    public class PersonaController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public PersonaController()
        {
        }

        public PersonaController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        // GET: Persona
        public ActionResult Index()
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                List<PersonaViewModel> persona = (from p in db.Persona
                                                  join c in db.Color on p.id_color equals c.Id
                                                  select new PersonaViewModel
                                                  {
                                                      nombre = p.nombre,
                                                      telefono = p.telefono,
                                                      direccion = p.direccion,
                                                      fecha_nacimiento = p.fecha_nacimiento,
                                                      edad = p.edad,
                                                      color = c.nombre_color,
                                                      id_usuario = p.id_usuario
                                                  }).ToList();
                return View(persona);
            }
        }

        // GET: Persona/Details/5
        public ActionResult Details(int id)
        {

            return View();
        }

        // GET: Persona/Create
        public ActionResult Create()
        {
            List<Color> colores = null;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                colores = db.Color.ToList();
            }

            //ViewBag.colores = colores;
            ViewBag.colores = colores;

            return View();
        }

        // POST: Persona/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "nombre,telefono,direccion,edad,fecha_nacimiento,id_color")] Persona persona, [Bind(Include = "Email,Password")] RegisterViewModel usuario)
        {
            try
            {
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    var user = new ApplicationUser { UserName = usuario.Email, Email = usuario.Email };
                    var result = UserManager.Create(user, usuario.Password);
                    if (result.Succeeded)
                    {
                        string code = UserManager.GenerateEmailConfirmationToken(user.Id);
                        var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                        UserManager.SendEmail(user.Id, "Confirma tu cuenta", "Por favor confirma tu cuenta haciendo click <a href=" + "'" + callbackUrl + "'" + ">aqui</a>");

                        persona.id_usuario = user.Id;

                        db.Persona.Add(persona);
                        db.SaveChanges();
                    }
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Persona/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Persona/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public JsonResult ConsultarUsuario(string id)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            var usuario = db.Users.Find(id);
            return Json(usuario, JsonRequestBehavior.AllowGet);
        }
    }
}
