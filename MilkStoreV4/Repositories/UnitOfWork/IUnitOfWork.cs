using Repositories.Models;
using Repositories.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.UnitOfWork
{
    public interface IUnitOfWork
    {
        void Save();

        Task<UnitOfWork> SaveAsync();
        GenericRepository<Milk> MilkRepository { get; }
        GenericRepository<Brand> BrandRepository { get; }
        GenericRepository<MilkType> MilkTypeRepository { get; }
        GenericRepository<MilkPicture> MilkPictureRepository { get; }
        GenericRepository<Comment> CommentRepository { get; }
        GenericRepository<OrderDetail> OrderDetailRepository { get; }
        GenericRepository<Admin> AdminRepository { get; }
        GenericRepository<User> UserRepository { get; }
        GenericRepository<Role> RoleRepository { get; }
        GenericRepository<Staff> StaffRepository { get; }
        GenericRepository<Member> MemberRepository { get; }
        GenericRepository<Order> OrderRepository { get; }
        GenericRepository<Voucher> VoucherRepository { get; }
    }
}
