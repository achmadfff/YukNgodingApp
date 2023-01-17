using YukNgoding_Livecode.Entities;

namespace YukNgoding_Livecode.Repository;

public class CredentialRepository : ICredentialRepository
{
    private readonly AppDbContext _appDbContext;

    public CredentialRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public void Save(Credential credential)
    {
        _appDbContext.Credentials.Add(credential);
    }
}