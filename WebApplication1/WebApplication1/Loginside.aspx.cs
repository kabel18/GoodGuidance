using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GoodGuidance
{
    public partial class Loginside : System.Web.UI.Page
    {
        int sessionCount = 0;
        string sessionBrugernavn = null;
        //string sessionPassword = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            //Session counter to sign out people of loginpage
            if (Session["CountCounter"] == null)
            {
                sessionCount = 0;
                Session["CountCounter"] = sessionCount;
            }
            else
            {
                sessionCount = Convert.ToInt32(Session["CountCounter"]);
                sessionCount++;
                Session["CountCounter"] = sessionCount;
            }


            //Session for transfering username and password from textbox to Hovedside.aspx
            if (TextBoxBrugernavn.Text == null)
            {
                sessionBrugernavn = Convert.ToString("UKENDT BRUGER"); //Virker ikke efter hensigten
                Session["Brugernavn"] = sessionBrugernavn;
            }
            else
            {
                sessionBrugernavn = TextBoxBrugernavn.Text;
                Session["Brugernavn"] = sessionBrugernavn;

                //sessionPassword = TextBoxPassword.Text;
                //Session["Password"] = sessionPassword;
            }

            Session["CountCounter"] = sessionCount;


        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            Session[""] = sessionCount;
            Session[""] = sessionBrugernavn;
        }

        //string[,] brugere = new string[,]
        //{
        //    {"helegris22", "jeppeko23", "kamilnin21"},    //Array 0
        //    {"hele", "jepp", "kami"}, //Array 1
        //};

        protected void ButtonLogin_Click(object sender, EventArgs e)
        {
            //Gammel kode for søgning i array, frem for SQL Database 
            /*
            try
            {
                for (int i = 0; i < brugere.Length; i++)
                {
                    if (TextBoxBrugernavn.Text.Equals(brugere[0, i])) //Array 0,index
                    {
                        if (TextBoxPassword.Text.Equals(brugere[1, i])) //Array 0,index
                        {
                            //sessionBrugernavn = brugere[0,i];       //Ikke nødvendig 
                            Response.Redirect("Hovedside.aspx");
                        }
                        else
                        {
                            LabelFejl.Text = "Forkert password.";
                            break;
                        }
                    }
                    else
                    {
                        LabelFejl.Text = "Brugernavnet findes ikke.";
                    }
                }
            }
            catch (Exception)
            {
                //Udskriv antal forsøg brugt
                Label5.Text = sessionCount.ToString();
            }

            if (sessionCount == 3)
            {
                Response.Redirect("Fejlloginside.aspx");
            }

            //Udskriv antal forsøg brugt
            Label5.Text = sessionCount.ToString();
            */

            //Her laves en SQL Connection objekt ud fra funktioner i System.Data.SqlClient
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection"].ConnectionString);

            //Brugernavn og password instantieres
            string userName = TextBoxBrugernavn.Text;
            string password = TextBoxPassword.Text;

            //try indeholder resten af koden for at programmet ikke crasher hvis en fejl opstår
            try
            {
                //Hele SQL-statementet med mulighed for at skifte elementer ud
                string sql = "SELECT ID from [Brugere].[dbo].[TableBrugere] where [Brugernavn] = @username and [Password] = @password";

                //Et objekt til at udføre en SQLkommando ud fra ovenstående 'sql' og en connection.
                SqlCommand cmd = new SqlCommand(sql, connection);

                //Avanceret getter/setter. Ud fra et objekt 'user' defineres username som en parameter til vores statement
                SqlParameter user = new SqlParameter();
                user.ParameterName = "@userName";
                user.Value = userName.Trim();
                cmd.Parameters.Add(user);

                SqlParameter pass = new SqlParameter();
                pass.ParameterName = "@password";
                pass.Value = password.Trim();
                cmd.Parameters.Add(pass);

                //Skaber forbindelse til databasen via connection objektet
                connection.Open();

                //en int instatieres og får værdien af den første linje fra 'cmd', som parses til int
                int fundetID = (int)cmd.ExecuteScalar();

                if (fundetID > 0)
                {
                    Response.Redirect("Hovedside.aspx"); //Login redirect
                }
                else
                {
                    LabelFejl.Text = "Brugernavn og password stemmer ikke overens.";
                }
            }
            catch (Exception)
            {
                LabelFejl.Text = "Catchfejl";
            }
            finally
            {
                if (connection != null) connection.Close();
            }

            //Udskriv antal forsøg brugt
            Label5.Text = sessionCount.ToString();

            if (sessionCount == 3)
            {
                Response.Redirect("Fejlloginside.aspx");
            }
        }

        protected void ButtonOpretBruger_Click(object sender, EventArgs e)
        {
            Response.Redirect("Brugeroprettelse.aspx");
        }
    }
}