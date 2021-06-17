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
    /// Класс формы добавления
    /// </summary>
    public partial class AddVehicleForm : Form
    {
        //TODO: доступ, именование, неизменяемость коллекции.+/-
        ///// <summary>
        ///// Словарь соответствия названия топлива с его типом
        ///// </summary>
        //public Dictionary<string, FuelEnum> dictionaryFuelInfo = new Dictionary<string, FuelEnum>
        //{
        //    { "Бензин", FuelEnum.Petrol },
        //    { "Дизель", FuelEnum.Diesel },
        //    { "Керосин", FuelEnum.Kerosene },
        //    { "Смешанное топливо", FuelEnum.Mixed },
        //    { "Водород", FuelEnum.Hydrogen },
        //    { "Электричество", FuelEnum.Electricity },
        //};

        /// <summary>
        /// Событие передачи данных
        /// </summary>
        public event EventHandler<VehicleEventArgs> SendDataFromFormEvent;

        /// <summary>
        /// Тип транспорта "Машина"
        /// </summary>
        private const string CarItem = "Машина";

        /// <summary>
        /// Тип транспорта "Гибрид"
        /// </summary>
        private const string HybridCarItem = "Гибрид";
        
        /// <summary>
        /// Тип транспорта "Вертолёт"
        /// </summary>
        private const string HelicopterItem = "Вертолёт";

        /// <summary>
        /// Инициализация компонентов
        /// </summary>
        public AddVehicleForm()
        {
            InitializeComponent();
            TypeOfTransportBox.Items.Add(CarItem);
            TypeOfTransportBox.Items.Add(HybridCarItem);
            TypeOfTransportBox.Items.Add(HelicopterItem);
            
            TypeOfTransportBox.SelectedIndexChanged += FormElementChange;

            ButtonAdd.Enabled = false;
            TypeOfFuelBox.Enabled = true;

            NameBox.TextChanged += ShowButton;
            WasteBox.TextChanged += ShowButton;
            WeightBox.TextChanged += ShowButton;
            PowerBox.TextChanged += ShowButton;
            DistanceTextBox.TextChanged += ShowButton;
        }

        /// <summary>
        /// Кнопка добаления транспорта
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Add_Click(object sender, EventArgs e)
        {
            try
            {
                switch (TypeOfTransportBox.Text)
                {
                    case CarItem:
                    {
                        var car = new Car
                        {
                            Name = NameBox.Text,
                            Waste = Double.Parse(WasteBox.Text),
                            Fuel = FuelSet(TypeOfFuelBox),
                            Weight = Double.Parse(WeightBox.Text),
                            Power = Double.Parse(PowerBox.Text),
                            Distance = Double.Parse(DistanceTextBox.Text)
                        };
                        SendDataFromFormEvent?.Invoke(this, new VehicleEventArgs(car));
                        break;
                    }
                    case HybridCarItem:
                    {
                        var hybridCar = new HybridCar
                        {
                            Name = NameBox.Text,
                            Waste = Double.Parse(WasteBox.Text),
                            Fuel = FuelSet(TypeOfFuelBox),
                            Weight = Double.Parse(WeightBox.Text),
                            Power = Double.Parse(PowerBox.Text),
                            Distance = Double.Parse(DistanceTextBox.Text)
                        };
                        SendDataFromFormEvent?.Invoke(this, new VehicleEventArgs(hybridCar));
                        break;
                    }
                    case HelicopterItem:
                    {
                        var helicopter = new Helicopter
                        {
                            Name = NameBox.Text,
                            Waste = Double.Parse(WasteBox.Text),
                            Fuel = FuelSet(TypeOfFuelBox),
                            Weight = Double.Parse(WeightBox.Text),
                            Power = Double.Parse(PowerBox.Text),
                            Distance = Double.Parse(DistanceTextBox.Text)
                        };
                        SendDataFromFormEvent?.Invoke(this, new VehicleEventArgs(helicopter));
                        break;
                    }
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Введено некорректное значение, проверьте данные!",
                    "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            WasteBox.Clear();
            WeightBox.Clear();
            PowerBox.Clear();

            switch (TypeOfTransportBox.Text)
            {
                case CarItem:
                {
                    //TODO: Использовать словарь+
                    TypeOfFuelBox.Items.Clear();
                    TypeOfFuelBox.Items.Add(VehicleBase.FuelToStringDictionary[FuelEnum.Petrol]);
                    TypeOfFuelBox.Items.Add(VehicleBase.FuelToStringDictionary[FuelEnum.Diesel]);
                    break;
                }
                case HelicopterItem:
                {
                    //TODO: Использовать словарь+
                    TypeOfFuelBox.Items.Clear();
                    TypeOfFuelBox.Items.Add(VehicleBase.FuelToStringDictionary[FuelEnum.Kerosene]);
                    break;
                }
                case HybridCarItem:
                {
                    //TODO: Использовать словарь+
                    TypeOfFuelBox.Items.Clear();
                    TypeOfFuelBox.Items.Add(VehicleBase.FuelToStringDictionary[FuelEnum.Mixed]);
                    TypeOfFuelBox.Items.Add(VehicleBase.FuelToStringDictionary[FuelEnum.Hydrogen]);
                    TypeOfFuelBox.Items.Add(VehicleBase.FuelToStringDictionary[FuelEnum.Electricity]);
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
            //TODO: duplication +/-
            if (double.TryParse(((TextBox)sender).Text + e.KeyChar, out _)
                || e.KeyChar == (char)Keys.Back) return;

            e.Handled = true;
        }

        /// <summary>
        /// Обработка текста на форме
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NameBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            //TODO: duplication +/-
            const string letterPattern = @"\W\s";
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
        private void ShowButton(object sender, EventArgs e)
        {
            ButtonAdd.Enabled = NameBox.Text.Length > 0
                                && WasteBox.Text.Length > 0
                                && WeightBox.Text.Length > 0
                                && PowerBox.Text.Length > 0
                                && DistanceTextBox.Text.Length > 0;
        }

        /// <summary>
        /// Кнопка случайных данных 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GetRandomData_Click(object sender, EventArgs e)
        {
            TypeOfTransportBox.Text = TypeOfTransportBox.Items
                [(int)VehicleRandomizer.GetRandomNumber(TypeOfTransportBox.Items.Count)].
                ToString();
            TypeOfFuelBox.Text = TypeOfFuelBox.Items
                [(int)VehicleRandomizer.GetRandomNumber(TypeOfFuelBox.Items.Count)].
                ToString();
            WasteBox.Enabled = true;
            switch (TypeOfTransportBox.Text)
            {
                case CarItem:
                {
                    NameBox.Text = VehicleRandomizer.GetRandomName(CarItem);
                    WasteBox.Text = VehicleRandomizer.GetRandomNumber(40).
                        ToString("#.000");
                    WeightBox.Text = VehicleRandomizer.GetRandomNumber(10).
                        ToString("#.000");
                    PowerBox.Text = VehicleRandomizer.GetRandomNumber(1000).
                        ToString("#.000");
                    DistanceTextBox.Text = VehicleRandomizer.GetRandomNumber(10000).
                        ToString("#.000");
                    break;
                }
                case HybridCarItem:
                {
                    NameBox.Text = VehicleRandomizer.GetRandomName(HybridCarItem);
                    if (TypeOfFuelBox.Text == VehicleBase.FuelToStringDictionary[FuelEnum.Electricity])
                    {
                        WasteBox.Text = "0";
                        WasteBox.Enabled = false;
                    }
                    else
                    {
                        WasteBox.Text = VehicleRandomizer.GetRandomNumber(10).
                            ToString("#.000");
                    }
                    WeightBox.Text = VehicleRandomizer.GetRandomNumber(24).
                        ToString("#.000");
                    PowerBox.Text = VehicleRandomizer.GetRandomNumber(1000).
                        ToString("#.000");
                    DistanceTextBox.Text = VehicleRandomizer.GetRandomNumber(10000).
                        ToString("#.000");
                    break;
                }
                case HelicopterItem:
                {
                    NameBox.Text = VehicleRandomizer.GetRandomName(HelicopterItem);
                    WasteBox.Text = VehicleRandomizer.GetRandomNumber(400).
                        ToString("#.000");
                    WeightBox.Text = VehicleRandomizer.GetRandomNumber(50).
                        ToString("#.000");
                    PowerBox.Text = VehicleRandomizer.GetRandomNumber(10000).
                        ToString("#.000");
                    DistanceTextBox.Text = VehicleRandomizer.GetRandomNumber(10000).
                        ToString("#.000");
                    break;
                }
            }
        }

        /// <summary>
        /// Событие изменения текста в поле DistanceTextBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DistanceTextBox_TextChanged(object sender, EventArgs e)
        {
            switch (TypeOfTransportBox.Text)
            {
                case CarItem:
                {
                    var car = new Car
                    {
                        Fuel = FuelSet(TypeOfFuelBox),
                        //TODO: duplication+
                        Waste = PropertyValueSet(WasteBox),
                        //TODO: duplication+
                        Distance = PropertyValueSet(DistanceTextBox)
                    };
                    ConsumptionTextBox.Text = car.Consumption().ToString("#.000");
                    break;
                }
                case HybridCarItem:
                {
                    var hybridCar = new HybridCar
                    {
                        Fuel = FuelSet(TypeOfFuelBox),
                        //TODO: duplication+
                        Waste = PropertyValueSet(WasteBox),
                        //TODO: duplication+
                        Distance = PropertyValueSet(DistanceTextBox)
                    };
                    ConsumptionTextBox.Text = hybridCar.Consumption().ToString("#.000");
                    break;
                }
                case HelicopterItem:
                {
                    var helicopter = new Helicopter
                    {
                        Fuel = FuelSet(TypeOfFuelBox),
                        //TODO: duplication+
                        Waste = PropertyValueSet(WasteBox),
                        //TODO: duplication+
                        Distance = PropertyValueSet(DistanceTextBox)
                    };
                    ConsumptionTextBox.Text = helicopter.Consumption().ToString("#.000");
                    break;
                }
            }
        }

        /// <summary>
        /// Событие изменения в поле TypeOfFuelBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TypeOfFuelBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TypeOfFuelBox.Text == VehicleBase.FuelToStringDictionary[FuelEnum.Electricity])
            {
                WasteBox.Text = "0";
                WasteBox.Enabled = false;
            }
            else
            {
                WasteBox.Enabled = true;
            }
        }
        /// <summary>
        /// Метод задания значения свойства по данным в textBox
        /// </summary>
        /// <param name="textBox"></param>
        /// <returns>Значение свойства</returns>
        private double PropertyValueSet(TextBox textBox)
        {
            return (textBox.Text.Length > 0)
                            ? Double.Parse(textBox.Text)
                            : 0;
        }
        /// <summary>
        /// Метод задания типа топлива по значению в comboBox
        /// </summary>
        /// <param name="comboBox"></param>
        /// <returns>Тип топлива</returns>
        private FuelEnum FuelSet(ComboBox comboBox)
        {
            return VehicleBase.FuelToStringDictionary.FirstOrDefault(x => x.Value == comboBox.Text).Key;
        }
    }
}
