using YukNgoding_Livecode.Entities;
using YukNgoding_Livecode.Extensions;
using YukNgoding_Livecode.Services;
using YukNgoding_Livecode.Utils;

namespace YukNgoding_Livecode.UI;

public class CourseView
{
    private readonly ICourseService _courseService;

    public CourseView(ICourseService courseService)
    {
        _courseService = courseService;
    }

    public void CreateCourseView()
    {
        try
        {
            
            var name = Utility.InputString("Enter Name of The Course", s => s.Length < 100);
            var description = Utility.InputString("Enter Description of The Course", s => s.Length < 100);
            var courseTime = Utility.InputInt("Enter Course Time of The Course", s => s.Length < 100);
            var costCategory = Utility.InputString("Enter Cost Category of The Course", s => s.Length < 100);
            var courseCategory = Utility.InputString("Enter Course Category of The Course", s => s.Length < 100);
            var minCriteria = Utility.InputInt("Enter Min Criteria of The Course",Validation.IntValidation);
            var trainer = Utility.InputString("Enter Trainer Name of The Course", s => s.Length < 100);
            var startTime = Utility.InputInt("Enter Start Time(Hour) of The Course",Validation.IntValidation);
            var endTime = Utility.InputInt("Enter End Time(Hour) of The Course",Validation.IntValidation);
            var courseAdd = new Course
            {
                Name = name,
                Description = description,
                CourseTime = courseTime,
                CostCategory = costCategory,
                CourseCategory = courseCategory,
                MinCriteria = minCriteria,
                Trainer = trainer,
                StartHour = startTime,
                EndHour = endTime
            };

            var course = _courseService.CreateNewCourse(courseAdd);
            Console.WriteLine(course);
            Console.WriteLine("Create Success!");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public void GetAllCoursesView()
    {
        try
        {
            Console.WriteLine('='.Repeat(40));
            Console.WriteLine(' '.Repeat(15)+"List Courses");
            Console.WriteLine('='.Repeat(40));

            var courses = _courseService.GetAll();
            foreach (var course in courses)
            {
                Console.WriteLine(course);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}