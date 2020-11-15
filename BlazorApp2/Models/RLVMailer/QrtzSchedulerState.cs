using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RlvMailer.Models.RlvMailer
{
  [Table("QRTZ_SCHEDULER_STATE", Schema = "dbo")]
  public partial class QrtzSchedulerState
  {
    [Key]
    public string SCHED_NAME
    {
      get;
      set;
    }
    [Key]
    public string INSTANCE_NAME
    {
      get;
      set;
    }
    public Int64 LAST_CHECKIN_TIME
    {
      get;
      set;
    }
    public Int64 CHECKIN_INTERVAL
    {
      get;
      set;
    }
  }
}
