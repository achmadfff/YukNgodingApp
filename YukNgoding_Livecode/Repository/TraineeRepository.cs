using YukNgoding_Livecode.DTO;
using YukNgoding_Livecode.Entities;

namespace YukNgoding_Livecode.Repository;

public class TraineeRepository : ITraineeRepository
{
    private readonly AppDbContext _appDbContext;

    public TraineeRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public Trainee Save(Trainee trainee)
    {
        return _appDbContext.Trainees.Add(trainee).Entity;
    }

    public Trainee? FindByEmail(string email)
    {
        return _appDbContext.Trainees.FirstOrDefault(trainee => trainee.Email.Equals(email));
    }

    public Trainee? FindByEmailIsActive(string email)
    {
        return _appDbContext.Trainees.FirstOrDefault(trainee => trainee.Email.Equals(email));
    }

    public void UpdateIsActive(Trainee trainee)
    {
        _appDbContext.Trainees.Update(trainee);
    }

    public List<Trainee> GetAll()
    {
        return _appDbContext.Trainees.ToList();
    }

    public List<Trainee> GetAllInactive()
    {
        return _appDbContext.Trainees.Where(trainee => trainee.IsActive == false).ToList();
    }

    public List<Trainee> GetAllAactive()
    {
        return _appDbContext.Trainees.Where(trainee => trainee.IsActive == true).ToList();
    }
}