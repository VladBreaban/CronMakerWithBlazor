using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RlvMailer.Models.RlvMailer
{
  [Table("report_line_img", Schema = "dbo")]
  public partial class ReportLineImg
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int report_line_img_id
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
    public string report_line_img_qs_app
    {
      get;
      set;
    }
    public string report_line_img_qs_bookmark_id
    {
      get;
      set;
    }
    public string report_line_img_qs_id
    {
      get;
      set;
    }
    public string report_line_img_qs_size
    {
      get;
      set;
    }
    public bool? report_line_img_attachement
    {
      get;
      set;
    }
  }
}
