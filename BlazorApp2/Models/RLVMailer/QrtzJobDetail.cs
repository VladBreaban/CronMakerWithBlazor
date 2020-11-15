using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RlvMailer.Models.RlvMailer
{
  [Table("QRTZ_JOB_DETAILS", Schema = "dbo")]
  public partial class QrtzJobDetail
  {
    [Key]
    public string SCHED_NAME
    {
      get;
      set;
    }

    public ICollection<QrtzTrigger> QrtzTriggers { get; set; }
    [Key]
    public string JOB_NAME
    {
      get;
      set;
    }
    [Key]
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
    public string JOB_CLASS_NAME
    {
      get;
      set;
    }
    public bool IS_DURABLE
    {
      get;
      set;
    }
    public bool IS_NONCONCURRENT
    {
      get;
      set;
    }
    public bool IS_UPDATE_DATA
    {
      get;
      set;
    }
    public bool REQUESTS_RECOVERY
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
