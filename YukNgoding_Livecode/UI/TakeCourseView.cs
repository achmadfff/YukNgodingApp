﻿using YukNgoding_Livecode.Entities;
using YukNgoding_Livecode.Extensions;
using YukNgoding_Livecode.Services;
using YukNgoding_Livecode.Utils;

namespace YukNgoding_Livecode.UI;

public class TakeCourseView
{
    private readonly ITraineeService _traineeService;
    private readonly ICourseService _courseService;
    private readonly ICourseDetailService _courseDetailService;

    public TakeCourseView(ITraineeService traineeService, ICourseService courseService, ICourseDetailService courseDetailService)
    {
        _traineeService = traineeService;
        _courseService = courseService;
        _courseDetailService = courseDetailService;
    }

    public void TakeCourse()
    {
        var email = Utility.InputEmail("Enter Email of The Trainee: ", s => s.Length < 100);
        var trainee = _traineeService.GetByEmailWithActive(email);
        
        var courseName =  Utility.InputString("Enter the name of the course you want to take: ", s => s.Length < 100);
        var course = _courseService.GetByName(courseName);

        var courseDetail = new CourseDetail
        {
            StartDate = default,
            EndDate = default,
            IsApprove = false,
            Course = course,
            Trainee = trainee
        };

        var courseDetails = _courseDetailService.CreateNewCourseDetail(courseDetail);
        Console.WriteLine(courseDetails);

        Console.WriteLine("Successful Course Taking!! Wait for approval!!");
    }

    public void ApproveTrainee()
    {
        try
        {
            var id = Utility.InputInt("Enter Id of The Course Detail you want to approve: ",Validation.IntValidation);
            
            var courseDetail = _courseDetailService.JoinToCourse(id);
            
            _courseDetailService.UpdateApproval(courseDetail);
            Console.WriteLine("Approve Trainee Success!!");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}