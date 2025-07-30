namespace MyServer.Application.DTOs.Patients
{
    public class PatientDto
    {
        public int Code { get; set; }
        public string DefaultId { get; set; } = string.Empty;
        public DefaultIdTypeDto DefaultIdType { get; set; } = new();
        public string FirstName { get; set; } = string.Empty;
        public string MiddleName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public List<IdentifierDto> Ids { get; set; } = new();
        public bool Inactive { get; set; }
        public string Age { get; set; } = string.Empty;
        public string AgeFull { get; set; } = string.Empty;
        public BirthDateDto BirthDate { get; set; } = new();
        public int BirthYear { get; set; }
        public AddressDto Address { get; set; } = new();
        public SexDto Sex { get; set; } = new();
    }
}
