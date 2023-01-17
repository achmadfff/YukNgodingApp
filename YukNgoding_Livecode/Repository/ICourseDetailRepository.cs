using YukNgoding_Livecode.Entities;

namespace YukNgoding_Livecode.Repository;

public interface ICourseDetailRepository
{
    CourseDetail Save(CourseDetail courseDetail);
    CourseDetail? FindById(int id);

    void UpdateApproval(CourseDetail courseDetail);

    CourseDetail? JoinCourse(CourseDetail courseDetail);
    public List<CourseDetail> JoinCourseList(int id);
    public List<CourseDetail> JoinCoursePercentage(int id);

    List<CourseDetail> TraineeToApprove();
    List<CourseDetail> ApprovedTrainee();
}