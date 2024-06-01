using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace MyProject
{
    public partial class AddProgramForm : Form
    {
        public AddProgramForm()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string programName = txtProgramName.Text;
            string programTime = txtProgramTime.Text;
            decimal programBudget = decimal.Parse(txtProgramBudget.Text);
            string programManager = txtProgramManager.Text;

            string connectionString = "Data Source=YourServer;Initial Catalog=YourDatabase;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Programs (ProgramName, ProgramTime, ProgramBudget, ProgramManager) VALUES (@ProgramName, @ProgramTime, @ProgramBudget, @ProgramManager)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ProgramName", programName);
                    command.Parameters.AddWithValue("@ProgramTime", programTime);
                    command.Parameters.AddWithValue("@ProgramBudget", programBudget);
                    command.Parameters.AddWithValue("@ProgramManager", programManager);

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }

            MessageBox.Show("Program added successfully.");
        }
    }
}