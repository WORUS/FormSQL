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
    public partial class Form4 : Form
    {
        object data1;

        public Form4(object data)
        {
            InitializeComponent();
            data1 = data;
        }

        //Form1.dgv.DataSource = prevEx.ToList();

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            textBox1.WordWrap = true;
            double[] sumMark = new double[12] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            int[] countMark = new int[12] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            for (int i = 0; i < dataGridView1.Rows.Count-1; i++)
            {
                DateTime temp = DateTime.Parse(dataGridView1.Rows[i].Cells[4].Value.ToString());
                

                switch (temp.Month.ToString()) {
                    case "1":
                        textBox9.Text += dataGridView1.Rows[i].Cells[2].Value.ToString() + Environment.NewLine;
                        sumMark[temp.Month-1] += Convert.ToDouble(dataGridView1.Rows[i].Cells[5].Value);
                        countMark[temp.Month - 1]++;
                        break;
                    case "2":
                        textBox8.Text += dataGridView1.Rows[i].Cells[2].Value.ToString() + Environment.NewLine;
                        sumMark[temp.Month - 1] += Convert.ToDouble(dataGridView1.Rows[i].Cells[5].Value);
                        countMark[temp.Month - 1]++;
                        break;
                    case "3":
                        textBox7.Text += dataGridView1.Rows[i].Cells[2].Value.ToString() + Environment.NewLine;
                        sumMark[temp.Month - 1] += Convert.ToDouble(dataGridView1.Rows[i].Cells[5].Value);
                        countMark[temp.Month - 1]++;
                        break;
                    case "4":
                        textBox1.Text += dataGridView1.Rows[i].Cells[2].Value.ToString() + Environment.NewLine;
                        sumMark[temp.Month - 1] += Convert.ToDouble(dataGridView1.Rows[i].Cells[5].Value);
                        countMark[temp.Month - 1]++;
                        break;
                    case "5":
                        textBox2.Text += dataGridView1.Rows[i].Cells[2].Value.ToString() + Environment.NewLine;
                        sumMark[temp.Month - 1] += Convert.ToDouble(dataGridView1.Rows[i].Cells[5].Value);
                        countMark[temp.Month - 1]++;
                        break;
                    case "6":
                        textBox3.Text += dataGridView1.Rows[i].Cells[2].Value.ToString() + Environment.NewLine;
                        sumMark[temp.Month - 1] += Convert.ToDouble(dataGridView1.Rows[i].Cells[5].Value);
                        countMark[temp.Month - 1]++;
                        break;
                    case "7":
                        textBox4.Text += dataGridView1.Rows[i].Cells[2].Value.ToString() + Environment.NewLine;
                        sumMark[temp.Month - 1] += Convert.ToDouble(dataGridView1.Rows[i].Cells[5].Value);
                        countMark[temp.Month - 1]++;
                        break;
                    case "8":
                        textBox5.Text += dataGridView1.Rows[i].Cells[2].Value.ToString() + Environment.NewLine;
                        sumMark[temp.Month - 1] += Convert.ToDouble(dataGridView1.Rows[i].Cells[5].Value);
                        countMark[temp.Month - 1]++;
                        break;
                    case "9":
                        textBox6.Text += dataGridView1.Rows[i].Cells[2].Value.ToString() + Environment.NewLine;
                        sumMark[temp.Month - 1] += Convert.ToDouble(dataGridView1.Rows[i].Cells[5].Value);
                        countMark[temp.Month - 1]++;
                        break;
                    case "10":
                        textBox12.Text += dataGridView1.Rows[i].Cells[2].Value.ToString() + Environment.NewLine;
                        sumMark[temp.Month - 1] += Convert.ToDouble(dataGridView1.Rows[i].Cells[5].Value);
                        countMark[temp.Month - 1]++;
                        break;
                    case "11":
                        textBox11.Text += dataGridView1.Rows[i].Cells[2].Value.ToString() + Environment.NewLine;
                        sumMark[temp.Month - 1] += Convert.ToDouble(dataGridView1.Rows[i].Cells[5].Value);
                        countMark[temp.Month - 1]++;
                        break;
                    case "12":
                        textBox10.Text += dataGridView1.Rows[i].Cells[2].Value.ToString() + Environment.NewLine;
                        sumMark[temp.Month - 1] += Convert.ToDouble(dataGridView1.Rows[i].Cells[5].Value);
                        countMark[temp.Month - 1]++;
                        break;

                }
            }
            double bestMark = 0;
            int bestMarkIndex = 0;
            button1.Enabled = false;
            textBox21.Text = (sumMark[0] / countMark[0]).ToString(); //Козерог
            textBox13.Text = (sumMark[3] / countMark[3]).ToString(); //Овен
            textBox14.Text = (sumMark[4] / countMark[4]).ToString(); //Телец
            textBox16.Text = (sumMark[5] / countMark[5]).ToString(); //Близнецы
            textBox15.Text = (sumMark[6] / countMark[6]).ToString(); //Раки
            textBox18.Text = (sumMark[7] / countMark[7]).ToString(); //Львы
            textBox17.Text = (sumMark[8] / countMark[8]).ToString(); //Девы
            textBox20.Text = (sumMark[9] / countMark[9]).ToString(); //Весы
            textBox19.Text = (sumMark[10] / countMark[10]).ToString(); //СКорпионы
            textBox22.Text = (sumMark[11] / countMark[11]).ToString(); //Стрельцы
            textBox24.Text = (sumMark[1] / countMark[1]).ToString(); //Водолеи
            textBox23.Text = (sumMark[2] / countMark[2]).ToString();//Рыбы

            for (int i=0; i < 12; i++) { if (sumMark[i] / countMark[i] > bestMark)
                {
                    bestMark = sumMark[i] / countMark[i];
                    bestMarkIndex = i;
                }
            }
            switch (bestMarkIndex) {
                case 0:

                    break;
                case 1:
                    textBox25.Text = "Водолей";
                    break;
                case 2:
                    textBox25.Text = "Рыбы";
                    break;
                case 3:
                    textBox25.Text = "Овен";

                    break;
                case 4:
                    textBox25.Text = "Телец";

                    break;
                case 5:
                    textBox25.Text = "Близнецы";

                    break;
                case 6:
                    textBox25.Text = "Раки";

                    break;
                case 7:
                    textBox25.Text = "Львы";

                    break;
                case 8:
                    textBox25.Text = "Дева";

                    break;
                case 9:
                    textBox25.Text = "Весы";

                    break;
                case 10:
                    textBox25.Text = "Скорпион";

                    break;
                case 11:
                    textBox25.Text = "Стрелец";

                    break;
            }


        }
    }
}
