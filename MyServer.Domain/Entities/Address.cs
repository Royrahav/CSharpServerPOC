using System.Diagnostics.Metrics;

namespace MyServer.Domain.Entities
{
    public class Address
    {
        public string Street1 { get; set; } = string.Empty;
        public string Street2 { get; set; } = string.Empty;
        public string Street3 { get; set; } = string.Empty;
        public string Zip { get; set; } = string.Empty;
        public string Phone1 { get; set; } = string.Empty;
        public string Phone2 { get; set; } = string.Empty;
        public string Fax { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int Extension { get; set; }

        public City City { get; set; } = new City();
        public State State { get; set; } = new State();
        public Country Country { get; set; } = new Country();
    }
}
