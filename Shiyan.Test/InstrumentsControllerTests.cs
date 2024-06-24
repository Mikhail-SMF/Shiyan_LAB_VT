using Instruments.Domain.Entities;
using Instruments.Domain.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shiyan.API.Controllers;
using Shiyan.API.Data;

namespace Shiyan.Tests
{
    public class InstrumentsControllerTests : IDisposable
    {
        private readonly DbConnection _connection;
        private readonly DbContextOptions<AppDbContext> _contextOptions;
        private readonly IWebHostEnvironment _environment;
        public InstrumentsControllerTests()
        {
            _environment = Substitute.For<IWebHostEnvironment>();
            // Create and open a connection. This creates the SQLite in-memory database, which will persist until the connection is closed
            // at the end of the test (see Dispose below).
            _connection = new SqliteConnection("Filename=:memory:");
            _connection.Open();
            // These options will be used by the context instances in this test suite,including the connection opened above.
            _contextOptions = new DbContextOptionsBuilder<AppDbContext>()
            .UseSqlServer(_connection)
            .Options;
            // Create the schema and seed some data
            using var context = new AppDbContext(_contextOptions);
            context.Database.EnsureCreated();
            var categories = new Category[]
            {
                new Category {Name="",NormalizedName="powerTools"},
                new Category {Name="",NormalizedName="handTools"},
                new Category {Name="",NormalizedName="measuringTools"},
                new Category {Name="",NormalizedName="householdTools"},
            };
            context.Categories.AddRange(categories);
            context.SaveChanges();
            var instruments = new List<Instrument>
            {
                new Instrument {Name="", Description="", Price=0, Category=categories.FirstOrDefault(c=>c.NormalizedName.Equals("powerTools"))},
                new Instrument {Name = "", Description="", Price=0, Category=categories.FirstOrDefault(c=>c.NormalizedName.Equals("handTools"))},
                new Instrument {Name = "", Description="", Price=0,Category=categories.FirstOrDefault(c=>c.NormalizedName.Equals("measuringTools"))},
                new Instrument {Name = "", Description="", Price=0,Category=categories.FirstOrDefault(c=>c.NormalizedName.Equals("householdTools"))},
            };
            context.AddRange(instruments);
            context.SaveChanges();
        }
        public void Dispose() => _connection?.Dispose();
        AppDbContext CreateContext() => new AppDbContext(_contextOptions);
        // Проверка фильтра по категории
        [Fact]
        public async void ControllerFiltersCategory()
        {
            // arrange
            using var context = CreateContext();
            var category = context.Categories.First();
            var controller = new InstrumentsController(context, _environment);
            // act
            var response = await controller.GetInstrument(category.NormalizedName);
            ResponseData<ProductListModel<Instrument>> responseData = response.Value;
            var flowersList = responseData.Data.Items; // полученный список объектов
                                                       //assert
            Assert.True(flowersList.All(d => d.CategoryId == category.Id));
        }
        // Проверка подсчета количества страниц
        // Первый параметр - размер страницы
        // Второй параметр - ожидаемое количество страниц (при условии, что всего объектов 5)
        [Theory]
        [InlineData(2, 3)]
        [InlineData(3, 2)]
        public async void ControllerReturnsCorrectPagesCount(int size, int qty)
        {
            using var context = CreateContext();
            var controller = new InstrumentsController(context, _environment);
            // act
            var response = await controller.GetInstrument(null, 1, size);
            ResponseData<ProductListModel<Instrument>> responseData = response.Value;
            var totalPages = responseData.Data.TotalPages; // полученное количество страниц
            //assert
            Assert.Equal(qty, totalPages); // количество страниц совпадает
        }
        [Fact]
        public async void ControllerReturnsCorrectPage()
        {
            using var context = CreateContext();
            var controller = new InstrumentsController(context, _environment);
            // При размере страницы 3 и общем количестве объектов 5
            // на 2-й странице должно быть 2 объекта
            int itemsInPage = 2;
            // Первый объект на второй странице
            Instrument firstItem = context.Instruments.ToArray()[3];
            // act
            // Получить данные 2-й страницы
            var response = await controller.GetInstrument(null, 2);
            ResponseData<ProductListModel<Instrument>> responseData = response.Value;
            var instrumentsList = responseData.Data.Items; // полученный список объектов
            var currentPage = responseData.Data.CurrentPage; // полученный номер текущей страницы
            //assert
            Assert.Equal(2, currentPage);// номер страницы совпадает
            Assert.Equal(2, instrumentsList.Count); // количество объектов на странице равно 2
            Assert.Equal(firstItem.Id, instrumentsList[0].Id); // 1-й объект в списке правильный
        }
    }
}
