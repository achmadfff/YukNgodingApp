using YukNgoding_Livecode.Entities;

namespace YukNgoding_Livecode.Repository;

public interface ICourseDetailRepository
{
    CourseDetail Save(CourseDetail courseDetail);
    CourseDetail? FindById(int id);

    void UpdateApproval(CourseDetail courseDetail);

    CourseDetail? JoinCourse(CourseDetail courseDetail);
}