using Repositories.Models;
using Repositories.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private MilkstoreContext _context;
        private GenericRepository<Milk> _milk;
        private GenericRepository<Milkpicture> _milkPicture;
        private GenericRepository<Brand> _brand;
        private GenericRepository<Milktype> _milkType;
        private GenericRepository<Orderdetail> _orderDetail;
        private GenericRepository<Comment> _comment;
        private GenericRepository<Commentpicture> _commentPicture;
        private GenericRepository<Admin> _admin;
        private GenericRepository<Order> _order;
        private GenericRepository<User> _user;
        private GenericRepository<Role> _role;
        private GenericRepository<Staff> _staff;
        private GenericRepository<Status> _status;
        private GenericRepository<Member> _member;
        private GenericRepository<Voucher> _voucher; 
        private GenericRepository<Voucherstatus> _voucherStatus;

        public UnitOfWork(MilkstoreContext context)
        {
            _context = context;
        }

        public GenericRepository<Milk> MilkRepository
        {
            get
            {
                if (_milk == null)
                {
                    this._milk = new GenericRepository<Milk>(_context);
                }
                return _milk;
            }
        }

        public GenericRepository<Brand> BrandRepository
        {
            get
            {
                if (_brand == null)
                {
                    this._brand = new GenericRepository<Brand>(_context);
                }
                return _brand;
            }
        }

        public GenericRepository<Milktype> MilkTypeRepository
        {
            get
            {
                if (_milkType == null)
                {
                    this._milkType = new GenericRepository<Milktype>(_context);
                }
                return _milkType;
            }
        }

        public GenericRepository<Milkpicture> MilkPictureRepository
        {
            get
            {
                if (_milkPicture == null)
                {
                    this._milkPicture = new GenericRepository<Milkpicture>(_context);
                }
                return _milkPicture;
            }
        }

        public GenericRepository<Comment> CommentRepository
        {
            get
            {
                if (_comment == null)
                {
                    this._comment = new GenericRepository<Comment>(_context);
                }
                return _comment;
            }
        }

        public GenericRepository<Commentpicture> CommentPictureRepository
        {
            get
            {
                if (_commentPicture == null)
                {
                    this._commentPicture = new GenericRepository<Commentpicture>(_context);
                }
                return _commentPicture;
            }
        }

        public GenericRepository<Orderdetail> OrderDetailRepository
        {
            get
            {
                if (_orderDetail == null)
                {
                    this._orderDetail = new GenericRepository<Orderdetail>(_context);
                }
                return _orderDetail;
            }
        }

        public GenericRepository<Admin> AdminRepository
        {
            get
            {
                if (_admin == null)
                {
                    this._admin = new GenericRepository<Admin>(_context);
                }
                return _admin;
            }
        }

        public GenericRepository<User> UserRepository
        {
            get
            {
                if (_user == null)
                {
                    this._user = new GenericRepository<User>(_context);
                }
                return _user;
            }
        }

        public GenericRepository<Role> RoleRepository
        {
            get
            {
                if (_role == null)
                {
                    this._role = new GenericRepository<Role>(_context);
                }
                return _role;
            }
        }

        public GenericRepository<Staff> StaffRepository
        {
            get
            {
                if (_staff == null)
                {
                    this._staff = new GenericRepository<Staff>(_context);
                }
                return _staff;
            }
        }

        public GenericRepository<Status> StatusRepository
        {
            get
            {
                if (_status == null)
                {
                    this._status = new GenericRepository<Status>(_context);
                }
                return _status;
            }
        }

        public GenericRepository<Member> MemberRepository
        {
            get
            {
                if (_member == null)
                {
                    this._member = new GenericRepository<Member>(_context);
                }
                return _member;
            }
        }

        public GenericRepository<Order> OrderRepository
        {
            get
            {
                if (_order == null)
                {
                    this._order = new GenericRepository<Order>(_context);
                }
                return _order;
            }
        }

        public GenericRepository<Voucher> VoucherRepository
        {
            get
            {
                if (_voucher == null)
                {
                    this._voucher = new GenericRepository<Voucher>(_context);
                }
                return _voucher;
            }
        }

        public GenericRepository<Voucherstatus> VoucherStatusRepository
        {
            get
            {
                if(_voucherStatus == null)
                {
                    this._voucherStatus = new GenericRepository<Voucherstatus>(_context);
                }
                return _voucherStatus;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task<UnitOfWork> SaveAsync()
        {
            await _context.SaveChangesAsync();
            return this;
        }
    }
}
