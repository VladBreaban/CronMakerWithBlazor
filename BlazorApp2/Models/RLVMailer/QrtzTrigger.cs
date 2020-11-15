using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RlvMailer.Models.RlvMailer
{
  [Table("QRTZ_TRIGGERS", Schema = "dbo")]
  public partial class QrtzTrigger
  {
    [Key]
    public string SCHED_NAME
    {
      get;
      set;
    }

    public ICollection<QrtzCronTrigger> QrtzCronTriggers { get; set; }
    public ICollection<QrtzSimpleTrigger> QrtzSimpleTriggers { get; set; }
    public ICollection<QrtzSimpropTrigger> QrtzSimpropTriggers { get; set; }
    public QrtzJobDetail QrtzJobDetail { get; set; }
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
    public string DESCRIPTION
    {
      get;
      set;
    }
    public Int64? NEXT_FIRE_TIME
    {
      get;
      set;
    }
    public Int64? PREV_FIRE_TIME
    {
      get;
      set;
    }
    public int? PRIORITY
    {
      get;
      set;
    }
    public string TRIGGER_STATE
    {
      get;
      set;
    }
    public string TRIGGER_TYPE
    {
      get;
      set;
    }
    public Int64 START_TIME
    {
      get;
      set;
    }
    public Int64? END_TIME
    {
      get;
      set;
    }
    public string CALENDAR_NAME
    {
      get;
      set;
    }
    public int? MISFIRE_INSTR
    {
      get;
      set;
    }
    public Byte[] JOB_DATA
    {
      get;
      set;
    }
  }
}
