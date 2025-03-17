using System;
using System.Web.UI;

namespace proWeb
{
    public partial class Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblMessage.Text = "";
            }
        }

        protected void btnRead_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "Reading product based on the entered code.";
        }

        protected void btnReadFirst_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "Reading the first product in the database.";
        }

        protected void btnReadPrev_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "Reading the previous product.";
        }

        protected void btnReadNext_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "Reading the next product.";
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "Creating a new product.";
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "Updating the existing product.";
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "Deleting the selected product.";
        }
    }
}

