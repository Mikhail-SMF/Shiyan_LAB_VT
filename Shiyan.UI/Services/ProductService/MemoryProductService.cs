using Instruments.Domain.Entities;
using Instruments.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Shiyan.UI.Controllers;
using Shiyan.UI.Services.CategoryService;

namespace Shiyan.UI.Services.InstrumentsService
{
    public class MemoryProductService : IProductService
    {
        private readonly IConfiguration _config;
        List<Instrument> _instruments;
        List<Category> _categories;
        public MemoryProductService([FromServices] IConfiguration config, ICategoryService categoryService, int pageNo)
        {
            _categories = categoryService.GetCategoryListAsync().Result.Data;
            _config = config;
            SetupData();
        }

        /// <summary>
        /// Инициализация списков
        /// </summary>
        private void SetupData()
        {
            _instruments = new List<Instrument>
            {
                new Instrument{
                    Id = 1,
                    Name="Лобзик Makita 4329KX1",
                    Description="Мощность, Вт: 450\nМаксимальная глубина пропила (дерево), мм: 65\nМаксимальная глубина пропила (сталь), мм: 6\nЧисло ходов полотна в минуту: 500-3100 ход/мин\n",
                    Price =339, Image="Images/powerTools/Лобзик_Makita_4329KX1.jpg",
                    CategoryId=_categories.Find(c=>c.NormalizedName.Equals("powerTools")).Id
                },

                new Instrument{
                    Id = 2,
                    Name="Перфоратор Makita HR 2470 X15",
                    Description="Мощность, Вт: 780\nМаксимальное количество ударов в минуту: 4500\nCкорость вращения, об/мин: 1100\nМаксимальный диаметр сверления, бетон/металл/дерево мм: 24/13/32\n",
                    Price =636, Image="Images/powerTools/Перфоратор_Makita_HR_2470_X15.jpg",
                    CategoryId=_categories.Find(c=>c.NormalizedName.Equals("powerTools")).Id
                },

                new Instrument{
                    Id = 3,
                    Name="Отбойный молоток Bull SH 1501",
                    Description="Мощность, Вт: 1750\nМаксимальное количество ударов в минуту: 1600\nЭнергия удара, Дж: 45",
                    Price =2251, Image="Images/powerTools/Отбойный_молоток_Bull_SH_1501 jpg.jpg",
                    CategoryId=_categories.Find(c=>c.NormalizedName.Equals("powerTools")).Id
                },

                new Instrument{
                    Id = 4,
                    Name="Штроборез Einhell TC-MA 1300",
                    Description="Мощность, Вт: 1320\nДиаметр диска, мм: 125\nCкорость вращения, об/мин: 9000\nГлубина паза, мм: 30",
                    Price =614, Image="Images/powerTools/Штроборез_Einhell_TC-MA_1300.jpg",
                    CategoryId=_categories.Find(c=>c.NormalizedName.Equals("powerTools")).Id
                },

                new Instrument{
                    Id = 5,
                    Name="Одноручная углошлифмашина Bull WS 1207",
                    Description="Мощность, Вт: 1400\nДиаметр диска, мм: 125\nЧастота вращения, об/мин: 11000\nПосадочный диаметр, мм: 22,2",
                    Price =293, Image="Images/powerTools/Одноручная_углошлифмашина_Bull_WS_1207.png",
                    CategoryId=_categories.Find(c=>c.NormalizedName.Equals("powerTools")).Id
                },

                new Instrument
                {
                    Id = 6,
                    Name="Торцовочная пила Makita LS1040N",
                    Description="Мощность, Вт: 1650\nУгол наклона диска, градус: 45\nСкорость вращения, об/мин: 4600\nПосадочный диаметр, мм: 30",
                    Price =1484, Image="Images/powerTools/Одноручная_углошлифмашина_Bull_WS_1207.png",
                    CategoryId=_categories.Find(c=>c.NormalizedName.Equals("powerTools")).Id
                },

                new Instrument{
                    Id = 7,
                    Name="Молоток каменьщика Yato (YT-4573)",
                    Description="Материал: сталь\nНазначение: для разгонки поверхностей из толстого листового металла\nВес, кг:0.6",
                    Price =67, Image="Images/handTools/Молоток_каменьщика_Yato_(YT-4573).jpg",
                    CategoryId=_categories.Find(c=>c.NormalizedName.Equals("handTools")).Id
                },

                new Instrument{
                    Id = 8,
                    Name="Отвертка-держатель Hobbi 33-4-312",
                    Description="Длина бит, мм: 25\nНазначение:для крепежных работ\nКоличество в комплекте: 20",
                    Price =42, Image="Images/handTools/Отвертка-держатель_Hobbi_33-4-312.jpg",
                    CategoryId=_categories.Find(c=>c.NormalizedName.Equals("handTools")).Id
                },

                new Instrument{
                    Id = 9,
                    Name="Набор инструментов Forsage F-38841",
                    Description="Количество в комплекте: 216",
                    Price =372, Image="Images/handTools/Набор_инструментов_Forsage_F-38841.jpg",
                    CategoryId=_categories.Find(c=>c.NormalizedName.Equals("handTools")).Id
                },

                new Instrument{
                    Id = 10,
                    Name="Напильник Yato YT-6233",
                    Description="Назначение: по металлу\nМатериал: сталь\nФорма: тупоносая\nДлина, мм: 250",
                    Price =24, Image="Images/handTools/Напильник_Yato_YT-6233.jpg",
                    CategoryId=_categories.Find(c=>c.NormalizedName.Equals("handTools")).Id
                },

                new Instrument{
                    Id = 11,
                    Name="Пила по газобетону Hardax 42-2-207",
                    Description="Назначение: по газобетону\nМатериал ручки: пластик\nДлина лезвия, мм: 700",
                    Price =65, Image="Images/handTools/Пила_по_газобетону_Hardax_42-2-207.jpg",
                    CategoryId=_categories.Find(c=>c.NormalizedName.Equals("handTools")).Id
                },


                new Instrument{
                    Id = 12,
                    Name="Уровень Sola AZ 80",
                    Description="Количество ампул: 2\nДлина, см: 80",
                    Price =145, Image="Images/measuringTools/Уровень_Sola_AZ_80_(01160801).jpg",
                    CategoryId=_categories.Find(c=>c.NormalizedName.Equals("measuringTools")).Id
                },

                new Instrument{
                    Id = 13,
                    Name="Мультиметр цифровой Hoegert HT1E604",
                    Description="Диапазон напряжения постоянного/переменного,B: 0-600/0-600\nДиапазон тока постоянного/переменного, A: 10/10\nИзмерение: постоянного тока, переменного тока, постоянного напряжения, переменного напряжения",
                    Price =169, Image="Images/measuringTools/Мультиметр_цифровой_Hoegert_HT1E604.jpg",
                    CategoryId=_categories.Find(c=>c.NormalizedName.Equals("measuringTools")).Id
                },

                new Instrument{
                    Id = 14,
                    Name="Лазерный уровень Wortex LL 0335 D",
                    Description="Лазерный диод, нм: 635\nУгол развертки луча горизонтального/вертикального, гр: 360°/360°\nДальность, м: 30",
                    Price =648, Image="Images/measuringTools/Лазерный_уровень_Wortex_LL_0335_D.jpg",
                    CategoryId=_categories.Find(c=>c.NormalizedName.Equals("measuringTools")).Id
                },

                 new Instrument{
                    Id = 15,
                    Name="Угольник столярный Vorel 18200",
                    Description="Материал: сталь\nДлина, м: 0.6",
                    Price =15, Image="Images/measuringTools/Угольник_столярный_Vorel_18200.jpg",
                    CategoryId=_categories.Find(c=>c.NormalizedName.Equals("measuringTools")).Id
                },

                new Instrument{
                    Id = 16,
                    Name="Рулетка Yato YT-7105 (5 м)",
                    Description="Ширина мерного полотна, мм: 19\nДлина, м: 5",
                    Price =14, Image="Images/measuringTools/Рулетка_Yato_YT-7105_(5 м).jpg",
                    CategoryId=_categories.Find(c=>c.NormalizedName.Equals("measuringTools")).Id
                },

                new Instrument{
                    Id = 17,
                    Name="Шило Yato YT-1374",
                    Description="Материал: сталь\nДлина лезвия, мм: 120\nФорма: круглая",
                    Price =26, Image="Images/householdTools/Шило_Yato_YT-1374_(120).jpg",
                    CategoryId=_categories.Find(c=>c.NormalizedName.Equals("householdTools")).Id
                },

                new Instrument{
                    Id = 18,
                    Name="Ножницы Vorel 76312",
                    Description="Материал: сталь\nДлина лезвия, мм: 220",
                    Price =7, Image="Images/householdTools/Ножницы_Vorel_76312.jpg",
                    CategoryId=_categories.Find(c=>c.NormalizedName.Equals("householdTools")).Id
                },

                new Instrument{
                    Id = 19,
                    Name="Нож для напольных покрытий Hobbi 19-0-120",
                    Description="Материал: сталь\nФорма лезвия: круглая\nДлина/ширина, мм: 45/45\nДиаметр: выдвижной",
                    Price =20, Image="Images/householdTools/Нож_для_напольных_покрытий_Hobbi_19-0-120.jpg",
                    CategoryId=_categories.Find(c=>c.NormalizedName.Equals("householdTools")).Id
                },

                new Instrument{
                    Id = 20,
                    Name="Набор ножей для резьбы по дереву Hobbi 40-3-916",
                    Description="Материал: сталь\nНазначение: для резки дерева\nКоличество дополнительных лезвий, шт: 13",
                    Price =13, Image="Images/householdTools/Набор_ножей_для_резьбы_по_дереву_Hobbi_40-3-916.jpg",
                    CategoryId=_categories.Find(c=>c.NormalizedName.Equals("householdTools")).Id
                },

                new Instrument{
                    Id = 21,
                    Name="Нож Top Tools с отламывающимся лезвием 18 мм 17В191",
                    Description="Материал: сталь\nНазначение: для резки бумаги, для резки картона, для резки линолеума\nФорма: трапециевидная\nФорма лезвия: сегментированная",
                    Price =7, Image="Images/householdTools/Нож_Top_Tools_с_отламывающимся_лезвием_18_мм_17В191.jpg",
                    CategoryId=_categories.Find(c=>c.NormalizedName.Equals("householdTools")).Id
                },
            };
        }
        public Task<ResponseData<ProductListModel<Instrument>>> GetInstrumentListAsync(string? categoryNormalizedName, int pageNo = 1)
        {
            // Создать объект результата
            var result = new ResponseData<ProductListModel<Instrument>>();
            // Id категории для фильрации
            int? categoryId = null;
            // если требуется фильтрация, то найти Id категории
            // с заданным categoryNormalizedName
            if (categoryNormalizedName != null)
                categoryId = _categories.Find(c => c.NormalizedName.Equals(categoryNormalizedName))?.Id;
            // Выбрать объекты, отфильтрованные по Id категории,
            // если этот Id имеется
            var data = _instruments.Where(d => categoryId == null || d.CategoryId.Equals(categoryId))?.ToList();

            // получить размер страницы из конфигурации
            int pageSize = _config.GetSection("ItemsPerPage").Get<int>();
            // получить общее количество страниц
            int totalPages = (int)Math.Ceiling(data.Count / (double)pageSize);
            // получить данные страницы
            var listData = new ProductListModel<Instrument>()
            {
                Items = data.Skip((pageNo - 1) * pageSize).Take(pageSize).ToList(),
                CurrentPage = pageNo,
                TotalPages = totalPages
            };
            // поместить данные в объект результата
            result.Data = listData;
            // Если список пустой
            if (data.Count == 0)
            {
                result.Success = false;
                result.ErrorMessage = "Нет объектов в выбраннной категории";
            }
            // Вернуть результат
            return Task.FromResult(result);
        }
        public Task<ResponseData<Instrument>> GetInstrumentByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateInstrumentAsync(int id, Instrument instruments, IFormFile? formFile)
        {
            throw new NotImplementedException();
        }

        public Task DeleteInstrumentAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseData<Instrument>> CreateInstrumentAsync(Instrument instruments, IFormFile? formFile)
        {
            throw new NotImplementedException();
        }
    }
}

