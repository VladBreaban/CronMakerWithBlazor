using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RlvMailer.Models.RlvMailer
{
  [Table("settings", Schema = "dbo")]
  public partial class Setting
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int app_id
    {
      get;
      set;
    }

    public ICollection<Report> Reports { get; set; }
    public int? app_sec_id
    {
      get;
      set;
    }
    public string app_name
    {
      get;
      set;
    }
    public string app_company_name
    {
      get;
      set;
    }
    public int? app_country_code
    {
      get;
      set;
    }
    public Country Country { get; set; }
    public string app_full_name
    {
      get;
      set;
    }
    public string app_telephone_no
    {
      get;
      set;
    }
    public string app_email
    {
      get;
      set;
    }
    public string app_clientid
    {
      get;
      set;
    }
    public string app_evaluate
    {
      get;
      set;
    }
    public DateTime? app_valid_up_to
    {
      get;
      set;
    }
    public string app_last_string_report
    {
      get;
      set;
    }
    public DateTime? app_last_report_date
    {
      get;
      set;
    }
    public bool? app_test_ok
    {
      get;
      set;
    }
  }
}
