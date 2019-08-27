using Shop.Domain.Entities;
using Shop.Infrastructure.EFDataContext;
using Shop.Services.Interfaces.Handlers;
using Shop.Services.Interfaces.Requests;
using Shop.Services.Interfaces.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Services.implementation
{
    public class EFProductHandler : IProductHandler
    {
        public IEnumerable<RegisteredCategory> GetAllCategories()
        {
            using (var db = new ShopDb())
            {
                return db.Categories.ToList().Select(x => new RegisteredCategory
                {
                    Id = x.Id,
                    Description = x.Description,
                    Name = x.Name
                });
            }
        }

        public IEnumerable<RegisteredProduct> GetProductByCategoryId(int categoryId)
        {
            using (var db = new ShopDb())
            {
                return db.Products
                         .Include("Category")
                         .Where(x=>x.CategoryId.Equals(categoryId))
                         .ToList()
                         .Select(x => new RegisteredProduct
                            {
                                Id = x.Id,
                                Description = x.Descripcion,
                                Name = x.Name,
                                CategoryName = x.Category.Name
                            });
            }
        }

        public RegisteredProduct RegisterProduct(CreateProducto newProducto)
        {
            var product = new Product()
            {
                CategoryId = newProducto.CategoryId,
                Name = newProducto.Name,
                Descripcion = newProducto.Descripcion
            };
            using (var db = new ShopDb())
            {
                db.Products.Add(product);
                db.SaveChanges();
                return new RegisteredProduct()
                {
                    Id = product.Id,
                    CategoryName = db.Categories.Find(product.CategoryId).Name,
                    Description = product.Descripcion,
                    Name = product.Name
                };
            }
        }
    }
}
