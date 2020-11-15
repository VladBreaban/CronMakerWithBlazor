using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RlvMailer.Models.RlvMailer
{
  [Table("report_line_xls", Schema = "dbo")]
  public partial class ReportLineXl
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int report_line_xls_id
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
    public string report_line_xls_qs_app
    {
      get;
      set;
    }
    public string report_line_xls_qs_id
    {
      get;
      set;
    }
    public string report_line_xls_path_template
    {
      get;
      set;
    }
  }
}
