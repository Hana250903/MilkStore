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
        private GenericRepository<Milk> _milk;
        private GenericRepository<MilkPicture> _milkPicture;
        private GenericRepository<Brand> _brand;
        private GenericRepository<MilkType> _milkType;
        private GenericRepository<OrderDetail> _orderDetail;
        private GenericRepository<Comment> _comment;
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

        public GenericRepository<Category> CategoryRepository
        {
            get
            {
                if (_category == null)
                {
                    this._category = new GenericRepository<Category>(_context);
                }
                return _category;
            }

        }
        public GenericRepository<Product> ProductRepository
        {
            get
            {
                if (_product == null)
                {
                    this._product = new GenericRepository<Product>(_context);
                }
                return _product;
            }
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
