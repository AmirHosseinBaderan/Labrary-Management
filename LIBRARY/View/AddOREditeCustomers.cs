using System;
using System.IO;
using System.Windows.Forms;
using LIBRARY.DataLayer.DB_Controler;
using LIBRARY.DataLayer.Modles;
using ValidationComponents;

namespace LIBRARY.View
{
    public partial class AddOREditeCustomers : Form
    {
        public int userId = 0;
        public AddOREditeCustomers()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {

            using (ControlerDB db = new ControlerDB())
            {
                string path = Application.StartupPath + "/Images/";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                string imagename = Guid.NewGuid().ToString() +
                                   Path.GetExtension(pcCustomer.ImageLocation);
                pcCustomer.Image.Save(path + imagename);
                if (BaseValidator.IsFormValid(this.components))
                {
                    CustomerTB customer = new CustomerTB()
                    {
                        FullName = txtFullName.Text,
                        Address = txtAddress.Text,
                        Email = txtEmail.Text,
                        Phone = txtPhone.Text,
                        CustomerIMG = imagename
                    };
                    if (userId == 0)
                    {
                        db.CustomersRepository.InsertCustomers(customer);
                    }

                    if (userId != 0)
                    {
                        customer.CustomerID = userId;
                        db.CustomersRepository.UpdateCustomer(customer);
                    }
                    db.Save();
                }

                DialogResult = DialogResult.OK;
            }
        }

        private void btnCansel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSelectPicture_Click(object sender, EventArgs e)
        {
            FileDialog fileDialog = new OpenFileDialog();
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                pcCustomer.ImageLocation = fileDialog.FileName;
                //fileDialog.Dispose();
                fileDialog.Dispose();
            }

        }

        private void AddOREditeCustomers_Load(object sender, EventArgs e)
        {
            if (userId != 0)
            {
                using (ControlerDB db= new ControlerDB())
                {
                    var  user = db.CustomersRepository.GetCustomerByID(userId);
                    this.Text = $"ویرایش {user.FullName}";
                    this.pcCustomer.ImageLocation = Application.StartupPath +"/Images/"+ user.CustomerIMG;
                    this.txtFullName.Text = user.FullName;
                    this.txtPhone.Text = user.Phone;
                    this.txtEmail.Text = user.Email;
                    this.txtAddress.Text = user.Address;
                    this.btnSubmit.Text = "ویرایش";

                }
                
            }
        }
    }
}
