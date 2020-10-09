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
using System.IO;
using System.Diagnostics;

namespace Database_Management_Software__DMS_
{
    public partial class Main : Form
    {
        
        public Main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void UpdateDataGridView()
        {
            if (label10.Text != "")
            {
                if (label10.Text.Substring(label10.Text.Length - 4) == ".mdf")
                {
                    SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=" + label10.Text + ";Integrated Security = True; Connect Timeout = 30");
                    ////
                    string sql_1 =
        @"SELECT Продукты.ИД_Продукта,ИД_Продукта.Наименование,Продукты.Штриховой_Код,Продукты.Количество,Продукты.Цена,Продукты.ИД_Еденицы_Измерения,ИД_Еденицы_Измерения.Название 
FROM Продукты 
JOIN ИД_Продукта ON Продукты.ИД_Продукта = ИД_Продукта.ИД_Продукта 
JOIN ИД_Еденицы_Измерения ON Продукты.ИД_Еденицы_Измерения = ИД_Еденицы_Измерения.ИД_Еденицы_Измерения 
WHERE Продукты.ИД_Продукта LIKE '%" + textBox1.Text + "%' AND ИД_Продукта.Наименование LIKE '%" + textBox2.Text + "%' AND Продукты.Штриховой_Код LIKE '%" + textBox3.Text + "%' AND Продукты.Количество LIKE '%" + textBox4.Text + "%' AND Продукты.Цена LIKE '%" + textBox5.Text + "%' AND Продукты.ИД_Еденицы_Измерения LIKE '%" + textBox6.Text + "%' AND ИД_Еденицы_Измерения.Название LIKE '%" + textBox7.Text + "%'";//SQL команда
                                                                                                                                                                                                                                                                                                                                                                                                                           ////
                    SqlDataAdapter da = new SqlDataAdapter();
                    DataSet ds1 = new DataSet();//DataSet для отображения таблицы
                    DataSet ds2 = new DataSet();//DataSet для отображения количества строк таблицы
                    try
                    {
                        ds1.Clear();//Очистка DataSet'а
                        ds2.Clear();//Очистка DataSet'а
                                    ////
                        SqlCommand com = new SqlCommand(sql_1, con);//Создание экземпляра команды
                        da.SelectCommand = com;//Выбор активной команды
                        da.Fill(ds1);//Выполнение команды //"ИД_Еденицы_Измерения"
                        dataGridView1.DataSource = ds1.Tables[0];//Назначение источника данных
                                                                 ////
                        sql_1 = "SELECT COUNT(ИД_Продукта) AS Count FROM Продукты";
                        com = new SqlCommand(sql_1, con);//Создание экземпляра команды
                        da.SelectCommand = com;//Выбор активной команды
                        da.Fill(ds2);//Выполнение команды //"ИД_Еденицы_Измерения"
                                     ////
                        label1.Text = Convert.ToString(ds2.Tables[0].Rows[0].ItemArray[0]) + " Rows | " + Convert.ToString(dataGridView1.Rows.Count) + " Shown";
                        ////
                        da.Dispose();//Освобождение ресурсов
                        com.Dispose();//Освобождение ресурсов
                        ds1.Dispose();//Освобождение ресурсов
                        ds2.Dispose();//Освобождение ресурсов
                        con.Dispose();//Освобождение ресурсов
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            string filePath = string.Empty;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            SqlConnection.ClearPool(new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=" + label10.Text + ";Integrated Security = True; Connect Timeout = 30"));
            openFileDialog.InitialDirectory = Application.StartupPath;
            openFileDialog.Filter = "Mdf files (*.mdf)|*.mdf";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = openFileDialog.FileName;
                label10.Text = filePath;
                
            }
            radioButton4.Checked = true;
            UpdateDataGridView();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            UpdateDataGridView();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            UpdateDataGridView();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            UpdateDataGridView();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            UpdateDataGridView();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            UpdateDataGridView();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            UpdateDataGridView();
            if (label10.Text != "")
            {
                if (label10.Text.Substring(label10.Text.Length - 4) == ".mdf")
                {
                    if (textBox6.Text == "1")
                        textBox7.Text = "Package";
                    if (textBox6.Text == "2")
                        textBox7.Text = "Piece";
                    if (textBox6.Text == "3")
                        textBox7.Text = "Kilogram";
                }
            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            if (textBox7.Text == "1" || textBox7.Text == "Package")
                radioButton1.Checked = true;
            if (textBox7.Text == "2" || textBox7.Text == "Piece")
                radioButton2.Checked = true;
            if (textBox7.Text == "3" || textBox7.Text == "Kilogram")
                radioButton3.Checked = true;
            if (textBox7.Text == "")
                radioButton4.Checked = true;
            UpdateDataGridView();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (label10.Text != "")
            {
                if (label10.Text.Substring(label10.Text.Length - 4) == ".mdf")
                {
                    SqlDataAdapter da = new SqlDataAdapter();
                    SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=" + label10.Text + ";Integrated Security = True; Connect Timeout = 30");
                    DataSet ds2 = new DataSet();
                    if (button2.BackColor == SystemColors.Control)
                    {
                        button2.BackColor = Color.Green;
                        button1.Visible = false;
                        button3.Visible = false;
                        button4.Visible = false;
                        button5.Visible = false;
                        button6.Visible = true;
                        label1.Visible = false;
                        textBox6.Visible = false;
                        radioButton1.Checked = false;
                        radioButton2.Checked = false;
                        radioButton3.Checked = false;
                        radioButton4.Checked = false;
                        radioButton4.Visible = false;
                        dataGridView1.Visible = false;
                        textBox1.ReadOnly = true;
                        textBox7.ReadOnly = true;
                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox3.Text = "";
                        textBox4.Text = "";
                        textBox5.Text = "";
                        textBox6.Text = "";
                        textBox7.Text = "";
                        ////
                        string sql_1 = "SELECT COUNT(ИД_Продукта) AS Count FROM Продукты";
                        SqlCommand com = new SqlCommand(sql_1, con);//Создание экземпляра команды
                        da.SelectCommand = com;//Выбор активной команды
                        da.Fill(ds2);//Выполнение команды //"ИД_Еденицы_Измерения"
                        ////
                        textBox1.Text = Convert.ToString(Convert.ToInt32(ds2.Tables[0].Rows[0].ItemArray[0]) + 1);
                    }
                    else
                    {
                        bool allIsFull = true;
                        if (textBox2.Text == "")
                        {
                            label12.Visible = true;
                            allIsFull = false;
                        }
                        else
                            label12.Visible = false;
                        if (textBox3.Text == "")
                        {
                            label13.Visible = true;
                            allIsFull = false;
                        }
                        else
                            try
                            {
                                int s = Convert.ToInt32(textBox3.Text);
                                label13.Visible = false;
                            }
                            catch(Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                        if (textBox4.Text == "")
                        {
                            label14.Visible = true;
                            allIsFull = false;
                        }
                        else
                            try
                            {
                                int s = Convert.ToInt32(textBox4.Text);
                                label14.Visible = false;
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                        if (textBox5.Text == "")
                        {
                            label15.Visible = true;
                            allIsFull = false;
                        }
                        else
                            try
                            {
                                int s = Convert.ToInt32(textBox5.Text);
                                label15.Visible = false;
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                        if (radioButton1.Checked == false && radioButton2.Checked == false && radioButton3.Checked == false)
                        {
                            label16.Visible = true;
                            allIsFull = false;
                        }
                        else
                            label16.Visible = false;
                        if (allIsFull)
                        {
                            try
                            {
                                con.Open();
                                string sql_1 = "INSERT INTO ИД_Продукта (ИД_Продукта, Наименование) VALUES('" + textBox1.Text + "','" + textBox2.Text + "')";
                                string sql_2 = "INSERT INTO Продукты (Штриховой_код, ИД_Продукта, Количество, Цена, ИД_Еденицы_Измерения) VALUES(" + textBox3.Text + "," + textBox1.Text + "," + textBox4.Text + "," + textBox5.Text + "," + textBox6.Text + ")";
                                SqlCommand sqlCom = new SqlCommand(sql_1, con);
                                sqlCom.ExecuteNonQuery();
                                sqlCom = new SqlCommand(sql_2, con);
                                sqlCom.ExecuteNonQuery();
                                con.Close();
                                MessageBox.Show("Done!");
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }

                            button2.BackColor = SystemColors.Control;
                            dataGridView1.Visible = true;
                            label1.Visible = true;
                            button6.Visible = false;
                            button1.Visible = true;
                            button3.Visible = true;
                            button4.Visible = true;
                            button5.Visible = true;
                            radioButton4.Visible = true;
                            radioButton4.Checked = true;
                            textBox1.ReadOnly = false;
                            textBox7.ReadOnly = false;
                            ////
                            textBox1.Text = "";
                            textBox2.Text = "";
                            textBox3.Text = "";
                            textBox4.Text = "";
                            textBox5.Text = "";
                            textBox6.Text = "";
                            textBox7.Text = "";
                            ////
                            label11.Visible = false;
                            label12.Visible = false;
                            label13.Visible = false;
                            label14.Visible = false;
                            label15.Visible = false;
                            label16.Visible = false;
                            label17.Visible = false;
                            UpdateDataGridView();
                        }
                    }
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (label10.Text != "")
            {
                if (label10.Text.Substring(label10.Text.Length - 4) == ".mdf")
                {
                    button2.BackColor = SystemColors.Control;
                    dataGridView1.Visible = true;
                    button6.Visible = false;
                    button1.Visible = true;
                    button3.Visible = true;
                    button4.Visible = true;
                    button5.Visible = true;
                    label1.Visible = true;
                    radioButton4.Visible = true;
                    radioButton4.Checked = true;
                    textBox1.ReadOnly = false;
                    ////
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    textBox6.Text = "";
                    textBox7.Text = "";
                    ////
                    label11.Visible = false;
                    label12.Visible = false;
                    label13.Visible = false;
                    label14.Visible = false;
                    label15.Visible = false;
                    label16.Visible = false;
                    label17.Visible = false;
                }
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (label10.Text != "")
            {
                if (label10.Text.Substring(label10.Text.Length - 4) == ".mdf")
                {
                    if (radioButton1.Checked)
                    {
                        textBox6.Text = "1";
                        textBox7.Text = "Package";
                    }
                }
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (label10.Text != "")
            {
                if (label10.Text.Substring(label10.Text.Length - 4) == ".mdf")
                {
                    if (radioButton2.Checked)
                    {
                        textBox6.Text = "2";
                        textBox7.Text = "Piece";
                    }
                }
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (label10.Text != "")
            {
                if (label10.Text.Substring(label10.Text.Length - 4) == ".mdf")
                {
                    if (radioButton3.Checked)
                    {
                        textBox6.Text = "3";
                        textBox7.Text = "Kilogram";
                    }
                }
            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (label10.Text != "")
            {
                if (label10.Text.Substring(label10.Text.Length - 4) == ".mdf")
                {
                    if (radioButton4.Checked)
                    {
                        textBox6.Text = "";
                        textBox7.Text = "";
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (label10.Text != "")
            {
                if (label10.Text.Substring(label10.Text.Length - 4) == ".mdf")
                {
                    if (button1.BackColor == SystemColors.Control)
                    {
                        button1.BackColor = Color.Green;
                        button2.Visible = false;
                        button3.Visible = false;
                        button4.Visible = false;
                        button5.Visible = false;
                        label1.Visible = false;
                        button7.Visible = true;
                        dataGridView1.Visible = false;
                        radioButton4.Visible = false;
                        radioButton1.Checked = false;
                        radioButton2.Checked = false;
                        radioButton3.Checked = false;
                        radioButton4.Checked = false;
                        textBox7.ReadOnly = true;
                    }
                    else
                    {
                        bool allIsFull = true;
                        SqlDataAdapter da = new SqlDataAdapter();
                        SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=" + label10.Text + ";Integrated Security = True; Connect Timeout = 30");
                        DataSet ds2 = new DataSet();

                        if (textBox1.Text != "")
                            try
                            {
                                int s = Convert.ToInt32(textBox1.Text);
                                string sql_1 = "SELECT COUNT(ИД_Продукта) AS Count FROM Продукты";
                                SqlCommand com = new SqlCommand(sql_1, con);//Создание экземпляра команды
                                da.SelectCommand = com;//Выбор активной команды
                                da.Fill(ds2);//Выполнение команды //"ИД_Еденицы_Измерения"
                                ////
                                s = Convert.ToInt32(ds2.Tables[0].Rows[0].ItemArray[0]);
                                if(Convert.ToInt32(textBox1.Text) <= s)
                                {
                                    label11.Visible = false;
                                }
                                else
                                {
                                    label11.Visible = true;
                                    allIsFull = false;
                                }
                            }
                            catch(Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                        else
                        {
                            label11.Visible = true;
                            allIsFull = false;
                        }

                        if(textBox2.Text != "")
                            label12.Visible = false;
                        else
                        {
                            label12.Visible = true;
                            allIsFull = false;
                        }

                        if(textBox3.Text != "")
                        {
                            try
                            {
                                int s = Convert.ToInt32(textBox3.Text);
                                label13.Visible = false;
                            }
                            catch(Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                        }
                        else
                        {
                            label13.Visible = true;
                            allIsFull = false;
                        }

                        if(textBox4.Text != "")
                        {
                            try
                            {
                                int s = Convert.ToInt32(textBox4.Text);
                                label14.Visible = false;
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                        }
                        else
                        {
                            label14.Visible = true;
                            allIsFull = false;
                        }

                        if (textBox5.Text != "")
                        {
                            try
                            {
                                int s = Convert.ToInt32(textBox4.Text);
                                label15.Visible = false;
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                        }
                        else
                        {
                            label15.Visible = true;
                            allIsFull = false;
                        }

                        if (radioButton1.Checked == false && radioButton2.Checked == false && radioButton3.Checked == false)
                        {
                            label16.Visible = true;
                            allIsFull = false;
                        }
                        else
                            label16.Visible = false;

                        if(allIsFull)
                        {
                            try
                            {
                                con.Open();
                                string sql_1 = "UPDATE ИД_Продукта SET Наименование = '" + textBox2.Text + "' WHERE ИД_Продукта = " + textBox1.Text;
                                string sql_2 = "UPDATE Продукты SET Штриховой_код = " + textBox3.Text + ", Количество = " + textBox4.Text + ", Цена = " + textBox5.Text + ", ИД_Еденицы_Измерения = " + textBox6.Text + " WHERE ИД_Продукта = " + textBox1.Text;
                                SqlCommand sqlCom = new SqlCommand(sql_1, con);
                                sqlCom.ExecuteNonQuery();
                                sqlCom = new SqlCommand(sql_2, con);
                                sqlCom.ExecuteNonQuery();
                                con.Close();
                                MessageBox.Show("Done!");
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            button1.BackColor = SystemColors.Control;
                            button2.Visible = true;
                            button3.Visible = true;
                            button4.Visible = true;
                            button5.Visible = true;
                            label1.Visible = true;
                            button7.Visible = false;
                            dataGridView1.Visible = true;
                            radioButton4.Visible = true;
                            radioButton4.Checked = true;
                            textBox7.ReadOnly = false;
                            textBox1.Text = "";
                            textBox2.Text = "";
                            textBox3.Text = "";
                            textBox4.Text = "";
                            textBox5.Text = "";
                            textBox6.Text = "";
                            textBox7.Text = "";
                        }
                    }
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (label10.Text != "")
            {
                if (label10.Text.Substring(label10.Text.Length - 4) == ".mdf")
                {
                    button1.BackColor = SystemColors.Control;
                    button2.Visible = true;
                    button3.Visible = true;
                    button4.Visible = true;
                    button5.Visible = true;
                    label1.Visible = true;
                    label11.Visible = false;
                    label12.Visible = false;
                    label13.Visible = false;
                    label14.Visible = false;
                    label15.Visible = false;
                    label16.Visible = false;
                    label17.Visible = false;
                    button7.Visible = false;
                    dataGridView1.Visible = true;
                    radioButton4.Visible = true;
                    radioButton4.Checked = true;
                    textBox7.ReadOnly = false;
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    textBox6.Text = "";
                    textBox7.Text = "";
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (label10.Text != "")
            {
                if (label10.Text.Substring(label10.Text.Length - 4) == ".mdf")
                {
                    if (button3.BackColor == SystemColors.Control)
                    {
                        button3.BackColor = Color.Red;
                        button1.Visible = false;
                        button2.Visible = false;
                        button4.Visible = false;
                        button5.Visible = false;
                        label1.Visible = false;
                        button8.Visible = true;
                        label3.Visible = false;
                        label4.Visible = false;
                        label5.Visible = false;
                        label6.Visible = false;
                        label7.Visible = false;
                        label8.Visible = false;
                        textBox2.Visible = false;
                        textBox3.Visible = false;
                        textBox4.Visible = false;
                        textBox5.Visible = false;
                        textBox7.Visible = false;
                        radioButton1.Visible = false;
                        radioButton2.Visible = false;
                        radioButton3.Visible = false;
                        radioButton4.Visible = false;
                        dataGridView1.Visible = false;
                        textBox1.Text = "";
                    }
                    else
                    {
                        bool allIsFull = true;
                        SqlDataAdapter da = new SqlDataAdapter();
                        SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=" + label10.Text + ";Integrated Security = True; Connect Timeout = 30");
                        DataSet ds2 = new DataSet();

                        if (textBox1.Text != "")
                            try
                            {
                                int s = Convert.ToInt32(textBox1.Text);
                                string sql_1 = "SELECT COUNT(ИД_Продукта) AS Count FROM Продукты";
                                SqlCommand com = new SqlCommand(sql_1, con);//Создание экземпляра команды
                                da.SelectCommand = com;//Выбор активной команды
                                da.Fill(ds2);//Выполнение команды //"ИД_Еденицы_Измерения"
                                ////
                                s = Convert.ToInt32(ds2.Tables[0].Rows[0].ItemArray[0]);
                                if (Convert.ToInt32(textBox1.Text) <= s)
                                {
                                    label11.Visible = false;
                                }
                                else
                                {
                                    label11.Visible = true;
                                    allIsFull = false;
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                        else
                        {
                            label11.Visible = true;
                            allIsFull = false;
                        }

                        if(allIsFull)
                        {
                            try
                            {
                                con.Open();
                                string sql_1 = "DELETE Продукты WHERE ИД_Продукта = " + textBox1.Text;
                                string sql_2 = "DELETE ИД_Продукта WHERE ИД_Продукта = " + textBox1.Text;
                                SqlCommand com = new SqlCommand(sql_1, con);
                                com.ExecuteNonQuery();
                                com = new SqlCommand(sql_2, con);
                                com.ExecuteNonQuery();

                                string sql_3 = "SELECT COUNT(ИД_Продукта) AS Count FROM Продукты";
                                com = new SqlCommand(sql_3, con);//Создание экземпляра команды
                                da.SelectCommand = com;//Выбор активной команды
                                da.Fill(ds2);//Выполнение команды //"ИД_Еденицы_Измерения"
                                ////
                                int number = Convert.ToInt32(ds2.Tables[0].Rows[0].ItemArray[0]);//всего
                                int count = Convert.ToInt32(textBox1.Text);//Выбранный ID

                                string sql_4 = string.Empty;

                                for (int i = count + 1; i <= number; i++)
                                {
                                    sql_4 = "UPDATE ИД_Продукта SET ИД_Продукта = " + (i - 1) + " WHERE ИД_Продукта = " + i;
                                    com = new SqlCommand(sql_4, con);
                                    com.ExecuteNonQuery();
                                }

                                for (int i = count + 1; i <= number; i++)
                                {
                                    sql_4 = "UPDATE Продукты SET ИД_Продукта = " + (i - 1) + " WHERE ИД_Продукта = " + i;
                                    com = new SqlCommand(sql_4, con);
                                    com.ExecuteNonQuery();
                                }

                                con.Close();
                                MessageBox.Show("Done!");
                            }
                            catch(Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            button3.BackColor = SystemColors.Control;
                            button1.Visible = true;
                            button2.Visible = true;
                            button4.Visible = true;
                            button5.Visible = true;
                            label1.Visible = true;
                            button8.Visible = false;
                            label3.Visible = true;
                            label4.Visible = true;
                            label5.Visible = true;
                            label6.Visible = true;
                            label7.Visible = true;
                            label8.Visible = true;
                            label11.Visible = false;
                            label12.Visible = false;
                            label13.Visible = false;
                            label14.Visible = false;
                            label15.Visible = false;
                            label16.Visible = false;
                            label17.Visible = false;
                            textBox2.Visible = true;
                            textBox3.Visible = true;
                            textBox4.Visible = true;
                            textBox5.Visible = true;
                            textBox7.Visible = true;
                            radioButton1.Visible = true;
                            radioButton2.Visible = true;
                            radioButton3.Visible = true;
                            radioButton4.Visible = true;
                            dataGridView1.Visible = true;
                            textBox1.Text = "";
                            textBox2.Text = "";
                            textBox3.Text = "";
                            textBox4.Text = "";
                            textBox5.Text = "";
                            textBox7.Text = "";
                        }
                    }
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (label10.Text != "")
            {
                if (label10.Text.Substring(label10.Text.Length - 4) == ".mdf")
                {
                    button3.BackColor = SystemColors.Control;
                    button1.Visible = true;
                    button2.Visible = true;
                    button4.Visible = true;
                    button5.Visible = true;
                    label1.Visible = true;
                    button8.Visible = false;
                    label3.Visible = true;
                    label4.Visible = true;
                    label5.Visible = true;
                    label6.Visible = true;
                    label7.Visible = true;
                    label8.Visible = true;
                    label11.Visible = false;
                    label12.Visible = false;
                    label13.Visible = false;
                    label14.Visible = false;
                    label15.Visible = false;
                    label16.Visible = false;
                    label17.Visible = false;
                    textBox2.Visible = true;
                    textBox3.Visible = true;
                    textBox4.Visible = true;
                    textBox5.Visible = true;
                    textBox7.Visible = true;
                    radioButton1.Visible = true;
                    radioButton2.Visible = true;
                    radioButton3.Visible = true;
                    radioButton4.Visible = true;
                    dataGridView1.Visible = true;
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap bm = new Bitmap(dataGridView1.Width, dataGridView1.Height);
            dataGridView1.DrawToBitmap(bm, new Rectangle(0, 0, dataGridView1.Width, dataGridView1.Height));
            e.Graphics.DrawImage(bm, 75, 75);
        }
    }
}
