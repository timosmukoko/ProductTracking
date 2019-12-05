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


namespace ProductTracking
{
    
    public partial class formLogin : Form
    {
        #region Instance Attributes
        private IModel Model;
        #endregion

        #region Instance Properties

        #endregion

        #region Constructors
        public formLogin(IModel Model)
        {
            InitializeComponent();
            this.Model = Model;
        }
        #endregion
       
        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
          
            bool validUser = Model.login(textBoxName.Text, textBoxPassword.Text);
          
            if (validUser)
                Close();
            else
            {
                MessageBox.Show("Invalid name or password");
                textBoxName.Text = "";
                textBoxPassword.Text = "";
                textBoxName.Select();
            }
        }
    }
}
