using YukNgoding_Livecode.Entities;

namespace YukNgoding_Livecode.Repository;

public class CourseRepository : ICourseRepository
{
    private readonly AppDbContext _appDbContext;

    public CourseRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public Course Save(Course course)
    {
        return _appDbContext.Courses.Add(course).Entity;
    }

    public Course? FindByName(string name)
    {
        return _appDbContext.Courses.FirstOrDefault(course => course.Name.Equals(name));
    }

    public List<Course> GetAll()
    {
        return _appDbContext.Courses.ToList();
    }
}