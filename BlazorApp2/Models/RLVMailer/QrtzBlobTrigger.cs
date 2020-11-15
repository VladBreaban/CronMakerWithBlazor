using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RlvMailer.Models.RlvMailer
{
  [Table("QRTZ_BLOB_TRIGGERS", Schema = "dbo")]
  public partial class QrtzBlobTrigger
  {
    [Key]
    public string SCHED_NAME
    {
      get;
      set;
    }
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
    public Byte[] BLOB_DATA
    {
      get;
      set;
    }
  }
}
