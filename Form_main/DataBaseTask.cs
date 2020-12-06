using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Data.Linq.Mapping;
using System.Windows.Forms.DataVisualization.Charting;

namespace Form_main
{
    public partial class DataBaseTask : Form
    {
        Form2 form2 = new Form2();
        public DataBaseTask()
        {
            InitializeComponent();
            LoadData();
        }
        List<string[]> data_1 = new List<string[]>();
        List<string[]> data_2 = new List<string[]>();
        List<string[]> data_3 = new List<string[]>();
        static string query0_1 = "SELECT * FROM TI ORDER BY TI_num";
        static string query0_2 = "SELECT * FROM TI_param ORDER BY TI_number_p";
        static string query0_3 = "SELECT * FROM TI_Values ORDER BY TI_number";
        static string substaion_name, parameter;
        static string query1;
        static string connectString = @"Data Source=LABUPR14\SQLEXPRESS;Initial Catalog=Final_Task;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        void LoadQuery(DataGridView dataGridView)
        {
            SqlConnection myConnection = new SqlConnection(connectString);

            myConnection.Open();

            SqlCommand command1 = new SqlCommand(query1, myConnection);

            //SqlDataReader reader1 = command1.ExecuteReader();
            //data_1 = DataFormation(reader1);
            SqlDataAdapter data_ad = new SqlDataAdapter(query1, myConnection);
            DataTable t = new DataTable();
            data_ad.Fill(t);
            dataGridView.DataSource = t;
            myConnection.Close();
        }
        void LoadData()
        {
            //string connectString = @"Data Source=LABUPR14\SQLEXPRESS;Initial Catalog=Final_Task;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            SqlConnection myConnection = new SqlConnection(connectString);

            myConnection.Open();

            //string query0_1 = "SELECT * FROM TI ORDER BY TI_num";
            //string query0_2 = "SELECT * FROM TI_param ORDER BY TI_number_p";
            //string query0_3 = "SELECT * FROM TI_Values ORDER BY TI_number";

            SqlCommand command_1 = new SqlCommand(query0_1, myConnection);
            SqlCommand command_2 = new SqlCommand(query0_2, myConnection);
            SqlCommand command_3 = new SqlCommand(query0_3, myConnection);

            SqlDataReader reader_1 = command_1.ExecuteReader();
            data_1 = DataFormation(reader_1);
            SqlDataReader reader_2 = command_2.ExecuteReader();
            data_2 = DataFormation(reader_2);
            SqlDataReader reader_3 = command_3.ExecuteReader();
            data_3 = DataFormation(reader_3);

            SqlDataAdapter data_ad_1 = new SqlDataAdapter(query0_1, myConnection);
            SqlDataAdapter data_ad_2 = new SqlDataAdapter(query0_2, myConnection);
            SqlDataAdapter data_ad_3 = new SqlDataAdapter(query0_3, myConnection);

            DataTable t_1 = new DataTable();
            data_ad_1.Fill(t_1);
            dataGridView1.DataSource = t_1;
            DataTable t_2 = new DataTable();
            data_ad_2.Fill(t_2);
            dataGridView2.DataSource = t_2;
            DataTable t_3 = new DataTable();
            data_ad_3.Fill(t_3);
            dataGridView3.DataSource = t_3;
            //dataGridView3.Columns[1].DefaultCellStyle.Format = "yyyy-MM-dd hh:mm:ss";

            myConnection.Close();

            //dataGridView1.RowHeadersVisible = false;
            //dataGridView1.AutoSize = true;
            //dataGridView2.AutoSize = true;
            //dataGridView3.AutoSize = true;
            //foreach (string[] s in data_1)
            //    dataGridView1.Rows.Add(s);
            //foreach (string[] s in data_2)
            //    dataGridView2.Rows.Add(s);
            //foreach (string[] s in data_3)
            //    dataGridView3.Rows.Add(s);
            listBox1.Items.Clear();
            for (int i = 0; i < data_3.Count;i++)
            {
                if (i > 0)
                {
                    if (data_3[i][0] != data_3[i - 1][0])
                    {
                        listBox1.Items.Add(data_3[i][0]);
                    }
                }
                else
                {
                    listBox1.Items.Add(data_3[i][0]);
                }
            }
        }
        private void DataBaseTask_Load(object sender, EventArgs e)
        {
            
        }
        private List<string[]> DataFormation(SqlDataReader reader)
        {
            List<string[]> data = new List<string[]>();
            int n = reader.FieldCount;
            while (reader.Read())
            {
                data.Add(new string[n]);
                for (int i = 0; i < n; i++)
                {
                    data[data.Count - 1][i] = reader[i].ToString().Replace('.',',');
                }
            }
            reader.Close();
            return data;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            int countSelection = listBox1.SelectedItems.Count;
            int n = data_3.Count;
            int[] tinum=new int[countSelection];
            List<GraphList[]> plot_ti= new List<GraphList[]>();
            int k;
            for (int j=0;j< countSelection; j++)
            {
                k = 1;
                tinum[j] = int.Parse(listBox1.SelectedItems[j].ToString());
                for (int i = 0; i < n; i++)
                {
                    if (data_3[i][0].ToString() == listBox1.SelectedItems[j].ToString())
                    {
                        if (k> plot_ti.Count)
                            plot_ti.Add(new GraphList[countSelection]);
                        plot_ti[(k-1)][j].TItime = DateTime.Parse(data_3[i][1]);
                        plot_ti[(k-1)][j].TIvalue = double.Parse(data_3[i][2]);
                        k++;
                    }
                }
            }
            GraphPoints.TInumber = tinum;
            GraphPoints.Length = tinum.Length;
            GraphPoints.Value = plot_ti;
            Graph graph = new Graph();
            graph.ShowDialog();
            minigraph();
        }

        private void DataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            string Connect = connectString;
            SqlConnection myConnection = new SqlConnection(Connect);
            myConnection.Open();
            SqlDataAdapter da1 = new SqlDataAdapter();
            SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(da1);
            da1.SelectCommand = new SqlCommand (query0_1, myConnection);
            da1.UpdateCommand = cmdBuilder.GetUpdateCommand();
            try
            {
                da1.Update((DataTable)dataGridView1.DataSource);
            }
            catch (SqlException)
            {
                Notification.Value = "Ошибка внесения изменений в БД - нарушение последовательности заполнения таблиц!";
                form2.ShowDialog();
            }
            myConnection.Close();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            string Connect = connectString;
            SqlConnection myConnection = new SqlConnection(Connect);
            myConnection.Open();
            SqlDataAdapter da2 = new SqlDataAdapter();
            SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(da2);
            da2.SelectCommand = new SqlCommand(query0_2, myConnection);
            da2.UpdateCommand = cmdBuilder.GetUpdateCommand();
            try
            {
                da2.Update((DataTable)dataGridView2.DataSource);
            }
            catch (SqlException)
            {
                Notification.Value = "Ошибка внесения изменений в БД - нарушение последовательности заполнения таблиц!";
                form2.ShowDialog();
            }
            myConnection.Close();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            string Connect = connectString;
            SqlConnection myConnection = new SqlConnection(Connect);
            myConnection.Open();
            SqlDataAdapter da3 = new SqlDataAdapter();
            SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(da3);
            da3.SelectCommand = new SqlCommand(query0_3, myConnection);
            da3.UpdateCommand = cmdBuilder.GetUpdateCommand();
            try
            {
                da3.Update((DataTable)dataGridView3.DataSource);
                SqlDataReader reader_3 = da3.SelectCommand.ExecuteReader();
                data_3 = DataFormation(reader_3);
                listBox1.Items.Clear();
                for (int i = 0; i < data_3.Count; i++)
                {
                    if (i > 0)
                    {
                        if (data_3[i][0] != data_3[i - 1][0])
                        {
                            listBox1.Items.Add(data_3[i][0]);
                        }
                    }
                    else
                    {
                        listBox1.Items.Add(data_3[i][0]);
                    }
                }
            }
            catch (SqlException)
            {
                Notification.Value = "Ошибка внесения изменений в БД - нарушение последовательности заполнения таблиц!";
                form2.ShowDialog();
            }
            myConnection.Close();
        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }

        private void Button6_Click(object sender, EventArgs e)
        {
            substaion_name = textBox1.Text;
            parameter = textBox2.Text;
            query1 = string.Format("DECLARE @Area varchar(64),@Regime varchar(64) SET @Area = '{0}'; SET @Regime = '{1}'; SELECT TI.Substaion_name AS \"Название подстанции\", TI_param.TI_parameter AS \"Параметр режима\", TI_Values.TI_Value AS \"Значение параметра\", TI_Values.TI_Time AS \"Время\" FROM TI, TI_param, TI_Values WHERE TI.Substaion_name = @Area AND TI_param.TI_parameter=@Regime AND TI_param.TI_number_p = TI.TI_num AND TI_Values.TI_number = TI.TI_num GROUP BY  TI.Substaion_name,TI_param.TI_parameter,TI_Values.TI_Value, TI_Values.TI_Time,TI.TI_num,TI_param.TI_number_p;", substaion_name, parameter);
            try { LoadQuery(dataGridView4); }
            catch (SqlException) { Notification.Value = "Проверьте название подстанции и параметра!"; form2.ShowDialog(); }
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            query1 = textBox3.Text;
            try { LoadQuery(dataGridView5); }
            catch (SqlException) { Notification.Value = "Некорректный запрос!"; form2.ShowDialog(); }
        }

        private void DataGridView5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void minigraph()
        {
            chart1.Series.Clear();
            int n = GraphPoints.Length;
            DateTime min, max;
            min = GraphPoints.Value[0][0].TItime;
            max = GraphPoints.Value[0][0].TItime;
            for (int j = 0; j < n; j++)
            {

                Series SeriesOfPoint = new Series(GraphPoints.TInumber[j].ToString());
                SeriesOfPoint.ChartType = SeriesChartType.Line;
                //SeriesOfPoint.ChartArea = GraphPoints.TInumber[j].ToString();
                for (int i = 0; i < GraphPoints.Value.Count; i++)
                {
                    if (GraphPoints.Value[i][j].TItime < min)
                        min = GraphPoints.Value[i][j].TItime;
                    if (GraphPoints.Value[i][j].TItime > max)
                        max = GraphPoints.Value[i][j].TItime;
                    //SeriesOfPoint.XValueType = ChartValueType.Time;
                    SeriesOfPoint.Points.AddXY(GraphPoints.Value[i][j].TItime, GraphPoints.Value[i][j].TIvalue);

                }
                //Добавляем созданный набор точек в Chart
                chart1.Series.Add(SeriesOfPoint);
            }
            chart1.ChartAreas[0].AxisX.Interval = Convert.ToDouble(IntervalAutoMode.FixedCount);
            chart1.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Auto;
            chart1.ChartAreas[0].AxisX.LabelStyle.Format = "HH:mm:ss";
            chart1.ChartAreas[0].RecalculateAxesScale();
        }
        private void Button5_Click(object sender, EventArgs e)
        {
            try
            {
                LoadData();
            }
            catch (SqlException)
            {
                Notification.Value = "Ошибка обновления БД!";
                form2.ShowDialog();
            }
        }
    }
}