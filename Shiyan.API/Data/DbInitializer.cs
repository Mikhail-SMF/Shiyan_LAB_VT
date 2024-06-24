using Instruments.Domain.Entities;

namespace Shiyan.API.Data
{
    public class DbInitializer
    {
        public static async Task SeedData(WebApplication app)
        {
            // Uri проекта
            var uri = "https://localhost:7002/";
            // Получение контекста БД
            using var scope = app.Services.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            // Заполнение данными
            if (!context.Categories.Any() && !context.Instruments.Any())
            {
                var categories = new Category[]
                {
                    new Category { Name="Электроинструменты",NormalizedName="powerTools"},
                    new Category { Name="Ручной инструмент",NormalizedName="handTools"},
                    new Category { Name="Измерительный инструмент",NormalizedName="measuringTools"},
                    new Category {Name="Хозяйственный инструмент",NormalizedName="householdTools"},
                };

                await context.Categories.AddRangeAsync(categories);
                await context.SaveChangesAsync();
                var instrument = new List<Instrument>
                {
                    new Instrument{
                        Name="Лобзик Makita 4329KX1",
                        Description="Мощность, Вт: 450\nМаксимальная глубина пропила (дерево), мм: 65\nМаксимальная глубина пропила (сталь), мм: 6\nЧисло ходов полотна в минуту: 500-3100 ход/мин",
                        Price =339, Image=uri+"Images/powerTools/Лобзик_Makita_4329KX1.jpg",
                        Category=categories.FirstOrDefault(c=>c.NormalizedName.Equals("powerTools"))
                    },

                    new Instrument{
                        Name="Перфоратор Makita HR 2470 X15",
                        Description="Мощность, Вт: 780\nМаксимальное количество ударов в минуту: 4500\nCкорость вращения, об/мин: 1100\nМаксимальный диаметр сверления, бетон/металл/дерево мм: 24/13/32",
                        Price =636, Image=uri+"Images/powerTools/Перфоратор_Makita_HR_2470_X15.jpg",
                        Category=categories.FirstOrDefault(c=>c.NormalizedName.Equals("powerTools"))
                    },

                    new Instrument{
                        Name="Отбойный молоток Bull SH 1501",
                        Description="Мощность, Вт: 1750\nМаксимальное количество ударов в минуту: 1600\nЭнергия удара, Дж: 45",
                        Price =2251, Image=uri+"Images/powerTools/Отбойный_молоток_Bull_SH_1501 jpg.jpg",
                        Category=categories.FirstOrDefault(c=>c.NormalizedName.Equals("powerTools"))
                    },

                    new Instrument{
                        Name="Штроборез Einhell TC-MA 1300",
                        Description="Мощность, Вт: 1320\nДиаметр диска, мм: 125\nCкорость вращения, об/мин: 9000\nГлубина паза, мм: 30",
                        Price =614, Image=uri+"Images/powerTools/Штроборез_Einhell_TC-MA_1300.jpg",
                        Category=categories.FirstOrDefault(c=>c.NormalizedName.Equals("powerTools"))
                    },

                    new Instrument{
                        Name="Одноручная углошлифмашина Bull WS 1207",
                        Description="Мощность, Вт: 1400\nДиаметр диска, мм: 125\nЧастота вращения, об/мин: 11000\nПосадочный диаметр, мм: 22,2",
                        Price =293, Image=uri+"Images/powerTools/Одноручная_углошлифмашина_Bull_WS_1207.png",
                        Category=categories.FirstOrDefault(c=>c.NormalizedName.Equals("powerTools"))
                    },

                    new Instrument{
                        Name="Торцовочная пила Makita LS1040N",
                        Description="Мощность, Вт: 1650\nУгол наклона диска, градус: 45\nСкорость вращения, об/мин: 4600\nПосадочный диаметр, мм: 30",
                        Price =1484, Image=uri+"Images/powerTools/Одноручная_углошлифмашина_Bull_WS_1207.png",
                        Category=categories.FirstOrDefault(c=>c.NormalizedName.Equals("powerTools"))
                    },

                    new Instrument{
                        Name="Молоток каменьщика Yato (YT-4573)",
                        Description="Материал: сталь\nНазначение: для разгонки поверхностей из толстого листового металла\nВес, кг:0.6",
                        Price =67, Image=uri+"Images/handTools/Молоток_каменьщика_Yato_(YT-4573).jpg",
                        Category=categories.FirstOrDefault(c=>c.NormalizedName.Equals("handTools"))
                    },

                    new Instrument{
                        Name="Отвертка-держатель Hobbi 33-4-312",
                        Description="Длина бит, мм: 25\nНазначение:для крепежных работ\nКоличество в комплекте: 20",
                        Price =42, Image=uri+"Images/handTools/Отвертка-держатель_Hobbi_33-4-312.jpg",
                        Category=categories.FirstOrDefault(c=>c.NormalizedName.Equals("handTools"))
                    },

                    new Instrument{
                        Name="Набор инструментов Forsage F-38841",
                        Description="Количество в комплекте: 216",
                        Price =372, Image=uri+"Images/handTools/Набор_инструментов_Forsage_F-38841.jpg",
                        Category=categories.FirstOrDefault(c=>c.NormalizedName.Equals("handTools"))
                    },

                    new Instrument{
                        Name="Напильник Yato YT-6233",
                        Description="Назначение: по металлу\nМатериал: сталь\nФорма: тупоносая\nДлина, мм: 250",
                        Price =24, Image=uri+"Images/handTools/Напильник_Yato_YT-6233.jpg",
                        Category=categories.FirstOrDefault(c=>c.NormalizedName.Equals("handTools"))
                    },

                    new Instrument{
                        Name="Пила по газобетону Hardax 42-2-207",
                        Description="Назначение: по газобетону\nМатериал ручки: пластик\nДлина лезвия, мм: 700",
                        Price =65, Image=uri+"Images/handTools/Пила_по_газобетону_Hardax_42-2-207.jpg",
                        Category=categories.FirstOrDefault(c=>c.NormalizedName.Equals("handTools"))
                    },


                    new Instrument{
                        Name="Уровень Sola AZ 80",
                        Description="Количество ампул: 2\nДлина, см: 80",
                        Price =145, Image=uri+"Images/measuringTools/Уровень_Sola_AZ_80_(01160801).jpg",
                        Category=categories.FirstOrDefault(c=>c.NormalizedName.Equals("measuringTools"))
                    },

                    new Instrument{
                        Name="Мультиметр цифровой Hoegert HT1E604",
                        Description="Диапазон напряжения постоянного/переменного,B: 0-600/0-600\nДиапазон тока постоянного/переменного, A: 10/10\nИзмерение: постоянного тока, переменного тока, постоянного напряжения, переменного напряжения",
                        Price =169, Image=uri+"Images/measuringTools/Мультиметр_цифровой_Hoegert_HT1E604.jpg",
                        Category=categories.FirstOrDefault(c=>c.NormalizedName.Equals("measuringTools"))
                    },

                    new Instrument{
                        Name="Лазерный уровень Wortex LL 0335 D",
                        Description="Лазерный диод, нм: 635\nУгол развертки луча горизонтального/вертикального, гр: 360°/360°\nДальность, м: 30",
                        Price =648, Image=uri+"Images/measuringTools/Лазерный_уровень_Wortex_LL_0335_D.jpg",
                        Category=categories.FirstOrDefault(c=>c.NormalizedName.Equals("measuringTools"))
                    },

                     new Instrument{
                        Name="Угольник столярный Vorel 18200",
                        Description="Материал: сталь\nДлина, м: 0.6",
                        Price =15, Image=uri+"Images/measuringTools/Угольник_столярный_Vorel_18200.jpg",
                        Category=categories.FirstOrDefault(c=>c.NormalizedName.Equals("measuringTools"))
                    },

                    new Instrument{
                        Name="Рулетка Yato YT-7105 (5 м)",
                        Description="Ширина мерного полотна, мм: 19\nДлина, м: 5",
                        Price =14, Image=uri+"Images/measuringTools/Рулетка_Yato_YT-7105_(5 м).jpg",
                        Category=categories.FirstOrDefault(c=>c.NormalizedName.Equals("measuringTools"))
                    },

                    new Instrument{
                        Name="Шило Yato YT-1374",
                        Description="Материал: сталь\nДлина лезвия, мм: 120\nФорма: круглая",
                        Price =26, Image=uri+"Images/householdTools/Шило_Yato_YT-1374_(120).jpg",
                        Category=categories.FirstOrDefault(c=>c.NormalizedName.Equals("householdTools"))
                    },

                    new Instrument{
                        Name="Ножницы Vorel 76312",
                        Description="Материал: сталь\nДлина лезвия, мм: 220",
                        Price =7, Image=uri+"Images/householdTools/Ножницы_Vorel_76312.jpg",
                        Category=categories.FirstOrDefault(c=>c.NormalizedName.Equals("householdTools"))
                    },

                    new Instrument{
                        Name="Нож для напольных покрытий Hobbi 19-0-120",
                        Description="Материал: сталь\nФорма лезвия: круглая\nДлина/ширина, мм: 45/45\nДиаметр: выдвижной",
                        Price =20, Image=uri+"Images/householdTools/Нож_для_напольных_покрытий_Hobbi_19-0-120.jpg",
                        Category=categories.FirstOrDefault(c=>c.NormalizedName.Equals("householdTools"))
                    },

                    new Instrument{
                        Name="Набор ножей для резьбы по дереву Hobbi 40-3-916",
                        Description="Материал: сталь\nНазначение: для резки дерева\nКоличество дополнительных лезвий, шт: 13",
                        Price =13, Image=uri+"Images/householdTools/Набор_ножей_для_резьбы_по_дереву_Hobbi_40-3-916.jpg",
                        Category=categories.FirstOrDefault(c=>c.NormalizedName.Equals("householdTools"))
                    },

                    new Instrument{
                        Name="Нож Top Tools с отламывающимся лезвием 18 мм 17В191",
                        Description="Материал: сталь\nНазначение: для резки бумаги, для резки картона, для резки линолеума\nФорма: трапециевидная\nФорма лезвия: сегментированная",
                        Price =7, Image=uri+"Images/householdTools/Нож_Top_Tools_с_отламывающимся_лезвием_18_мм_17В191.jpg",
                        Category=categories.FirstOrDefault(c=>c.NormalizedName.Equals("householdTools"))
                    },

                };
                await context.AddRangeAsync(instrument);
                await context.SaveChangesAsync();
            }
        }
    }
}
