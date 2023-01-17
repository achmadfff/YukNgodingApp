using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YukNgoding_Livecode.Entities;

[Table("trainees", Schema = "dbo")]
public class Trainee
{
    [Key]
    [Column(name:"email",TypeName = "NVarchar(100)")]
    [Display(Name = "Email")]
    public string Email { get; set; }

    [Required]
    [Column(name:"first_name",TypeName = "NVarchar(100)")]
    [Display(Name = "First Name")]
    public string FirstName { get; set; }
    
    [Required]
    [Column(name:"last_name",TypeName = "NVarchar(100)")]
    [Display(Name = "Last Name")]
    public string LastName { get; set; }
    
    [Required]
    [Column(name:"call_name",TypeName = "NVarchar(100)")]
    [Display(Name = "Call Name")]
    public string CallName { get; set; }
    
    [Column(name:"domicile_address",TypeName = "NVarchar(100)")]
    [Display(Name = "Domicile Address")]
    public string DomicileAddress { get; set; }
    
    [Column(name:"phone_number",TypeName = "NVarchar(14)")]
    [Display(Name = "Phone Number")]
    public string PhoneNumber { get; set; }
        
    [Column(name:"nik")]
    [Display(Name = "NIK")]
    public int Nik { get; set; }

    [Column(name:"last_education",TypeName = "NVarchar(14)")]
    [Display(Name = "Last Education")]
    public string LastEducation { get; set; }
    
    [Column(name:"is_active")]
    [Display(Name = "Is Active")]
    public bool IsActive { get; set; }
    
    public virtual Credential Credential { get; set; }
    
    public ICollection<CourseDetail> CourseDetails { get; set; }
}