using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RlvMailer.Models.RlvMailer
{
  [Table("tag", Schema = "dbo")]
  public partial class Tag
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int tag_id
    {
      get;
      set;
    }
    public int report_id
    {
      get;
      set;
    }
    public Report Report { get; set; }
    public string tag_name
    {
      get;
      set;
    }
    public string tag_app_id
    {
      get;
      set;
    }
    public string tag_field
    {
      get;
      set;
    }
  }
}
