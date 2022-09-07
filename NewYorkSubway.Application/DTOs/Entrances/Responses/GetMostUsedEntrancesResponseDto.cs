using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewYorkSubway.Application.DTOs
{
    public class UsedEntranceDto
    {
        public string? EntranceName { get; init; }
        public int Count { get; init; }
        public int EntranceId { get; internal set; }
    }
    public record GetMostUsedEntrancesResponseDto : BaseResponse
    {
        public GetMostUsedEntrancesResponseDto(bool IsSuccess, string? Message) 
            :base(IsSuccess, Message)
        {}
        public List<UsedEntranceDto>? Entrances { get; set; }
    }
}
