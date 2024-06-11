using AutoMapper;
using MilkStoreV4.DTOs;
using Repositories.Models;

namespace MilkStoreV4.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Admin, AdminDTO>();
            CreateMap<CreateAdminDTO, Admin>();
            CreateMap<Member, MemberDTO>();
            CreateMap<CreateMemberDTO, Member>();
            CreateMap<Order, OrderDTO>();
            CreateMap<CreateOrderDTO, Order>();
            CreateMap<Role, RoleDTO>();
            CreateMap<CreateRoleDTO, Role>();
            CreateMap<Staff, StaffDTO>();
            CreateMap<CreateStaffDTO, Staff>();
            CreateMap<User, UserDTO>();
            CreateMap<CreateUserDTO, User>();
            CreateMap<Comment, CommentDTO>();
            CreateMap<CreateCommentDTO, Comment>();
            CreateMap<Voucher,  VoucherDTO>();
            CreateMap<CreateVoucherDTO, Voucher>();
            CreateMap<Milk, MilkDTO>();
            CreateMap<CreateMilkDTO, Milk>();
            CreateMap<MilkPicture, MilkPictureDTO>();
            CreateMap<CreateMilkPictureDTO, MilkPicture>();
            CreateMap<MilkType, MilkTypeDTO>();
            CreateMap<CreateMilkTypeDTO, MilkType>();
            CreateMap<Brand, BrandDTO>();
            CreateMap<CreateBrandDTO, Brand>();
            CreateMap<OrderDetail, OrderDetailDTO>();
            CreateMap<CreateOrderDetailDTO, OrderDetail>();
        }
    }
}
