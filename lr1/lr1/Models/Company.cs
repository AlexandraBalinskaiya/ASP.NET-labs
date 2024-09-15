namespace lr1.Models
{
    namespace lr1.Models
    {
        public class Company
        {
            public string Name { get; set; } = string.Empty; // Назва компанії
            public string Industry { get; set; } = string.Empty; // Індустрія, в якій працює компанія
            public int NumberOfEmployees { get; set; } = 0; // Кількість співробітників
            public decimal Revenue { get; set; } = 0m; // Річний дохід компанії
            public string Headquarters { get; set; } = string.Empty; // Головний офіс компанії

            public override string ToString()
            {
                return $"Company: {Name}, Industry: {Industry}, Employees: {NumberOfEmployees}, Revenue: ${Revenue}M, HQ: {Headquarters}";
            }
        }

    }

}
