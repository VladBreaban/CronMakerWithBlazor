using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RlvMailer.Models.RlvMailer
{
  [Table("countries", Schema = "dbo")]
  public partial class Country
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int code
    {
      get;
      set;
    }

    public ICollection<Setting> Settings { get; set; }
    public string name
    {
      get;
      set;
    }
    public string continent_name
    {
      get;
      set;
    }
  }
}
