using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RlvMailer.Models.RlvMailer
{
  [Table("QRTZ_SIMPLE_TRIGGERS", Schema = "dbo")]
  public partial class QrtzSimpleTrigger
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
    public int REPEAT_COUNT
    {
      get;
      set;
    }
    public Int64 REPEAT_INTERVAL
    {
      get;
      set;
    }
    public int TIMES_TRIGGERED
    {
      get;
      set;
    }
  }
}
