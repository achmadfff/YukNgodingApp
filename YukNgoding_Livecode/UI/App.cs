using YukNgoding_Livecode.Extensions;
using YukNgoding_Livecode.Utils;

namespace YukNgoding_Livecode.UI;

public class App
{
    private readonly TraineeView _traineeView;
    private readonly CourseView _courseView;
    private readonly TakeCourseView _takeCourseView;
    private readonly TestCourseView _testCourseView;

    public App(TraineeView traineeView, CourseView courseView, TakeCourseView takeCourseView, TestCourseView testCourseView)
    {
        _traineeView = traineeView;
        _courseView = courseView;
        _takeCourseView = takeCourseView;
        _testCourseView = testCourseView;
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
                Console.WriteLine("4. Management Test Courses");
                Console.WriteLine("0. Exit");
                choose = Utility.InputInt("Enter Option", Validation.IntValidation);
            
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
                            Console.WriteLine("3. View All Trainee");
                            Console.WriteLine("4. View All Active Trainee");
                            Console.WriteLine("5. View All Inactive Trainee");
                            Console.WriteLine("0. Exit");
                            optionTrainee = Utility.InputInt("Enter Option", Validation.IntValidation);

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
                                case 3:
                                    Console.WriteLine("View All Trainee");
                                    _traineeView.GetAllTraineeView();
                                    Console.ReadKey();
                                    break;
                                case 4:
                                    Console.WriteLine("View All Active Trainee");
                                    _traineeView.GetAllActiveTraineeView();
                                    Console.ReadKey();
                                    break;
                                case 5:
                                    Console.WriteLine("View All Inactive Trainee");
                                    _traineeView.GetAllInactiveTraineeView();
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
                            Console.WriteLine("2. View Course");
                            Console.WriteLine("0. Exit");
                            optionCourse = Utility.InputInt("Enter Option", Validation.IntValidation);

                            switch (optionCourse)
                            {
                                case 1:
                                    Console.WriteLine("Create Course");
                                    _courseView.CreateCourseView();
                                    Console.ReadKey();
                                    break;
                                case 2:
                                    Console.WriteLine("View All Courses");
                                    _courseView.GetAllCoursesView();
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
                            Console.WriteLine("3. List Trainee To Approve");
                            Console.WriteLine("4. List Approved Trainee");
                            Console.WriteLine("0. Exit");
                            optionTakeCourse = Utility.InputInt("Enter Option", Validation.IntValidation);

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
                                case 3:
                                    Console.WriteLine("List Trainee To Approve");
                                    _takeCourseView.GetAllTraineeToApproveView();
                                    Console.ReadKey();
                                    break;
                                case 4:
                                    Console.WriteLine("List Approved Trainee");
                                    _takeCourseView.GetAllApprovedTraineeView();
                                    Console.ReadKey();
                                    break;
                            }
                        } while (optionTakeCourse != 0);
                        break;
                    case 4:
                        int optionTestCourse;
                        do
                        {
                            Console.Clear();
                            Console.WriteLine('-'.Repeat(100));
                            Console.WriteLine(' '.Repeat(40) +"Test Courses Management");
                            Console.WriteLine('-'.Repeat(100));
                            Console.WriteLine("1. Report Average Score Course");
                            Console.WriteLine("2. Report Percentage Pass Course");
                            Console.WriteLine("0. Exit");
                            optionTakeCourse = Utility.InputInt("Enter Option", Validation.IntValidation);
                    
                            switch (optionTakeCourse)
                            {
                                case 1:
                                    Console.WriteLine("Average");
                                    _testCourseView.ReportAverageScore();
                                    Console.ReadKey();
                                    break;
                                case 2:
                                    Console.WriteLine("Percentage Pass Course");
                                    _testCourseView.ReportPercentagePass();
                                    Console.ReadKey();
                                    break;
                            }
                        } while (optionTakeCourse != 0);
                        break;
                }
            } while (choose != 0);
    }
}