namespace MyServer.Application.DTOs.Patients
{
    public class AddressDto
    {
        public string Street1 { get; set; } = string.Empty;
        public string Street2 { get; set; } = string.Empty;
        public string Street3 { get; set; } = string.Empty;
        public string Zip { get; set; } = string.Empty;
        public CityDto City { get; set; } = new();
        public StateDto State { get; set; } = new();
        public CountryDto Country { get; set; } = new();
        public string Phone1 { get; set; } = string.Empty;
        public string Phone2 { get; set; } = string.Empty;
        public string Fax { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int Extension { get; set; }
    }
}
