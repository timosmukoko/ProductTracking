using BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProductTracking
{
    public partial class formManager : Form
    {
        #region Instance Attributes
        private formContainer fc;
        private IModel Model;
        #endregion

        #region Constructors
        public formManager(formContainer parent, IModel Model)
        {
            InitializeComponent();
            MdiParent = parent;
            fc = parent;
            this.Model = Model;
        }
        #endregion


       
        private void buttonExit_Click(object sender, EventArgs e)
        {
                   Application.Exit();
        }

        private void formManager_Load(object sender, EventArgs e)
        {

        }

        private void buttonAddUser_Click(object sender, EventArgs e)
        {
            formAddUser form = new formAddUser(fc,  Model);
            form.Dock = DockStyle.Fill;
            form.Show();
         }

        private void buttonDeleteUser_Click(object sender, EventArgs e)
        {
            formDeleteUser form = new formDeleteUser(fc, Model);
            form.Dock = DockStyle.Fill;
            form.Show();
        }

        private void buttonEditUser_Click(object sender, EventArgs e)
        {
            formEditUser form = new formEditUser(fc, Model);
            form.Dock = DockStyle.Fill;
            form.Show();

        }
    }
}
