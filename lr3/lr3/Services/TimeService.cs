namespace lr3.Services
{
    public class TimeService
    {
        public string GetCurrentTimePeriod()
        {
            var currentHour = DateTime.Now.Hour;
            return currentHour switch
            {
                >= 12 and < 18 => "зараз день",
                >= 18 and < 24 => "зараз вечір",
                >= 0 and < 6 => "зараз ніч",
                _ => "зараз ранок",
            };
        }
    }
}
