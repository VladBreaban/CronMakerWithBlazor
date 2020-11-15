using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RlvMailer.Models.RlvMailer
{
  [Table("external_email", Schema = "dbo")]
  public partial class ExternalEmail
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int external_email_id
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
    public string external_filed_value
    {
      get;
      set;
    }
    public string external_email_to
    {
      get;
      set;
    }
    public string external_email_cc
    {
      get;
      set;
    }
    public string external_email_bcc
    {
      get;
      set;
    }
  }
}
