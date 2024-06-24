using Instruments.Domain.Entities;
using Instruments.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shiyan.UI.Controllers;
using Shiyan.UI.Services.CategoryService;
using Shiyan.UI.Services.InstrumentsService;

namespace Shiyan.Tests
{
    public class ProductControllerTests
    {
        IProductService _instrumentsService;
        ICategoryService _categoryService;
        public ProductControllerTests()
        {
            SetupData();
        }
        // Список категорий сохраняется во ViewData
        [Fact]
        public async void IndexPutsCategoriesToViewData()
        {
            //arrange
            var controller = new ProductController(_categoryService, _instrumentsService);
            //act
            var response = await controller.Index(null);
            //assert
            var view = Assert.IsType<ViewResult>(response);
            var categories = Assert.IsType<List<Category>>(view.ViewData["categories"]);
            Assert.Equal(6, categories.Count);
            Assert.Equal("Все", view.ViewData["currentCategory"]);
        }
        // Имя текущей категории сохраняется во ViewData
        [Fact]
        public async void IndexSetsCorrectCurrentCategory()
        {
            //arrange
            var categories = await _categoryService.GetCategoryListAsync();
            var currentCategory = categories.Data[0];
            var controller = new ProductController(_categoryService, _instrumentsService);
            //act
            var response = await controller.Index(currentCategory.NormalizedName);
            //assert
            var view = Assert.IsType<ViewResult>(response);
            Assert.Equal(currentCategory.Name, view.ViewData["currentCategory"]);
        }
        // В случае ошибки возвращается NotFoundObjectResult
        [Fact]
        public async void IndexReturnsNotFound()
        {
            //arrange
            string errorMessage = "Test error";
            var categoriesResponse = new ResponseData<List<Category>>();
            categoriesResponse.Success = false;
            categoriesResponse.ErrorMessage = errorMessage;
            _categoryService.GetCategoryListAsync().Returns(Task.FromResult(categoriesResponse))
            ;
            var controller = new ProductController(_categoryService, _instrumentsService);
            //act
            var response = await controller.Index(null);
            //assert
            var result = Assert.IsType<NotFoundObjectResult>(response);
            Assert.Equal(errorMessage, result.Value.ToString());
        }
        // Настройка имитации ICategoryService и IProductService
        void SetupData()
        {
            _categoryService = Substitute.For<ICategoryService>();
            var categoriesResponse = new ResponseData<List<Category>>();
            categoriesResponse.Data = new List<Category>
            {
                new Category {Id=1, Name="Электроинструменты",NormalizedName="powerTools"},
                new Category {Id=2, Name="Ручной инструмент",NormalizedName="handTools"},
                new Category {Id=3, Name="Измерительный инструмент",NormalizedName="measuringTools"},
                new Category {Id=4, Name="Хозяйственный инструмент",NormalizedName="householdTools"},
            };
            _categoryService.GetCategoryListAsync().Returns(Task.FromResult(categoriesResponse))
            ;
            _instrumentsService = Substitute.For<IProductService>();
            var instruments = new List<Instrument>
            {
                new Instrument { Id = 1 },
                new Instrument { Id = 2 },
                new Instrument { Id = 3 },
                new Instrument { Id = 4 },

            };
            var productResponse = new ResponseData<ProductListModel<Instrument>>();
            productResponse.Data = new ProductListModel<Instrument> { Items = instruments };
            _instrumentsService.GetInstrumentListAsync(Arg.Any<string?>(), Arg.Any<int>())
            .Returns(productResponse);
        }
    }
}
