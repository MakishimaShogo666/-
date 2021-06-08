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
using Model.Transport;
using System.Text.RegularExpressions;

namespace GUI
{
    /// <summary>
    /// Класс формы добавления
    /// </summary>
    public partial class AddTransportForm : Form
    {
        /// <summary>
        /// Ивент для передачи данных
        /// </summary>
        public event EventHandler<TransportEventArgs> SendDataFromFormEvent;

        /// <summary>
        /// Тип транспорта "Машина"
        /// </summary>
        private const string CarItem = "Машина";

        /// <summary>
        /// Тип транспорта "Машина-гибрид"
        /// </summary>
        private const string HybridCarItem = "Машина-гибрид";
        
        /// <summary>
        /// Тип транспорта "Вертолет"
        /// </summary>
        private const string HelicopterItem = "Вертолет";

        /// <summary>
        /// Инициализация компонентов
        /// </summary>
        public AddTransportForm()
        {
            InitializeComponent();
            TypeOfTransportBox.Items.Add(CarItem);
            TypeOfTransportBox.Items.Add(HybridCarItem);
            TypeOfTransportBox.Items.Add(HelicopterItem);

            PowerBox.Visible = false;
            PowerLabel.Visible = false;
            PowerLabelUnits.Visible = false;

            TypeOfTransportBox.SelectedIndexChanged += FormElementChange;

            ButtonAdd.Enabled = false;

            NameBox.TextChanged += BottonShow;
            ConsumptionBox.TextChanged += BottonShow;
            DistanceBox.TextChanged += BottonShow;
            PowerBox.TextChanged += BottonShow;

            #if !DEBUG
            {
                GetRandomData.Visible = false;
            }
            #endif
        }

        /// <summary>
        /// Кнопка добаления транспорта
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Add_Click(object sender, EventArgs e)
        {
            switch (TypeOfTransportBox.Text)
            {
                case CarItem:
                {
                    var car = new Car
                    {        
                        Name = NameBox.Text,            
                        AverageConsumption = Double.Parse(ConsumptionBox.Text),        
                        Distance = Double.Parse(DistanceBox.Text)        
                    };        
                    SendDataFromFormEvent?.Invoke(this, new TransportEventArgs(car));    
                    break;                    
                }        
                case HybridCarItem:
                {    
                    var hybridCar = new HybridCar        
                    {    
                        Name = NameBox.Text,        
                        SpecificConsumptionGasEngine = Double.Parse(ConsumptionBox.Text),    
                        TravelTime = Double.Parse(DistanceBox.Text),    
                        ElectricMotorPower = Double.Parse(PowerBox.Text    )
                    };
                    SendDataFromFormEvent?.Invoke(this, new TransportEventArgs(hybridCar));    
                    break;        
                }    
                case HelicopterItem:
                {    
                    var helicopter = new Helicopter        
                    {
                        Name = NameBox.Text,
                        AverageConsumption = Double.Parse(ConsumptionBox.Text),
                        FlightTime = Double.Parse(DistanceBox.Text)
                    };
                    SendDataFromFormEvent?.Invoke(this, new TransportEventArgs(helicopter));    
                    break;        
                }    
            }
            #if !DEBUG
            {
                Close();
            }
            #endif
        }

        /// <summary>
        /// Изменение полей на форме в зависимости
        /// от ComboBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormElementChange(object sender, EventArgs e)
        {
            NameBox.Clear();
            ConsumptionBox.Clear();
            DistanceBox.Clear();
            PowerBox.Clear();

            PowerBox.Visible = false;
            PowerLabel.Visible = false;
            PowerLabelUnits.Visible = false;

            switch (TypeOfTransportBox.Text)
            {
                case CarItem:
                {
                    ConsumptionLabel.Text = "Средний расход:";
                    ConsumptionLabelUnits.Text = "л/100км";
                    DistanceLabel.Text = "Дистанция:";
                    DistanceLabelUnits.Text = "км";
                    break;
                }
                case HybridCarItem:
                {
                    PowerBox.Visible = true;        
                    PowerLabel.Visible = true;    
                    PowerLabelUnits.Visible = true;    

                    ConsumptionLabel.Text = "Удельный расход:";    
                    ConsumptionLabelUnits.Text = "г/кВтч";    
                    DistanceLabel.Text = "Время в пути:";    
                    DistanceLabelUnits.Text = "ч";    
                    break;    
                }    
                case HelicopterItem:
                {
                    ConsumptionLabel.Text = "Средний расход:";        
                    ConsumptionLabelUnits.Text = "кг/ч";    
                    DistanceLabel.Text = "Время полета:";    
                    DistanceLabelUnits.Text = "ч";    
                    break;    
                }
            }
        }

        /// <summary>
        /// Обработка чисел на форме
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NumberBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            const string letterPattern = @"[^0-9]";
            Regex letterRegex = new Regex(letterPattern);

            if (!letterRegex.IsMatch(e.KeyChar.ToString())
                || e.KeyChar == (char)Keys.Back) return;

            e.Handled = true;
        }

        /// <summary>
        /// Обработка наименований на форме
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NameBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            const string letterPattern = @"[^а-я^ё^А-Я^Ё^-]";
            Regex letterRegex = new Regex(letterPattern);

            if (!letterRegex.IsMatch(e.KeyChar.ToString())
                    || e.KeyChar == (char)Keys.Back) return;

            e.Handled = true;
        }

        /// <summary>
        /// Активаия кнопки, если заполнены поля
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BottonShow(object sender, EventArgs e)
        {
            switch (TypeOfTransportBox.Text)
            {
                case CarItem:
                case HelicopterItem:
                {
                    ButtonAdd.Enabled = NameBox.Text.Length > 0        
                        && ConsumptionBox.Text.Length > 0        
                        && DistanceBox.Text.Length > 0;    
                    break;    
                }
                case HybridCarItem:
                {
                    ButtonAdd.Enabled = NameBox.Text.Length > 0    
                        && ConsumptionBox.Text.Length > 0        
                        && DistanceBox.Text.Length > 0    
                        && PowerBox.Text.Length > 0;    
                    break;    
                }
            }
        }

        /// <summary>
        /// Кнопка рандомных данных 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GetRandomData_Click(object sender, EventArgs e)
        {
            TypeOfTransportBox.Text = TypeOfTransportBox.Items
                [Randomizer.GetRandomNumber(0, TypeOfTransportBox.Items.Count)].
                ToString();

            switch (TypeOfTransportBox.Text)
            {
                case CarItem:
                {
                    NameBox.Text = Randomizer.GetRandomName();        
                    ConsumptionBox.Text = Randomizer.GetRandomNumber(1, 40).
                        ToString();            
                    DistanceBox.Text = Randomizer.GetRandomNumber(1, 1000).    
                        ToString();    
                    break;    
                }
                case HybridCarItem:
                {
                    NameBox.Text = Randomizer.GetRandomName();    
                    ConsumptionBox.Text = Randomizer.GetRandomNumber(1, 40).    
                        ToString();    
                    DistanceBox.Text = Randomizer.GetRandomNumber(1, 24).    
                        ToString();    
                    PowerBox.Text = Randomizer.GetRandomNumber(1, 1000).    
                        ToString();    
                    break;   
                }
                case HelicopterItem:
                {
                    NameBox.Text = Randomizer.GetRandomName();    
                    ConsumptionBox.Text = Randomizer.GetRandomNumber(1, 80).    
                        ToString();    
                    DistanceBox.Text = Randomizer.GetRandomNumber(1, 24).    
                        ToString();    
                    break;    
                }    
            }
        }
    }
}
