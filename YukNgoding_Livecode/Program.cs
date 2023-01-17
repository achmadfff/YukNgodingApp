using YukNgoding_Livecode.Repository;
using YukNgoding_Livecode.Services;
using YukNgoding_Livecode.UI;

class Program
{
    public static void Main(string[] args)
    {
        AppDbContext context = new AppDbContext();
        IPersistence persistence = new DbPersistence(context);
        ITraineeRepository traineeRepository = new TraineeRepository(context);
        ICourseRepository courseRepository = new CourseRepository(context);
        ICourseDetailRepository courseDetailRepository = new CourseDetailRepository(context);
        
        ITraineeService traineeService = new TraineeService(traineeRepository, persistence);
        ICourseService courseService = new CourseService(courseRepository, persistence);
        ICourseDetailService courseDetailService = new CourseDetailService(courseDetailRepository, persistence);
        
        TraineeView traineeView = new TraineeView(traineeService);
        CourseView courseView = new CourseView(courseService);
        TakeCourseView takeCourseView = new TakeCourseView(traineeService, courseService, courseDetailService);
        App app = new App(traineeView,courseView,takeCourseView);
        
        app.Run();
    }
}