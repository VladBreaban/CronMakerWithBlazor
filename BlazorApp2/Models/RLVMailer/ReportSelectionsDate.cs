using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RlvMailer.Models.RlvMailer
{
  [Table("report_selections_date", Schema = "dbo")]
  public partial class ReportSelectionsDate
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int report_selections_date_id
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
    public string report_selections_date_app
    {
      get;
      set;
    }
    public string report_selections_date_field
    {
      get;
      set;
    }
    public DateTime? report_selections_date_value
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
