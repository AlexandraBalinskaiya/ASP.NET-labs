namespace lr8.Models
{
    public class Product
    {
        public int ID { get; set; } // Унікальний ідентифікатор продукту
        public string Name { get; set; } // Назва продукту
        public decimal Price { get; set; } // Ціна продукту
        public DateTime CreatedDate { get; set; } // Дата створення продукту
    }
}
