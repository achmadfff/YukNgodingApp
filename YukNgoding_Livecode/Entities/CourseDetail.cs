using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YukNgoding_Livecode.Entities;

[Table("course_details")]
public class CourseDetail
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Display(Name = "Id")]
    public int Id { get; set; }

    [Column(name:"start_date")]
    [Display(Name = "Start Date")]
    public DateTime StartDate { get; set; }
    
    [Column(name:"end_date")]
    [Display(Name = "End Date")]
    public DateTime EndDate { get; set; }

    [Column(name:"is_approve")]
    [Display(Name = "Is Approve")]
    public bool IsApprove { get; set; }
    
    public Course Course { get; set; }
    
    public Trainee Trainee { get; set; }

    public override string ToString()
    {
        return $"{nameof(Id)}: {Id}, {nameof(StartDate)}: {StartDate}," +
               $" {nameof(EndDate)}: {EndDate}, {nameof(IsApprove)}: {IsApprove}," +
               $" Course Name: {Course.Name}, Trainee Name: {Trainee.CallName}";
    }
}