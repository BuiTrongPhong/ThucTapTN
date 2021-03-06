using PagedList;
using System;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Authorize;
using WebApplication3.Server.DAO;
using WebApplication3.Server.EF;

namespace WebApplication3.Areas.Admin.Controllers
{
    [AuthorizeUserAttribute]
    public class SanPhamController : Controller
    {
        SanPhamDAO SanPhamDAO = new SanPhamDAO();
        public ActionResult Index(int? page)
        {
            int pageSize = 10;
            int pageNumber = page ?? 1;
            return View(SanPhamDAO.GetAll().ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Them()
        {
            var dm = new DanhMucDAO();
            ViewBag.Categories = dm.GetAll();
            return View("Them");
        }


        [HttpPost]
        public ActionResult Them(SanPham g, HttpPostedFileBase image)
        {
            if (image != null)
            {
                image.SaveAs((HttpContext.Server.MapPath("~/Images/")+ image.FileName));
                g.image = image.FileName;
            } 
            int res = SanPhamDAO.add(g);
            if (res != -1)
            {
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Thêm giày xảy ra lỗi. Xin thử lại!");
            return View();
        }


        public ActionResult Sua(int id)
        {
            SanPham entity = SanPhamDAO.getShoeById(id);
            var dm = new DanhMucDAO();
            ViewBag.Categories = dm.GetAll();
            return View(entity);
        }
        [HttpPost]
        public ActionResult Sua(SanPham g, HttpPostedFileBase imageEdit)
        {
            if (imageEdit != null)
            {
                byte[] img = new byte[imageEdit.ContentLength];
                //image.InputStream.Read(img, 0, image.ContentLength);
                imageEdit.SaveAs((HttpContext.Server.MapPath("~/Images/") + imageEdit.FileName));
                g.image = imageEdit.FileName;
            }
            bool res = SanPhamDAO.edit(g, false);
            if (res)
            {
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Cập nhật xảy ra lỗi. Xin kiểm tra lại!");
            return View();
        }

        public ActionResult Xoa(int id)
        {
            SanPham entity = SanPhamDAO.getShoeById(id);
            var res = SanPhamDAO.edit(entity, true);
            if (!res)
            {
                ModelState.AddModelError("", "Xóa khách hàng xảy ra lỗi. Xin thử lại!");
                return View();
            }
            return RedirectToAction("Index");
        }
    }
}