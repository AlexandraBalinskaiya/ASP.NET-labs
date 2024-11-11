﻿namespace lr4.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public override string ToString()
        {
            return $"ID: {Id}, Назва: {Title}, Автор: {Author}";
        }
    }
}
