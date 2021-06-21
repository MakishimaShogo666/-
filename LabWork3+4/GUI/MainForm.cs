﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VehicleModel;
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
        /// Список транспорта
        /// </summary>
        private List<VehicleBase> _vehicleList = new List<VehicleBase>();

        /// <summary>
        /// Список отфильтрованного трансорта
        /// </summary>
        private readonly List<VehicleBase> _listForSearch = new List<VehicleBase>();

        /// <summary>
        /// Сериалайзер
        /// </summary>
        private readonly XmlSerializer _serializer = new XmlSerializer(typeof(List<VehicleBase>));

        /// <summary>
        /// Инициализация компонентов
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            DataGridVehicle.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            ClearButton.Visible = false;
        }

        /// <summary>
        /// Кнопка открытия формы добавления
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void AddTransport_Click(object sender, EventArgs e)
        {
            var addTransportForm = new AddVehicleForm();
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
            if (DataGridVehicle.RowCount < 1)
            {
                _vehicleList.Clear();
                return;
            }

            var vehicleRemoval = DataGridVehicle.SelectedRows;
            var vehicleRemovalCount = vehicleRemoval.Count;
            List<int> listRemovalIndex = new List<int>();

            for (int i = 0; i < vehicleRemovalCount; i++)
            {
                listRemovalIndex.Add(vehicleRemoval[i].Index);
            }

            var sortedListRemoval = listRemovalIndex.OrderByDescending(x => x).ToList();
            for (int i = 0; i < vehicleRemovalCount; i++)
            {
                _vehicleList.RemoveAt(sortedListRemoval[i]);
            }
            ShowList(_vehicleList);
        }

        /// <summary>
        /// Обработчик события получения данных из формы добавления
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddTransportEvent(object sender, VehicleEventArgs e)
        {
            _vehicleList.Add(e.SendingVehicle);
            ShowList(_vehicleList);
        }

        /// <summary>
        /// Вывод листа в DataGrid
        /// </summary>
        /// <param name="listToShow">Лист для вывода на форму</param>
        private void ShowList(List<VehicleBase> listToShow)
        {
            DataGridVehicle.DataSource = null;
            DataSourceSet(listToShow);
            ColumnHeaderMaker();
        }

        /// <summary>
        /// Обработчик события получения данных из формы поиска
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void AddSearchTransportEvent(object sender, VehicleEventArgs e)
        {
            _listForSearch.Add(e.SendingVehicle);
            ShowList(_listForSearch);
        }

        /// <summary>
        /// Кнопка открытия формы поиска
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchButton_Click(object sender, EventArgs e)
        {
            SearchForm searchForm = new SearchForm(_vehicleList);
            searchForm.FormClosed += VisibleButton;
            searchForm.SendDataFromFormEvent += AddSearchTransportEvent;
            searchForm.ShowDialog();
            if (ClearButton.Visible)
            {
                SearchButton.Enabled = false;
            }
        }

        /// <summary>
        /// Кнопка очистки фильтрованного списка
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClearButton_Click(object sender, EventArgs e)
        {
            _listForSearch.Clear();
            DataSourceSet(_vehicleList);
            ClearButton.Visible = false;
            SearchButton.Enabled = true;
        }

        /// <summary>
        /// Изменение видимости кнопки очитски
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
                Filter = "Файлы (*.zak)|*.zak|Все файлы (*.*)|*.*",
            };

            if (openFileDialog.ShowDialog() != DialogResult.OK) return;

            var path = openFileDialog.FileName.ToString();
            try
            {
                using (FileStream fileStream = new FileStream(path, 
                    FileMode.OpenOrCreate))
                {
                    _vehicleList = (List<VehicleBase>)_serializer.Deserialize(fileStream);
                }
                DataSourceSet(_vehicleList);

                ColumnHeaderMaker();
                DataGridVehicle.CurrentCell = null;
                MessageBox.Show("Файл успешно загружен.", "Загрузка завершена",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
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
            if (_vehicleList.Count == 0)
            {
                MessageBox.Show("Отсутствуют данные для сохранения.",
                    "Данные не сохранены",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var saveFileDialog = new SaveFileDialog
            {
                Filter = "Файлы (*.zak)|*.zak|Все файлы (*.*)|*.*",
                AddExtension = true,
                DefaultExt = ".zak"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                var path = saveFileDialog.FileName.ToString();
                using (FileStream fileStream = new FileStream(path,
                    FileMode.Create))
                {
                    _serializer.Serialize(fileStream, _vehicleList);
                }
                MessageBox.Show("Файл успешно сохранён.", "Сохранение завершено",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Файл не сохранён", "Сохранение отменено",
                    MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Метод построения заголовков DataGrid
        /// </summary>
        private void ColumnHeaderMaker()
        {
            DataGridVehicle.Columns[0].HeaderText = "Название транспорта";
            DataGridVehicle.Columns[1].HeaderText = "Тип топлива";
            DataGridVehicle.Columns[2].HeaderText = "Дистанция, км";
            DataGridVehicle.Columns[3].HeaderText = "Затраченное топливо, л";
        }
        /// <summary>
        /// Метод задания источника данных в DataGrid
        /// </summary>
        /// <param name="vehicleList">Список единиц транспорта</param>
        private void DataSourceSet(List<VehicleBase> vehicleList)
        {
            DataGridVehicle.DataSource = vehicleList.Select(vehicle => new
            {
                Column1 = vehicle.Name,
                Column2 = VehicleDictionaryRus.FuelToString[vehicle.Fuel],
                Column3 = vehicle.Distance,
                Column4 = vehicle.Consumption()
            }).ToList();
        }
    }
}
