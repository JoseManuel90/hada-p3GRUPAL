using System;
using System.Globalization;
using library;
using System.Collections.Generic;

namespace proWeb
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblMessage.Text = "";
                LoadCategories();
            }
        }

        private void LoadCategories()
        {
            CADCategory cad = new CADCategory();
            List<ENCategory> categories = cad.ReadAll();
            ddlCategory.DataSource = categories;
            ddlCategory.DataTextField = "Name";
            ddlCategory.DataValueField = "Id";
            ddlCategory.DataBind();
        }

        protected void btnRead_Click(object sender, EventArgs e)
        {
            ENProduct product = new ENProduct();
            product.Code = txtCode.Text.Trim();

            if (product.Read())
            {
                txtName.Text = product.Name;
                txtAmount.Text = product.Amount.ToString();
                txtPrice.Text = product.Price.ToString("F2", CultureInfo.InvariantCulture);
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
                txtPrice.Text = product.Price.ToString("F2", CultureInfo.InvariantCulture);
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
                txtPrice.Text = product.Price.ToString("F2", CultureInfo.InvariantCulture);
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
                txtPrice.Text = product.Price.ToString("F2", CultureInfo.InvariantCulture);
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
                string code = txtCode.Text.Trim();
                string name = txtName.Text.Trim();
                if (code.Length < 1 || code.Length > 16)
                {
                    lblMessage.Text = "Code must be between 1 and 16 characters.";
                    return;
                }
                if (name.Length > 32)
                {
                    lblMessage.Text = "Name must not exceed 32 characters.";
                    return;
                }

                if (!int.TryParse(txtAmount.Text, out int amount) || amount < 0 || amount > 9999)
                {
                    lblMessage.Text = "Amount must be an integer between 0 and 9999.";
                    return;
                }

                if (!float.TryParse(txtPrice.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out float price) || price < 0 || price > 9999.99f)
                {
                    lblMessage.Text = "Price must be a positive number (max 9999.99).";
                    return;
                }

                if (!DateTime.TryParseExact(txtCreationDate.Text, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime creationDate))
                {
                    lblMessage.Text = "Invalid date format. Use dd/MM/yyyy HH:mm:ss.";
                    return;
                }

                if (!int.TryParse(ddlCategory.SelectedValue, out int category) || category < 0 || category > 3)
                {
                    lblMessage.Text = "Invalid category selected.";
                    return;
                }

                ENProduct product = new ENProduct(code, name, amount, price, category, creationDate);

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
                string code = txtCode.Text.Trim();
                string name = txtName.Text.Trim();
                if (code.Length < 1 || code.Length > 16)
                {
                    lblMessage.Text = "Code must be between 1 and 16 characters.";
                    return;
                }
                if (name.Length > 32)
                {
                    lblMessage.Text = "Name must not exceed 32 characters.";
                    return;
                }

                if (!int.TryParse(txtAmount.Text, out int amount) || amount < 0 || amount > 9999)
                {
                    lblMessage.Text = "Amount must be an integer between 0 and 9999.";
                    return;
                }

                if (!float.TryParse(txtPrice.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out float price) || price < 0 || price > 9999.99f)
                {
                    lblMessage.Text = "Price must be a positive number (max 9999.99).";
                    return;
                }

                if (!DateTime.TryParseExact(txtCreationDate.Text, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime creationDate))
                {
                    lblMessage.Text = "Invalid date format. Use dd/MM/yyyy HH:mm:ss.";
                    return;
                }

                if (!int.TryParse(ddlCategory.SelectedValue, out int category) || category < 0 || category > 3)
                {
                    lblMessage.Text = "Invalid category selected.";
                    return;
                }

                ENProduct product = new ENProduct(code, name, amount, price, category, creationDate);

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
