using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Linq.Mapping;

namespace Form_main
{
    struct WORKER //объявление структуры WORKER
    {
        //атрибуты структуры
        public string name;
        public string position;
        public int start_year;
        public string age;
        public string workersname(string a, string b, string c)//функция для форматирования ФИО работника
        {
            if (a != "" & b != "" & c != "")
            {
                string name_of_worker = string.Format("{0} {1}.{2}.", a, b[0], c[0]);
                return name_of_worker;
            }
            else if (a != "" & b != "")
            {
                string name_of_worker = string.Format("{0} {1}.", a, b[0]);
                return name_of_worker;
            }
            else if (a != "")
            {
                string name_of_worker = string.Format("{0}", a);
                return name_of_worker;
            }
            else
            {
                Console.WriteLine("Некорректный ввод ФИО!");
                return "";
            }
        }
        public WORKER(string name, string position, int start_year, string age)
        {
            this.name = name;
            this.position = position;
            this.start_year = start_year;
            this.age = age;
        }
    }
        struct GraphList
    {
        public DateTime TItime;
        public double TIvalue;
    }
    static class GraphPoints
    {
        public static List<GraphList[]> Value { get; set; }
        public static int[] TInumber { get; set; }
        public static int Length { get; set; }
    }

    static class Notification
    {
        public static string Value { get; set; }
    }
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new XML_form());
            //Application.Run(new DataBaseTask());
            //Application.Run(new Form1());
            //Application.Run(new Form3());
            Application.Run(new Common());
        }
    }
}
//CREATE TABLE[Final_Task].[dbo].TI(
//TI_num INT NOT NULL,   --Напряжение
//Substaion_name VARCHAR(64) NOT NULL,  --Название подстанции

//    CONSTRAINT sub_pk PRIMARY KEY(TI_num),
//);
//CREATE TABLE[Final_Task].[dbo].TI_Values(
//TI_number INT NOT NULL,     --Название магазина

//TI_time DATETIME NOT NULL,
//TI_Value FLOAT(24) NOT NULL,
//CONSTRAINT TI_number_fk FOREIGN KEY(TI_number) REFERENCES TI(TI_num),
//	CONSTRAINT TI_time_pk PRIMARY KEY(TI_time),
//);
//CREATE TABLE[Final_Task].[dbo].TI_param(
//TI_number_p INT NOT NULL,
//TI_parameter VARCHAR(64) NOT NULL,
//CONSTRAINT TI_number_pk FOREIGN KEY(TI_number_p) REFERENCES TI(TI_num)
//);

//INSERT INTO Final_Task.dbo.TI(TI_num, Substaion_name)
//VALUES('10001', 'ПС 500 кВ Ключи');
//INSERT INTO Final_Task.dbo.TI(TI_num, Substaion_name)
//VALUES('10002', 'ПС 500 кВ Ключи');
//INSERT INTO Final_Task.dbo.TI(TI_num, Substaion_name)
//VALUES('10003', 'ПС 500 кВ Ключи');
//INSERT INTO Final_Task.dbo.TI(TI_num, Substaion_name)
//VALUES('10004', 'ПС 500 кВ Ключи');
//INSERT INTO Final_Task.dbo.TI(TI_num, Substaion_name)
//VALUES('10005', 'ПС 500 кВ Ключи');
//INSERT INTO Final_Task.dbo.TI(TI_num, Substaion_name)
//VALUES('20001', 'ПС 220 кВ Шелехово');
//INSERT INTO Final_Task.dbo.TI(TI_num, Substaion_name)
//VALUES('20002', 'ПС 220 кВ Шелехово');
//INSERT INTO Final_Task.dbo.TI(TI_num, Substaion_name)
//VALUES('20003', 'ПС 220 кВ Шелехово');
//INSERT INTO Final_Task.dbo.TI(TI_num, Substaion_name)
//VALUES('20004', 'ПС 220 кВ Шелехово');
//INSERT INTO Final_Task.dbo.TI(TI_num, Substaion_name)
//VALUES('20005', 'ПС 220 кВ Шелехово');
//DELETE FROM TI
//WHERE Substaion_name = 'ППС 220 кВ Шелехово';
//INSERT INTO Final_Task.dbo.TI_param(TI_number_p, TI_parameter)
//VALUES('10001', 'P');
//INSERT INTO Final_Task.dbo.TI_param(TI_number_p, TI_parameter)
//VALUES('10002', 'Q');
//INSERT INTO Final_Task.dbo.TI_param(TI_number_p, TI_parameter)
//VALUES('10003', 'I');
//INSERT INTO Final_Task.dbo.TI_param(TI_number_p, TI_parameter)
//VALUES('10004', 'U');
//INSERT INTO Final_Task.dbo.TI_param(TI_number_p, TI_parameter)
//VALUES('10005', 'f');
//INSERT INTO Final_Task.dbo.TI_param(TI_number_p, TI_parameter)
//VALUES('20001', 'P');
//INSERT INTO Final_Task.dbo.TI_param(TI_number_p, TI_parameter)
//VALUES('20002', 'Q');
//INSERT INTO Final_Task.dbo.TI_param(TI_number_p, TI_parameter)
//VALUES('20003', 'I');
//INSERT INTO Final_Task.dbo.TI_param(TI_number_p, TI_parameter)
//VALUES('20004', 'U');
//INSERT INTO Final_Task.dbo.TI_param(TI_number_p, TI_parameter)
//VALUES('20005', 'f');
//INSERT INTO Final_Task.dbo.TI_Values(TI_number, TI_time, TI_Value)
//VALUES('10001','12-01-16 06:59:59' ,'105.2');
//INSERT INTO Final_Task.dbo.TI_Values(TI_number, TI_time, TI_Value)
//VALUES('10001','12-01-16 07:01:59' ,'100.3');
//INSERT INTO Final_Task.dbo.TI_Values(TI_number, TI_time, TI_Value)
//VALUES('10001','12-01-16 07:02:01' ,'107.2');
//INSERT INTO Final_Task.dbo.TI_Values(TI_number, TI_time, TI_Value)
//VALUES('10001','12-01-16 07:04:00' ,'106.6');
//INSERT INTO Final_Task.dbo.TI_Values(TI_number, TI_time, TI_Value)
//VALUES('10001','12-01-16 07:06:01' ,'106.2');
//INSERT INTO Final_Task.dbo.TI_Values(TI_number, TI_time, TI_Value)
//VALUES('10001','12-01-16 07:07:59' ,'106.0');
//INSERT INTO Final_Task.dbo.TI_Values(TI_number, TI_time, TI_Value)
//VALUES('10001','12-01-16 07:09:59' ,'105.8');
//INSERT INTO Final_Task.dbo.TI_Values(TI_number, TI_time, TI_Value)
//VALUES('10001','12-01-16 07:12:01' ,'105.6');
//INSERT INTO Final_Task.dbo.TI_Values(TI_number, TI_time, TI_Value)
//VALUES('10001','12-01-16 07:14:02' ,'105.4');
//INSERT INTO Final_Task.dbo.TI_Values(TI_number, TI_time, TI_Value)
//VALUES('10001','12-01-16 07:15:59' ,'105.2');
//INSERT INTO Final_Task.dbo.TI_Values(TI_number, TI_time, TI_Value)
//VALUES('10002','12-01-16 06:59:59' ,'50.2');
//INSERT INTO Final_Task.dbo.TI_Values(TI_number, TI_time, TI_Value)
//VALUES('10002','12-01-16 07:01:59' ,'56.3');
//INSERT INTO Final_Task.dbo.TI_Values(TI_number, TI_time, TI_Value)
//VALUES('10002','12-01-16 07:02:01' ,'57.2');
//INSERT INTO Final_Task.dbo.TI_Values(TI_number, TI_time, TI_Value)
//VALUES('10002','12-01-16 07:04:00' ,'56.6');
//INSERT INTO Final_Task.dbo.TI_Values(TI_number, TI_time, TI_Value)
//VALUES('10002','12-01-16 07:06:01' ,'56.2');
//INSERT INTO Final_Task.dbo.TI_Values(TI_number, TI_time, TI_Value)
//VALUES('10002','12-01-16 07:07:59' ,'56.0');
//INSERT INTO Final_Task.dbo.TI_Values(TI_number, TI_time, TI_Value)
//VALUES('10002','12-01-16 07:09:59' ,'55.8');
//INSERT INTO Final_Task.dbo.TI_Values(TI_number, TI_time, TI_Value)
//VALUES('10002','12-01-16 07:12:01' ,'55.6');
//INSERT INTO Final_Task.dbo.TI_Values(TI_number, TI_time, TI_Value)
//VALUES('10002','12-01-16 07:14:02' ,'55.4');
//INSERT INTO Final_Task.dbo.TI_Values(TI_number, TI_time, TI_Value)
//VALUES('10002','12-01-16 07:15:59' ,'55.2');
//INSERT INTO Final_Task.dbo.TI_Values(TI_number, TI_time, TI_Value)
//VALUES('10003','12-01-16 06:59:59' ,'138');
//INSERT INTO Final_Task.dbo.TI_Values(TI_number, TI_time, TI_Value)
//VALUES('10003','12-01-16 07:01:59' ,'200');
//INSERT INTO Final_Task.dbo.TI_Values(TI_number, TI_time, TI_Value)
//VALUES('10003','12-01-16 07:02:01' ,'204');
//INSERT INTO Final_Task.dbo.TI_Values(TI_number, TI_time, TI_Value)
//VALUES('10003','12-01-16 07:04:00' ,'189');
//INSERT INTO Final_Task.dbo.TI_Values(TI_number, TI_time, TI_Value)
//VALUES('10003','12-01-16 07:06:01' ,'100');
//INSERT INTO Final_Task.dbo.TI_Values(TI_number, TI_time, TI_Value)
//VALUES('10003','12-01-16 07:07:59' ,'65');
//INSERT INTO Final_Task.dbo.TI_Values(TI_number, TI_time, TI_Value)
//VALUES('10003','12-01-16 07:09:59' ,'48');
//INSERT INTO Final_Task.dbo.TI_Values(TI_number, TI_time, TI_Value)
//VALUES('10003','12-01-16 07:12:01' ,'54');
//INSERT INTO Final_Task.dbo.TI_Values(TI_number, TI_time, TI_Value)
//VALUES('10003','12-01-16 07:14:02' ,'86');
//INSERT INTO Final_Task.dbo.TI_Values(TI_number, TI_time, TI_Value)
//VALUES('10003','12-01-16 07:15:59' ,'138');
//INSERT INTO Final_Task.dbo.TI_Values(TI_number, TI_time, TI_Value)
//VALUES('10004','12-01-16 06:59:59' ,'220.5');
//INSERT INTO Final_Task.dbo.TI_Values(TI_number, TI_time, TI_Value)
//VALUES('10004','12-01-16 07:01:59' ,'210.7');
//INSERT INTO Final_Task.dbo.TI_Values(TI_number, TI_time, TI_Value)
//VALUES('10004','12-01-16 07:02:01' ,'208.4');
//INSERT INTO Final_Task.dbo.TI_Values(TI_number, TI_time, TI_Value)
//VALUES('10004','12-01-16 07:04:00' ,'208.9');
//INSERT INTO Final_Task.dbo.TI_Values(TI_number, TI_time, TI_Value)
//VALUES('10004','12-01-16 07:06:01' ,'209.9');
//INSERT INTO Final_Task.dbo.TI_Values(TI_number, TI_time, TI_Value)
//VALUES('10004','12-01-16 07:07:59' ,'215.5');
//INSERT INTO Final_Task.dbo.TI_Values(TI_number, TI_time, TI_Value)
//VALUES('10004','12-01-16 07:09:59' ,'232.6');
//INSERT INTO Final_Task.dbo.TI_Values(TI_number, TI_time, TI_Value)
//VALUES('10004','12-01-16 07:12:01' ,'207.8');
//INSERT INTO Final_Task.dbo.TI_Values(TI_number, TI_time, TI_Value)
//VALUES('10004','12-01-16 07:14:02' ,'240.3');
//INSERT INTO Final_Task.dbo.TI_Values(TI_number, TI_time, TI_Value)
//VALUES('10004','12-01-16 07:15:59' ,'220.6');
//INSERT INTO Final_Task.dbo.TI_Values(TI_number, TI_time, TI_Value)
//VALUES('10005','12-01-16 06:59:59' ,'50.00');
//INSERT INTO Final_Task.dbo.TI_Values(TI_number, TI_time, TI_Value)
//VALUES('10005','12-01-16 07:01:59' ,'49.99');
//INSERT INTO Final_Task.dbo.TI_Values(TI_number, TI_time, TI_Value)
//VALUES('10005','12-01-16 07:02:01' ,'49.98');
//INSERT INTO Final_Task.dbo.TI_Values(TI_number, TI_time, TI_Value)
//VALUES('10005','12-01-16 07:04:00' ,'49.99');
//INSERT INTO Final_Task.dbo.TI_Values(TI_number, TI_time, TI_Value)
//VALUES('10005','12-01-16 07:06:01' ,'50.01');
//INSERT INTO Final_Task.dbo.TI_Values(TI_number, TI_time, TI_Value)
//VALUES('10005','12-01-16 07:07:59' ,'50.02');
//INSERT INTO Final_Task.dbo.TI_Values(TI_number, TI_time, TI_Value)
//VALUES('10005','12-01-16 07:09:59' ,'50.01');
//INSERT INTO Final_Task.dbo.TI_Values(TI_number, TI_time, TI_Value)
//VALUES('10005','12-01-16 07:12:01' ,'50.01');
//INSERT INTO Final_Task.dbo.TI_Values(TI_number, TI_time, TI_Value)
//VALUES('10005','12-01-16 07:14:02' ,'49.99');
//INSERT INTO Final_Task.dbo.TI_Values(TI_number, TI_time, TI_Value)
//VALUES('10005','12-01-16 07:15:59' ,'50.00');