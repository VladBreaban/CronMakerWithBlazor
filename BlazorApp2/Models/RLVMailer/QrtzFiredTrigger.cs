using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RlvMailer.Models.RlvMailer
{
  [Table("QRTZ_FIRED_TRIGGERS", Schema = "dbo")]
  public partial class QrtzFiredTrigger
  {
    [Key]
    public string SCHED_NAME
    {
      get;
      set;
    }
    [Key]
    public string ENTRY_ID
    {
      get;
      set;
    }
    public string TRIGGER_NAME
    {
      get;
      set;
    }
    public string TRIGGER_GROUP
    {
      get;
      set;
    }
    public string INSTANCE_NAME
    {
      get;
      set;
    }
    public Int64 FIRED_TIME
    {
      get;
      set;
    }
    public Int64 SCHED_TIME
    {
      get;
      set;
    }
    public int PRIORITY
    {
      get;
      set;
    }
    public string STATE
    {
      get;
      set;
    }
    public string JOB_NAME
    {
      get;
      set;
    }
    public string JOB_GROUP
    {
      get;
      set;
    }
    public bool? IS_NONCONCURRENT
    {
      get;
      set;
    }
    public bool? REQUESTS_RECOVERY
    {
      get;
      set;
    }
  }
}
