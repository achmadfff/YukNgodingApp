using System.Net;
using YukNgoding_Livecode.DTO;
using YukNgoding_Livecode.Extensions;
using YukNgoding_Livecode.Services;
using YukNgoding_Livecode.Utils;

namespace YukNgoding_Livecode.UI;

public class TraineeView
{
    private readonly ITraineeService _traineeService;

    public TraineeView(ITraineeService traineeService)
    {
        _traineeService = traineeService;
    }

    public void CreateTraineeView()
    {
        try
        {
            var email = Utility.InputEmail("Enter Email of The Trainee: ", s => s.Length < 100);
            var firstName = Utility.InputString("Enter First Name of The Trainee: ", s => s.Length < 100);
            var lastName = Utility.InputString("Enter Last Name of The Trainee: ", s => s.Length < 100);
            var callName = Utility.InputString("Enter Call Name of The Trainee: ", s => s.Length < 100);
            var domicileAddress = Utility.InputString("Enter Domicile Address of The Trainee: ", s => s.Length < 100);
            var phoneNumber = Utility.InputString("Enter Phone Number of The Trainee: ", s => s.Length < 14);
            var nik = Utility.InputInt("Enter NIK of The Trainee: ", Validation.IntValidation);
            var lastEducation = Utility.InputString("Enter Last Education of The Trainee: ", s => s.Length < 100);
            var password = Utility.InputString("Enter Password of The Trainee: ", s => s.Length < 100);
            var registerTrainee = new RegisterTrainee
            {
                Email = email,
                FirstName = firstName,
                LastName = lastName,
                CallName = callName,
                DomicileAddress = domicileAddress,
                PhoneNumber = phoneNumber,
                Nik = nik,
                LastEducation = lastEducation,
                IsActive = false,
                Password = password
            };
            var trainee = _traineeService.CreateNewTrainee(registerTrainee);
            Console.WriteLine(trainee);
            Console.WriteLine("Create Success!");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public void ActivationTraineeView()
    {
        try
        {
            var email = Utility.InputEmail("Enter Email of The Trainee: ", s => s.Length < 100);
            var trainee = _traineeService.GetByEmail(email);

            if (trainee.IsActive)
            {
                Console.WriteLine("Trainee was already active!!");
            }
            else
            {
                _traineeService.ActivationTrainee(trainee);
                Console.WriteLine($"Traine with email: {email}, Is Currently Active");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}