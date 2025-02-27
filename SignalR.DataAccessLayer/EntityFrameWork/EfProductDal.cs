﻿using Microsoft.EntityFrameworkCore;
using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repository;
using SignalR.EntiyLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.EntityFramework
{
    public class EfProductDal : GenericRepository<Product>, IProductDal
    {

        public EfProductDal(Context context) : base(context)
        {

        }

        public List<Product> GetLast9Products()
        {
            var context = new Context();
            var values = context.Products.Take(9).ToList();
            return values;
        }

        public List<Product> GetProductsWithCategories()
        {
            var context = new Context();
            var values = context.Products.Include(x => x.Category).ToList();
            return values;
        }

        public decimal ProductAvgPriceByHamburger()
        {
            using var context = new Context();
            return context.Products.Where(x => x.CategoryID == (context.Categories.Where(y => y.CategoryName == "Burger").Select(z => z.CategoryID)).FirstOrDefault()).Average(w => w.Price);
         

            //return context.Products.Average(x=>x.Price(context.Products.Where(y=>y.ProductName=="Burger")));
        }

        public int ProductCount()
        {
            var context = new Context();
            return context.Products.Count();

        }

        public int ProductCountByCategoryNameDrink()
        {
            using var context = new Context();
            return context.Products.Where(x => x.CategoryID == (context.Categories.Where(y => y.CategoryName == "İçecek").Select(z => z.CategoryID).FirstOrDefault())).Count();
        }

        public int ProductCountByCategoryNameHamburger()
        {
            using var context = new Context();
            return context.Products.Where(x => x.CategoryID == (context.Categories.Where(y => y.CategoryName == "Burger").Select(z => z.CategoryID).FirstOrDefault())).Count();
        }

        public string ProductNameByMaxPrice()
        {
            using var context = new Context();
            return context.Products.Where(x => x.Price == (context.Products.Max(y => y.Price))).Select(z => z.ProductName).FirstOrDefault();
        }

        public string ProductNameByMinPrice()
        {
            using var context = new Context();

            return context.Products.Where(x => x.Price == (context.Products.Min(y => y.Price))).Select(z => z.ProductName).FirstOrDefault();
        }


        public decimal ProductPriceAvg()
        {
            using var context = new Context();
            return context.Products.Average(x => x.Price);
        }

        public decimal ProductPriceBySteakBurger()
        {
           using var context=new Context();
            return context.Products.Where(x => x.ProductName == "Steak Burger").Select(y=>y.Price).FirstOrDefault();
        }

        public decimal TotalPriceByDrinkCategory()
        {
            using var context = new Context();
            int id=context.Categories.Where(x=>x.CategoryName=="İçecek").Select(y=>y.CategoryID).FirstOrDefault();
            return context.Products.Where(x => x.CategoryID == id).Sum(y => y.Price);
        }

        public decimal TotalPriceBySaladCategory()
        {
            using var context = new Context();
            int id= context.Categories.Where(x=>x.CategoryName== "Salata").Select(y=>y.CategoryID).FirstOrDefault();
            return context.Products.Where(x=>x.CategoryID==id).Sum(y=>y.Price);

        }
    }
}
