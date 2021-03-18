using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Server.DAO;
using WebApplication3.Server.EF;

namespace WebApplication3.Controllers
{
    public class ChiTietSanPhamController : Controller
    {
        private PhongShopDB db = new PhongShopDB();
        // GET: ChiTietSanPham
        public ActionResult Index()
        {
            return View();
        }

        // GET: ChiTietSanPham/Details/5
        public ActionResult Details(int id)
        {
            DanhMucDAO dm = new DanhMucDAO();
            ViewBag.danhMuc = dm.GetAll().ToList();
            return View(db.SanPhams.Where(item => item.spId == id).SingleOrDefault());
        }
    }
}
