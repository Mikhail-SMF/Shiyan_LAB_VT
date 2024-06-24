using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Instruments.Domain.Entities
{
    public class Instrument
    {
        public int Id { get; set; } // id букета
        public string Name { get; set; } // название букета
        public string Description { get; set; } // описание букета
        public int Price { get; set; } // стоимость
        public string? Image { get; set; } // путь к файлу изображения
                                           // Навигационные свойства
        /// <summary>
        /// группа цветы
        /// </summary>
        public int CategoryId { get; set; }
        [JsonIgnore]
        public Category? Category { get; set; }
    }
}
