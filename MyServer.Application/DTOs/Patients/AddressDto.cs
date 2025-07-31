namespace MyServer.Application.DTOs.Patients
{
    public class AddressDto
    {
        public CityDto? City { get; set; }
        public StateDto? State { get; set; }
        public CountryDto? Country { get; set; }

        public string Street1 { get; set; } = string.Empty;
        public string Street2 { get; set; } = string.Empty;
        public string Street3 { get; set; } = string.Empty;

        public string Zip { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Fax { get; set; } = string.Empty;
        public string Phone1 { get; set; } = string.Empty;
        public string Phone2 { get; set; } = string.Empty;
        public short Extension { get; set; }
    }
}
