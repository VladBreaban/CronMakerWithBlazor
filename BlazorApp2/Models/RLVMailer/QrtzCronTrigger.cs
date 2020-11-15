using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RlvMailer.Models.RlvMailer
{
  [Table("QRTZ_CRON_TRIGGERS", Schema = "dbo")]
  public partial class QrtzCronTrigger
  {
    [Key]
    public string SCHED_NAME
    {
      get;
      set;
    }
    public QrtzTrigger QrtzTrigger { get; set; }
    [Key]
    public string TRIGGER_NAME
    {
      get;
      set;
    }
    [Key]
    public string TRIGGER_GROUP
    {
      get;
      set;
    }
    public string CRON_EXPRESSION
    {
      get;
      set;
    }
    public string TIME_ZONE_ID
    {
      get;
      set;
    }
  }
}
