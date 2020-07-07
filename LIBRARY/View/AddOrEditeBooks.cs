using System;
using System.Windows.Forms;
using LIBRARY.DataLayer.DB_Controler;
using LIBRARY.DataLayer.Modles;
using ValidationComponents;

namespace LIBRARY.View
{
    public partial class AddOrEditeBooks : Form
    {
        public int BookId = 0;
        public AddOrEditeBooks()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (BaseValidator.IsFormValid(this.components))
            {
                BookTB book = new BookTB()
                {
                    BookName = txtBookName.Text,
                    Code = txtBookCode.Text,
                    Publishare = txtPublishare.Text,
                    Writer = txtWriter.Text
                };
                using (ControlerDB db = new ControlerDB())
                {
                    if (BookId ==0)
                    {
                        db.BookRepository.Insert(book);
                        db.Save();
                    }
                    else
                    {
                        book.BookID = BookId;
                        db.BookRepository.Updatae(book);
                        db.Save();
                    }
                }
                DialogResult = DialogResult.OK;
            }
        }

        private void AddOrEditeBooks_Load(object sender, EventArgs e)
        {
            if (BookId != 0)
            {
                using (ControlerDB db = new ControlerDB())
                {
                   var book = db.BookRepository.GetByID(BookId);
                   this.Text = "ویرایش " + book.BookName;
                   this.txtBookName.Text = book.BookName;
                   this.txtBookCode.Text = book.Code;
                   this.txtPublishare.Text = book.Publishare;
                   this.txtWriter.Text = book.Writer;
                   this.btnSubmit.Text = "ویرایش";
                }
              
            }
        }

        private void txtBookName_TextChanged(object sender, EventArgs e)
        {
            if (txtBookName.Text.Length ==20)
            {
                MessageBox.Show("اندازه کارکتر ها بیشتر است");
            }
        }
    }
}
