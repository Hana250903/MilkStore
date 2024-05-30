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
        private MilkStoreContext _context;
        private GenericRepository<Admin> _admin;
        private GenericRepository<Order> _order;
        private GenericRepository<User> _user;
        private GenericRepository<Role> _role;
        private GenericRepository<Staff> _staff;
        private GenericRepository<Member> _member;
        private GenericRepository<Voucher> _voucher;

        public UnitOfWork(MilkStoreContext context)
        {
            _context = context;
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
