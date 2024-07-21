using MilkStoreV4.DTOs;
using Repositories.Models;

namespace MilkStoreV4.Mappers
{
    public static class VoucherStatusMapper
    {
        public static VoucherStatusDTO ToVoucherStatusDTO(this Voucherstatus voucherstatus)
        {
            return new VoucherStatusDTO
            {
                VoucherStatusId = voucherstatus.VoucherStatusId,
                VoucherStatus = voucherstatus.VoucherStatus1,
            };
        }

        public static Voucherstatus ToVoucherStatusFromCreateDTO(this CreateVoucherStatusDTO voucherStatusDTO)
        {
            return new Voucherstatus
            {
                VoucherStatus1 = voucherStatusDTO.VoucherStatus
            };
        }

        public static void ToVoucherStatusFromUpdateDTO(UpdateVoucherStatusDTO voucherStatusDTO, Voucherstatus voucherstatus)
        {
            voucherstatus.VoucherStatus1 = voucherStatusDTO.VoucherStatus;
        }
    }
}
