using Core.Persistence.Repositories;

namespace Kodlama.io.Devs.Domain.Entities;

public class ProgrammingLanguage : Entity
{
    public string Name { get; set; }
    public ICollection<ProgrammingLanguageTechnology> ProgrammingLanguageTechnologies { get; set; }

    public ProgrammingLanguage()
    {
    }

    public ProgrammingLanguage(int id, string name)
    {
        Id = id;
        Name = name;
    }
}