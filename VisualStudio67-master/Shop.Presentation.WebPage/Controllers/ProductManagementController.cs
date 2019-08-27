﻿using Shop.Presentation.WebPage.Filtros;
using Shop.Services.implementation;
using Shop.Services.Interfaces.Handlers;
using Shop.Services.Interfaces.Requests;
using Shop.Services.Interfaces.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Shop.Presentation.WebPage.Controllers
{
    [FiltroDeExcepciones]
    public class ProductManagementController : ApiController
    {

        IProductHandler _productHandler = new EFProductHandler();

        [HttpGet]
        public IEnumerable<RegisteredCategory> GetAllCategories()
        {
            return this._productHandler.GetAllCategories();
        }

        [HttpGet]
        public IEnumerable<RegisteredProduct> GetProductByCategoryId(int categoryId)
        {
            return this._productHandler.GetProductByCategoryId(categoryId);
        }

        [HttpPost]
        public RegisteredProduct RegisterProduct(CreateProducto newProducto)
        {
            return this._productHandler.RegisterProduct(newProducto);
        }

        [HttpGet] 
        public IEnumerable<RegisteredProduct> GetAllProducts()
        {
            return this._productHandler.GetAllProducts();
        }
    }
}
