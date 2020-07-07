using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LIBRARY.DataLayer.DB_Controler;
using LIBRARY.DataLayer.Modles;
using LIBRARY.View.Books;

namespace LIBRARY.View
{
    public partial class AddOrEditAction : Form
    {
        public int userId = 0;
        public int bookId;
        public AddOrEditAction()
        {
            InitializeComponent();
        }

        private void AddOrEditAction_Load(object sender, EventArgs e)
        {
            DGV_Customize.DGV_Customize.dgvdesign(dgvBook, 2);
            BooksBind();
            if (userId != 0)
            {
                using (ControlerDB db = new ControlerDB())
                {
                    var user = db.CustomersRepository.GetCustomerByID(userId);
                    this.Text = user.FullName;
                }
            }
        }

        void BooksBind()
        {
            using (ControlerDB db = new ControlerDB())
            {
                var books = db.BookRepository.get();
                
                List<BooksViewModel> book = new List<BooksViewModel>();
                foreach (var booktb in books)
                {
                    book.Add(new BooksViewModel {BookId = booktb.BookID, BookName = booktb.BookName});
                }
                DGV_Customize.DGV_Customize.DGV_Columns(dgvBook, 0, "ID", "BookID", "code", false);
                DGV_Customize.DGV_Customize.DGV_Columns(dgvBook, 1, "User", "BookName", "کتاب");
                dgvBook.AutoGenerateColumns = false;
                dgvBook.DataSource = book.ToList();

            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            using (ControlerDB db = new ControlerDB())
            {
                FromTb from = new FromTb()
                {
                    BookID = bookId,
                    Date = DateTime.Now,
                    Type = (rdbPay.Checked)? true : false,
                    UserID = userId
                };
                db.FromRepository.Insert(from);
                db.Save();
            }
            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSearchBook_TextChanged(object sender, EventArgs e)
        {
            using (ControlerDB db = new ControlerDB())
            {
                var books = db.BookRepository.get(tb => tb.BookName.Contains(txtSearchBook.Text));
                List<BooksViewModel> book = new List<BooksViewModel>();
                foreach (var booktb in books)
                {
                    book.Add(new BooksViewModel { BookId = booktb.BookID, BookName = booktb.BookName });
                }
                DGV_Customize.DGV_Customize.DGV_Columns(dgvBook, 0, "ID", "BookID", "code", false);
                DGV_Customize.DGV_Customize.DGV_Columns(dgvBook, 1, "User", "BookName", "کتاب");
                dgvBook.AutoGenerateColumns = false;
                dgvBook.DataSource = book.ToList();

            }
        }

        private void dgvBook_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtBookName.Text = dgvBook.CurrentRow.Cells[1].Value.ToString();
            bookId = int.Parse(dgvBook.CurrentRow.Cells[0].Value.ToString());
        }
    }
}
