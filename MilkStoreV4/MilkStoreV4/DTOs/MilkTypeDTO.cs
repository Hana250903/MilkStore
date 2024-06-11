namespace MilkStoreV4.DTOs
{
    public class MilkTypeDTO
    {
        public int MilkTypeId { get; set; }

        public string TypeName { get; set; }
    }

    public class CreateMilkTypeDTO
    {
        public string TypeName { get; set; }
    }

    public class UpdateMilkTypeDTO
    {
        public string TypeName { get; set; }
    }
}
