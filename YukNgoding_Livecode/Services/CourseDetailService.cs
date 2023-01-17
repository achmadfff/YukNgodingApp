using YukNgoding_Livecode.Entities;
using YukNgoding_Livecode.Extensions;
using YukNgoding_Livecode.Repository;

namespace YukNgoding_Livecode.Services;

public class CourseDetailService : ICourseDetailService
{
    private readonly ICourseDetailRepository _courseDetailRepository;
    private readonly IPersistence _persistence;

    public CourseDetailService(ICourseDetailRepository courseDetailRepository, IPersistence persistence)
    {
        _courseDetailRepository = courseDetailRepository;
        _persistence = persistence;
    }

    public CourseDetail CreateNewCourseDetail(CourseDetail courseDetail)
    {
        _persistence.BeginTransaction();
        try
        {
            var savedCourseDetail = _courseDetailRepository.Save(courseDetail);
            _persistence.SaveChanges();
            _persistence.Commit();
            return savedCourseDetail;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            _persistence.Rollback();
            throw;
        }
    }

    public CourseDetail? GetById(int id)
    {
        try
        {
            var courseDetail = _courseDetailRepository.FindById(id);
            if (courseDetail is null) throw new Exception("Course Detail Not Found!!");
            return courseDetail;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public void UpdateApproval(CourseDetail courseDetail)
    {
        _persistence.BeginTransaction();
        try
        {
            var traineeToApprove = GetById(courseDetail.Id);
            
            traineeToApprove.IsApprove = true;
            traineeToApprove.StartDate = DateTime.Now.AddBusinessDays(1);
            traineeToApprove.EndDate = DateTime.Now.AddBusinessDays(courseDetail.Course.CourseTime + 1);
            _persistence.SaveChanges();
            _persistence.Commit();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            _persistence.Rollback();
            throw;
        }
    }

    public CourseDetail JoinToCourse(int id)
    {
        try
        {
            var courseDetails = GetById(id);
            var courseDetailsJoin = _courseDetailRepository.JoinCourse(courseDetails);
            return courseDetailsJoin;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}