using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyServer.Domain.Entities
{
    [Table("i")]
    public class Patient
    {
        [Key]
        [Column("icode")]
        public int Code { get; set; }

        [Column("itz")] public string? Itz { get; set; }
        [Column("ilast")] public string? LastName { get; set; }
        [Column("ifirst")] public string? FirstName { get; set; }
        [Column("ifather")] public string? Father { get; set; }
        [Column("idob")] public int? DateOfBirth { get; set; }
        [Column("isex")] public short? Sex { get; set; }
        [Column("istr1")] public string? Str1 { get; set; }
        [Column("istr2")] public string? Str2 { get; set; }
        [Column("izip")] public string? Zip { get; set; }
        [Column("iphone")] public string? Phone { get; set; }
        [Column("ifax")] public string? Fax { get; set; }
        [Column("itype")] public byte? Type { get; set; }
        [Column("idate")] public int? Date { get; set; }
        [Column("idept")] public int? Dept { get; set; }
        [Column("icredit")] public byte? Credit { get; set; }
        [Column("ihiv")] public byte? HIV { get; set; }
        [Column("isrce")] public byte? Srce { get; set; }
        [Column("iacc")] public string? Acc { get; set; }
        [Column("ihpb")] public byte? HPB { get; set; }
        [Column("isndcode")] public int? SndCode { get; set; }
        [Column("iheight")] public short? Height { get; set; }
        [Column("iweight")] public float? Weight { get; set; }
        [Column("istate")] public int? State { get; set; }
        [Column("iroom")] public string? Room { get; set; }
        [Column("iorigland")] public short? OrigLand { get; set; }
        [Column("iisdead")] public byte? IsDead { get; set; }
        [Column("ipopultype")] public short? PopuType { get; set; }
        [Column("iprofession")] public short? Profession { get; set; }
        [Column("iemploydate")] public int? EmployDate { get; set; }
        [Column("iidtype")] public byte? IdType { get; set; }
        [Column("imosrce2")] public short? Mosrce2 { get; set; }
        [Column("imosrce1")] public short? Mosrce1 { get; set; }
        [Column("ifasrce2")] public short? Fasrce2 { get; set; }
        [Column("ifasrce1")] public short? Fasrce1 { get; set; }
        [Column("iwphone1")] public string? WPhone1 { get; set; }
        [Column("iphoneext")] public short? PhoneExt { get; set; }
        [Column("imobile")] public string? Mobile { get; set; }
        [Column("iemail")] public string? Email { get; set; }
        [Column("ibeeper")] public int? Beeper { get; set; }
        [Column("iotherid1")] public string? OtherId1 { get; set; }
        [Column("iotherid2")] public string? OtherId2 { get; set; }
        [Column("idoccode")] public int? DocCode { get; set; }
        [Column("ipersonal")] public byte? Personal { get; set; }
        [Column("icity")] public int? City { get; set; }
        [Column("icountry")] public int? Country { get; set; }
        [Column("istr3")] public string? Str3 { get; set; }
        [Column("idateofdeath")] public int? DateOfDeath { get; set; }
        [Column("iselfpay")] public byte? SelfPay { get; set; }
        [Column("imid")] public string? MiddleName { get; set; }
        [Column("ielastname")] public string? IELastName { get; set; }
        [Column("iefirstname")] public string? IEFirstName { get; set; }
        [Column("ieid")] public string? IEId { get; set; }
        [Column("iestr1")] public string? IEStr1 { get; set; }
        [Column("iestr2")] public string? IEStr2 { get; set; }
        [Column("iestr3")] public string? IEStr3 { get; set; }
        [Column("iezip")] public string? IEZip { get; set; }
        [Column("iestate")] public int? IEState { get; set; }
        [Column("iecity")] public int? IECity { get; set; }
        [Column("iecountry")] public int? IECountry { get; set; }
        [Column("iemobile")] public string? IEMobile { get; set; }
        [Column("iebeeper")] public int? IEBeep { get; set; }
        [Column("ieemail")] public string? IEEmail { get; set; }
        [Column("iephone")] public string? IEPhone { get; set; }
        [Column("iephoneext")] public short? IEPhoneExt { get; set; }
        [Column("iewphone1")] public string? IEWPhone1 { get; set; }
        [Column("iefax")] public string? IEFax { get; set; }
        [Column("iref")] public string? IRef { get; set; }
        [Column("iid")] public string? IID { get; set; }
        [Column("inocharge")] public byte? InOCharge { get; set; }
        [Column("lastupdate")] public int? LastUpdate { get; set; }
        [Column("icityn")] public string? ICityN { get; set; }
        [Column("iecityn")] public string? IECityN { get; set; }
        [Column("istatus")] public short? Status { get; set; }
        [Column("ibloodtype")] public string? BloodType { get; set; }
        [Column("istudycode")] public int? StudyCode { get; set; }
        [Column("isstr1")] public string? ISStr1 { get; set; }
        [Column("isstr2")] public string? ISStr2 { get; set; }
        [Column("iszip")] public string? ISZip { get; set; }
        [Column("iscity")] public int? ISCity { get; set; }
        [Column("iscityn")] public string? ISCityN { get; set; }
        [Column("isstate")] public int? ISState { get; set; }
        [Column("iscountry")] public int? ISCountry { get; set; }
        [Column("isphone")] public string? ISPhone { get; set; }
        [Column("ismobile")] public string? ISMobile { get; set; }
        [Column("iviewresultdist")] public byte? ViewResultDist { get; set; }
        [Column("ivip")] public byte? VIP { get; set; }

        public virtual ICollection<PatientIdentifier> IiRecords { get; set; } = new List<PatientIdentifier>();
    }
}
