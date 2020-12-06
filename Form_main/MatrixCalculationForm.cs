using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Form_main
{
    public partial class MatrixCalculationForm : Form
    {
        Random rnd = new Random();
        public static string FileSaver(NotificationForm form)//возврат 2-х переменных
        {
                SaveFileDialog SFD = new SaveFileDialog(); //создание объекта, соответствуюшего диалоговому окну сохранения файла
                SFD.Title = "Выберите файл для записи"; //название диалогового окна
                
                DialogResult SD = SFD.ShowDialog(); //результат диалогового окна (нажатие клавиш "ОК" или "Cancel" или закрытие окна)
                if (SD == DialogResult.OK) //если файл выбран
                {
                    string path1 = SFD.FileName; //полный путь к сохраняемому файлу
                    Notification.Value = "Файл сохранён в "+ path1;
                    form.ShowDialog();
                    return SFD.FileName;
                }
                else
                {
                    Notification.Value = "Вы отменили сохранение, файл не сохранён!";
                    form.ShowDialog();
                    return "";
                }
        }
        public TextBox[,] RandomMaker(int n)
        {
            MatrText = new TextBox[n, n];
            int i, j;
            // 3. Выделение памяти для каждой ячейки матрицы и ее настройка
            for (i = 0; i < n; i++)
                for (j = 0; j < n; j++)
                {
                    // 3.1. Выделить память
                    MatrText[i, j] = new TextBox();

                    // 3.2. Обнулить эту ячейку
                    MatrText[i, j].Text = (rnd.NextDouble()*rnd.Next(-101,101)).ToString("F2");

                    // 3.3. Установить позицию ячейки в форме Form2
                    MatrText[i, j].Location = new System.Drawing.Point(10 + i * dx, 10 + j * dy);

                    // 3.4. Установить размер ячейки
                    MatrText[i, j].Size = new System.Drawing.Size(dx, dy);

                    // 3.5. Пока что спрятать ячейку
                    MatrText[i, j].Visible = false;

                    // 3.6. Добавить MatrText[i,j] в форму form2
                    form4.Controls.Add(MatrText[i, j]);
                }
            return MatrText;
        }
        public TextBox[,] MatrMaker(int n)
        {
            MatrText = new TextBox[n, n];
            int i, j;
            // 3. Выделение памяти для каждой ячейки матрицы и ее настройка
            for (i = 0; i < n; i++)
                for (j = 0; j < n; j++)
                {
                    // 3.1. Выделить память
                    MatrText[i, j] = new TextBox();

                    // 3.2. Обнулить эту ячейку
                    MatrText[i, j].Text = "0";

                    // 3.3. Установить позицию ячейки в форме Form2
                    MatrText[i, j].Location = new System.Drawing.Point(10 + i * dx, 10 + j * dy);

                    // 3.4. Установить размер ячейки
                    MatrText[i, j].Size = new System.Drawing.Size(dx, dy);

                    // 3.5. Пока что спрятать ячейку
                    MatrText[i, j].Visible = false;

                    // 3.6. Добавить MatrText[i,j] в форму form2
                    form4.Controls.Add(MatrText[i, j]);
                }
            return MatrText;
        }
        static double[][] MatrixInverse(double[][] matrix,NotificationForm form)
        {
            int n = matrix.Length;
            double[][] result = MatrixDuplicate(matrix);
            int[] perm;
            int toggle;
            double[][] lum = MatrixDecompose(matrix, out perm, out toggle);
            if (lum == null)
            {
                Notification.Value = "Не удаётся вычислить обратную матрицу! (det=0)";
                form.ShowDialog();
                return null;
            }
            double[] b = new double[n];
            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    if (i == perm[j])
                        b[j] = 1.0;
                    else
                        b[j] = 0.0;
                }
                double[] x = HelperSolve(lum, b);
                for (int j = 0; j < n; ++j)
                    result[j][i] = x[j];
            }
            return result;
        }
        static double[] HelperSolve(double[][] luMatrix, double[] b) //решение уравнения A*X = E
        {
            int n = luMatrix.Length;
            double[] x = new double[n];
            b.CopyTo(x, 0);
            for (int i = 1; i < n; ++i)
            {
                double sum = x[i];
                for (int j = 0; j < i; ++j)
                    sum -= luMatrix[i][j] * x[j];
                x[i] = sum;
            }
            x[n - 1] /= luMatrix[n - 1][n - 1];
            for (int i = n - 2; i >= 0; --i)
            {
                double sum = x[i];
                for (int j = i + 1; j < n; ++j)
                    sum -= luMatrix[i][j] * x[j];
                x[i] = sum / luMatrix[i][i];
            }
            return x;
        }
        static double[][] MatrixCreate(int rows, int cols)
        {
            double[][] result = new double[rows][];
            for (int i = 0; i < rows; ++i)
                result[i] = new double[cols]; 
            return result;
        }
        static double[][] MatrixDuplicate(double[][] matrix)
        {
            double[][] result = MatrixCreate(matrix.Length, matrix[0].Length);
            for (int i = 0; i < matrix.Length; ++i) 
                for (int j = 0; j < matrix[i].Length; ++j)
                    result[i][j] = matrix[i][j];
            return result;
        }
        static double MatrixDeterminant(double[][] matrix,NotificationForm form)
        {
            int[] perm;
            int toggle;
            double[][] lum = MatrixDecompose(matrix, out perm, out toggle);
            if (lum == null)
            {
                return 0;
            }
            double result = toggle;
            for (int i = 0; i < lum.Length; ++i)
                result *= lum[i][i];
            return result;
        }
        static double[][] MatrixDecompose(double[][] matrix, out int[] perm, out int toggle)
        {
            int n = matrix.Length; 
            double[][] result = MatrixDuplicate(matrix);
            perm = new int[n];
            for (int i = 0; i < n; ++i) { perm[i] = i; }
            toggle = 1;
            for (int j = 0; j < n - 1; ++j) // каждый столбец
            {
                double colMax = Math.Abs(result[j][j]); // Наибольшее значение в столбце j
                int pRow = j;
                for (int i = j + 1; i < n; ++i)
                {
                    if (result[i][j] > colMax)
                    {
                        colMax = result[i][j];
                        pRow = i;
                    }
                }
                if (pRow != j) // перестановка строк
                {
                    double[] rowPtr = result[pRow];
                    result[pRow] = result[j];
                    result[j] = rowPtr;
                    int tmp = perm[pRow]; // Меняем информацию о перестановке
                    perm[pRow] = perm[j];
                    perm[j] = tmp;
                    toggle = -toggle; // переключатель перестановки строк
                }
                if (result[j][j] == 0)
                {
                    return null;
                }
                if (result[n-1][n-1] == 0)
                {
                    return null;
                }
                for (int i = j + 1; i < n; ++i)
                {
                    result[i][j] /= result[j][j];
                    for (int k = j + 1; k < n; ++k)
                        result[i][k] -= result[i][j] * result[j][k];
                }
            } // основной цикл по столбцу j
            return result;
        }
        private void Clear_MatrText()
        {
            int MaxX, MaxY;
            MaxX = MatrText.GetLength(0);
            MaxY = MatrText.GetLength(1);
            // Обнуление ячеек MatrText
            for (int i = 0; i < MaxX; i++)
                for (int j = 0; j < MaxY; j++)
                {
                    MatrText[i, j].Text = "0";
                }
        }
        //const int MaxN = 20; // максимально допустимая размерность матрицы
        static int n; // текущая размерность матрицы
        TextBox[,] MatrText = null; // матрица элементов типа TextBox
        double[][] Matr1;
        double[][] result0;
        bool f1; // флажок, который указывает о вводе данных в матрицу Matr1
        bool fdet=false; // флажок, который указывает о вводе данных в матрицу Matr2
        int dx = 40, dy = 20; // ширина и высота ячейки в MatrText[,]
        double det;
        Form4 form4 = null;   // экземпляр (объект) класса формы Form4
        NotificationForm form2 = null;
        private void Button1_Click(object sender, EventArgs e)
        {
            // 1. Чтение размерности матрицы
            if (textBox1.Text == "")
            {
                Notification.Value = "Введите размерность квадратной матрицы!";
                form2.ShowDialog();
                return;
            }
            try
            {
                n = int.Parse(textBox1.Text);
            }
            catch(FormatException)
            {
                Notification.Value = "Размерность должна быть натуральным числом";
                form2.ShowDialog();
                return;
            }
            Matr1 = MatrixCreate(n, n);
            if (MatrText == null)
            {
                MatrText = MatrMaker(n);
            }
            else
            {
                Clear_MatrText();
                int MaxX = MatrText.GetLength(0);
                int MaxY = MatrText.GetLength(1);
                for (int i = 0; i < MaxX; i++)
                {
                    for (int j = 0; j < MaxY; j++)
                    {
                        form4.Controls.Remove(MatrText[i, j]);
                    }
                }
                MatrText = MatrMaker(n);
            }
            // 2. Обнуление ячейки MatrText

            // 3. Настройка свойств ячеек матрицы MatrText
            //    с привязкой к значению n и форме Form2
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    // 3.1. Порядок табуляции
                    MatrText[i, j].TabIndex = i * n + j + 1;
                    // 3.2. Сделать ячейку видимой
                    MatrText[i, j].Visible = true;
                }

            // 4. Корректировка размеров формы
            form4.Width = 10 + n * dx + 20;
            form4.Height = 10 + n * dy + form4.button1.Height + 50;

            // 5. Корректировка позиции и размеров кнопки на форме Form2
            form4.button1.Left = 10;
            form4.button1.Top = 10 + n * dy + 10;
            form4.button1.Width = form4.Width - 30;

            // 6. Название формы
            form4.Text = "Ввод матрицы";

            // 7. Вызов формы Form2
            if (form4.ShowDialog() == DialogResult.OK)
            {
                // 8. Перенос строк из формы Form2 в матрицу Matr1
                for (int j = 0; j < n; j++)
                    for (int i = 0; i < n; i++)
                        if (MatrText[j, i].Text != "")
                        {
                            try
                            {
                                Matr1[j][i] = double.Parse(MatrText[j, i].Text);
                            }
                            catch (FormatException)
                            {
                                Notification.Value=string.Format("Неправильный формат ввода для ({0};{1}) элемента матрицы. Проверьте исходные данные!",i+1,j+1);
                                form2.ShowDialog();
                                return;
                            }
                        }
                        else
                        { Matr1[j][i] = 0;}
                // 9. Данные в матрицу Matr1 внесены
                f1 = true;
                label2.Text = "Матрица введена";
            }
        }
        private void Button3_Click(object sender, EventArgs e)
        {
            //1. Проверка, введены ли данные в обеих матрицах
            if (!(f1 == true))
            {
                Notification.Value = "Матрица не введена!";
                form2.ShowDialog();
                return;
            }
            det = MatrixDeterminant(Matr1, form2);
            fdet = true;
            Notification.Value = det.ToString();
            form2.ShowDialog();
        }
        private void Button5_Click(object sender, EventArgs e)
        {
            if (!(f1 == true))
            {
                Notification.Value = "Матрица не введена!";
                form2.ShowDialog();
                return;
            }
            n = Matr1.Length;
            result0 = MatrixCreate(n, n);
            result0 = MatrixInverse(Matr1,form2);
            if (result0 != null)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        MatrText[i, j].Text = result0[i][j].ToString("F2");
                    }
                }
                form4.Text="Обратная матрица";
                form4.ShowDialog();
            }
        }
        private void Button4_Click(object sender, EventArgs e)
        {
            if (!(f1 == true))
            {
                Notification.Value = "Матрица не введена!";
                form2.ShowDialog();
                return;
            }
            FileStream fw = null;
            string msg;
            byte[] msgByte = null; // байтовый массив

            if ((result0 == null) & (fdet == false))
            {
                Notification.Value = "Не выбрана операция, будет сохранена только исходная матрица!";
                form2.ShowDialog();
            }

            string path = FileSaver(form2);

            // 1. Открыть файл для записи
            if (path == "") return;
            fw = new FileStream(path, FileMode.Create);

            // 2. Запись матрицы результата в файл
            // 2.1. Сначала записать число элементов матрицы Matr3
            msg = "Размерность: "+n.ToString() + "\r\n";
            // перевод строки msg в байтовый массив msgByte
            msgByte = Encoding.Default.GetBytes(msg);

            // запись массива msgByte в файл
            fw.Write(msgByte, 0, msgByte.Length);
            // 2.2. Теперь записать саму матрицу
            msg = "Исходная матрица:"+"\n";
            for (int i = 0; i < n; i++)
            {
                // формируем строку msg из элементов матрицы
                for (int j = 0; j < n; j++)
                {
                    msg = msg + Matr1[j][i].ToString() + "\t";
                }
                msg = msg + "\r\n"; // добавить перевод строки
            }
            if (fdet == true)
            {
                msg += "\n" + "Определитель исходной матрицы: " + det.ToString();
            }
            if (result0 != null)
            {
                msg += "\n"+"Обратная матрица:" + "\n";
                for (int i = 0; i < n; i++)
                {
                    // формируем строку msg из элементов матрицы
                    for (int j = 0; j < n; j++)
                    {
                        msg = msg + result0[j][i].ToString("F2") + "\t";
                    }
                    msg = msg + "\r\n"; // добавить перевод строки
                }
            }
            else
            {
                msg += "\n" + "Обратная матрица: не определена, так как определитель исходной матрицы равен 0!" + "\n";
            }

            // 3. Перевод строки msg в байтовый массив msgByte
            msgByte = Encoding.Default.GetBytes(msg);

            // 4. запись строк матрицы в файл
            fw.Write(msgByte, 0, msgByte.Length);

            // 5. Закрыть файл
            if (fw != null) fw.Close();
        }


        private void Form3_Load(object sender, EventArgs e)
        {

            // І. Инициализация элементов управления и внутренних переменных
            textBox1.Text = "";
            f1 = false; // матрицы еще не заполнены
            label2.Text = "Матрица не введена!";

            // 1. Выделение памяти для формы Form2
            form4 = new Form4();
            form2 = new NotificationForm();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            // 1. Чтение размерности матрицы
            if (textBox1.Text == "")
            {
                Notification.Value = "Введите размерность квадратной матрицы!";
                form2.ShowDialog();
                return;
            }
            try
            {
                n = int.Parse(textBox1.Text);
            }
            catch (FormatException)
            {
                Notification.Value = "Размерность должна быть натуральным числом";
                form2.ShowDialog();
                return;
            }
            Matr1 = MatrixCreate(n, n);
            if (MatrText == null)
            {
                MatrText = RandomMaker(n);
            }
            else
            {
                Clear_MatrText();
                int MaxX = MatrText.GetLength(0);
                int MaxY = MatrText.GetLength(1);
                for (int i = 0; i < MaxX; i++)
                {
                    for (int j = 0; j < MaxY; j++)
                    {
                        form4.Controls.Remove(MatrText[i, j]);
                    }
                }
                MatrText = RandomMaker(n);
            }
            // 2. Обнуление ячейки MatrText

            // 3. Настройка свойств ячеек матрицы MatrText
            //    с привязкой к значению n и форме Form2
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    // 3.1. Порядок табуляции
                    MatrText[i, j].TabIndex = i * n + j + 1;
                    // 3.2. Сделать ячейку видимой
                    MatrText[i, j].Visible = true;
                }

            // 4. Корректировка размеров формы
            form4.Width = 10 + n * dx + 20;
            form4.Height = 10 + n * dy + form4.button1.Height + 50;

            // 5. Корректировка позиции и размеров кнопки на форме Form2
            form4.button1.Left = 10;
            form4.button1.Top = 10 + n * dy + 10;
            form4.button1.Width = form4.Width - 30;

            // 6. Название формы
            form4.Text = "Ввод матрицы";

            // 7. Вызов формы Form2
            if (form4.ShowDialog() == DialogResult.OK)
            {
                // 8. Перенос строк из формы Form2 в матрицу Matr1
                for (int j = 0; j < n; j++)
                    for (int i = 0; i < n; i++)
                        if (MatrText[j, i].Text != "")
                        {
                            try
                            {
                                Matr1[j][i] = double.Parse(MatrText[j, i].Text);
                            }
                            catch (FormatException)
                            {
                                Notification.Value = string.Format("Неправильный формат ввода для ({0};{1}) элемента матрицы. Проверьте исходные данные!", i + 1, j + 1);
                                form2.ShowDialog();
                                return;
                            }
                        }
                        else
                        { Matr1[j][i] = 0; }
                // 9. Данные в матрицу Matr1 внесены
                f1 = true;
                label2.Text = "Матрица сгенерирована";
            }
        }

        public MatrixCalculationForm()
        {
            InitializeComponent();
        }
    }
}
