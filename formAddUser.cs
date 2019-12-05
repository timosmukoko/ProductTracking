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
    public partial class formAddUser : Form
    {
        #region Instance Attributes
        IModel Model;
        formContainer fc;
        #endregion 

       #region Constructors
        public formAddUser( formContainer parent, IModel Model)
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
        /*
         * LINQ (Language Integrated Query) is a Microsoft programming model and methodology that essentially adds formal query capabilities into Microsoft .NET-based programming languages. LINQ offers a 
         * compact, expressive, and intelligible syntax for manipulating data.
         * */
        private void buttonCommit_Click(object sender, EventArgs e)
        {
            if (listBoxUserType.SelectedIndex != -1)
            { // some validation on userName, we won't allow duplicate usernames
               IUser duplicateUser = Model.UserList.FirstOrDefault(user => user.Name == textBoxName.Text.Trim()); 
                          /* provides a shortcut to accessing the element that occurs first in the collection or query,
                          while protecting against invalid accesses if there are no elements.It'sa linq query. FirstOrDefault is a generic method which means it accepts a type parameter that indicates what types it acts upon. 
                          The => is a lambda operator. Anything before the => are the input parameters, and anything after is the expression. You can have multiple input parameters.
                          Think of a lambda expression as"given x, do something with x"                                                                                          * */
                if (duplicateUser == null)
                {
                    if (Model.addNewUser(textBoxName.Text, textBoxPassword.Text, listBoxUserType.SelectedItem.ToString()))
                    {
                        MessageBox.Show("User created");
                        textBoxName.Text = "";
                        textBoxPassword.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show("Duplicate User name, enter a different name!");
                    MessageBox.Show(duplicateUser.Name + " " + duplicateUser.Password);  // just to show directOrDefault returns the matching user where there is one. 
                    textBoxName.Text = "";
                    textBoxPassword.Text = "";
                }

            }
            else
            {
                MessageBox.Show("You must select a user type!");
                textBoxName.Text = "";
                textBoxPassword.Text = "";

            }
        }
    }
}
