using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RlvMailer.Models.RlvMailer
{
  [Table("mail", Schema = "dbo")]
  public partial class Mail
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int srv_mail_id
    {
      get;
      set;
    }

    public ICollection<Report> Reports { get; set; }
    public string srv_mail_smtp
    {
      get;
      set;
    }
    public string srv_mail_port
    {
      get;
      set;
    }
    public string srv_mail_from
    {
      get;
      set;
    }
    public string srv_mail_username
    {
      get;
      set;
    }
    public string srv_mail_password
    {
      get;
      set;
    }
    public bool? srv_mail_test_ok
    {
      get;
      set;
    }
    public DateTime? srv_mail_last_date_ok
    {
      get;
      set;
    }
    public bool? srv_mail_ssl
    {
      get;
      set;
    }
    public int? srv_mail_max_retries_on_failure
    {
      get;
      set;
    }
    public int? srv_mail_delay_between_retries
    {
      get;
      set;
    }
    public string debug_email_to
    {
      get;
      set;
    }
    public string debug_email_cc
    {
      get;
      set;
    }
    public string debug_email_bcc
    {
      get;
      set;
    }
  }
}
