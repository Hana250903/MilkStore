using MilkStoreV4.DTOs;
using Repositories.Models;

namespace MilkStoreV4.Mappers
{
    public static class StatusMapper
    {
        public static StatusDTO ToStatusDTO(this Status statusDTO)
        {
            return new StatusDTO
            {
                StatusId = statusDTO.StatusId,
                Status = statusDTO.Status1,
            };
        }

        public static Status ToStatusFromCreateDTO(this CreateStatusDTO statusDTO)
        {
            return new Status
            {
                Status1 = statusDTO.Status
            };
        }

        public static void ToStatusFromUpdateDTO(this UpdateStatusDTO statusDTO, Status status)
        {
            status.Status1 = statusDTO.Status;
        }
    }
}
