using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RlvMailer.Models.RlvMailer
{
  [Table("log_app", Schema = "dbo")]
  public partial class LogApp
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int id
    {
      get;
      set;
    }
    public string event_type
    {
      get;
      set;
    }
    public DateTime? event_date
    {
      get;
      set;
    }
    public string object_name
    {
      get;
      set;
    }
    public string message
    {
      get;
      set;
    }
  }
}
