using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VehicleModel;
using System.Text.RegularExpressions;

namespace GUI
{
    /// <summary>
    /// Класс формы поиска
    /// </summary>
    public partial class SearchForm : Form
    {
        /// <summary>
        /// Событие для передачи данных 
        /// </summary>
        public event EventHandler<VehicleEventArgs> SendDataFromFormEvent;

        /// <summary>
        /// Лист фильтрованных транспортных средств
        /// </summary>
        private readonly List<VehicleBase> _listForSearch;

        /// <summary>
        /// Конструктор формы
        /// </summary>
        public SearchForm(List<VehicleBase> transportList)
        {
            InitializeComponent();
            _listForSearch = transportList;
        }

        /// <summary>
        /// Кнопка фильтрации транспорта
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchButton_Click(object sender, EventArgs e)
        {
            if (CheckCarBox.Checked == false &&
                CheckHybridCarBox.Checked == false &&
                CheckHelicopterBox.Checked == false &&
                CheckFuelLessBox.Checked == false &&
                CheckFuelMoreBox.Checked == false) return;

            foreach (VehicleBase vehicleBase in _listForSearch)
            {
                double fuelFind = double.TryParse(FuelBox.Text, out _)
                            ? Double.Parse(FuelBox.Text)
                            : 0;

                switch (vehicleBase)
                {
                    case Car _ when CheckCarBox.Checked:
                    case HybridCar _ when CheckHybridCarBox.Checked:
                    case Helicopter _ when CheckHelicopterBox.Checked:
                    {
                        if (!(CheckFuelLessBox.Checked || CheckFuelMoreBox.Checked))
                        {
                            SendDataFromFormEvent?.Invoke(this, new VehicleEventArgs(vehicleBase));
                            break;
                        }
                        else
                        {
                            FindVehicleCondition(vehicleBase, fuelFind);
                            break;
                        }
                    }
                }
                if (!(CheckCarBox.Checked || CheckHybridCarBox.Checked || CheckHelicopterBox.Checked))
                {
                    FindVehicleCondition(vehicleBase, fuelFind);
                    break;
                }
            }
            Close();
        }

        /// <summary>
        /// Обработка ввода числа
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NumberBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (double.TryParse(FuelBox.Text + e.KeyChar, out _)
                || e.KeyChar == (char)Keys.Back) return;

            e.Handled = true;
        }

        /// <summary>
        /// Метод проверки объёма топлива для поиска транспорта
        /// </summary>
        /// <param name="vehicleBase">Транспорт</param>
        /// <param name="fuelFind">Значение, относительно которого проверяется топливо</param>
        private void FindVehicleCondition(VehicleBase vehicleBase, double fuelFind)
        {
            if (CheckFuelLessBox.Checked && vehicleBase.Consumption() < fuelFind)
            {
                SendDataFromFormEvent?.Invoke(this, new VehicleEventArgs(vehicleBase));
            }
            else if (CheckFuelMoreBox.Checked && vehicleBase.Consumption() > fuelFind)
            {
                SendDataFromFormEvent?.Invoke(this, new VehicleEventArgs(vehicleBase));
            }
        }
    }
}
