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