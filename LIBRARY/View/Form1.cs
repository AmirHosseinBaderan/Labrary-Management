using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using LIBRARY.Utilitys;
using LIBRARY.DataLayer.DB_Controler;
using LIBRARY.View;
using LIBRARY.View.From;

namespace LIBRARY
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblDate.Text = DateTime.Now.Toshamsi();
            lblTime.Text = DateTime.Now.ToString("HH:mm:ss");


            #region CustomersData
            //Data Grid View Design  
            DGV_Customize.DGV_Customize.dgvdesign(dgvCustomers, 5);
            UsersBind();
            #endregion
            #region FromDate
            DGV_Customize.DGV_Customize.dgvdesign(dgvFrom, 5);
            FromBimd();
            #endregion
            #region booksData
            DGV_Customize.DGV_Customize.dgvdesign(dgvBooks, 5);
            BooksBind();
            #endregion
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        #region Colors


        private void btnBlack_Click(object sender, EventArgs e)
        {
            BackColor = Color.Black;
        }

        private void btnWhite_Click(object sender, EventArgs e)
        {
            BackColor = Color.White;
        }

        private void btnBlue_Click(object sender, EventArgs e)
        {
            BackColor = Color.Blue;
        }

        private void btnRed_Click(object sender, EventArgs e)
        {
            BackColor = Color.Red;
        }

        private void btnBrown_Click(object sender, EventArgs e)
        {
            BackColor = Color.Brown;
        }

        private void btnyellow_Click(object sender, EventArgs e)
        {
            BackColor = Color.Yellow;
        }

        private void btnGreen_Click(object sender, EventArgs e)
        {
            BackColor = Color.Green;
        }

        private void btnBlackBook_Click(object sender, EventArgs e)
        {
            tbpBooks.BackColor = Color.Black;
        }

        private void btnWhitebook_Click(object sender, EventArgs e)
        {
            tbpBooks.BackColor = Color.White;
        }

        private void btnBlueBooks_Click(object sender, EventArgs e)
        {
            tbpBooks.BackColor = Color.Blue;
        }

        private void btnRedBooks_Click(object sender, EventArgs e)
        {
            tbpBooks.BackColor = Color.Red;
        }

        private void btnYellowBooks_Click(object sender, EventArgs e)
        {
            tbpBooks.BackColor = Color.Yellow;
        }

        private void btnGreenBooks_Click(object sender, EventArgs e)
        {
            tbpBooks.BackColor = Color.Green;
        }

        private void btnBrownBooks_Click(object sender, EventArgs e)
        {
            tbpBooks.BackColor = Color.Brown;
        }

        private void btnblackCustomer_Click(object sender, EventArgs e)
        {
            tbpCustomers.BackColor = Color.Black;
        }

        private void btnBlueCustomer_Click(object sender, EventArgs e)
        {
            tbpCustomers.BackColor = Color.Blue;
        }

        private void btnWhiteCustomer_Click(object sender, EventArgs e)
        {
            tbpCustomers.BackColor = Color.White;
        }

        private void btnRedCustomer_Click(object sender, EventArgs e)
        {
            tbpCustomers.BackColor = Color.Red;
        }

        private void btnYellowCustomer_Click(object sender, EventArgs e)
        {
            tbpCustomers.BackColor = Color.Yellow;
        }

        private void btnGreenCustomer_Click(object sender, EventArgs e)
        {
            tbpCustomers.BackColor = Color.Green;
        }

        private void btnBrownCustomer_Click(object sender, EventArgs e)
        {
            tbpCustomers.BackColor = Color.Brown;
        }

        #endregion

        #region ColorCustomizeDataGridView
        //Data Grid view Customize Customers
        private void مسکیToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dgvBooks.BackgroundColor = Color.Black;
        }

        private void سفیدToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dgvBooks.BackgroundColor = Color.White;
        }

        private void dgvBlue_Click(object sender, EventArgs e)
        {
            dgvBooks.BackgroundColor = Color.Blue;
        }

        private void red_Click(object sender, EventArgs e)
        {
            dgvBooks.BackgroundColor = Color.Red;
        }

        private void yellow_Click(object sender, EventArgs e)
        {
            dgvBooks.BackgroundColor = Color.Yellow;
        }

        private void brown_Click(object sender, EventArgs e)
        {
            dgvBooks.BackgroundColor = Color.Brown;
        }

        //Data Grid View Customize books
        private void Cblack_Click(object sender, EventArgs e)
        {
            dgvCustomers.BackgroundColor = Color.Black;
        }

        private void Cwhite_Click(object sender, EventArgs e)
        {
            dgvCustomers.BackgroundColor = Color.White;
        }

        private void CBlue_Click(object sender, EventArgs e)
        {
            dgvCustomers.BackgroundColor = Color.Blue;
        }

        private void CRed_Click(object sender, EventArgs e)
        {
            dgvCustomers.BackgroundColor = Color.Red;
        }

        private void CYellow_Click(object sender, EventArgs e)
        {
            dgvCustomers.BackgroundColor = Color.Yellow;
        }

        private void CBrown_Click(object sender, EventArgs e)
        {
            dgvCustomers.BackgroundColor = Color.Brown;
        }



        #endregion

        private void btnInsertBooks_Click(object sender, EventArgs e)
        {
            AddOrEditeBooks frmAddBooks = new AddOrEditeBooks();
            if (frmAddBooks.ShowDialog() == DialogResult.OK)
            {
                BooksBind();
            }
        }

        private void btnInsertCustomer_Click(object sender, EventArgs e)
        {
            AddOREditeCustomers frmAddCustomers = new AddOREditeCustomers();
            if (frmAddCustomers.ShowDialog() == DialogResult.OK)
            {
                UsersBind();
            }
        }

        #region DataBinding

        void UsersBind()
        {
            using (ControlerDB db = new ControlerDB())
            {
                DGV_Customize.DGV_Customize.DGV_Columns(dgvCustomers, 0, "ID", "CustomerID", "Code", false);
                DGV_Customize.DGV_Customize.DGV_Columns(dgvCustomers, 1, "FullName", "FullName", "نام");
                DGV_Customize.DGV_Customize.DGV_Columns(dgvCustomers, 2, "Phone", "Phone", "تلفن");
                DGV_Customize.DGV_Customize.DGV_Columns(dgvCustomers, 3, "Email", "Email", "ایمیل");
                DGV_Customize.DGV_Customize.DGV_Columns(dgvCustomers, 4, "Address", "Address", "آدرس");
                //Data Grid View Source And InforMation 
                dgvCustomers.AutoGenerateColumns = false;
                dgvCustomers.DataSource = db.CustomersRepository.GetAllCustomer();
                db.Dispose();
            }
        }

        void BooksBind()
        {
            using (ControlerDB db = new ControlerDB())
            {
                DGV_Customize.DGV_Customize.DGV_Columns(dgvBooks, 0, "ID", "BookID", "Cod", false);
                DGV_Customize.DGV_Customize.DGV_Columns(dgvBooks, 1, "name", "BookName", "نام کتاب");
                DGV_Customize.DGV_Customize.DGV_Columns(dgvBooks, 2, "Writer", "Writer", "نویسنده");
                DGV_Customize.DGV_Customize.DGV_Columns(dgvBooks, 3, "Publishare", "Publishare", "انتشارات");
                DGV_Customize.DGV_Customize.DGV_Columns(dgvBooks, 4, "Code", "Code", "کد");

                dgvBooks.AutoGenerateColumns = false;
                dgvBooks.DataSource = db.BookRepository.get();
                db.Dispose();

            }
        }

        void FromBimd()
        {
            using (ControlerDB db = new ControlerDB())
            {
                DGV_Customize.DGV_Customize.DGV_Columns(dgvFrom, 0, "ID", "ID", "code", false);
                DGV_Customize.DGV_Customize.DGV_Columns(dgvFrom, 1, "User", "UserName", "کاربر");
                DGV_Customize.DGV_Customize.DGV_Columns(dgvFrom, 2, "Book", "BookName", "کتاب");
                DGV_Customize.DGV_Customize.DGV_Columns(dgvFrom, 3, "Date", "DateTime", "تاریخ");
                DGV_Customize.DGV_Customize.DGV_Columns(dgvFrom, 4, "Type", "Type", "نوع");

                dgvFrom.AutoGenerateColumns = false;
                List<FromViewModel> fromViewModels = new List<FromViewModel>();
                var froms = db.FromRepository.get();
                foreach (var fromTb in froms)
                {
                    FromViewModel from = new FromViewModel()
                    {
                        Type = (fromTb.Type) ? "تحویل" : "دریافت",
                        BookName = fromTb.BookTB.BookName,
                        UserName = fromTb.CustomerTB.FullName,
                        FromId = fromTb.ID,
                        DateTime = fromTb.Date.Toshamsi()
                    };
                    fromViewModels.Add(from);
                }

                dgvFrom.DataSource = fromViewModels.ToList();
            }

        }

        #endregion




        private void btnRefreshCustomer_Click(object sender, EventArgs e)
        {
            UsersBind();
        }

        private void txtSearchCustomer_TextChanged(object sender, EventArgs e)
        {
            using (ControlerDB db = new ControlerDB())
            {
                dgvCustomers.DataSource = db.CustomersRepository.GetCustomersByFilter(txtSearchCustomer.Text);
            }
        }

        private void btnrefreshBooks_Click(object sender, EventArgs e)
        {
            BooksBind();
        }

        private void btnDeleteCustomer_Click(object sender, EventArgs e)
        {
            if (dgvCustomers.CurrentRow != null)
            {
                int userid = int.Parse(dgvCustomers.CurrentRow.Cells[0].Value.ToString());
                using (ControlerDB db = new ControlerDB())
                {
                    if (MessageBox.Show("ایا از حذف اطمینان دارید؟", "هشدار", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        var user = db.CustomersRepository.GetCustomerByID(userid);
                        File.Delete(Application.StartupPath + "/Images/" + user.CustomerIMG);
                        db.CustomersRepository.DeleteCustomer(userid);
                        db.Save();
                        UsersBind();
                    }
                }
            }
            else
            {
                MessageBox.Show("لطفا یک نغر را انتخاب کنید", "خطا", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        private void dgvCustomers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCustomers.CurrentRow != null)
            {
                int userid = int.Parse(dgvCustomers.CurrentRow.Cells[0].Value.ToString());
                using (ControlerDB db = new ControlerDB())
                {
                    string imagename = Application.StartupPath + "/Images/" + db.CustomersRepository.GetCustomerpictourById(userid);
                    pcCustomers.ImageLocation = imagename;
                }
            }
        }

        private void btnEditeCustomer_Click(object sender, EventArgs e)
        {
            if (dgvCustomers.CurrentRow != null)
            {
                int userid = int.Parse(dgvCustomers.CurrentRow.Cells[0].Value.ToString());
                AddOREditeCustomers editCustomers = new AddOREditeCustomers();
                editCustomers.userId = userid;
                if (editCustomers.ShowDialog() == DialogResult.OK)
                {
                    UsersBind();
                }
            }
            else
            {
                MessageBox.Show("لطفا یک نغر را انتخاب کنید", "خطا", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        private void btnEditeBooks_Click(object sender, EventArgs e)
        {
            if (dgvBooks.CurrentRow != null)
            {
                int bookId = int.Parse(dgvBooks.CurrentRow.Cells[0].Value.ToString());
                AddOrEditeBooks editBooks = new AddOrEditeBooks();
                editBooks.BookId = bookId;
                if (editBooks.ShowDialog() == DialogResult.OK)
                {
                    BooksBind();
                }
            }
            else
            {
                MessageBox.Show("لطفا یک نغر را انتخاب کنید", "خطا", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        private void btnNewAction_Click(object sender, EventArgs e)
        {
            AddOrEditAction addAction = new AddOrEditAction();
            if (dgvCustomers.CurrentRow != null)
            {
                int userid = int.Parse(dgvCustomers.CurrentRow.Cells[0].Value.ToString());
                addAction.userId = userid;
                if (addAction.ShowDialog() == DialogResult.OK)
                {
                    FromBimd();
                }
            }
        }

        private void btnDeleteBooks_Click(object sender, EventArgs e)
        {
            if (dgvBooks.CurrentRow != null)
            {
                int bookId = int.Parse(dgvBooks.CurrentRow.Cells[0].Value.ToString());
                if (MessageBox.Show("ایا میخواهید این کتاب را حذف کنید؟", "هشدار", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    using (ControlerDB db = new ControlerDB())
                    {
                        try
                        {
                            var form = db.FromRepository.get(fr => fr.BookID == bookId);
                            foreach (var fromTb in form)
                            {
                                db.FromRepository.Delete(fromTb);
                            }
                            db.BookRepository.Delete(bookId);
                            db.Save();
                            BooksBind();
                            FromBimd();
                        }
                        catch
                        {
                            MessageBox.Show("حذف با خطا مواجه شد");
                        }
                        db.Save();
                        BooksBind();
                    }
                }
            }
            else
            {
                MessageBox.Show("لطفا یک نغر را انتخاب کنید", "خطا", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        private void txtSearchBooks_TextChanged(object sender, EventArgs e)
        {
            using (ControlerDB db = new ControlerDB())
            {
                dgvBooks.DataSource = db.BookRepository.get(tb => tb.BookName.Contains(txtSearchBooks.Text) || tb.Publishare.Contains(txtSearchBooks.Text) || tb.Writer.Contains(txtSearchBooks.Text));
            }
        }
    }
}
