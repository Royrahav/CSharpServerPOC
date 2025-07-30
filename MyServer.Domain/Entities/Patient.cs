namespace MyServer.Domain.Entities
{
    public class Patient
    {
        public int Icode { get; set; } // code
        public string Ifirst { get; set; } = string.Empty; // firstName
        public string Ilast { get; set; } = string.Empty; // lastName
        public string Ifather { get; set; } = string.Empty; // middleName
        public int Idob { get; set; } // birthDate raw int
        public short Isex { get; set; } // sex code
        public string Imobile { get; set; } = string.Empty;
        public string Iemail { get; set; } = string.Empty;
        public string Istr1 { get; set; } = string.Empty;
        public string Istr2 { get; set; } = string.Empty;
        public string Istr3 { get; set; } = string.Empty;
        public string Izip { get; set; } = string.Empty;
        public int Icity { get; set; }
        public string Icityn { get; set; } = string.Empty;
        public int Istate { get; set; }
        public int Icountry { get; set; }
        public byte Iisdead { get; set; } // inactive
    }
}
