using MilkStoreV4.DTOs;
using Repositories.Models;

namespace MilkStoreV4.Mappers
{
    public static class VoucherMapper
    {
        public static VoucherDTO ToVoucherDTO(this Voucher voucher)
        {
            return new VoucherDTO
            {
                VoucherId = voucher.VoucherId,
                Title = voucher.Title,
                StartDate = voucher.StartDate.ToString("yyyy-MM-dd HH:mm"),
                EndDate = voucher.EndDate.ToString("yyyy-MM-dd HH:mm"),
                Discount = voucher.Discount,
                Quantity = voucher.Quantity,
                Status = voucher.Status,
            };
        }
        public static Voucher ToVoucherFromCreateDTO(this CreateVoucherDTO voucher)
        {
            return new Voucher
            {
                Title = voucher.Title,
                StartDate = voucher.StartDate,
                EndDate = voucher.EndDate,
                Discount = voucher.Discount,
                Quantity = voucher.Quantity,
                Status = voucher.Status,
            };
        }
        public static void ToVoucherFromUpdateDTO(this UpdateVoucherDTO voucherDTO, Voucher voucher)
        {
            voucher.Title = voucherDTO.Title;
            voucher.StartDate = voucherDTO.StartDate;
            voucher.EndDate = voucherDTO.EndDate;
            voucher.Discount = voucherDTO.Discount;
            voucher.Quantity = voucherDTO.Quantity;
            voucher.Status = voucherDTO.Status;
        }
    }
}
