using YukNgoding_Livecode.DTO;
using YukNgoding_Livecode.Entities;
using YukNgoding_Livecode.Repository;

namespace YukNgoding_Livecode.Services;

public class TraineeService : ITraineeService
{
    private readonly ITraineeRepository _traineeRepository;
    private readonly IPersistence _persistence;

    public TraineeService(ITraineeRepository traineeRepository, IPersistence persistence)
    {
        _traineeRepository = traineeRepository;
        _persistence = persistence;
    }

    public Trainee CreateNewTrainee(RegisterTrainee registerTrainee)
    {
        _persistence.BeginTransaction();
        try
        {
            var trainee = new Trainee
            {
                Email = registerTrainee.Email,
                FirstName = registerTrainee.FirstName,
                LastName = registerTrainee.LastName,
                CallName = registerTrainee.CallName,
                DomicileAddress = registerTrainee.DomicileAddress,
                PhoneNumber = registerTrainee.PhoneNumber,
                Nik = registerTrainee.Nik,
                LastEducation = registerTrainee.LastEducation,
                IsActive = false,
                Credential = new Credential
                {
                    Password = registerTrainee.Password
                }
            };
            _traineeRepository.Save(trainee);
            _persistence.SaveChanges();
            _persistence.Commit();
            return trainee;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            _persistence.Rollback();
            throw;
        }
    }

    public Trainee GetByEmail(string email)
    {
        try
        {
            var trainee = _traineeRepository.FindByEmail(email);
            if (trainee is null) throw new Exception("Trainee Not Found!!");
            return trainee;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public Trainee GetByEmailWithActive(string email)
    {
        try
        {
            var trainee = _traineeRepository.FindByEmailIsActive(email);
            if (trainee is null) throw new Exception("Trainee Not Found!!");
            return trainee;
            
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public void ActivationTrainee(Trainee trainee)
    {
        _persistence.BeginTransaction();
        try
        {
            var traineeToActive = GetByEmail(trainee.Email);
            traineeToActive.IsActive = true;
            _traineeRepository.UpdateIsActive(traineeToActive);
            _persistence.SaveChanges();
            _persistence.Commit();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            _persistence.Rollback();
            throw;
        }
    }

    public List<Trainee> GetAll()
    {
        return _traineeRepository.GetAll();
    }

    public List<Trainee> GetAllInactive()
    {
        return _traineeRepository.GetAllInactive();
    }

    public List<Trainee> GetAllActive()
    {
        return _traineeRepository.GetAllAactive();
    }
}