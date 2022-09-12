using Core.Persistence.Repositories;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using Kodlama.io.Devs.Persistence.Contexts;

namespace Kodlama.io.Devs.Persistence.Repositories;

public class ProgrammingLanguageTechnologyRepository:EfRepositoryBase<ProgrammingLanguageTechnology,KodlamaioDevsContext>,IProgrammingLanguageTechnologyRepository
{
    public ProgrammingLanguageTechnologyRepository(KodlamaioDevsContext context) : base(context)
    {
    }
}