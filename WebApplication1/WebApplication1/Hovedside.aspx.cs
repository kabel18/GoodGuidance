using System;
using static System.Console;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GoodGuidance
{
    public partial class Hovedside : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonSave_Click(object sender, EventArgs e)
        {
            //Print til fil
            if (EmailChecker(TextBoxEmail.Text) == true && IsWholeNumber(TextBoxMobil.Text) == true)
            {
                //Save in viewable file
                StreamWriter sw = new StreamWriter("C:\\Users\\Birkebæk\\Desktop\\Besked.txt", true);
                sw.Write("\n_______________________________________________________\n" + "Indsendt: " + DateTime.Now + "\n");
                sw.WriteLine("Navn: " + Session["Brugernavn"]);
                sw.WriteLine("Email: " + TextBoxEmail.Text);
                sw.WriteLine("Adresse: " + TextBoxAdressse.Text);
                sw.WriteLine("Mobil nr.: " + TextBoxMobil.Text);
                sw.WriteLine("Besked: " + TextBoxBesked.Text);

                sw.Close();

                //Save in a permanent log file
                StreamWriter sf = new StreamWriter("C:\\Users\\Birkebæk\\Desktop\\Log.txt", true);
                sf.Write("_______________________________________________________\n" + "Indsendt: " + DateTime.Now + "\n");
                sf.WriteLine("Navn: " + Session["Brugernavn"]);
                sf.WriteLine("Email: " + TextBoxEmail.Text);
                sf.WriteLine("Besked: " + TextBoxBesked.Text);
                sf.WriteLine("Adresse: " + TextBoxAdressse.Text);
                sf.WriteLine("Mobil nr.: " + TextBoxMobil.Text);

                sf.Close();

                LabelConfirmed.Text = "Beskeden er gemt som en fil på computeren.";
                LabelConfirmed2.Text = "";
            }
            else
            {
                LabelConfirmed2.Text = "Der er fejl i de indtastede felter";
            }
        }

        

        public bool IsWholeNumber(string number)
        {
            if (number.Length == 8)
            {
                Regex objNotWholeNumber = new Regex("[^0-9]");

                LabelMobileFailure.Text = "";
                return !objNotWholeNumber.IsMatch(number);
            }
            LabelMobileFailure.Text = "Dit nummer skal være 8 cifre langt og kun bestående af tal.";
            return false;
        }

        bool EmailChecker(string email)
        {
            int count = 0;

            foreach (char letter in email)
            {
                if (letter == '@')
                {
                    count++;
                }
            }

            if (email.Length >= 7 && email.Length < 31)
            {
                if (count == 1) //Hvordan checker jeg efter flere @??
                {
                    if (email.EndsWith(".dk") || email.EndsWith(".com"))
                    {
                        LabelConfirmed.Text = "";
                        return true;
                    }
                    else
                    {
                        LabelConfirmed.Text = "Din email skal slutte på '.dk' eller '.com'";
                        return false;
                    }
                }
                else
                {
                    LabelConfirmed.Text = "Din email skal indeholde ét @.";
                    return false;
                }
            }
            else
            {
                LabelConfirmed.Text = "Din email skal være mellem 7-30 tegn. Den skal inde holde ét '@' og  ende på '.dk' eller '.com'";
                return false;
            }
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter("C:\\Users\\Birkebæk\\Desktop\\Besked.txt", false);

            sw.WriteLine("");

            sw.Close();

            LabelConfirmed2.Text = "Alle beskeder er slettet.";
        }

        protected void ButtonRead_Click(object sender, EventArgs e)
        {
            Response.Redirect("Beskedside.aspx");
        }


        protected void ButtonLogout_Click(object sender, EventArgs e)
        {

            Response.Redirect("Loginside.aspx");

        }

        protected void ButtonReset_Click(object sender, EventArgs e)
        {
            TextBoxEmail.Text = "";
            TextBoxBesked.Text = "";
            TextBoxAdressse.Text = "";
            TextBoxMobil.Text = "";
        }
    }
}