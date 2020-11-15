using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RlvMailer.Models.RlvMailer
{
  [Table("QRTZ_SIMPROP_TRIGGERS", Schema = "dbo")]
  public partial class QrtzSimpropTrigger
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
    public string STR_PROP_1
    {
      get;
      set;
    }
    public string STR_PROP_2
    {
      get;
      set;
    }
    public string STR_PROP_3
    {
      get;
      set;
    }
    public int? INT_PROP_1
    {
      get;
      set;
    }
    public int? INT_PROP_2
    {
      get;
      set;
    }
    public Int64? LONG_PROP_1
    {
      get;
      set;
    }
    public Int64? LONG_PROP_2
    {
      get;
      set;
    }
    public decimal? DEC_PROP_1
    {
      get;
      set;
    }
    public decimal? DEC_PROP_2
    {
      get;
      set;
    }
    public bool? BOOL_PROP_1
    {
      get;
      set;
    }
    public bool? BOOL_PROP_2
    {
      get;
      set;
    }
    public string TIME_ZONE_ID
    {
      get;
      set;
    }
  }
}
