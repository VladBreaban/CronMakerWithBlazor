using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RlvMailer.Models.RlvMailer
{
  [Table("actiuni", Schema = "dbo")]
  public partial class Actiuni
  {
    [Key]
    public int id_app
    {
      get;
      set;
    }
    [Key]
    public DateTime data_actiune
    {
      get;
      set;
    }
    public int? nr_actiuni
    {
      get;
      set;
    }
  }
}
