using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace VehicleModel
{
    public enum FuelEnum
    {
        NotDefined,
        Petrol,
        Diesel,
        Kerosene,
        Mixed,
        Hydrogen,
        Electricity,
        Count
    }
    public abstract class VehicleBase
    {
        private const double gravityAcceleration = 9.8;
        private const double horseForceToWatt = 735.5;
        private string _name;
        private double _weight;
        private protected double _waste;
        private double _power;
        private protected FuelEnum _fuel;

        public double Weight
        {
            get
            {
                return _weight;            
            }
            set
            {
                PropertyCheck(value);
                _weight = value;
            }
        }
        public virtual double Waste
        {
            get
            {
                return _waste;
            }
            set
            {
                PropertyCheck(value);
                _waste = value;
            }
        }
        public double Power
        {
            get
            {
                return _power;
            }
            set
            {
                PropertyCheck(value);
                _power = value;
            }
        }
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                PropertyCheck(value);
                _name = value;
            }
        }
        public virtual FuelEnum Fuel
        {
            get
            {
                return _fuel;
            }
            set
            {
                PropertyCheck(value);
                _fuel = value;
            }
        }
        public VehicleBase()
        {

        }
        public VehicleBase(string name, double weight, double power, FuelEnum fuel, double waste)
        { 
            Name = name;
            Weight = weight;
            Power = power;
            Fuel = fuel;
            Waste = waste;
        }

        public double Acceleration()
        {
            return (_power * horseForceToWatt) / ((_weight / 1000) * gravityAcceleration);
        }
        
        public double Velocity(double startValue, double timeInSecond)
        {
            return (startValue/3.6) + Acceleration() * timeInSecond;
        }
        public double Distance(double startVelocity, double timeInSecond)
        {
            return Velocity(startVelocity, timeInSecond) * timeInSecond - Acceleration() * (timeInSecond / 2);
        }
        public virtual double Consumption(double distance)
        {
            return distance * _waste;
        }
        protected void PropertyCheck(object value)
        {
            switch(value)
            {
                case double doubleValue:
                {
                    if (doubleValue < 0)
                    {
                        throw new ArgumentOutOfRangeException("Значение не может быть отрицательным!");
                    }
                    break;
                }
                case string stringValue:
                {
                    if (string.IsNullOrWhiteSpace(stringValue))
                    {
                        throw new ArgumentException("Имя не может быть пустым!");
                    }
                    break;
                }
                case FuelEnum fuelValue:
                {
                    if (fuelValue == FuelEnum.Count || fuelValue == FuelEnum.NotDefined)
                    {
                        throw new ArgumentException("Некорректный вид топлива (служебные значения)!");
                    }
                    break;
                }
                default:
                    throw new FormatException("Строка имела не допустимый формат!");
            }
        }
        public static bool PatternCoincidence(string inputString, object keyInfo,
            string pattern, byte stringMaxLength)
        {
            return (Regex.IsMatch(keyInfo.ToString(), pattern) == true)
                && (inputString.Length < stringMaxLength);
        }
    }
}
