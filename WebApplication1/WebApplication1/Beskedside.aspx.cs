using System;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GoodGuidance
{
    public partial class Beskedside : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string besked;
            StreamReader sr = new StreamReader("C:\\Users\\Birkebæk\\Desktop\\Besked.txt");
            besked = sr.ReadLine();

            while (besked != null)
            {
                ListBoxBeskeder.Items.Add(besked);
                besked = sr.ReadLine();
            }

            sr.Close();
        }

        protected void ButtonTilbage_Click(object sender, EventArgs e)
        {
            Response.Redirect("Hovedside.aspx");
        }
    }
}