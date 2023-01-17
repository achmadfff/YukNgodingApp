using YukNgoding_Livecode.DTO;
using YukNgoding_Livecode.Entities;

namespace YukNgoding_Livecode.Services;

public interface ITraineeService
{
    Trainee CreateNewTrainee(RegisterTrainee registerTrainee);

    Trainee GetByEmail(string email);
    Trainee GetByEmailWithActive(string email);

    void ActivationTrainee(Trainee trainee);

    List<Trainee> GetAll();
    List<Trainee> GetAllInactive();
    List<Trainee> GetAllActive();
}