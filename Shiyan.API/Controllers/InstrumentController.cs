using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Instruments.Domain.Entities;
using Shiyan.API.Data;
using Instruments.Domain.Models;

namespace Shiyan.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstrumentsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public InstrumentsController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        // GET: api/Instruments1
        [HttpGet]
        public async Task<ActionResult<ResponseData<ProductListModel<Instrument>>>> GetInstrument(string? category, int pageNo = 1, int pageSize = 3)
        {
            // Создать объект результата
            var result = new ResponseData<ProductListModel<Instrument>>();
            // Фильтрация по категории загрузка данных категории
            var data = _context.Instruments.Include(d => d.Category).Where(d => String.IsNullOrEmpty(category) || d.Category.NormalizedName.Equals(category));
            // Подсчет общего количества страниц
            int totalPages = (int)Math.Ceiling(data.Count() / (double)pageSize);
            if (pageNo > totalPages)
                pageNo = totalPages;
            // Создание объекта ProductListModel с нужной страницей данных
            var listData = new ProductListModel<Instrument>()
            {
                Items = await data.Skip((pageNo - 1) * pageSize).Take(pageSize).ToListAsync(),
                CurrentPage = pageNo,
                TotalPages = totalPages
            };
            // поместить данные в объект результата
            result.Data = listData;
            // Если список пустой
            if (data.Count() == 0)
            {
                result.Success = false;
                result.ErrorMessage = "Нет объектов в выбранной категории";
            }
            return result;
        }

        // GET: api/Instruments1/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Instrument>> GetInstrument(int id)
        {
            var instrument = await _context.Instruments.Include(d => d.Category).FirstOrDefaultAsync(d => d.Id == id); ;

            if (instrument == null)
            {
                return NotFound();
            }

            return instrument;
        }

        // PUT: api/Instruments1/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInstrument(int id, Instrument instrument)
        {
            if (id != instrument.Id)
            {
                return BadRequest();
            }

            _context.Entry(instrument).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InstrumentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Instruments1
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Instrument>> PostInstrument(Instrument instrument)
        {
            _context.Instruments.Add(instrument);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInstrument", new { id = instrument.Id }, instrument);
        }

        // DELETE: api/Instruments1/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInstrument(int id)
        {
            var instrument = await _context.Instruments.FindAsync(id);
            if (instrument == null)
            {
                return NotFound();
            }

            _context.Instruments.Remove(instrument);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InstrumentExists(int id)
        {
            return _context.Instruments.Any(e => e.Id == id);
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> SaveImage(int id, IFormFile image)
        {
            // Найти объект по Id
            var instrument = await _context.Instruments.FindAsync(id);
            if (instrument == null)
            {
                return NotFound();
            }

            // Путь к папке wwwroot/Images
            var imagesPath = Path.Combine(_env.WebRootPath, "Images");
            // получить случайное имя файла
            var randomName = Path.GetRandomFileName();
            // получить расширение в исходном файле
            var extension = Path.GetExtension(image.FileName);
            // задать в новом имени расширение как в исходном файле
            var fileName = Path.ChangeExtension(randomName, extension);
            // полный путь к файлу
            var filePath = Path.Combine(imagesPath, fileName);
            // создать файл и открыть поток для чтения
            using var stream = System.IO.File.OpenWrite(filePath);
            // скопировать файл в поток
            await image.CopyToAsync(stream);
            // получить Url хоста
            var host = "https://" + Request.Host;
            // Url файла изображения
            var url = $"{host}/Images/{fileName}";
            // Сохранить url файла в объекте
            instrument.Image = url;
            await _context.SaveChangesAsync();
            return Ok();

        }
    }
}
