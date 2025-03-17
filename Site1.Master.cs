using System;
using System.Web.UI;

namespace proWeb
{
    public partial class Site1 : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Verifica que no sea un postback para evitar sobrescribir datos en cada recarga
            if (!IsPostBack)
            {
            }
        }
    }
}
