using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RlvMailer.Models.RlvMailer
{
  [Table("auth_methods", Schema = "dbo")]
  public partial class AuthMethod
  {
    [Key]
    public int auth_method_id
    {
      get;
      set;
    }

    public ICollection<QsVirtualProxy> QsVirtualProxies { get; set; }
    public string auth_method_description
    {
      get;
      set;
    }
  }
}
