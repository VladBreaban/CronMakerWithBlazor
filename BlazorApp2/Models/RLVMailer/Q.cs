using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RlvMailer.Models.RlvMailer
{
  [Table("qs", Schema = "dbo")]
  public partial class Q
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int qs_id
    {
      get;
      set;
    }

    public ICollection<Report> Reports { get; set; }
    public ICollection<QsVirtualProxy> QsVirtualProxies { get; set; }
    public string qs_servr_uri
    {
      get;
      set;
    }
    public string qs_servr_baseuri
    {
      get;
      set;
    }
    public string qs_servr_hub
    {
      get;
      set;
    }
    public string qsengine_version
    {
      get;
      set;
    }
    public string qs_logintype
    {
      get;
      set;
    }
    public string qs_domain
    {
      get;
      set;
    }
    public string qs_user
    {
      get;
      set;
    }
    public string qs_password
    {
      get;
      set;
    }
    public string qs_certificate_path
    {
      get;
      set;
    }
    public string qs_certificate_password
    {
      get;
      set;
    }
    public bool? qs_test_ok
    {
      get;
      set;
    }
    public DateTime? qs_last_date_ok
    {
      get;
      set;
    }
  }
}
