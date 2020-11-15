using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RlvMailer.Models.RlvMailer
{
  [Table("log_reports", Schema = "dbo")]
  public partial class LogReport
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int id
    {
      get;
      set;
    }
    public string event_type
    {
      get;
      set;
    }
    public DateTime? event_date
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
    public string report_name
    {
      get;
      set;
    }
    public string message
    {
      get;
      set;
    }
  }
}
