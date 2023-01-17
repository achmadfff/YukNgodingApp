// using YukNgoding_Livecode.Repository;
// using YukNgoding_Livecode.Services;
// using YukNgoding_Livecode.UI;
//
// class Program
// {
//     public static void Main(string[] args)
//     {
//         AppDbContext context = new AppDbContext();
//         IPersistence persistence = new DbPersistence(context);
//         ITraineeRepository traineeRepository = new TraineeRepository(context);
//         ICourseRepository courseRepository = new CourseRepository(context);
//         ICourseDetailRepository courseDetailRepository = new CourseDetailRepository(context);
//         
//         ITraineeService traineeService = new TraineeService(traineeRepository, persistence);
//         ICourseService courseService = new CourseService(courseRepository, persistence);
//         ICourseDetailService courseDetailService = new CourseDetailService(courseDetailRepository, persistence);
//         
//         TraineeView traineeView = new TraineeView(traineeService);
//         CourseView courseView = new CourseView(courseService);
//         TakeCourseView takeCourseView = new TakeCourseView(traineeService, courseService, courseDetailService);
//         App app = new App(traineeView,courseView,takeCourseView);
//         
//         app.Run();
//     }
// }

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using YukNgoding_Livecode.Repository;
using YukNgoding_Livecode.Services;
using YukNgoding_Livecode.UI;

var host = CreateHostBuilder(args).Build();

var serviceProvider = host.Services;

try
{
    var app = serviceProvider.GetRequiredService<App>();
    app.Run();
}
catch (Exception e)
{
    Console.WriteLine(e);
    throw;
}

static IHostBuilder CreateHostBuilder(string[] args) => 
    Host.CreateDefaultBuilder(args)
        .ConfigureServices((context, services) =>
        {
            services.AddDbContext<AppDbContext>(builder => builder
                .UseSqlServer(context.Configuration.GetConnectionString("MyConnection")));

            services.AddTransient<IPersistence, DbPersistence>();
        
            services.AddTransient<ITraineeRepository, TraineeRepository>();
            services.AddTransient<ICourseRepository, CourseRepository>();
            services.AddTransient<ICourseDetailRepository, CourseDetailRepository>();
        
            services.AddTransient<ITraineeService, TraineeService>();
            services.AddTransient<ICourseService, CourseService>();
            services.AddTransient<ICourseDetailService, CourseDetailService>();
        
            services.AddTransient<TraineeView>();
            services.AddTransient<TakeCourseView>();
            services.AddTransient<CourseView>();
        
            services.AddTransient<App>();
        });