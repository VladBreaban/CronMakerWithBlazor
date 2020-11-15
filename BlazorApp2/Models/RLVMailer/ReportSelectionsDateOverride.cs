using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RlvMailer.Models.RlvMailer
{
  [Table("report_selections_date_override", Schema = "dbo")]
  public partial class ReportSelectionsDateOverride
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int report_selections_date_override_id
    {
      get;
      set;
    }
    public int? report_id
    {
      get;
      set;
    }
    public Report Report { get; set; }
    public int? report_selections_date
    {
      get;
      set;
    }
    public string report_selections_date_custom
    {
      get;
      set;
    }
  }
}
