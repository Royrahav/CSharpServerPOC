namespace MyServer.Application.DTOs.Patients
{
    public class IdentifierDto
    {
        public int Code { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
        public string ValueForDisplay { get; set; } = string.Empty;
    }
}
