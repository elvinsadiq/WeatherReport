namespace Domain.Entities
{
    public class Contact : BaseEntity
    {
        public string Mobile { get; set; }
        public string Hotline { get; set; }
        public string Address { get; set; }
        public string WeekdayWorkingTime { get; set; }
        public string WeekendWorkingTime { get; set; }
    }
}