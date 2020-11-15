using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RlvMailer.Models.RlvMailer
{
  [Table("QRTZ_CALENDARS", Schema = "dbo")]
  public partial class QrtzCalendar
  {
    [Key]
    public string SCHED_NAME
    {
      get;
      set;
    }
    [Key]
    public string CALENDAR_NAME
    {
      get;
      set;
    }
    public Byte[] CALENDAR
    {
      get;
      set;
    }
  }
}
