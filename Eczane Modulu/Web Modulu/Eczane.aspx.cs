using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web_Modulu
{
    public partial class Eczane : System.Web.UI.Page
    {
        bool yetkikontrolu = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            yetkikontrolu = EczaneGiris.kullanici_yetkili_mi;
            if (yetkikontrolu==false)
            {
                Response.Redirect("EczaneGiris.aspx");
            }
        }
    }
}