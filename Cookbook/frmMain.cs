using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace Cookbook
{
    public partial class frmMain : Form
    {
        string connectionString;
        SqlConnection connection;

        public frmMain()
        {
            InitializeComponent();

            //had to add a reference to system.configuration (project->add referenence, in top menu)
            //this string blow contains data about the database used
            connectionString = ConfigurationManager.ConnectionStrings["Cookbook.Properties.Settings.CookbookConnectionString"].ConnectionString;

        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            PopulateRecipes();
        }

        private void PopulateRecipes()
        {
            using (connection = new SqlConnection(connectionString))
            using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Recipe", connection))
            {
                DataTable recipeTable = new DataTable();
                adapter.Fill(recipeTable);

                lstRecipes.DisplayMember = "Name";
                lstRecipes.ValueMember = "Id";
                lstRecipes.DataSource = recipeTable;
            }
        }
    }
}
