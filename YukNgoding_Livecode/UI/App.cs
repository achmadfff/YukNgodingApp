using YukNgoding_Livecode.Extensions;

namespace YukNgoding_Livecode.UI;

public class App
{
    private readonly TraineeView _traineeView;
    private readonly CourseView _courseView;
    private readonly TakeCourseView _takeCourseView;

    public App(TraineeView traineeView, CourseView courseView, TakeCourseView takeCourseView)
    {
        _traineeView = traineeView;
        _courseView = courseView;
        _takeCourseView = takeCourseView;
    }

    public void Run()
    {
        Console.WriteLine('='.Repeat(100));
        Console.WriteLine(' '.Repeat(40) +"Welcome to App YukNgoding");
        Console.WriteLine('='.Repeat(100));

        int choose;
            do
            {
                Console.Clear();
                Console.WriteLine("1. Management Trainee");
                Console.WriteLine("2. Management Course");
                Console.WriteLine("3. Management Take Courses");
                Console.WriteLine("0. Exit");
                Console.Write("Enter option: ");
                choose = int.Parse(Console.ReadLine());
            
                switch (choose)
                {
                    case 1:
                        int optionTrainee;
                        do
                        {
                            Console.Clear();
                            Console.WriteLine('-'.Repeat(100));
                            Console.WriteLine(' '.Repeat(40) +"Management Trainee");
                            Console.WriteLine('-'.Repeat(100));
                            Console.WriteLine("1. Create Trainee");
                            Console.WriteLine("2. Activation Trainee");
                            Console.WriteLine("0. Exit");
                            Console.Write("Enter option: ");
                            optionTrainee = int.Parse(Console.ReadLine());

                            switch (optionTrainee)
                            {
                                case 1:
                                    Console.WriteLine("Create Trainee");
                                    _traineeView.CreateTraineeView();
                                    Console.ReadKey();
                                    break;
                                case 2:
                                    Console.WriteLine("Activation Trainee");
                                    _traineeView.ActivationTraineeView();
                                    Console.ReadKey();
                                    break;
                            }
                        } while (optionTrainee != 0);
                        break;
                    case 2:
                        int optionCourse;
                        do
                        {
                            Console.Clear();
                            Console.WriteLine('-'.Repeat(100));
                            Console.WriteLine(' '.Repeat(40) +"Management Course");
                            Console.WriteLine('-'.Repeat(100));
                            Console.WriteLine("1. Create Course");
                            Console.WriteLine("0. Exit");
                            Console.Write("Enter option: ");
                            optionCourse = int.Parse(Console.ReadLine());

                            switch (optionCourse)
                            {
                                case 1:
                                    Console.WriteLine("Create Course");
                                    _courseView.CreateCourseView();
                                    Console.ReadKey();
                                    break;
                            }
                        } while (optionCourse != 0);
                        break;
                    case 3:
                        int optionTakeCourse;
                        do
                        {
                            Console.Clear();
                            Console.WriteLine('-'.Repeat(100));
                            Console.WriteLine(' '.Repeat(40) +"Course Taking Management");
                            Console.WriteLine('-'.Repeat(100));
                            Console.WriteLine("1. Course Taking");
                            Console.WriteLine("2. Approve Traine");
                            Console.WriteLine("0. Exit");
                            Console.Write("Enter option: ");
                            optionTakeCourse = int.Parse(Console.ReadLine());

                            switch (optionTakeCourse)
                            {
                                case 1:
                                    Console.WriteLine("Course Taking");
                                    _takeCourseView.TakeCourse();
                                    Console.ReadKey();
                                    break;
                                case 2:
                                    Console.WriteLine("Approve Trainee");
                                    _takeCourseView.ApproveTrainee();
                                    Console.ReadKey();
                                    break;
                            }
                        } while (optionTakeCourse != 0);
                        break;
                }
            } while (choose != 0);
    }
}