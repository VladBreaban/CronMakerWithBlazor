using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RlvMailer.Models.RlvMailer
{
  [Table("reports_exec_conditions", Schema = "dbo")]
  public partial class ReportsExecCondition
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int report_exec_condition_id
    {
      get;
      set;
    }
    public int? report_id
    {
      get;
      set;
    }
    public Report Report { get; set; }
    public string report_exec_condition_type
    {
      get;
      set;
    }
    public string report_exec_condition_qs_object_id
    {
      get;
      set;
    }
    public string report_exec_condition_operator
    {
      get;
      set;
    }
    public string report_exec_condition_value
    {
      get;
      set;
    }
    public int? report_exec_priority_no
    {
      get;
      set;
    }
  }
}
