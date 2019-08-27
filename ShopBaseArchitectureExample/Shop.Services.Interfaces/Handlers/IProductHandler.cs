using Shop.Services.Interfaces.Requests;
using Shop.Services.Interfaces.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Services.Interfaces.Handlers
{
    public interface IProductHandler
    {
        IEnumerable<RegisteredProduct> GetProductByCategoryId(int categoryId);
        IEnumerable<RegisteredCategory> GetAllCategories();
        RegisteredProduct RegisterProduct(CreateProducto newProducto);
        IEnumerable<RegisteredProduct> GetAllProducts();
    }
}
