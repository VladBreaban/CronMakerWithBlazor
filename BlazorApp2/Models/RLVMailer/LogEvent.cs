using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RlvMailer.Models.RlvMailer
{
  [Table("LogEvents", Schema = "dbo")]
  public partial class LogEvent
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id
    {
      get;
      set;
    }
    public string Message
    {
      get;
      set;
    }
    public string Level
    {
      get;
      set;
    }
    public DateTime? TimeStamp
    {
      get;
      set;
    }
    public string Exception
    {
      get;
      set;
    }
    public string Source
    {
      get;
      set;
    }
    public string Report
    {
      get;
      set;
    }
  }
}
