using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RlvMailer.Models.RlvMailer
{
  [Table("qs_virtual_proxy", Schema = "dbo")]
  public partial class QsVirtualProxy
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int id
    {
      get;
      set;
    }
    public int? qs_id
    {
      get;
      set;
    }
    public Q Q { get; set; }
    public string virtual_proxy_header_name
    {
      get;
      set;
    }
    public string virtual_proxy_prefix
    {
      get;
      set;
    }
    public string virtual_proxy_user_directory
    {
      get;
      set;
    }
    public string virtual_proxy_user
    {
      get;
      set;
    }
    public int? virtual_proxy_auth_method_id
    {
      get;
      set;
    }
    public AuthMethod AuthMethod { get; set; }
  }
}
