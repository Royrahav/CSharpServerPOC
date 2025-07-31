namespace MyServer.Application.DTOs.Patients
{
    public class SexDto
    {
        public short Code { get; set; }
        public string Identifier { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
    }
}
