using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;
using System.Xml.Serialization;
using System.IO;

namespace GUI
{
    /// <summary>
    /// Основная форма
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// Лист транспорта
        /// </summary>
        private List<TransportBase> _transportList = new List<TransportBase>();

        /// <summary>
        /// Лист фильтрованного трансорта
        /// </summary>
        private readonly List<TransportBase> _listForSearch = new List<TransportBase>();

        /// <summary>
        /// На будующее
        /// </summary>
        private readonly XmlSerializer _serializer = new XmlSerializer(typeof(List<TransportBase>));

        /// <summary>
        /// Инициализация компонентов
        /// </summary>
        public MainForm()
        {
            InitializeComponent();

            ClearButton.Visible = false;
        }

        /// <summary>
        /// Кнопка открытия формы добавления
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void AddTransport_Click(object sender, EventArgs e)
        {
            var addTransportForm = new AddTransportForm();
            addTransportForm.SendDataFromFormEvent += AddTransportEvent;
            addTransportForm.ShowDialog();
        }

        /// <summary>
        /// Кнопка удаления
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveTransport_Click(object sender, EventArgs e)
        {
            if (DataGridTransport.RowCount < 1) return;

            var transportRemoval = DataGridTransport.CurrentRow.DataBoundItem;
            _transportList.Remove((TransportBase)transportRemoval);
            ShowList(_transportList);
        }

        /// <summary>
        /// Обработчик события получения даннх из формы добавления
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddTransportEvent(object sender, TransportEventArgs e)
        {
            _transportList.Add(e.SendingTransport);
            ShowList(_transportList);
        }

        //TODO: RSDN+
        /// <summary>
        /// Вывод листа в DataGrid
        /// </summary>
        /// <param name="listToShow">Лист для вывода на форму</param>
        private void ShowList(List<TransportBase> listToShow)
        {
            DataGridTransport.DataSource = null;
            DataGridTransport.DataSource = listToShow;
            DataGridTransport.Columns[0].HeaderText = "Наименование транспорта";
            DataGridTransport.Columns[1].HeaderText = "Затраченное топливо";
        }

        /// <summary>
        /// Обработчик события получения данных из формы поиска
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void AddSearchTransportEvent(object sender, TransportEventArgs e)
        {
            _listForSearch.Add(e.SendingTransport);
            ShowList(_listForSearch);
        }

        /// <summary>
        /// Кнопка открытия формы поиска
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchButton_Click(object sender, EventArgs e)
        {
            SearchForm searchForm = new SearchForm(_transportList);
            searchForm.FormClosed += VisibleButton;
            searchForm.SendDataFromFormEvent += AddSearchTransportEvent;
            searchForm.ShowDialog();
        }

        /// <summary>
        /// Кнопка отчистки фильтрованного списка
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClearButton_Click(object sender, EventArgs e)
        {
            _listForSearch.Clear();
            DataGridTransport.DataSource = null;
            ClearButton.Visible = false;
        }

        /// <summary>
        /// Изменение видимости кнопки отчитски
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VisibleButton (object sender, EventArgs e)
        {
            if (_listForSearch.Count < 1) return;

            ClearButton.Visible = true;
        }

        /// <summary>
        /// Кнопка загрузки файла
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadButton_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = "Файлы (*.aas)|*.aas|Все файлы (*.*)|*.*",
            };

            if (openFileDialog.ShowDialog() != DialogResult.OK) return;

            var path = openFileDialog.FileName.ToString();
            try
            {
                using (FileStream fileStream = new FileStream(path, 
                    FileMode.OpenOrCreate))
                {
                    _transportList = (List<TransportBase>)_serializer.
                        Deserialize(fileStream);
                }
                DataGridTransport.DataSource = _transportList;
                DataGridTransport.CurrentCell = null;
                MessageBox.Show("Файл успешно загружен.", "Загрузка завершена",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception)
            {
                MessageBox.Show("Файл повреждён или не соответствует формату.",
                    "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Кнопка сохранения файла
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (_transportList.Count == 0)
            {
                MessageBox.Show("Отсутствуют данные для сохранения.",
                    "Данные не сохранены",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var saveFileDialog = new SaveFileDialog
            {
                Filter = "Файлы (*.aas)|*.aas|Все файлы (*.*)|*.*",
                AddExtension = true,
                DefaultExt = ".aas"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                var path = saveFileDialog.FileName.ToString();
                using (FileStream fileStream = new FileStream(path,
                    FileMode.OpenOrCreate))
                {
                    _serializer.Serialize(fileStream, _transportList);
                }
            }

            MessageBox.Show("Файл успешно сохранён.", "Сохранение завершено",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
