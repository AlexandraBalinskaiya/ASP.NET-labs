using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace lr7.Controllers
{
    public class FileController : Controller
    {
        // Відображення форми
        public IActionResult DownloadFile()
        {
            return View();
        }

        // Обробка введених даних і створення файлу
        [HttpPost]
        public IActionResult DownloadFile(string firstName, string lastName, string fileName)
        {
            // Формуємо вміст файлу
            string content = $"Ім'я: {firstName}\nПрізвище: {lastName}";

            // Визначаємо шлях файлу
            string filePath = $"{fileName}.txt";

            // Конвертуємо вміст у байти
            byte[] fileBytes = Encoding.UTF8.GetBytes(content);

            // Повертаємо файл на завантаження
            return File(fileBytes, "text/plain", filePath);
        }
    }
}
