using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RlvMailer.Models.RlvMailer
{
  [Table("report_line", Schema = "dbo")]
  public partial class ReportLine
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int report_line_id
    {
      get;
      set;
    }

    public ICollection<ReportLineImg> ReportLineImgs { get; set; }
    public ICollection<ReportLineText> ReportLineTexts { get; set; }
    public ICollection<ReportLineXl> ReportLineXls { get; set; }
    public int? report_id
    {
      get;
      set;
    }
    public Report Report { get; set; }
    public int? report_line_order
    {
      get;
      set;
    }
    public string report_line_type
    {
      get;
      set;
    }
  }
}
