using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YukNgoding_Livecode.Entities;

[Table("courses",Schema = "dbo")]
public class Course
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Display(Name = "Id")]
    public int Id { get; set; }

    [Required]
    [Column(name:"name",TypeName = "NVarchar(100)")]
    [Display(Name = "Name")]
    public string Name { get; set; }
    
    [Required]
    [Column(name:"description",TypeName = "NVarchar(100)")]
    [Display(Name = "Description")]
    public string Description { get; set; }
    
    [Required]
    [Column(name:"course_time",TypeName = "NVarchar(100)")]
    [Display(Name = "Course Time")]
    public int CourseTime { get; set; }
    
    [Column(name:"cost_category",TypeName = "NVarchar(100)")]
    [Display(Name = "Cost Category")]
    public string CostCategory { get; set; }
    
    [Column(name:"course_category",TypeName = "NVarchar(100)")]
    [Display(Name = "Course Category")]
    public string CourseCategory { get; set; }
        
    [Column(name:"min_criteria")]
    [Display(Name = "Min Criteria")]
    public int MinCriteria { get; set; }

    [Column(name:"trainer",TypeName = "NVarchar(100)")]
    [Display(Name = "Trainer")]
    public string Trainer { get; set; }
    
    [Required]
    [Column(name:"start_time",TypeName = "NVarchar(100)")]
    [Display(Name = "Start Name")]
    public int StartTime { get; set; }
    
    [Required]
    [Column(name:"end_time",TypeName = "NVarchar(100)")]
    [Display(Name = "End Time")]
    public int EndTime { get; set; }
    
    public ICollection<CourseDetail> CourseDetails { get; set; }

    public override string ToString()
    {
        return $"{nameof(Id)}: {Id}, {nameof(Name)}: {Name}, {nameof(Description)}: {Description}," +
               $" {nameof(CourseTime)}: {CourseTime}, {nameof(CostCategory)}: {CostCategory}," +
               $" {nameof(CourseCategory)}: {CourseCategory}, {nameof(MinCriteria)}: {MinCriteria}";
    }
}