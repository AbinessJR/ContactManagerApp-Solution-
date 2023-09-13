using System;
using System.Data;
using System.Windows.Forms;

namespace ContactManagerApp
{
    public partial class Form1 : Form
    {
        private ContactManager contactManager;

        public Form1()
        {
            InitializeComponent();
            contactManager = new ContactManager();
            RefreshGrid();
        }

        private void RefreshGrid()
        {
            DataTable dt = contactManager.GetContacts();
            dataGridViewContacts.DataSource = dt;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            string name = textBoxName.Text;
            string email = textBoxEmail.Text;
            string phone = textBoxPhone.Text;

            if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(phone))
            {
                contactManager.AddContact(name, email, phone);
                RefreshGrid();
                ClearFields();
            }
            else
            {
                MessageBox.Show("Please fill in all fields.");
            }
        }

        // Implement other CRUD operations here (update, delete).
        
        private void ClearFields()
        {
            textBoxName.Clear();
            textBoxEmail.Clear();
            textBoxPhone.Clear();
        }
    }
}
