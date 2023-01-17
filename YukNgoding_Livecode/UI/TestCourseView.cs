using YukNgoding_Livecode.Services;
using YukNgoding_Livecode.Utils;

namespace YukNgoding_Livecode.UI;

public class TestCourseView
{
    private readonly ICourseService _courseService;
    private readonly ICourseDetailService _courseDetailService;

    public TestCourseView(ICourseService courseService, ICourseDetailService courseDetailService)
    {
        _courseService = courseService;
        _courseDetailService = courseDetailService;
    }

    public void ReportAverageScore()
    {
        var courseName =
            Utility.InputString("Enter the name of the course you want to get Report Average", s => s.Length < 100);
        var course = _courseService.GetByName(courseName);

        var courseDetails = _courseDetailService.JoinToCourseGroupBy(course.Id);
        List<int> score = new List<int>();
        foreach (var courseDetail in courseDetails)
        {
            score.Add(courseDetail.Score); 
        }
        double average = Queryable.Average(score.AsQueryable());
        Console.WriteLine($"Average from course: {course.Name} is {average}");
    }

    public void ReportPercentagePass()
    {
        var courseName =
            Utility.InputString("Enter the name of the course you want to get Report Average", s => s.Length < 100);
        var course = _courseService.GetByName(courseName);

        var courseDetailsTotal = _courseDetailService.JoinToCourseGroupBy(course.Id);

        var courseDetailsPass = _courseDetailService.JoinCoursePercentage(course.Id);

        var result = ((double)courseDetailsPass.Count / (double)courseDetailsTotal.Count) * 100;
        Console.WriteLine($"Percentage Pass Of Course: {course.Name} is {result}%");
    }
}