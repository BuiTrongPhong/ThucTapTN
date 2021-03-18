using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using WebApplication3.Models;
using WebApplication3.Server.EF;

namespace WebApplication3.Server.DAO
{
    public class SanPhamDAO
    {
        PhongShopDB db = null;
        public SanPhamDAO()
        {
            db = new PhongShopDB();
        }

        public IEnumerable<SanPham> GetAll()
        {
            SlideNewProductDAO sl = new SlideNewProductDAO();
            return db.SanPhams.Where(item => (bool)!item.isDeleted).ToList().Select(item => {
                item.viewCount = item.viewCount != null ? item.viewCount : 0;
                item.categoryName = db.TheLoais.Find(item.categoryId).categoryName;
                item.isActive = sl.getSlideBaseProductId(item.spId) != null ? true : false;
                return item;
            });
        }
        public IEnumerable<SanPham> GetName(string searchString)
        {
            SlideNewProductDAO sl = new SlideNewProductDAO();
            return db.SanPhams.Where(p=>p.spName.Contains(searchString)).Where(item => (bool)!item.isDeleted).ToList().Select(item => {
                item.viewCount = item.viewCount != null ? item.viewCount : 0;
                item.categoryName = db.TheLoais.Find(item.categoryId).categoryName;
                item.isActive = sl.getSlideBaseProductId(item.spId) != null ? true : false;
                return item;
            });
        }


        public IEnumerable<SanPham> getSlideBaseProductId(string size, string filterPrice, string filterType, string sortOrder, string type)
        {
            switch (filterType)
            {
                case "all":
                    switch (sortOrder)
                    {
                        case "name_desc":
                            return db.SanPhams.OrderByDescending(s => s.spName).Where(item => size == "all" ? item.type == type || item.type == "all" : item.size.Contains(size) && (item.type == type || item.type == "all")).ToList().Select(item => {
                                if (item.comparePrice > 0 && item.comparePrice != null)
                                {
                                    double gia = (double)(100 - item.price / item.comparePrice * 100);
                                    item.promotion = Math.Round(gia, 0).ToString();
                                }

                                return item;
                            });
                        case "name_asc":
                            return db.SanPhams.OrderBy(s => s.spName).Where(item => size == "all" ? item.type == type || item.type == "all" : item.size.Contains(size) && (item.type == type || item.type == "all")).ToList().Select(item => {
                                if (item.comparePrice > 0 && item.comparePrice != null)
                                {
                                    double gia = (double)(100 - item.price / item.comparePrice * 100);
                                    item.promotion = Math.Round(gia, 0).ToString();
                                }

                                return item;
                            });
                        case "price_asc":
                            return db.SanPhams.OrderBy(s => s.price).Where(item => size == "all" ? item.type == type || item.type == "all" : item.size.Contains(size) && (item.type == type || item.type == "all")).ToList().Select(item => {
                                if (item.comparePrice > 0 && item.comparePrice != null)
                                {
                                    double gia = (double)(100 - item.price / item.comparePrice * 100);
                                    item.promotion = Math.Round(gia, 0).ToString();
                                }

                                return item;
                            });
                        case "price_desc":
                            return db.SanPhams.OrderByDescending(s => s.price).Where(item => size == "all" ? item.type == type || item.type == "all" : item.size.Contains(size) && (item.type == type || item.type == "all")).ToList().Select(item => {
                                if (item.comparePrice > 0 && item.comparePrice != null)
                                {
                                    double gia = (double)(100 - item.price / item.comparePrice * 100);
                                    item.promotion = Math.Round(gia, 0).ToString();
                                }

                                return item;
                            });
                        case "oldest":
                            return db.SanPhams.OrderBy(s => s.createdAt).Where(item => size == "all" ? item.type == type || item.type == "all" : item.size.Contains(size) && (item.type == type || item.type == "all")).ToList().Select(item => {
                                if (item.comparePrice > 0 && item.comparePrice != null)
                                {
                                    double gia = (double)(100 - item.price / item.comparePrice * 100);
                                    item.promotion = Math.Round(gia, 0).ToString();
                                }

                                return item;
                            });
                        case "newest":
                            return db.SanPhams.OrderByDescending(s => s.createdAt).Where(item => size == "all" ? item.type == type || item.type == "all" : item.size.Contains(size) && (item.type == type || item.type == "all")).ToList().Select(item => {
                                if (item.comparePrice > 0 && item.comparePrice != null)
                                {
                                    double gia = (double)(100 - item.price / item.comparePrice * 100);
                                    item.promotion = Math.Round(gia, 0).ToString();
                                }

                                return item;
                            });
                        case "soldest":
                            return db.SanPhams.OrderByDescending(s => s.quantitySold).Where(item => size == "all" ? item.type == type || item.type == "all" : item.size.Contains(size) && (item.type == type || item.type == "all")).ToList().Select(item => {
                                if (item.comparePrice > 0 && item.comparePrice != null)
                                {
                                    double gia = (double)(100 - item.price / item.comparePrice * 100);
                                    item.promotion = Math.Round(gia, 0).ToString();
                                }

                                return item;
                            });
                        default:
                            return db.SanPhams.OrderByDescending(s => s.createdAt).Where(item => size == "all" ? item.type == type || item.type == "all" : item.size.Contains(size) && (item.type == type || item.type == "all")).ToList().Select(item => {
                                if (item.comparePrice > 0 && item.comparePrice != null)
                                {
                                    double gia = (double)(100 - item.price / item.comparePrice * 100);
                                    item.promotion = Math.Round(gia, 0).ToString();
                                }

                                return item;
                            });
                    }

                case "lesser":
                    int priceLesser = Convert.ToInt32(filterPrice);
                    switch (sortOrder)
                    {
                        case "name_desc":
                            return db.SanPhams.OrderByDescending(s => s.spName).Where(item => size == "all" ? item.price < priceLesser && (item.type == type || item.type == "all") : item.size.Contains(size) && item.price < priceLesser && (item.type == type || item.type == "all")).ToList().Select(item => {
                                if (item.comparePrice > 0 && item.comparePrice != null)
                                {
                                    double gia = (double)(100 - item.price / item.comparePrice * 100);
                                    item.promotion = Math.Round(gia, 0).ToString();
                                }
                                return item;
                            });
                        case "name_asc":
                            return db.SanPhams.OrderBy(s => s.spName).Where(item => size == "all" ? item.price < priceLesser && (item.type == type || item.type == "all") : item.size.Contains(size) && item.price < priceLesser && (item.type == type || item.type == "all")).ToList().Select(item => {
                                if (item.comparePrice > 0 && item.comparePrice != null)
                                {
                                    double gia = (double)(100 - item.price / item.comparePrice * 100);
                                    item.promotion = Math.Round(gia, 0).ToString();
                                }
                                return item;
                            });
                        case "price_asc":
                            return db.SanPhams.OrderBy(s => s.price).Where(item => size == "all" ? item.price < priceLesser && (item.type == type || item.type == "all") : item.size.Contains(size) && item.price < priceLesser && (item.type == type || item.type == "all")).ToList().Select(item => {
                                if (item.comparePrice > 0 && item.comparePrice != null)
                                {
                                    double gia = (double)(100 - item.price / item.comparePrice * 100);
                                    item.promotion = Math.Round(gia, 0).ToString();
                                }
                                return item;
                            });
                        case "price_desc":
                            return db.SanPhams.OrderByDescending(s => s.price).Where(item => size == "all" ? item.price < priceLesser && (item.type == type || item.type == "all") : item.size.Contains(size) && item.price < priceLesser && (item.type == type || item.type == "all")).ToList().Select(item => {
                                if (item.comparePrice > 0 && item.comparePrice != null)
                                {
                                    double gia = (double)(100 - item.price / item.comparePrice * 100);
                                    item.promotion = Math.Round(gia, 0).ToString();
                                }
                                return item;
                            });
                        case "oldest":
                            return db.SanPhams.OrderBy(s => s.createdAt).Where(item => size == "all" ? item.price < priceLesser && (item.type == type || item.type == "all") : item.size.Contains(size) && item.price < priceLesser && (item.type == type || item.type == "all")).ToList().Select(item => {
                                if (item.comparePrice > 0 && item.comparePrice != null)
                                {
                                    double gia = (double)(100 - item.price / item.comparePrice * 100);
                                    item.promotion = Math.Round(gia, 0).ToString();
                                }
                                return item;
                            });
                        case "newest":
                            return db.SanPhams.OrderByDescending(s => s.createdAt).Where(item => size == "all" ? item.price < priceLesser && (item.type == type || item.type == "all") : item.size.Contains(size) && item.price < priceLesser && (item.type == type || item.type == "all")).ToList().Select(item => {
                                if (item.comparePrice > 0 && item.comparePrice != null)
                                {
                                    double gia = (double)(100 - item.price / item.comparePrice * 100);
                                    item.promotion = Math.Round(gia, 0).ToString();
                                }
                                return item;
                            });
                        case "soldest":
                            return db.SanPhams.OrderByDescending(s => s.quantitySold).Where(item => size == "all" ? item.price < priceLesser && (item.type == type || item.type == "all") : item.size.Contains(size) && item.price < priceLesser && (item.type == type || item.type == "all")).ToList().Select(item => {
                                if (item.comparePrice > 0 && item.comparePrice != null)
                                {
                                    double gia = (double)(100 - item.price / item.comparePrice * 100);
                                    item.promotion = Math.Round(gia, 0).ToString();
                                }
                                return item;
                            });
                        default:
                            return db.SanPhams.OrderByDescending(s => s.createdAt).Where(item => size == "all" ? item.price < priceLesser && (item.type == type || item.type == "all") : item.size.Contains(size) && item.price < priceLesser && (item.type == type || item.type == "all")).ToList().Select(item => {
                                if (item.comparePrice > 0 && item.comparePrice != null)
                                {
                                    double gia = (double)(100 - item.price / item.comparePrice * 100);
                                    item.promotion = Math.Round(gia, 0).ToString();
                                }
                                return item;
                            });
                    }

                case "bigger":
                    int priceBigger = Convert.ToInt32(filterPrice);
                    switch (sortOrder)
                    {
                        case "name_desc":
                            return db.SanPhams.OrderByDescending(s => s.spName).Where(item => size == "all" ? item.price > priceBigger && (item.type == type || item.type == "all") : item.size.Contains(size) && item.price > priceBigger && (item.type == type || item.type == "all")).ToList().Select(item => {
                                if (item.comparePrice > 0 && item.comparePrice != null)
                                {
                                    double gia = (double)(100 - item.price / item.comparePrice * 100);
                                    item.promotion = Math.Round(gia, 0).ToString();
                                }
                                return item;
                            });
                        case "name_asc":
                            return db.SanPhams.OrderBy(s => s.spName).Where(item => size == "all" ? item.price > priceBigger && (item.type == type || item.type == "all") : item.size.Contains(size) && item.price > priceBigger && (item.type == type || item.type == "all")).ToList().Select(item => {
                                if (item.comparePrice > 0 && item.comparePrice != null)
                                {
                                    double gia = (double)(100 - item.price / item.comparePrice * 100);
                                    item.promotion = Math.Round(gia, 0).ToString();
                                }
                                return item;
                            });
                        case "price_asc":
                            return db.SanPhams.OrderBy(s => s.price).Where(item => size == "all" ? item.price > priceBigger && (item.type == type || item.type == "all") : item.size.Contains(size) && item.price > priceBigger && (item.type == type || item.type == "all")).ToList().Select(item => {
                                if (item.comparePrice > 0 && item.comparePrice != null)
                                {
                                    double gia = (double)(100 - item.price / item.comparePrice * 100);
                                    item.promotion = Math.Round(gia, 0).ToString();
                                }
                                return item;
                            });
                        case "price_desc":
                            return db.SanPhams.OrderByDescending(s => s.price).Where(item => size == "all" ? item.price > priceBigger && (item.type == type || item.type == "all") : item.size.Contains(size) && item.price > priceBigger && (item.type == type || item.type == "all")).ToList().Select(item => {
                                if (item.comparePrice > 0 && item.comparePrice != null)
                                {
                                    double gia = (double)(100 - item.price / item.comparePrice * 100);
                                    item.promotion = Math.Round(gia, 0).ToString();
                                }
                                return item;
                            });
                        case "oldest":
                            return db.SanPhams.OrderBy(s => s.createdAt).Where(item => size == "all" ? item.price > priceBigger && (item.type == type || item.type == "all") : item.size.Contains(size) && item.price > priceBigger && (item.type == type || item.type == "all")).ToList().Select(item => {
                                if (item.comparePrice > 0 && item.comparePrice != null)
                                {
                                    double gia = (double)(100 - item.price / item.comparePrice * 100);
                                    item.promotion = Math.Round(gia, 0).ToString();
                                }
                                return item;
                            });
                        case "newest":
                            return db.SanPhams.OrderByDescending(s => s.createdAt).Where(item => size == "all" ? item.price > priceBigger && (item.type == type || item.type == "all") : item.size.Contains(size) && item.price > priceBigger && (item.type == type || item.type == "all")).ToList().Select(item => {
                                if (item.comparePrice > 0 && item.comparePrice != null)
                                {
                                    double gia = (double)(100 - item.price / item.comparePrice * 100);
                                    item.promotion = Math.Round(gia, 0).ToString();
                                }
                                return item;
                            });
                        case "soldest":
                            return db.SanPhams.OrderByDescending(s => s.quantitySold).Where(item => size == "all" ? item.price > priceBigger && (item.type == type || item.type == "all") : item.size.Contains(size) && item.price > priceBigger && (item.type == type || item.type == "all")).ToList().Select(item => {
                                if (item.comparePrice > 0 && item.comparePrice != null)
                                {
                                    double gia = (double)(100 - item.price / item.comparePrice * 100);
                                    item.promotion = Math.Round(gia, 0).ToString();
                                }
                                return item;
                            });
                        default:
                            return db.SanPhams.OrderByDescending(s => s.createdAt).Where(item => size == "all" ? item.price > priceBigger && (item.type == type || item.type == "all") : item.size.Contains(size) && item.price > priceBigger && (item.type == type || item.type == "all")).ToList().Select(item => {
                                if (item.comparePrice > 0 && item.comparePrice != null)
                                {
                                    double gia = (double)(100 - item.price / item.comparePrice * 100);
                                    item.promotion = Math.Round(gia, 0).ToString();
                                }
                                return item;
                            });
                    }
                default:
                    string[] price = filterPrice.Split('-');
                    int start = Convert.ToInt32(price[0]);
                    int end = Convert.ToInt32(price[1]);
                    switch (sortOrder)
                    {
                        case "name_desc":
                            return db.SanPhams.OrderByDescending(s => s.spName).Where(item => size == "all" ? item.price >= start && item.price <= end && (item.type == type || item.type == "all") : item.size.Contains(size) && item.price >= start && item.price <= end && (item.type == type || item.type == "all")).ToList().Select(item => {
                                if (item.comparePrice > 0 && item.comparePrice != null)
                                {
                                    double gia = (double)(100 - item.price / item.comparePrice * 100);
                                    item.promotion = Math.Round(gia, 0).ToString();
                                }
                                return item;
                            });
                        case "name_asc":
                            return db.SanPhams.OrderBy(s => s.spName).Where(item => size == "all" ? item.price >= start && item.price <= end && (item.type == type || item.type == "all") : item.size.Contains(size) && item.price >= start && item.price <= end && (item.type == type || item.type == "all")).ToList().Select(item => {
                                if (item.comparePrice > 0 && item.comparePrice != null)
                                {
                                    double gia = (double)(100 - item.price / item.comparePrice * 100);
                                    item.promotion = Math.Round(gia, 0).ToString();
                                }
                                return item;
                            });
                        case "price_asc":
                            return db.SanPhams.OrderBy(s => s.price).Where(item => size == "all" ? item.price >= start && item.price <= end && (item.type == type || item.type == "all") : item.size.Contains(size) && item.price >= start && item.price <= end && (item.type == type || item.type == "all")).ToList().Select(item => {
                                if (item.comparePrice > 0 && item.comparePrice != null)
                                {
                                    double gia = (double)(100 - item.price / item.comparePrice * 100);
                                    item.promotion = Math.Round(gia, 0).ToString();
                                }
                                return item;
                            });
                        case "price_desc":
                            return db.SanPhams.OrderByDescending(s => s.price).Where(item => size == "all" ? item.price >= start && item.price <= end && (item.type == type || item.type == "all") : item.size.Contains(size) && item.price >= start && item.price <= end && (item.type == type || item.type == "all")).ToList().Select(item => {
                                if (item.comparePrice > 0 && item.comparePrice != null)
                                {
                                    double gia = (double)(100 - item.price / item.comparePrice * 100);
                                    item.promotion = Math.Round(gia, 0).ToString();
                                }
                                return item;
                            });
                        case "oldest":
                            return db.SanPhams.OrderBy(s => s.createdAt).Where(item => size == "all" ? item.price >= start && item.price <= end && (item.type == type || item.type == "all") : item.size.Contains(size) && item.price >= start && item.price <= end && (item.type == type || item.type == "all")).ToList().Select(item => {
                                if (item.comparePrice > 0 && item.comparePrice != null)
                                {
                                    double gia = (double)(100 - item.price / item.comparePrice * 100);
                                    item.promotion = Math.Round(gia, 0).ToString();
                                }
                                return item;
                            });
                        case "newest":
                            return db.SanPhams.OrderByDescending(s => s.createdAt).Where(item => size == "all" ? item.price >= start && item.price <= end && (item.type == type || item.type == "all") : item.size.Contains(size) && item.price >= start && item.price <= end && (item.type == type || item.type == "all")).ToList().Select(item => {
                                if (item.comparePrice > 0 && item.comparePrice != null)
                                {
                                    double gia = (double)(100 - item.price / item.comparePrice * 100);
                                    item.promotion = Math.Round(gia, 0).ToString();
                                }
                                return item;
                            });
                        case "soldest":
                            return db.SanPhams.OrderByDescending(s => s.quantitySold).Where(item => size == "all" ? item.price >= start && item.price <= end && (item.type == type || item.type == "all") : item.size.Contains(size) && item.price >= start && item.price <= end && (item.type == type || item.type == "all")).ToList().Select(item => {
                                if (item.comparePrice > 0 && item.comparePrice != null)
                                {
                                    double gia = (double)(100 - item.price / item.comparePrice * 100);
                                    item.promotion = Math.Round(gia, 0).ToString();
                                }
                                return item;
                            });
                        default:
                            return db.SanPhams.OrderByDescending(s => s.createdAt).Where(item => size == "all" ? item.price >= start && item.price <= end && (item.type == type || item.type == "all") : item.size.Contains(size) && item.price >= start && item.price <= end && (item.type == type || item.type == "all")).ToList().Select(item => {
                                if (item.comparePrice > 0 && item.comparePrice != null)
                                {
                                    double gia = (double)(100 - item.price / item.comparePrice * 100);
                                    item.promotion = Math.Round(gia, 0).ToString();
                                }
                                return item;
                            });
                    }
            }
        }
        public IEnumerable<SanPham> getSlideBaseProductId(string size, string filterPrice, string filterType, string sortOrder)
        {
            return this.getSlideBaseProductId(size, filterPrice, filterType, sortOrder, "male");
        }

        public IEnumerable<SanPham> getProductsFemale(string size, string filterPrice, string filterType, string sortOrder)
        {
            return this.getSlideBaseProductId(size, filterPrice, filterType, sortOrder, "female");
        }

        public IEnumerable<SanPham> GetProductsBaseCategoryId(int categoryId, string type, string filterPrice, string filterType, string size, string sortOrder)
        {
            switch (filterType)
            {
                case "all":
                    switch (sortOrder)
                    {
                        case "name_desc":
                            return db.SanPhams.OrderByDescending(s => s.spName).Where(item => size == "all" ? item.categoryId == categoryId && (item.type == type || item.type == "all") : item.size.Contains(size) && item.categoryId == categoryId && (item.type == type || item.type == "all")).ToList().Select(item => {
                                if (item.comparePrice > 0 && item.comparePrice != null)
                                {
                                    double gia = (double)(100 - item.price / item.comparePrice * 100);
                                    item.promotion = Math.Round(gia, 0).ToString();
                                }
                                return item;
                            });
                        case "name_asc":
                            return db.SanPhams.OrderBy(s => s.spName).Where(item => size == "all" ? item.categoryId == categoryId && (item.type == type || item.type == "all") : item.size.Contains(size) && item.categoryId == categoryId && (item.type == type || item.type == "all")).ToList().Select(item => {
                                if (item.comparePrice > 0 && item.comparePrice != null)
                                {
                                    double gia = (double)(100 - item.price / item.comparePrice * 100);
                                    item.promotion = Math.Round(gia, 0).ToString();
                                }
                                return item;
                            });
                        case "price_asc":
                            return db.SanPhams.OrderBy(s => s.price).Where(item => size == "all" ? item.categoryId == categoryId && (item.type == type || item.type == "all") : item.size.Contains(size) && item.categoryId == categoryId && (item.type == type || item.type == "all")).ToList().Select(item => {
                                if (item.comparePrice > 0 && item.comparePrice != null)
                                {
                                    double gia = (double)(100 - item.price / item.comparePrice * 100);
                                    item.promotion = Math.Round(gia, 0).ToString();
                                }
                                return item;
                            });
                        case "price_desc":
                            return db.SanPhams.OrderByDescending(s => s.price).Where(item => size == "all" ? item.categoryId == categoryId && (item.type == type || item.type == "all") : item.size.Contains(size) && item.categoryId == categoryId && (item.type == type || item.type == "all")).ToList().Select(item => {
                                if (item.comparePrice > 0 && item.comparePrice != null)
                                {
                                    double gia = (double)(100 - item.price / item.comparePrice * 100);
                                    item.promotion = Math.Round(gia, 0).ToString();
                                }
                                return item;
                            });
                        case "oldest":
                            return db.SanPhams.OrderBy(s => s.createdAt).Where(item => size == "all" ? item.categoryId == categoryId && (item.type == type || item.type == "all") : item.size.Contains(size) && item.categoryId == categoryId && (item.type == type || item.type == "all")).ToList().Select(item => {
                                if (item.comparePrice > 0 && item.comparePrice != null)
                                {
                                    double gia = (double)(100 - item.price / item.comparePrice * 100);
                                    item.promotion = Math.Round(gia, 0).ToString();
                                }
                                return item;
                            });
                        case "newest":
                            return db.SanPhams.OrderByDescending(s => s.createdAt).Where(item => size == "all" ? item.categoryId == categoryId && (item.type == type || item.type == "all") : item.size.Contains(size) && item.categoryId == categoryId && (item.type == type || item.type == "all")).ToList().Select(item => {
                                if (item.comparePrice > 0 && item.comparePrice != null)
                                {
                                    double gia = (double)(100 - item.price / item.comparePrice * 100);
                                    item.promotion = Math.Round(gia, 0).ToString();
                                }
                                return item;
                            });
                        case "soldest":
                            return db.SanPhams.OrderByDescending(s => s.quantitySold).Where(item => size == "all" ? item.categoryId == categoryId && (item.type == type || item.type == "all") : item.size.Contains(size) && item.categoryId == categoryId && (item.type == type || item.type == "all")).ToList().Select(item => {
                                if (item.comparePrice > 0 && item.comparePrice != null)
                                {
                                    double gia = (double)(100 - item.price / item.comparePrice * 100);
                                    item.promotion = Math.Round(gia, 0).ToString();
                                }
                                return item;
                            });
                        default:
                            return db.SanPhams.OrderByDescending(s => s.createdAt).Where(item => size == "all" ? item.categoryId == categoryId && (item.type == type || item.type == "all") : item.size.Contains(size) && item.categoryId == categoryId && (item.type == type || item.type == "all")).ToList().Select(item => {
                                if (item.comparePrice > 0 && item.comparePrice != null)
                                {
                                    double gia = (double)(100 - item.price / item.comparePrice * 100);
                                    item.promotion = Math.Round(gia, 0).ToString();
                                }
                                return item;
                            });
                    }
                case "lesser":
                    int priceLesser = Convert.ToInt32(filterPrice);
                    switch (sortOrder)
                    {
                        case "name_desc":
                            return db.SanPhams.OrderByDescending(s => s.spName).Where(item => size == "all" ? item.price < priceLesser && item.categoryId == categoryId && (item.type == type || item.type == "all") : item.size.Contains(size) && item.price < priceLesser && item.categoryId == categoryId && (item.type == type || item.type == "all")).ToList().Select(item => {
                                if (item.comparePrice > 0 && item.comparePrice != null)
                                {
                                    double gia = (double)(100 - item.price / item.comparePrice * 100);
                                    item.promotion = Math.Round(gia, 0).ToString();
                                }
                                return item;
                            });
                        case "name_asc":
                            return db.SanPhams.OrderBy(s => s.spName).Where(item => size == "all" ? item.price < priceLesser && item.categoryId == categoryId && (item.type == type || item.type == "all") : item.size.Contains(size) && item.price < priceLesser && item.categoryId == categoryId && (item.type == type || item.type == "all")).ToList().Select(item => {
                                if (item.comparePrice > 0 && item.comparePrice != null)
                                {
                                    double gia = (double)(100 - item.price / item.comparePrice * 100);
                                    item.promotion = Math.Round(gia, 0).ToString();
                                }
                                return item;
                            });
                        case "price_asc":
                            return db.SanPhams.OrderBy(s => s.price).Where(item => size == "all" ? item.price < priceLesser && item.categoryId == categoryId && (item.type == type || item.type == "all") : item.size.Contains(size) && item.price < priceLesser && item.categoryId == categoryId && (item.type == type || item.type == "all")).ToList().Select(item => {
                                if (item.comparePrice > 0 && item.comparePrice != null)
                                {
                                    double gia = (double)(100 - item.price / item.comparePrice * 100);
                                    item.promotion = Math.Round(gia, 0).ToString();
                                }
                                return item;
                            });
                        case "price_desc":
                            return db.SanPhams.OrderByDescending(s => s.price).Where(item => size == "all" ? item.price < priceLesser && item.categoryId == categoryId && (item.type == type || item.type == "all") : item.size.Contains(size) && item.price < priceLesser && item.categoryId == categoryId && (item.type == type || item.type == "all")).ToList().Select(item => {
                                if (item.comparePrice > 0 && item.comparePrice != null)
                                {
                                    double gia = (double)(100 - item.price / item.comparePrice * 100);
                                    item.promotion = Math.Round(gia, 0).ToString();
                                }
                                return item;
                            });
                        case "oldest":
                            return db.SanPhams.OrderBy(s => s.createdAt).Where(item => size == "all" ? item.price < priceLesser && item.categoryId == categoryId && (item.type == type || item.type == "all") : item.size.Contains(size) && item.price < priceLesser && item.categoryId == categoryId && (item.type == type || item.type == "all")).ToList().Select(item => {
                                if (item.comparePrice > 0 && item.comparePrice != null)
                                {
                                    double gia = (double)(100 - item.price / item.comparePrice * 100);
                                    item.promotion = Math.Round(gia, 0).ToString();
                                }
                                return item;
                            });
                        case "newest":
                            return db.SanPhams.OrderByDescending(s => s.createdAt).Where(item => size == "all" ? item.price < priceLesser && item.categoryId == categoryId && (item.type == type || item.type == "all") : item.size.Contains(size) && item.price < priceLesser && item.categoryId == categoryId && (item.type == type || item.type == "all")).ToList().Select(item => {
                                if (item.comparePrice > 0 && item.comparePrice != null)
                                {
                                    double gia = (double)(100 - item.price / item.comparePrice * 100);
                                    item.promotion = Math.Round(gia, 0).ToString();
                                }
                                return item;
                            });
                        case "soldest":
                            return db.SanPhams.OrderByDescending(s => s.quantitySold).Where(item => size == "all" ? item.price < priceLesser && item.categoryId == categoryId && (item.type == type || item.type == "all") : item.size.Contains(size) && item.price < priceLesser && item.categoryId == categoryId && (item.type == type || item.type == "all")).ToList().Select(item => {
                                if (item.comparePrice > 0 && item.comparePrice != null)
                                {
                                    double gia = (double)(100 - item.price / item.comparePrice * 100);
                                    item.promotion = Math.Round(gia, 0).ToString();
                                }
                                return item;
                            });
                        default:
                            return db.SanPhams.OrderByDescending(s => s.createdAt).Where(item => size == "all" ? item.price < priceLesser && item.categoryId == categoryId && (item.type == type || item.type == "all") : item.size.Contains(size) && item.price < priceLesser && item.categoryId == categoryId && (item.type == type || item.type == "all")).ToList().Select(item => {
                                if (item.comparePrice > 0 && item.comparePrice != null)
                                {
                                    double gia = (double)(100 - item.price / item.comparePrice * 100);
                                    item.promotion = Math.Round(gia, 0).ToString();
                                }
                                return item;
                            });
                    }

                case "bigger":
                    int priceBigger = Convert.ToInt32(filterPrice);
                    switch (sortOrder)
                    {
                        case "name_desc":
                            return db.SanPhams.OrderByDescending(s => s.spName).Where(item => size == "all" ? item.price > priceBigger && item.categoryId == categoryId && (item.type == type || item.type == "all") : item.size.Contains(size) && item.price > priceBigger && item.categoryId == categoryId && (item.type == type || item.type == "all")).ToList().Select(item => {
                                if (item.comparePrice > 0 && item.comparePrice != null)
                                {
                                    double gia = (double)(100 - item.price / item.comparePrice * 100);
                                    item.promotion = Math.Round(gia, 0).ToString();
                                }
                                return item;
                            });
                        case "name_asc":
                            return db.SanPhams.OrderBy(s => s.spName).Where(item => size == "all" ? item.price > priceBigger && item.categoryId == categoryId && (item.type == type || item.type == "all") : item.size.Contains(size) && item.price > priceBigger && item.categoryId == categoryId && (item.type == type || item.type == "all")).ToList().Select(item => {
                                if (item.comparePrice > 0 && item.comparePrice != null)
                                {
                                    double gia = (double)(100 - item.price / item.comparePrice * 100);
                                    item.promotion = Math.Round(gia, 0).ToString();
                                }
                                return item;
                            });
                        case "price_asc":
                            return db.SanPhams.OrderBy(s => s.price).Where(item => size == "all" ? item.price > priceBigger && item.categoryId == categoryId && (item.type == type || item.type == "all") : item.size.Contains(size) && item.price > priceBigger && item.categoryId == categoryId && (item.type == type || item.type == "all")).ToList().Select(item => {
                                if (item.comparePrice > 0 && item.comparePrice != null)
                                {
                                    double gia = (double)(100 - item.price / item.comparePrice * 100);
                                    item.promotion = Math.Round(gia, 0).ToString();
                                }
                                return item;
                            });
                        case "price_desc":
                            return db.SanPhams.OrderByDescending(s => s.price).Where(item => size == "all" ? item.price > priceBigger && item.categoryId == categoryId && (item.type == type || item.type == "all") : item.size.Contains(size) && item.price > priceBigger && item.categoryId == categoryId && (item.type == type || item.type == "all")).ToList().Select(item => {
                                if (item.comparePrice > 0 && item.comparePrice != null)
                                {
                                    double gia = (double)(100 - item.price / item.comparePrice * 100);
                                    item.promotion = Math.Round(gia, 0).ToString();
                                }
                                return item;
                            });
                        case "oldest":
                            return db.SanPhams.OrderBy(s => s.createdAt).Where(item => size == "all" ? item.price > priceBigger && item.categoryId == categoryId && (item.type == type || item.type == "all") : item.size.Contains(size) && item.price > priceBigger && item.categoryId == categoryId && (item.type == type || item.type == "all")).ToList().Select(item => {
                                if (item.comparePrice > 0 && item.comparePrice != null)
                                {
                                    double gia = (double)(100 - item.price / item.comparePrice * 100);
                                    item.promotion = Math.Round(gia, 0).ToString();
                                }
                                return item;
                            });
                        case "newest":
                            return db.SanPhams.OrderByDescending(s => s.createdAt).Where(item => size == "all" ? item.price > priceBigger && item.categoryId == categoryId && (item.type == type || item.type == "all") : item.size.Contains(size) && item.price > priceBigger && item.categoryId == categoryId && (item.type == type || item.type == "all")).ToList().Select(item => {
                                if (item.comparePrice > 0 && item.comparePrice != null)
                                {
                                    double gia = (double)(100 - item.price / item.comparePrice * 100);
                                    item.promotion = Math.Round(gia, 0).ToString();
                                }
                                return item;
                            });
                        case "soldest":
                            return db.SanPhams.OrderByDescending(s => s.quantitySold).Where(item => size == "all" ? item.price > priceBigger && item.categoryId == categoryId && (item.type == type || item.type == "all") : item.size.Contains(size) && item.price > priceBigger && item.categoryId == categoryId && (item.type == type || item.type == "all")).ToList().Select(item => {
                                if (item.comparePrice > 0 && item.comparePrice != null)
                                {
                                    double gia = (double)(100 - item.price / item.comparePrice * 100);
                                    item.promotion = Math.Round(gia, 0).ToString();
                                }
                                return item;
                            });
                        default:
                            return db.SanPhams.OrderByDescending(s => s.createdAt).Where(item => size == "all" ? item.price > priceBigger && item.categoryId == categoryId && (item.type == type || item.type == "all") : item.size.Contains(size) && item.price > priceBigger && item.categoryId == categoryId && (item.type == type || item.type == "all")).ToList().Select(item => {
                                if (item.comparePrice > 0 && item.comparePrice != null)
                                {
                                    double gia = (double)(100 - item.price / item.comparePrice * 100);
                                    item.promotion = Math.Round(gia, 0).ToString();
                                }
                                return item;
                            });

                    }
                default:
                    string[] price = filterPrice.Split('-');
                    int start = Convert.ToInt32(price[0]);
                    int end = Convert.ToInt32(price[1]);
                    switch (sortOrder)
                    {
                        case "name_desc":
                            return db.SanPhams.OrderByDescending(s => s.spName).Where(item => size == "all" ? item.price >= start && item.price <= end && item.categoryId == categoryId && (item.type == type || item.type == "all") : item.size.Contains(size) && item.price >= start && item.price <= end && item.categoryId == categoryId && (item.type == type || item.type == "all")).ToList().Select(item => {
                                if (item.comparePrice > 0 && item.comparePrice != null)
                                {
                                    double gia = (double)(100 - item.price / item.comparePrice * 100);
                                    item.promotion = Math.Round(gia, 0).ToString();
                                }
                                return item;
                            });
                        case "name_asc":
                            return db.SanPhams.OrderBy(s => s.spName).Where(item => size == "all" ? item.price >= start && item.price <= end && item.categoryId == categoryId && (item.type == type || item.type == "all") : item.size.Contains(size) && item.price >= start && item.price <= end && item.categoryId == categoryId && (item.type == type || item.type == "all")).ToList().Select(item => {
                                if (item.comparePrice > 0 && item.comparePrice != null)
                                {
                                    double gia = (double)(100 - item.price / item.comparePrice * 100);
                                    item.promotion = Math.Round(gia, 0).ToString();
                                }
                                return item;
                            });
                        case "price_asc":
                            return db.SanPhams.OrderBy(s => s.price).Where(item => size == "all" ? item.price >= start && item.price <= end && item.categoryId == categoryId && (item.type == type || item.type == "all") : item.size.Contains(size) && item.price >= start && item.price <= end && item.categoryId == categoryId && (item.type == type || item.type == "all")).ToList().Select(item => {
                                if (item.comparePrice > 0 && item.comparePrice != null)
                                {
                                    double gia = (double)(100 - item.price / item.comparePrice * 100);
                                    item.promotion = Math.Round(gia, 0).ToString();
                                }
                                return item;
                            });
                        case "price_desc":
                            return db.SanPhams.OrderByDescending(s => s.price).Where(item => size == "all" ? item.price >= start && item.price <= end && item.categoryId == categoryId && (item.type == type || item.type == "all") : item.size.Contains(size) && item.price >= start && item.price <= end && item.categoryId == categoryId && (item.type == type || item.type == "all")).ToList().Select(item => {
                                if (item.comparePrice > 0 && item.comparePrice != null)
                                {
                                    double gia = (double)(100 - item.price / item.comparePrice * 100);
                                    item.promotion = Math.Round(gia, 0).ToString();
                                }
                                return item;
                            });
                        case "oldest":
                            return db.SanPhams.OrderBy(s => s.createdAt).Where(item => size == "all" ? item.price >= start && item.price <= end && item.categoryId == categoryId && (item.type == type || item.type == "all") : item.size.Contains(size) && item.price >= start && item.price <= end && item.categoryId == categoryId && (item.type == type || item.type == "all")).ToList().Select(item => {
                                if (item.comparePrice > 0 && item.comparePrice != null)
                                {
                                    double gia = (double)(100 - item.price / item.comparePrice * 100);
                                    item.promotion = Math.Round(gia, 0).ToString();
                                }
                                return item;
                            });
                        case "newest":
                            return db.SanPhams.OrderByDescending(s => s.createdAt).Where(item => size == "all" ? item.price >= start && item.price <= end && item.categoryId == categoryId && (item.type == type || item.type == "all") : item.size.Contains(size) && item.price >= start && item.price <= end && item.categoryId == categoryId && (item.type == type || item.type == "all")).ToList().Select(item => {
                                if (item.comparePrice > 0 && item.comparePrice != null)
                                {
                                    double gia = (double)(100 - item.price / item.comparePrice * 100);
                                    item.promotion = Math.Round(gia, 0).ToString();
                                }
                                return item;
                            });
                        case "soldest":
                            return db.SanPhams.OrderByDescending(s => s.quantitySold).Where(item => size == "all" ? item.price >= start && item.price <= end && item.categoryId == categoryId && (item.type == type || item.type == "all") : item.size.Contains(size) && item.price >= start && item.price <= end && item.categoryId == categoryId && (item.type == type || item.type == "all")).ToList().Select(item => {
                                if (item.comparePrice > 0 && item.comparePrice != null)
                                {
                                    double gia = (double)(100 - item.price / item.comparePrice * 100);
                                    item.promotion = Math.Round(gia, 0).ToString();
                                }
                                return item;
                            });
                        default:
                            return db.SanPhams.OrderByDescending(s => s.createdAt).Where(item => size == "all" ? item.price >= start && item.price <= end && item.categoryId == categoryId && (item.type == type || item.type == "all") : item.size.Contains(size) && item.price >= start && item.price <= end && item.categoryId == categoryId && (item.type == type || item.type == "all")).ToList().Select(item => {
                                if (item.comparePrice > 0 && item.comparePrice != null)
                                {
                                    double gia = (double)(100 - item.price / item.comparePrice * 100);
                                    item.promotion = Math.Round(gia, 0).ToString();
                                }
                                return item;
                            });
                    }
            }
        }

        public SanPham getShoeById(int id)
        {
            return db.SanPhams.Find(id);
        }

        public int add(SanPham g)
        {
            try
            {
                g.createdAt = DateTime.Now;
                g.status = g.inventory == null || g.inventory == 0 ? false : true;
                g.isDeleted = false;
                g.isActive = false;
                db.SanPhams.Add(g);
                db.SaveChanges();
                return g.spId;
            }
            catch (Exception)
            {

                return -1;
            }
        }

        public bool edit(SanPham g, bool isDeleted)
        {
            try
            {
                var SanPham = db.SanPhams.Find(g.spId);
                if (g.image != null)
                {
                    SanPham.image = g.image;
                }
                SanPham.spName = g.spName;
                SanPham.categoryId = g.categoryId;
                SanPham.color = g.color;
                SanPham.minifyDate = DateTime.Now;
                SanPham.material = g.material;
                SanPham.inventory = g.inventory;
                SanPham.price = g.price;
                SanPham.quantitySold = g.quantitySold;
                SanPham.size = g.size;
                SanPham.type = g.type;
                SanPham.isDeleted = isDeleted;
                SanPham.warranty = g.warranty;
                SanPham.description = g.description;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool remove(int id)
        {
            try
            {
                SanPham g = new SanPham() { spId = id };
                db.SanPhams.Attach(g);
                db.SanPhams.Remove(g);
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