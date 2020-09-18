using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogProjesi.Context;
using BlogProjesi.Models.Views;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using static BlogProjesi.Context.BlogContext;

namespace BlogProjesi.Controllers
{
    public class LoginController : Controller
    {
        BlogContext _db;
        UserModel _userModel;
        ISession _session;
        public LoginController(BlogContext db, UserModel userModel , IHttpContextAccessor httpContextAccessor)
        {
            _userModel = userModel;
            _db = db;
            _session = httpContextAccessor.HttpContext.Session;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View(_userModel);
        }
        [HttpPost]
        public IActionResult Login(UserModel model)
        {
            Users user = _db.User.Find(model.Email);
            if (user == null)
            {
               // ViewBag.Msg = "Böyle bir Kullanıcı Yok";
                return View();
            }
             else if (user.Password == model.Password)
            {
                // ViewBag.Msg = "Giriş Balarılı";
                _session.SetString("username", JsonConvert.SerializeObject(user.Email));
                return RedirectToAction("MyList","Blogs");
            }
            else
            {
                //  ViewBag.Msg = "şifre Yanlış"; 
                return View();
            }

        }
    }
}