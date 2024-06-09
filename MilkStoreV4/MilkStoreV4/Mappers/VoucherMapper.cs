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
                StartDate = voucher.StartDate,
                EndDate = voucher.EndDate,
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
        public static Voucher ToVoucherFromUpdateDTO(this UpdateVoucherDTO voucher)
        {
            return new Voucher
            {
                Title = voucher.Title,
                Discount = voucher.Discount,
                Quantity = voucher.Quantity,
                Status = voucher.Status,
            };
        }
    }
}
