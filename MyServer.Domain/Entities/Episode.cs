using System.ComponentModel.DataAnnotations.Schema;

namespace MyServer.Domain.Entities
{
    [Table("ep")]
    public class Episode
    {
        [Column("eptype")] public short Type { get; set; }
        [Column("epcode")] public string Code { get; set; } = string.Empty;
        [Column("epdate")] public int? Date { get; set; }
        [Column("eptime")] public short? Time { get; set; }
        [Column("epid")] public string Id { get; set; } = string.Empty;
        [Column("epclosedate")] public int? CloseDate { get; set; }
        [Column("epclosetime")] public short? CloseTime { get; set; }
        [Column("epcommconst")] public short? CommConst { get; set; }
        [Column("epcommfree")] public short? CommFree { get; set; }
        [Column("epnumber")] public int Number { get; set; }
        [Column("eppatcode")] public int PatientCode { get; set; }
        [Column("epextfield1")] public int? ExtField1 { get; set; }
        [Column("epextfield2")] public int? ExtField2 { get; set; }
        [Column("epextfield3")] public int? ExtField3 { get; set; }
        [Column("epsite")] public int? Site { get; set; }

        // Optional navigation property
        public Patient? Patient { get; set; }
    }
}
