using MilkStoreV4.DTOs;
using Repositories.Models;

namespace MilkStoreV4.Mappers
{
    public static class MilkMapper
    {
        public static MilkDTO ToMilkDTO(this Milk milk)
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

        public static void ToMilkFromUpdateDTO(UpdateMilkDTO milkDTO, Milk milk)
        {
            milk.MilkName = milkDTO.MilkName;
            milk.BrandId = milkDTO.BrandId;
            milk.Capacity = milkDTO.Capacity;
            milk.MilkTypeId = milkDTO.MilkTypeId;
            milk.AppropriateAge = milkDTO.AppropriateAge;
            milk.StorageInstructions = milkDTO.StorageInstructions;
            milk.Price = milkDTO.Price;
            milk.Discount = milkDTO.Discount;
        }
    }
}
