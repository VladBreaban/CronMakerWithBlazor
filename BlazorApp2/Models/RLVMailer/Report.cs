using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RlvMailer.Models.RlvMailer
{
  [Table("reports", Schema = "dbo")]
  public partial class Report
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int report_id
    {
      get;
      set;
    }

    public ICollection<ExternalEmail> ExternalEmails { get; set; }
    public ICollection<ReportSelection> ReportSelections { get; set; }
    public ICollection<ReportLine> ReportLines { get; set; }
    public ICollection<LogReport> LogReports { get; set; }
    public ICollection<Tag> Tags { get; set; }
    public ICollection<ReportSelectionsDate> ReportSelectionsDates { get; set; }
    public ICollection<ReportSelectionsDateOverride> ReportSelectionsDateOverrides { get; set; }
    public ICollection<ReportsExecCondition> ReportsExecConditions { get; set; }
    public int? app_id
    {
      get;
      set;
    }
    public Setting Setting { get; set; }
    public int? srv_mail_id
    {
      get;
      set;
    }
    public Mail Mail { get; set; }
    public int? qs_id
    {
      get;
      set;
    }
    public Q Q { get; set; }
    public string report_name
    {
      get;
      set;
    }
    public string report_description
    {
      get;
      set;
    }
    public bool? report_iterative_field_flag
    {
      get;
      set;
    }
    public bool? report_external_email_flag
    {
      get;
      set;
    }
    public string report_iterative_field_app_id
    {
      get;
      set;
    }
    public string report_iterative_field
    {
      get;
      set;
    }
    public string report_iterative_field_email_to
    {
      get;
      set;
    }
    public string report_iterative_field_email_cc
    {
      get;
      set;
    }
    public string report_iterative_field_email_bcc
    {
      get;
      set;
    }
    public string report_simple_email_to
    {
      get;
      set;
    }
    public string report_simple_email_cc
    {
      get;
      set;
    }
    public string report_simple_email_bcc
    {
      get;
      set;
    }
    public string report_subject
    {
      get;
      set;
    }
    public string report_schedule
    {
      get;
      set;
    }
    public bool? report_date_field_flag
    {
      get;
      set;
    }
    public string report_date_field
    {
      get;
      set;
    }
    public bool? report_status
    {
      get;
      set;
    }
    public string report_alert_kpi_id
    {
      get;
      set;
    }
    public string report_simple_email_alert_to
    {
      get;
      set;
    }
    public string report_simple_email_alert_cc
    {
      get;
      set;
    }
    public string report_simple_email_alert_bcc
    {
      get;
      set;
    }
    public string report_subject_alert
    {
      get;
      set;
    }
    public string report_re_schedule
    {
      get;
      set;
    }
    public string report_err_kpi_id
    {
      get;
      set;
    }
    public string report_simple_email_err_to
    {
      get;
      set;
    }
    public string report_simple_email_err_cc
    {
      get;
      set;
    }
    public string report_simple_email_err_bcc
    {
      get;
      set;
    }
    public string report_subject_err
    {
      get;
      set;
    }
  }
}
