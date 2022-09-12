using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguageTechnologies.Models;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguageTechnologies.Queries.GetProgrammingLanguageTechnologyList;

public class GetProgrammingLanguageTechnologyListQuery:IRequest<ProgrammingLanguageTechnologyListModel>
{
    public PageRequest PageRequest { get; set; }
    
    public class GetProgrammingLanguageTechnologyListQueryHandler:IRequestHandler<GetProgrammingLanguageTechnologyListQuery,ProgrammingLanguageTechnologyListModel>
    {
        private readonly IProgrammingLanguageTechnologyRepository _programmingLanguageTechnologyRepository;
        private readonly IMapper _mapper;

        public GetProgrammingLanguageTechnologyListQueryHandler(IProgrammingLanguageTechnologyRepository programmingLanguageTechnologyRepository, IMapper mapper)
        {
            _programmingLanguageTechnologyRepository = programmingLanguageTechnologyRepository;
            _mapper = mapper;
        }

        public async Task<ProgrammingLanguageTechnologyListModel> Handle(GetProgrammingLanguageTechnologyListQuery request, CancellationToken cancellationToken)
        {
           IPaginate<ProgrammingLanguageTechnology> programmingLanguageTechnologys =  await _programmingLanguageTechnologyRepository.GetListAsync(include:
                x => x.Include(y => y.ProgrammingLanguage),
                index:request.PageRequest.Page,
                size:request.PageRequest.PageSize);

           ProgrammingLanguageTechnologyListModel mappedTechnologyListModel =  _mapper.Map<ProgrammingLanguageTechnologyListModel>(programmingLanguageTechnologys);
           return mappedTechnologyListModel;
        }
    }
    
}