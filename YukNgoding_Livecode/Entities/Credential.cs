using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YukNgoding_Livecode.Entities;

[Table("credentials", Schema = "dbo")]
public class Credential
{
    [Key, Column(name:"id")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Display(Name = "Id")]
    public int Id { get; set; }
    
    [ForeignKey("Trainee")]
    [Column(name:"email")]
    [Display(Name = "Id")]
    public string Email { get; set; }
    
    [Column(name:"password",TypeName = "NVarchar(50)")]
    [Display(Name = "Password")]
    public string Password { get; set; }
    
    public virtual Trainee Trainee { get; set; }
}