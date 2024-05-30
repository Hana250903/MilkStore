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


        public UnitOfWork(MilkStoreContext context)
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

        public GenericRepository<MilkType> MilkTypeRepository
        {
            get
            {
                if (_milkType == null)
                {
                    this._milkType = new GenericRepository<MilkType>(_context);
                }
                return _milkType;
            }
        }

        public GenericRepository<MilkPicture> MilkPictureRepository
        {
            get
            {
                if (_milkPicture == null)
                {
                    this._milkPicture = new GenericRepository<MilkPicture>(_context);
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

        public GenericRepository<OrderDetail> OrderDetailRepository
        {
            get
            {
                if (_orderDetail == null)
                {
                    this._orderDetail = new GenericRepository<OrderDetail>(_context);
                }
                return _orderDetail;
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
