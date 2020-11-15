using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RlvMailer.Models.RlvMailer
{
  [Table("report_selections", Schema = "dbo")]
  public partial class ReportSelection
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int report_selections_id
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
    public string report_selections_app
    {
      get;
      set;
    }
    public string report_selections_field
    {
      get;
      set;
    }
    public string report_selections_value
    {
      get;
      set;
    }
  }
}
