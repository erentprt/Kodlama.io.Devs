using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguageTechnologies.Dtos;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguageTechnologies.Models;

public class ProgrammingLanguageTechnologyListModel:BasePageableModel
{
    public IList<ProgrammingLanguageTechnologyListDto> Items { get; set; }
}