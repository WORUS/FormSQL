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
    public partial class Form3 : Form
    {
        SqlConnection sqlConnection;
        public Form3(String id, String name, String surname, String paronym, String datee, String mark)
        {
            InitializeComponent();
            textBox6.Text = id;
            textBox1.Text = name.Replace(" ", string.Empty);
            textBox2.Text = surname.Replace(" ", string.Empty);
            textBox3.Text = paronym.Replace(" ", string.Empty);
            textBox4.Text = datee.Replace(" ", string.Empty);
            textBox5.Text = mark.Replace(" ", string.Empty);
            textBox6.ReadOnly = true;
            
        }

        private void ConnectSql()
        {
            NameDB namedb = new NameDB();
            string connectionString = namedb.connectionString;
            sqlConnection = new SqlConnection(connectionString);
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            ConnectSql();
            await sqlConnection.OpenAsync();
            DateTime temp;
            string dateCheck = textBox4.Text + " 0:00:00";
            string markChecker = textBox5.Text;
            string dtachck = "";
            string dtachck1 = "";
            int a;
            if (int.TryParse(dateCheck.Substring(0, 2), out a) && int.TryParse(dateCheck.Substring(3, 2), out a))
            {
                dtachck = dateCheck.Substring(0, 2);
                dtachck1 = dateCheck.Substring(3, 2);
            }
            else
            {
                dtachck = "32";
                dtachck1 = "13";
            }
            if (dateCheck.Contains(',') || !(DateTime.TryParse(dateCheck, out temp)) || dateCheck == "" || int.Parse(dtachck) > 31 || int.Parse(dtachck1) > 12)
            {
                MessageBox.Show("Неверно заполнено поле <Дата рождения>. \nИспользуйте формат <ДД.ММ.ГГГГ>." + DateTime.TryParse(dateCheck, out temp) + " " + dtachck + " " + dtachck1, "Неверный ввод данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (markChecker.Contains('.'))
            {
                MessageBox.Show("Неверно заполнено поле <Средняя оценка>. \nИспользуйте запись с 'плавающей запятой'.", "Неверный ввод данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrEmpty(textBox3.Text) && !string.IsNullOrEmpty(textBox4.Text) && !string.IsNullOrEmpty(textBox5.Text))
            {
                SqlCommand command = new SqlCommand("UPDATE [Table] SET [Name]=@Name, [SurName]=@SurName, [Patronym]=@Patronym, [BirthDay]=@BirthDay, [AvgMark]=@AvgMark WHERE [Id]=@Id", sqlConnection);
                command.Parameters.AddWithValue("Id", textBox6.Text);
                command.Parameters.AddWithValue("Name", textBox1.Text);
                command.Parameters.AddWithValue("SurName", textBox2.Text);
                command.Parameters.AddWithValue("Patronym", textBox3.Text);
                command.Parameters.AddWithValue("BirthDay", DateTime.Parse(textBox4.Text));
                command.Parameters.AddWithValue("AvgMark", Convert.ToDouble(textBox5.Text));  //Преобразовать тип данных из string в int, float, date

                await command.ExecuteNonQueryAsync();
                sqlConnection.Close();
                Close();
            }
            else
            {
                MessageBox.Show("Вы заполнили не все данные!!!");
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
