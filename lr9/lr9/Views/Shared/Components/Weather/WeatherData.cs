namespace lr9.Views.Shared.Components.Weather
{
    public class WeatherData
    {
        public string Name { get; set; } // Назва міста або регіону
        public Main Main { get; set; } // Дані про температуру
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
