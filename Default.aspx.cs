using System;
using System.Globalization;
using library;

namespace proWeb
{
    public partial class Default : System.Web.UI.Page
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
            ENProduct product = new ENProduct();
            product.Code = txtCode.Text.Trim();

            if (product.Read())
            {
                txtName.Text = product.Name;
                txtAmount.Text = product.Amount.ToString();
                txtPrice.Text = product.Price.ToString("F2");
                ddlCategory.SelectedValue = product.Category.ToString();
                txtCreationDate.Text = product.CreationDate.ToString("dd/MM/yyyy HH:mm:ss");
                lblMessage.Text = "Product loaded successfully.";
            }
            else
            {
                lblMessage.Text = "Product not found.";
            }
        }

        protected void btnReadFirst_Click(object sender, EventArgs e)
        {
            ENProduct product = new ENProduct();
            if (product.ReadFirst())
            {
                txtCode.Text = product.Code;
                txtName.Text = product.Name;
                txtAmount.Text = product.Amount.ToString();
                txtPrice.Text = product.Price.ToString("F2");
                ddlCategory.SelectedValue = product.Category.ToString();
                txtCreationDate.Text = product.CreationDate.ToString("dd/MM/yyyy HH:mm:ss");
                lblMessage.Text = "First product loaded.";
            }
            else
            {
                lblMessage.Text = "No products found.";
            }
        }

        protected void btnReadPrev_Click(object sender, EventArgs e)
        {
            ENProduct product = new ENProduct();
            product.Code = txtCode.Text.Trim();
            if (product.ReadPrev())
            {
                txtCode.Text = product.Code;
                txtName.Text = product.Name;
                txtAmount.Text = product.Amount.ToString();
                txtPrice.Text = product.Price.ToString("F2");
                ddlCategory.SelectedValue = product.Category.ToString();
                txtCreationDate.Text = product.CreationDate.ToString("dd/MM/yyyy HH:mm:ss");
                lblMessage.Text = "Previous product loaded.";
            }
            else
            {
                lblMessage.Text = "No previous product found.";
            }
        }

        protected void btnReadNext_Click(object sender, EventArgs e)
        {
            ENProduct product = new ENProduct();
            product.Code = txtCode.Text.Trim();
            if (product.ReadNext())
            {
                txtCode.Text = product.Code;
                txtName.Text = product.Name;
                txtAmount.Text = product.Amount.ToString();
                txtPrice.Text = product.Price.ToString("F2");
                ddlCategory.SelectedValue = product.Category.ToString();
                txtCreationDate.Text = product.CreationDate.ToString("dd/MM/yyyy HH:mm:ss");
                lblMessage.Text = "Next product loaded.";
            }
            else
            {
                lblMessage.Text = "No next product found.";
            }
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                ENProduct product = new ENProduct(
                    txtCode.Text.Trim(),
                    txtName.Text.Trim(),
                    int.Parse(txtAmount.Text),
                    float.Parse(txtPrice.Text, CultureInfo.InvariantCulture),
                    int.Parse(ddlCategory.SelectedValue),
                    DateTime.ParseExact(txtCreationDate.Text, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture)
                );

                if (product.Create())
                {
                    lblMessage.Text = "Product created successfully.";
                }
                else
                {
                    lblMessage.Text = "Failed to create product. It might already exist.";
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error creating product: " + ex.Message;
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                ENProduct product = new ENProduct(
                    txtCode.Text.Trim(),
                    txtName.Text.Trim(),
                    int.Parse(txtAmount.Text),
                    float.Parse(txtPrice.Text, CultureInfo.InvariantCulture),
                    int.Parse(ddlCategory.SelectedValue),
                    DateTime.ParseExact(txtCreationDate.Text, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture)
                );

                if (product.Update())
                {
                    lblMessage.Text = "Product updated successfully.";
                }
                else
                {
                    lblMessage.Text = "Failed to update product. It might not exist.";
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error updating product: " + ex.Message;
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            ENProduct product = new ENProduct();
            product.Code = txtCode.Text.Trim();

            if (product.Delete())
            {
                lblMessage.Text = "Product deleted successfully.";
                txtName.Text = "";
                txtAmount.Text = "";
                txtPrice.Text = "";
                txtCreationDate.Text = "";
            }
            else
            {
                lblMessage.Text = "Failed to delete product.";
            }
        }
    }
}
