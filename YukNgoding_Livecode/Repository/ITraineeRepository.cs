using YukNgoding_Livecode.DTO;
using YukNgoding_Livecode.Entities;

namespace YukNgoding_Livecode.Repository;

public interface ITraineeRepository
{
    Trainee Save(Trainee trainee);
    Trainee? FindByEmail(string email);
    Trainee? FindByEmailIsActive(string email);

    void UpdateIsActive(Trainee trainee);
    List<Trainee> GetAll();
    List<Trainee> GetAllInactive();
    List<Trainee> GetAllAactive();
}