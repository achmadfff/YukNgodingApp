using YukNgoding_Livecode.Entities;

namespace YukNgoding_Livecode.Services;

public interface ICourseDetailService
{
    CourseDetail CreateNewCourseDetail(CourseDetail courseDetail);
    CourseDetail? GetById(int id);

    void UpdateApproval(CourseDetail courseDetail);

    CourseDetail JoinToCourse(int id);

    List<CourseDetail> TraineeToApprove();
    List<CourseDetail> ApprovedTrainee();
}