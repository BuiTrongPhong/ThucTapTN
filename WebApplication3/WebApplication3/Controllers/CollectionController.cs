using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Server.DAO;

namespace WebApplication3.Controllers
{
    public class CollectionController : Controller
    {
        // GET: Collection
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Shop(int? page, string currentFilter, string size = "all", string price = "0", string filterType = "all", string sortOrder = "option", string sortActive = "Tùy chọn")
        {
            DanhMucDAO dm = new DanhMucDAO();
            SanPhamDAO x = new SanPhamDAO();
            ViewBag.danhMuc = dm.GetAll().ToList();
            ViewBag.price = price.ToString();
            ViewBag.filterType = filterType;
            ViewBag.action = "Shop";
            ViewBag.title = "Shop";
            ViewBag.size = size;
            ViewBag.sortOrder = sortOrder;
            ViewBag.sortActive = sortActive;
            int pageSize = 4;
            int pageNumber = page ?? 1;
            return View(x.GetAll().ToPagedList(pageNumber, pageSize));
        }

        public ActionResult GiayNu(int? page, string size = "all", string price = "0", string filterType = "all", string sortOrder = "option", string sortActive = "Tùy chọn")
        {
            DanhMucDAO dm = new DanhMucDAO();
            ViewBag.danhMuc = dm.GetAll().ToList();
            SanPhamDAO x = new SanPhamDAO();
            ViewBag.action = "GiayNu";
            ViewBag.price = price.ToString();
            ViewBag.filterType = filterType;
            ViewBag.title = "Giày nữ";
            ViewBag.size = size;
            ViewBag.sortOrder = sortOrder;
            ViewBag.sortActive = sortActive;
            int pageSize = 3;
            int pageNumber = page ?? 1;
            return View(x.getProductsFemale(size, price, filterType, sortOrder).ToPagedList(pageNumber, pageSize));
        }

        public ActionResult TheLoai(int? page, int? id, string typeMaleorFemale, string categoryName, string price = "0", string filterType = "all", string size = "all", string sortOrder = "option", string sortActive = "Tùy chọn")
        {
            SanPhamDAO g = new SanPhamDAO();
            DanhMucDAO dm = new DanhMucDAO();
            ViewBag.danhMuc = dm.GetAll().ToList();
            ViewBag.filterTypeMaleorFemale = typeMaleorFemale;
            ViewBag.filterType = filterType;
            ViewBag.action = "TheLoai";
            ViewBag.price = price.ToString();
            ViewBag.title = categoryName;
            ViewBag.size = size;
            ViewBag.sortActive = sortActive;
            ViewBag.sortOrder = sortOrder;
            if (id == null )
            {
                return RedirectToAction("Index", "Home");
            }
            int pageSize = 3;
            int pageNumber = page ?? 1;
            return View("TheLoai", g.GetProductsBaseCategoryId(id ?? 0, typeMaleorFemale, price, filterType, size, sortOrder).ToPagedList(pageNumber, pageSize));
        }

    }
}