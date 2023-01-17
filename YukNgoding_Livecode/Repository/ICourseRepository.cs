using YukNgoding_Livecode.Entities;

namespace YukNgoding_Livecode.Repository;

public interface ICourseRepository
{
    Course Save(Course course);
    
    Course? FindByEmail(string name);
}