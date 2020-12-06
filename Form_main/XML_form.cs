using System;
using System.Collections.Generic;
using System.Xml;
using System.Linq;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Form_main
{
    public partial class XML_form : Form
    {
        static int n;
        Form2 form2 = null;
        static XElement xml_creator(XElement xworkers, int N, List<WORKER> W) //функция создания xml-файла
        {
            WORKER[] workers = new WORKER[N]; //объявление массива работников
            for (int i = 0; i < N; i++)
            {
                workers[i] = new WORKER(W[i].name, W[i].position, W[i].start_year, W[i].age);
            }
            foreach (WORKER w in workers)
            {
                XElement xworker = new XElement("Работник"); //создание элемента, разграничивающего элементы в xml
                XElement xname = new XElement("ФИО_работника", w.name);
                XElement xposition = new XElement("Должность_работника", w.position);
                XElement xstart_year = new XElement("Год_поступления_на_работу", w.start_year);
                XElement xage = new XElement("Дата_рождения_работника", w.age);
                xworker.Add(xname, xposition, xstart_year,xage); //добавление в сущность "Работник" данных 
                xworkers.Add(xworker); //добавление сущности "работник" в файл
            }
            return xworkers;
        }
        public static string FileSaver_path() //функция для указания пути сохранения файла
        {
            SaveFileDialog SFD = new SaveFileDialog(); //создание объекта, соответствуюшего диалоговому окну сохранения файла
            SFD.Title = "Выберите файл для записи"; //название диалогового окна
            SFD.InitialDirectory = @"C:\Users\1234\Desktop\Программирование и основы алгоритмизации";
            SFD.Filter = "Файлы xml | *.xml";
            SFD.Title = "Выберите файл для записи";
            SFD.RestoreDirectory = true;
            DialogResult SD = SFD.ShowDialog(); //результат диалогового окна (нажатие клавиш "ОК" или "Cancel" или закрытие окна)
            if (SD == DialogResult.OK) //если файл выбран
            {
                return SFD.FileName; //полный путь к сохраняемому файлу
            }
            else
            {
                return "";
            }
        }
        public static string FileOpener()
        {
            OpenFileDialog OFD = new OpenFileDialog(); //создание объекта диалогового окна Windows для выбора файла
            OFD.Filter = "Файлы xml |*.xml"; //фильтр формата файлов
            OFD.InitialDirectory = @"C:\Users\1234\Desktop\Программирование и основы алгоритмизации"; //задание стартовой директории
            OFD.Multiselect = false; //запрет выбора нескольких файлов
            OFD.Title = "Выберите файл для чтения"; //название диалогового окна
            OFD.RestoreDirectory = true;
            DialogResult SD = OFD.ShowDialog();
            if (SD == DialogResult.OK) //результат диалогового окна (нажатие клавиш "ОК" или "Cancel" или закрытие окна)
            {
                return OFD.FileName;
            }
            else return "";
        }
        static List<WORKER> first_xml_table()
        {
            Random rnd = new Random();
            List<WORKER> workers = new List<WORKER>();
            string[] name = new string[10] { "Жуйков А.К.", "Иванов И.Д.", "Андреев Н.С.", "Петров И.А.", "Сидоров А.С.", "Суворов А.В.", "Скобелев М.Д.", "Нахимов П.С.", "Ушаков Ф.Ф.", "Ковалевская С.В." };
            string[] position = new string[10] { "безработный", "инженер-технолог", "специалист 1-ой категории", "специалист 1-ой категории", "дворник", "начанльник охраны", "вахтёр", "начальник отдела", "ведущий специалист", "главный бухгалтер" };
            int[] start_year = new int[10];
            string[] age = new string[10];
            
            for (int i = 0; i < 10; i++)
            {
                WORKER worker = new WORKER();
                start_year[i] = rnd.Next(1980, DateTime.Now.Year);
                DateTime n = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                while (start_year[i]- n.Year < 18)
                {
                    try
                    {
                        n = new DateTime(rnd.Next(1950, (DateTime.Now.Year - 18)), rnd.Next(1, 12), rnd.Next(1, 31));
                    }
                    catch (Exception)
                    {
                        n = new DateTime(rnd.Next(1950, (DateTime.Now.Year - 18)), rnd.Next(1, 12), rnd.Next(1, 28));
                    }
                }
                age[i] = n.ToString("dd.MM.yyyy");
                worker.name = name[i];
                worker.position = position[i];
                worker.start_year = start_year[i];
                worker.age = age[i];
                workers.Add(worker);
            }

            return workers;
        }
        public XML_form()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            List<WORKER> w = first_xml_table();
            n = w.Count;
            XDocument xdoc = new XDocument();
            //XmlElement xRoot = xdoc.DocumentElement;
            XElement xworkers = new XElement("Работники");
            xworkers = xml_creator(xworkers, n, w);
            xdoc.Add(xworkers);
            string path = FileSaver_path();
            try
            {
                xdoc.Save(path);
            }
            catch (Exception ex)
            {
                Notification.Value = ex.Message;
                form2.ShowDialog();
            }
        }
        private DataTable CreateTable()
        {

            //создаём таблицу
            DataTable dt = new DataTable("Работники");
            //создаём три колонки
            DataColumn xml_name = new DataColumn("ФИО_работника", typeof(String));
            DataColumn xml_position = new DataColumn("Должность_работника", typeof(String));
            DataColumn xml_startyear = new DataColumn("Год_поступления_на_работу", typeof(Int32));
            DataColumn xml_age = new DataColumn("Дата_рождения_работника", typeof(String));
            comboBox1.Items.Clear();
            comboBox1.Items.Add("ФИО_работника");
            comboBox1.Items.Add("Должность_работника");
            comboBox1.Items.Add("Год_поступления_на_работу");
            comboBox1.Items.Add("Дата_рождения_работника");
            //добавляем колонки в таблицу
            dt.Columns.Add(xml_name);
            dt.Columns.Add(xml_position);
            dt.Columns.Add(xml_startyear);
            dt.Columns.Add(xml_age);
            return dt;
        }

        private DataTable ReadXml()
        {
            DataTable dt = null;
            string path;
            try
            {
                path = FileOpener();
                //загружаем xml файл
                //XDocument xDoc = XDocument.Load(path);
                //создаём таблицу
                dt = CreateTable();
                DataRow newRow = null;
                XmlDocument xDoc = new XmlDocument(); //создание xml-файла
                xDoc.Load(path); //загрузка xml-файла
                XmlElement xRoot = xDoc.DocumentElement; //объявление корневого элемента xml
                foreach (XmlNode xnode in xRoot) //цикл по всем элементам xml-файла
                {
                    newRow = dt.NewRow();
                    //WORKER W1 = new WORKER(); //создание новой структуры
                    //string shapka = "";
                    //if (xnode.Attributes.Count > 0) //если число атрибутов в xml-файле не равно 0
                    //{
                    //    XmlNode attr = xnode.Attributes.GetNamedItem("ФИО_работника"); //ключевой атрибут
                    //    if (attr != null) //если атрибут с заданным именем не пустой
                    //    {
                    //        newRow["ФИО_работника"] = attr.Value; //задание ФИО работника
                    //        //shapka = "ФИО работника"; //шапка таблицы
                    //    }
                    //}
                    foreach (XmlNode childnode in xnode.ChildNodes) //цикл для неключевых атрибутов
                    {
                        if (childnode.Name == "ФИО_работника") //если имя дочернего атрибута соответствует указанному
                        {
                            newRow["ФИО_работника"] = childnode.InnerText; //задание должности работника
                            //shapka = shapka + "\t" + "Должность работника"; //шапка таблицы
                        }
                        if (childnode.Name == "Должность_работника") //если имя дочернего атрибута соответствует указанному
                        {
                            newRow["Должность_работника"] = childnode.InnerText; //задание должности работника
                            //shapka = shapka + "\t" + "Должность работника"; //шапка таблицы
                        }
                        if (childnode.Name == "Год_поступления_на_работу") //если имя дочернего атрибута соответствует указанному
                        {
                            newRow["Год_поступления_на_работу"] = int.Parse(childnode.InnerText); //задание года поступления на работу
                            //shapka = shapka + "\t" + "Год поступления на работу"; //шапка таблицы
                        }
                        if (childnode.Name == "Дата_рождения_работника") //если имя дочернего атрибута соответствует указанному
                        {
                            newRow["Дата_рождения_работника"] = childnode.InnerText; //задание года поступления на работу
                            //shapka = shapka + "\t" + "Год поступления на работу"; //шапка таблицы
                        }
                    }
                    dt.Rows.Add(newRow);
                }
            }
            catch (Exception ex)
            {
                Notification.Value = ex.Message;
                form2.ShowDialog();
            }
            return dt;
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ReadXml();
        }

        private void XML_form_Load(object sender, EventArgs e)
        {
            form2 = new Form2();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            for (int i = 1; i < dataGridView1.Columns.Count + 1; i++)
            {
                DataColumn column = new DataColumn(dataGridView1.Columns[i - 1].HeaderText);
                dt.Columns.Add(column);
            }
            int columnCount = dataGridView1.Columns.Count;
            foreach (DataGridViewRow dr in dataGridView1.Rows)
            {
                DataRow dataRow = dt.NewRow();
                for (int i = 0; i < columnCount; i++)
                {
                    dataRow[i] = dr.Cells[i].Value;
                }
                dt.Rows.Add(dataRow);
            }
            dt.Rows[dt.Rows.Count - 1].Delete();
            DataSet ds = new DataSet();
            ds.Tables.Add(dt);
            string path = FileSaver_path();
            XmlTextWriter xmlSave = new XmlTextWriter(path, Encoding.UTF8);

            ds.WriteXml(xmlSave);
            xmlSave.Close();
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Button4_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = (DataTable)dataGridView1.DataSource;
                DataTable dt2 = new DataTable();
                dt2.Columns.Add("ФИО_работника", typeof(String));
                dt2.Columns.Add("Должность_работника", typeof(String));
                dt2.Columns.Add("Год_поступления_на_работу", typeof(Int32));
                dt2.Columns.Add("Дата_рождения_работника", typeof(String));
                //DataTable dt = CreateTable();
                DataRow[] orderRows = dt.Select(String.Format("{0} LIKE '%{1}%'", comboBox1.Text,textBox1.Text),comboBox1.Text);
                foreach (DataRow dr in orderRows)
                {
                    dt2.Rows.Add(dr.ItemArray); //Error thrown here.
                }
                //for (int i = 0; i < dataGridView1.Columns.Count; i++)
                //{
                //    if (dataGridView1.Columns[i].HeaderText.ToString() == comboBox1.SelectedItem.ToString())
                //    {
                //        for (int j = 0; j < dataGridView1.Rows.Count; j++)
                //        {
                //            if (dataGridView1.Rows[j].Cells[i].Value.ToString().Contains(textBox1.Text) == true)
                //            {
                //                string n = dt.Rows[j][0].ToString();
                //                string n1 = dt.Rows[j][1].ToString();
                //                int n2 = int.Parse(dt.Rows[j][2].ToString());
                //                string n3 = dt.Rows[j][3].ToString();
                //                DataRow dataRow = dt.Rows[j];
                //                dt2.Rows.Add(dataRow.ItemArray);
                //            }
                //        }
                //    }
                //}
                dataGridView2.DataSource = dt2;
                dataGridView2.AutoResizeColumns();
                //dt2 = (DataTable)dataGridView2.DataSource;
            }
            catch (Exception ex)
            {
                Notification.Value = ex.Message;
                form2.ShowDialog();
            }
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            for (int i = 1; i < dataGridView2.Columns.Count + 1; i++)
            {
                DataColumn column = new DataColumn(dataGridView2.Columns[i - 1].HeaderText);
                dt.Columns.Add(column);
            }
            int columnCount = dataGridView2.Columns.Count;
            foreach (DataGridViewRow dr in dataGridView2.Rows)
            {
                DataRow dataRow = dt.NewRow();
                for (int i = 0; i < columnCount; i++)
                {
                    dataRow[i] = dr.Cells[i].Value;
                }
                dt.Rows.Add(dataRow);
            }
            dt.Rows[dt.Rows.Count - 1].Delete();
            DataSet ds = new DataSet();
            ds.Tables.Add(dt);
            string path = FileSaver_path();
            XmlTextWriter xmlSave = new XmlTextWriter(path, Encoding.UTF8);

            ds.WriteXml(xmlSave);
            xmlSave.Close();
        }
        //DataTable dt = (DataTable)dataGridView1.DataSource;
        ////DataTable dt = new DataTable("Работники");
        ////foreach (DataGridViewColumn column in dataGridView1.Columns)
        ////{
        ////    dt.Columns.Add(column.Name, column.ValueType);
        ////}
        ////for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
        ////{
        ////    DataGridViewRow row = dataGridView1.Rows[i];
        ////    DataRow newRow = dt.Rows.Add();
        ////    for (int j = 0; j < row.Cells.Count; j++)
        ////    {
        ////        newRow[j] = row.Cells[j].Value;
        ////    }
        ////}
        //string path = FileSaver_path();
        //try
        //{
        //    dt.WriteXml(path,false);
        //}
        //catch (Exception ex)
        //{
        //    Notification.Value = ex.Message;
        //    form2.ShowDialog();
        //}
    }
}
