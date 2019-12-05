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
    public partial class formEditUser : Form
    {
         #region Instance Attributes
        IModel Model;
        formContainer fc;
        #endregion 

       #region Constructors
        public formEditUser(formContainer parent, IModel Model)
        {
            InitializeComponent();
            MdiParent = parent;
            fc = parent;
            this.Model = Model;        
        }
       #endregion

        private void buttonBack_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonCommit_Click(object sender, EventArgs e)
        {
            foreach (User user in Model.UserList)
            {
                if (user.Name == listBoxUsers.SelectedItem.ToString())
                {
                    user.Name = textBoxName.Text;
                    user.Password = textBoxPassword.Text;
                    Model.editUser(user);
                }
            }
            textBoxName.Text = "";
            textBoxPassword.Text = "";
        

        }

        private void formEditUser_Load(object sender, EventArgs e)
        {
            foreach (User user in Model.UserList)
            {
                listBoxUsers.Items.Add(user.Name);
            }
        }

        private void listBoxUsers_DoubleClick(object sender, EventArgs e)
        {
            textBoxName.Text = listBoxUsers.SelectedItem.ToString();
            foreach (User user in Model.UserList)
            {
                if (user.Name == textBoxName.Text)
                    textBoxPassword.Text = user.Password;
            }
            
        }

    }
}
