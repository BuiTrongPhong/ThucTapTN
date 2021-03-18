﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication3.Server.EF;

namespace WebApplication3.Server.DAO
{
    public class SlideNewProductDAO
    {
        PhongShopDB db = null;
        public SlideNewProductDAO()
        {
            db = new PhongShopDB();
        }

        public IEnumerable<SlideNewProduct> GetAll()
        {
            return db.SlideNewProducts.ToList().Select(item =>
            {
                var g = db.SanPhams.Find(item.spId);
                item.description = g?.description;
                item.shoeName = g?.spName;
                item.createdAt = g?.createdAt;
                return item;
            });
        }

        public SlideNewProduct getSlideBaseProductId(int id)
        {
            return this.db.SlideNewProducts.SingleOrDefault(item => item.spId == id);
        }

        public int Them(SlideNewProduct item)
        {
            try
            {
                db.SlideNewProducts.Add(item);
                db.SaveChanges();
                return item.slideId;
            }
            catch (Exception)
            {

                return -1;
            }

        }

        public bool Xoa(int id)
        {
            try
            {
                int slideId = db.SlideNewProducts.SingleOrDefault(item => item.spId == id).slideId;
                var entity = db.SlideNewProducts.Find(slideId);
                db.SlideNewProducts.Attach(entity);
                db.SlideNewProducts.Remove(entity);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}