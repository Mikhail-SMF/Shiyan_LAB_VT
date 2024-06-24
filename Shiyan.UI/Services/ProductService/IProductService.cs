using Instruments.Domain.Entities;
using Instruments.Domain.Models;

namespace Shiyan.UI.Services.InstrumentsService
{
    public interface IProductService
    {
        /// <summary>
        /// Получение списка всех объектов
        /// </summary>
        /// <param name="categoryNormalizedName">нормализованное имя категории для фильтрации</param>
        /// <param name="pageNo">номер страницы списка</param>
        /// <returns></returns>
        public Task<ResponseData<ProductListModel<Instrument>>> GetInstrumentListAsync(string? categoryNormalizedName, int pageNo = 1);
        /// <summary>
        /// Поиск объекта по Id
        /// </summary>
        /// <param name="id">Идентификатор объекта</param>
        /// <returns>Найденный объект или null, если объект не найден</returns>
        public Task<ResponseData<Instrument>> GetInstrumentByIdAsync(int id);
        /// <summary>
        /// Обновление объекта
        /// </summary>
        /// <param name="id">Id изменяемомго объекта</param>
        /// <param name="instruments">объект с новыми параметрами</param>
        /// <param name="formFile">Файл изображения</param>
        /// <returns></returns>
        public Task UpdateInstrumentAsync(int id, Instrument instruments, IFormFile? formFile);
        /// <summary>
        /// Удаление объекта
        /// </summary>
        /// <param name="id">Id удаляемомго объекта</param>
        /// <returns></returns>
        public Task DeleteInstrumentAsync(int id);
        /// <summary>
        /// Создание объекта
        /// </summary>
        /// <param name="instruments">Новый объект</param>
        /// <param name="formFile">Файл изображения</param>
        /// <returns>Созданный объект</returns>
        public Task<ResponseData<Instrument>> CreateInstrumentAsync(Instrument instruments, IFormFile? formFile);
    }
}
