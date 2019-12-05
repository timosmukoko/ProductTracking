using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using BusinessLayer;
using BusinessEntities;


namespace ProductTracking
{
    public partial class formDeleteUser : Form
    {
        #region Instance Attributes
        IModel Model;
        formContainer fc;
        #endregion 

       #region Constructors
        public formDeleteUser(formContainer parent, IModel Model)
        {
            InitializeComponent();
            MdiParent = parent;
            fc = parent;
            this.Model = Model;        
        }
       #endregion

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Delete " + listBoxUsers.SelectedItem.ToString() + " ? ", "Are you sure !", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                return;
            foreach (User user in Model.UserList)
            {
                 if (user.Name == listBoxUsers.SelectedItem.ToString())
                 {
                     Model.deleteUser(user);
                     listBoxUsers.Items.Remove(listBoxUsers.SelectedItem); //remove name from listbox
                                    break;
                 }
            }
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void formDeleteUser_Load(object sender, EventArgs e)
        {
            foreach (User user in Model.UserList)
            {
                listBoxUsers.Items.Add(user.Name);
            }
        
        }
    }
}
