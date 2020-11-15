using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RlvMailer.Models.RlvMailer
{
  [Table("report_line_text", Schema = "dbo")]
  public partial class ReportLineText
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int report_line_text_id
    {
      get;
      set;
    }
    public int? report_line_id
    {
      get;
      set;
    }
    public ReportLine ReportLine { get; set; }

    [Column("report_line_text")]
    public string report_line_text1
    {
      get;
      set;
    }
  }
}
