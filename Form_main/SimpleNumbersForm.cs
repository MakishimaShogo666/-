using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Form_main
{
    public partial class SimpleNumbersForm : Form
    {
        bool a1 = true, a2 = true;
        int n,n0;
        byte k;
        double x;
        long sum;
        string buffer;
        Form2 form2 = null;   // экземпляр (объект) класса формы Form2
        private static int GCD(int n1, int n2)
        {
            while (n2 != 0)
                n2 = n1 % (n1 = n2);
            return n1;
        }
        public void Check(out byte k,out int n, out int n0)
        {
            k = 0;
            n = n0 = 0;
            listBox1.Items.Clear();
            try
            {
                a1 = int.TryParse(textBox1.Text, out n);
                a2 = int.TryParse(textBox6.Text, out n0);
            }
            catch (FormatException)
            {
                textBox1.Text = textBox1.Text.Replace('.', ',');
                textBox6.Text = textBox6.Text.Replace('.', ',');
            };
            if (textBox1.Text == "" | textBox6.Text == "")
            {
                Notification.Value = "Введите границы диапазона!";
                form2.ShowDialog();
                k++;
            }
            else if ((n0 > n) | (n0 <= 0) | (n <= 0) | (a1 = false) | (a2 = false)) //проверка корректности введённых чисел
            {
                Notification.Value = "Неправильные границы диапазона! (Необходимо n0<n, n0,n>0, n0,n - целые)";
                form2.ShowDialog();
                k++;
            }
        }
        static void SimplePairs(int a, int b, List<string> s)
        {
            for (int n1 = a; n1 < b; n1++)
            {
                for (int n2 = n1 + 1; n2 <= b; n2++)
                {
                    if (GCD(n1, n2) == 1)
                    {
                        s.Add(n1 + " и " + n2);
                    }
                }
            }
        }
        static void SimpleNumbersFunction(int n0,int n, List<int> SimpleNumbers)
        {
            int k;
            for (int i = n0; i <= n; i++)
            {
                k = 0;
                for (int j = 1; j <= i; j++)
                {
                    if ((i==1)|((i % j == 0) & (i != j) & (j != 1)))
                    {
                        k++;
                    }
                }
                if (k == 0)
                {
                    SimpleNumbers.Add(i);
                }
            }
        }
        public SimpleNumbersForm()
        {
            InitializeComponent();
            this.BackgroundImageLayout = ImageLayout.Stretch;

            // создаем элементы меню
            ToolStripMenuItem copyMenuItem = new ToolStripMenuItem("Копировать");
            // добавляем элементы в меню
            contextMenuStrip1.Items.AddRange(new[] { copyMenuItem });
            // ассоциируем контекстное меню с текстовым полем
            listBox1.ContextMenuStrip = contextMenuStrip1;
            // устанавливаем обработчики событий для меню
            copyMenuItem.Click += copyMenuItem_Click;
        }
        void copyMenuItem_Click(object sender, EventArgs e)
        {
            buffer = "";
            // если выделен текст в текстовом поле, то копируем его в буфер
            foreach (object h in listBox1.SelectedItems)
            {
                buffer = buffer + h.ToString() + "\n";
            }
            Clipboard.SetText(buffer);
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            List<string> Pairs = new List<string>();
            Check(out k, out n, out n0);
            if (k==0)
            {
                SimplePairs(n0, n, Pairs);
                if (Pairs.Count != 0)
                {
                    textBox2.Text = Pairs.Count.ToString();
                    foreach (string h in Pairs)
                    {
                        listBox1.Items.Add(h);
                    }
                    textBox3.Text = "-";
                    textBox4.Text = "-";
                    textBox5.Text = "-";
                }
                else
                {
                    Notification.Value = "В диапазоне нет пар взаимно простых чисел!";
                    form2.ShowDialog();
                }
            }
        }

        private void ContextMenuStrip1_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(listBox1.SelectedItem.ToString());
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            form2 = new Form2();
        }

        private void Button1_Click_1(object sender, EventArgs e)
        {
            sum = 0;
            List<int> SimpleNumbers = new List<int>();
            Check(out k, out n, out n0);
            if (k==0)
            {
                SimpleNumbersFunction(n0, n, SimpleNumbers);
                if (SimpleNumbers.Count != 0)
                {
                    textBox2.Text = SimpleNumbers.Count.ToString();
                    foreach (int h in SimpleNumbers)
                    {
                        listBox1.Items.Add(h);
                        sum += h;
                    }
                    x = double.Parse(sum.ToString() + ",0") / double.Parse(SimpleNumbers.Count.ToString() + ",0");
                    textBox3.Text = x.ToString();
                    textBox4.Text = SimpleNumbers.Min().ToString();
                    textBox5.Text = SimpleNumbers.Max().ToString();
                }
                else
                {
                    Notification.Value = "В диапазоне нет простых чисел!";
                    form2.ShowDialog();
                }
            }
        }
    }
}
