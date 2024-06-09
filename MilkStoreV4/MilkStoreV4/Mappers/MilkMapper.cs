using MilkStoreV4.DTOs;
using Repositories.Models;

namespace MilkStoreV4.Mappers
{
    public static class MilkMapper
    {
        public static MilkDTO ToMilkDTO(this MilkDTO milk)
        {
            return new MilkDTO
            {
                MilkId = milk.MilkId,
                MilkName = milk.MilkName,
                BrandId = milk.BrandId,
                Capacity = milk.Capacity,
                MilkTypeId = milk.MilkTypeId,
                AppropriateAge = milk.AppropriateAge,
                StorageInstructions = milk.StorageInstructions,
                Price = milk.Price,
                Discount = milk.Discount,
            };
        }

        public static Milk ToMilkFromCreateDTO(this CreateMilkDTO milk)
        {
            return new Milk
            {
                MilkName = milk.MilkName,
                BrandId = milk.BrandId,
                Capacity = milk.Capacity,
                MilkTypeId = milk.MilkTypeId,
                AppropriateAge = milk.AppropriateAge,
                StorageInstructions = milk.StorageInstructions,
                Price = milk.Price,
                Discount = milk.Discount,
            };
        }

        public static Milk ToMilkFromUpdateDTO(this UpdateMilkDTO milk)
        {
            return new Milk
            {
                MilkName = milk.MilkName,
                BrandId = milk.BrandId,
                Capacity = milk.Capacity,
                MilkTypeId = milk.MilkTypeId,
                AppropriateAge = milk.AppropriateAge,
                StorageInstructions = milk.StorageInstructions,
                Price = milk.Price,
                Discount = milk.Discount,
            };
        }
    }
}
