using YukNgoding_Livecode.Entities;

namespace YukNgoding_Livecode.Repository;

public interface ICredentialRepository
{
    void Save(Credential credential);
}