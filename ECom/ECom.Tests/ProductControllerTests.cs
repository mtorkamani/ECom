using ECom.API.Controllers;
using ECom.Common;
using ECom.Common.Services;
using ECom.Tests.Doubles;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace ECom.Tests
{
    public class ProductControllerTests
    {
        [Theory]
        [ClassData(typeof(ProductTestData))]
        public void SortShouldReturnSortedProductsAccordingly(SortOption sortOption, IEnumerable<Product> expected)
        {
            var productProxy = new Mock<IProductProxy>();
            productProxy.Setup(ps => ps.GetProductsAsync())
                .Returns(Task.FromResult(ProductTestData.products.AsEnumerable()));

            var shopperHistoryProxy = new Mock<IShopperHistoryProxy>();
            shopperHistoryProxy.Setup(ps => ps.GetShopperHistoryAsync())
                .Returns(Task.FromResult(ProductTestData.shopperHistory));

            var productService = new ProductService(
                productProxy.Object, 
                shopperHistoryProxy.Object, 
                new ShopperHistoryAnalyzer());

            var userCtrl = new ProductController(productService);
            var result = userCtrl.Sort(sortOption).Result;

            var okResult = Assert.IsType<OkObjectResult>(result);
            var sortedProducts = Assert.IsAssignableFrom<IEnumerable<Product>>(okResult.Value);
            Assert.Equal(expected.ToList(), sortedProducts.ToList());
        }


    }
}
