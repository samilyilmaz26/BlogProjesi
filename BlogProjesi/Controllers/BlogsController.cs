using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogProjesi.Context;
using BlogProjesi.Models.Views;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using static BlogProjesi.Context.BlogContext;

namespace BlogProjesi.Controllers
{
    public class BlogsController : Controller
    {
        BlogContext _db;
        MakaleModel _makaleModel;
        ISession _session;
        public BlogsController(BlogContext db ,MakaleModel makaleModel, IHttpContextAccessor httpContextAccessor)
        {
            _db = db;
            _makaleModel = makaleModel;
            _session = httpContextAccessor.HttpContext.Session;
        }
        public IActionResult List()
        {
            ICollection<Makaleler> mlist = _db.Makale.ToList();
            return View(mlist);
        }
        public IActionResult MyList()
        {
            var value = _session.GetString("username");
            string yazar = "";
            if (value != null)
            {
                ViewBag.Msg = "Başarılı Bir Şekilde Login Oldunuz...";
                ViewBag.UserName = JsonConvert.DeserializeObject<string>(value);
                yazar = JsonConvert.DeserializeObject<string>(value);
            }
            ICollection<Makaleler> mlist = _db.Makale.Where(x => x.Yazar == yazar).ToList();
            return View(mlist);
        }
        [HttpGet]
        public IActionResult Giris()
        {
             _makaleModel.Action = "Giris";
            _makaleModel.BtnClass = "btn btn-primary";
            _makaleModel.BtnValue = "Giriş";
            return View(_makaleModel);
        }
        [HttpPost]
        public IActionResult Giris(MakaleModel model)
        {
            model.Makele.Detay = model.Detay;
             model.Makele.Yazar = "samil";
            _db.Entry(model.Makele).State = EntityState.Added;
            _db.SaveChanges();
            return RedirectToAction("MyList");
        }
        [HttpGet]
        public IActionResult Guncel(int id)
        {
            _makaleModel.Makele = _db.Set<Makaleler>().Find(id);
            _makaleModel.Action = "Guncel";
            _makaleModel.BtnClass = "btn btn-success";
            _makaleModel.BtnValue = "Güncelle";
            return View("Giris", _makaleModel);
        }
        [HttpPost]
        public IActionResult Guncel(MakaleModel model)
        {
            model.Makele.Detay = model.Detay;
            model.Makele.Yazar = "samil";
            _db.Entry(model.Makele).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("MyList");
        }
        [HttpGet]
        public IActionResult Sil(int id)
        {
            _makaleModel.Makele = _db.Set<Makaleler>().Find(id);
            _makaleModel.Action = "Sil";
            _makaleModel.BtnClass = "btn btn-danger";
            _makaleModel.BtnValue = "Sil";
            return View("Giris", _makaleModel);
        }
        [HttpPost]
        public IActionResult Sil(MakaleModel model)
        {
            _db.Entry(model.Makele).State = EntityState.Deleted;
            _db.SaveChanges();
            return RedirectToAction("MyList");
        }
        [HttpGet]
        public IActionResult Detay(int id)
        {
            Makaleler makale   = _db.Set<Makaleler>().Find(id);
            
            return View(makale);
        }
    }
}