using YukNgoding_Livecode.Entities;

namespace YukNgoding_Livecode.Services;

public interface ICourseService
{
    Course CreateNewCourse(Course course);

    Course? GetByName(string name);
}