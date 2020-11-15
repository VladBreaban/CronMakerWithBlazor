using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RlvMailer.Models.RlvMailer
{
  [Table("QRTZ_LOCKS", Schema = "dbo")]
  public partial class QrtzLock
  {
    [Key]
    public string SCHED_NAME
    {
      get;
      set;
    }
    [Key]
    public string LOCK_NAME
    {
      get;
      set;
    }
  }
}
