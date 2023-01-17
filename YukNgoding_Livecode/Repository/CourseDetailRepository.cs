using Microsoft.EntityFrameworkCore;
using YukNgoding_Livecode.Entities;

namespace YukNgoding_Livecode.Repository;

public class CourseDetailRepository : ICourseDetailRepository
{
    private readonly AppDbContext _appDbContext;

    public CourseDetailRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public CourseDetail Save(CourseDetail courseDetail)
    {
        var entity = _appDbContext.CourseDetails.Add(courseDetail).Entity;
        return entity;
    }

    public CourseDetail? FindById(int id)
    {
        return _appDbContext.CourseDetails.FirstOrDefault(detail => detail.Id.Equals(id));
    }

    public void UpdateApproval(CourseDetail courseDetail)
    {
        _appDbContext.CourseDetails.Update(courseDetail);
    }

    public CourseDetail? JoinCourse(CourseDetail courseDetail)
    {
        return _appDbContext.CourseDetails
            .Include(p => p.Course).FirstOrDefault(detail => detail.Id.Equals(courseDetail.Id));
    }

    public List<CourseDetail> JoinCourseList(int id)
    {
        return _appDbContext.CourseDetails
            .Include(detail => detail.Course)
            .Where(detail => detail.Course.Id.Equals(id)).ToList();
    }
    
    public List<CourseDetail> JoinCoursePercentage(int id)
    {
        return _appDbContext.CourseDetails
            .Include(detail => detail.Course)
            .Where(detail => detail.Score >= detail.Course.MinCriteria && detail.Course.Id.Equals(id)).ToList();
    }

    public List<CourseDetail> TraineeToApprove()
    {
        return _appDbContext.CourseDetails.Include(detail => detail.Course)
            .Include(detail => detail.Trainee)
            .Where(detail => detail.IsApprove == false).ToList();
    }

    public List<CourseDetail> ApprovedTrainee()
    {
        return _appDbContext.CourseDetails.Include(detail => detail.Course)
            .Include(detail => detail.Trainee)
            .Where(detail => detail.IsApprove == true).ToList();
    }
}