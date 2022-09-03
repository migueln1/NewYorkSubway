using MediatR;
using NewYorkSubway.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewYorkSubway.Application.Handlers.Queries.Entrances
{
    public class GetAllEntrancesQuery : IRequest<GetAllEntrancesResponseDto> { };
    public class AllEntrancesQueryHandler : IRequestHandler<GetAllEntrancesQuery, GetAllEntrancesResponseDto>
    {
        //private readonly IEntranceService
        public AllEntrancesQueryHandler()
        {

        }
        Task<GetAllEntrancesResponseDto> IRequestHandler<GetAllEntrancesQuery, GetAllEntrancesResponseDto>.Handle(GetAllEntrancesQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
