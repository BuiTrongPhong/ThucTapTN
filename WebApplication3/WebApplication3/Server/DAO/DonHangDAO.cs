using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication3.Server.EF;

namespace WebApplication3.Server.DAO
{
    public class DonHangDAO
    {
        PhongShopDB db = null;
            public DonHangDAO()
            {
                db = new PhongShopDB();
            }

            public void them(DonHang dh)
            {
                db.DonHangs.Add(dh);
                db.SaveChanges();
            }

            public int themCTDH(ChiTietDonHang dh)
            {
                db.ChiTietDonHangs.Add(dh);
                db.SaveChanges();
                return dh.orderId;
            }
    }
}