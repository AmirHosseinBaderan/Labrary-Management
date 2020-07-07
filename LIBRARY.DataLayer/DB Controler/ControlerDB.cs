using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LIBRARY.DataLayer.Modles;
using LIBRARY.DataLayer.Reositoris;
using LIBRARY.DataLayer.Servises;

namespace LIBRARY.DataLayer.DB_Controler
{
    public class ControlerDB : IDisposable
    {
        Library_DBEntities db = new Library_DBEntities();
        private ICustomersRepository _customersRepository;

        public ICustomersRepository CustomersRepository
        {
            get
            {
                if(_customersRepository == null)
                {
                    _customersRepository = new CustoomerRepository(db);
                }

                return _customersRepository;
            }
        }

        private GenericRepository<BookTB> _booksRepository;
        public GenericRepository<BookTB> BookRepository
        {
            get
            {
                if (_booksRepository == null)
                {
                    _booksRepository = new GenericRepository<BookTB>(db);
                }

                return _booksRepository;
            }
        }

        private GenericRepository<FromTb> _fromRepository;
        public GenericRepository<FromTb> FromRepository
        {
            get
            {
                if (_booksRepository == null)
                {
                    _fromRepository = new GenericRepository<FromTb>(db);
                }

                return _fromRepository;
            }
        }



        public void Save()
        {
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
