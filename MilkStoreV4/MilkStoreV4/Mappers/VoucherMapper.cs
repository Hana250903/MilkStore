using MilkStoreV4.DTOs;
using Repositories.Models;
using System.Globalization;

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
                StartDate = voucher.StartDate.ToString("G"),
                EndDate = voucher.EndDate.ToString("G"),
                Discount = voucher.Discount,
                Quantity = voucher.Quantity,
                Status = voucher.Status,
            };
        }
        public static Voucher ToVoucherFromCreateDTO(this CreateVoucherDTO voucher)
        {
            if (voucher.EndDate <= voucher.StartDate)
            {
               throw new Exception("EndDate must be greater than StartDate.");
            }
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
            if (voucherDTO.EndDate <= voucherDTO.StartDate)
            {
                throw new Exception("EndDate must be greater than StartDate.");
            }

            voucher.Title = voucherDTO.Title;
            voucher.StartDate = voucherDTO.StartDate;
            voucher.EndDate = voucherDTO.EndDate;
            voucher.Discount = voucherDTO.Discount;
            voucher.Quantity = voucherDTO.Quantity;
            voucher.Status = voucherDTO.Status;
        }
    }
}
