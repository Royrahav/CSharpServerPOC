using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyServer.Domain.Entities
{
    [Table("ii")]
    public class PatientIdentifier
    {
        [Key]
        [Column("iicode")]
        public int Iicode { get; set; }

        [Column("iiid")]
        public string? IiId { get; set; }

        [Column("iiidtype")]
        public byte? IiIdType { get; set; }

        [Column("iipid")]
        public string? Iipid { get; set; }

        // Navigation property
        public Patient? Patient { get; set; }
    }
}
