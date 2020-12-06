using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;


namespace Form_main
{
    public partial class Graph : Form
    {
        public Graph()
        {
            InitializeComponent();
            //создаем элемент Chart
            //Chart myChart = new Chart();
            ////кладем его на форму и растягиваем на все окно.
            //myChart.Parent = this;
            //myChart.Dock = DockStyle.Fill;
            //добавляем в Chart область для рисования графиков, их может быть
            //много, поэтому даем ей имя.
        }

        private void Graph_Load(object sender, EventArgs e)
        {
            //Создаем и настраиваем набор точек для рисования графика, в том
            //не забыв указать имя области на которой хотим отобразить этот
            //набор точек.
            int n = GraphPoints.Length;
            //chart1.ChartAreas.Add(new ChartArea("Графики"));
            DateTime min,max;
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
        }
    }
}
