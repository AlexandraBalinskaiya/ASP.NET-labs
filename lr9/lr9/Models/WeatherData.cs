namespace lr9.Models
{
    public class WeatherData
    {
        public string Name { get; set; } // Назва регіону
        public Main Main { get; set; } // Температурні дані
        public Weather[] Weather { get; set; } // Опис погоди
    }

    public class Main
    {
        public float Temp { get; set; } // Температура
    }

    public class Weather
    {
        public string Description { get; set; } // Опис погоди
    }

}
