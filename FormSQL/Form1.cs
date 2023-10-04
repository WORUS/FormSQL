using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace FormSQL
{
    public partial class Form1 : Form
    {

        public static DataGridView dgv = new DataGridView();

        public string GetValue(int i) {
            return dataGridView1.Rows[i].Cells[4].Value.ToString();
        }
        public string GetRowsValue() {
            return dataGridView1.Rows.Count.ToString();
        }

        private SqlConnection sqlConnection = null;
        private SqlCommandBuilder sqlBuilder = null;
        private SqlDataAdapter sqlDataAdapter = null;
        private DataSet dataSet = null;
        public DataGridViewCellEventArgs ta;
        public Form1()
        {
            InitializeComponent();
        }

        private void LoadData() 
        {
            try
            {
                sqlDataAdapter = new SqlDataAdapter("SELECT *, 'Delete' AS [Delete] FROM [Table]",sqlConnection);
                sqlBuilder = new SqlCommandBuilder(sqlDataAdapter);
                sqlBuilder.GetInsertCommand();
                sqlBuilder.GetUpdateCommand();
                sqlBuilder.GetDeleteCommand();
                dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet,"[Table]");
                dataGridView1.DataSource = dataSet.Tables["[Table]"];
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message,"Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ReLoadData()
        {
            try
            {
                dataSet.Tables["[Table]"].Clear();
                sqlDataAdapter.Fill(dataSet, "[Table]");
                dataGridView1.DataSource = dataSet.Tables["[Table]"];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "studentsDBDataSet.Table". При необходимости она может быть перемещена или удалена.
            try
            {
                this.tableTableAdapter.Fill(this.studentsDBDataSet.Table);
                sqlConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\StudentsDB.mdf;Integrated Security=True");
                sqlConnection.Open();

                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occured on database connection");
            };
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            ReLoadData();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Вы уверены, что хотите удалить данную строку?", "Удаление записи", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int rowIndex = dataGridView1.SelectedCells[0].RowIndex;
                    dataGridView1.Rows.RemoveAt(rowIndex);
                    dataSet.Tables["[Table]"].Rows[rowIndex].Delete();
                    sqlDataAdapter.Update(dataSet, "[Table]");
                }
            }
            catch(Exception ex) 
            { 
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            Form2 addStudent = new Form2();
            addStudent.Show();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            
            string idSend = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            string nameSend = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            string surnameSend = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            string paronymSend = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            string dateSend = ((DateTime)dataGridView1.CurrentRow.Cells[4].Value).ToShortDateString();
            string markSend = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            Form3 changeStudentRecord = new Form3(idSend, nameSend, surnameSend, paronymSend, dateSend, markSend );
            changeStudentRecord.Show();
        }

        private void дополнительноToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 calc = new Form4(dataGridView1);
            calc.dataGridView1 = this.dataGridView1;
            calc.Show();
        }

        private void tableBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }
    }
}
