using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using VehicleModel;

namespace ConsoleRead
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Type[] typeList = Assembly.GetAssembly(typeof(VehicleBase)).GetTypes()
                    .Where(type => type.Namespace == "VehicleModel" && type.Name != "VehicleBase").ToArray();
                Console.WriteLine("Создайте транспорт!");
                int number = CheckCount(byte.MaxValue, "Введите число объектов транспорта: ",
                    $"Введено нецелое число или число, превыщающее максимальное значение! ({byte.MaxValue})");

                List<VehicleBase> vehicleList = new List<VehicleBase>();
                for (int i = 0; i < number; i++)
                {
                    string vehicleInfo = $"Введите тип {i + 1}-го транспорта: ";
                    for (int j = 0; j < typeList.Length - 1; j++)
                    {
                        vehicleInfo += "\n" + $"{j + 1} - " + typeList[j].Name;
                    }
                    InputOutput.TextWriteLine(vehicleInfo, ConsoleColor.Yellow);
                    var vehicleType = int.Parse(InputOutput.Input(null, InputOutput.InputTypeEnum.Integer));
                    switch (vehicleType)
                    {
                        case 1:
                            vehicleList.Add(new Car());
                            break;
                        case 2:
                            vehicleList.Add(new Helicopter());
                            break;
                        case 3:
                            vehicleList.Add(new HybridCar());
                            break;
                        default:
                            throw new Exception("Введённое число больше числа существующих типов транспорта!");
                    }
                }
                foreach (VehicleBase vehicle in vehicleList)
                {
                    switch (vehicle)
                    {
                        case Car car:
                            car = (Car)InputOutput.InputVehicle(vehicle);
                            break;
                        case HybridCar hybrid:
                            hybrid = (HybridCar)InputOutput.InputVehicle(vehicle);
                            break;
                        case Helicopter helicopter:
                            helicopter = (Helicopter)InputOutput.InputVehicle(vehicle);
                            break;
                    }
                }
                foreach (VehicleBase vehicle in vehicleList)
                {
                    InputOutput.VehicleWrite(vehicle.GetType().Name, vehicle);
                }
                
                foreach (VehicleBase vehicle in vehicleList)
                {
                    double distance = double.Parse(InputOutput.Input("Введите пройденную дистанцию: ", 
                        InputOutput.InputTypeEnum.Digit));
                    InputOutput.TextWriteLine($"Потребление на {distance} км: " + 
                        vehicle.Consumption(distance) + " л", ConsoleColor.White);
                }

                foreach (VehicleBase vehicle in vehicleList)
                {
                    double velocity = double.Parse(InputOutput.Input("Введите начальную скорость (км/ч): ", 
                        InputOutput.InputTypeEnum.Digit));
                    double time = double.Parse(InputOutput.Input("Введите время движения, с: ", 
                        InputOutput.InputTypeEnum.Digit));
                    double distance = vehicle.Distance(velocity, time);
                    InputOutput.TextWriteLine($"Потребление на {distance} км: " 
                        + vehicle.Consumption(distance) + " л", ConsoleColor.White);
                }

                if (InputOutput.QuitOfProgram()) return;
            }
        }
        private static int CheckCount(int comparedVar, string inputMessage, string awareMessage)
        {
            int primeVar;

            while (!int.TryParse(InputOutput.Input(inputMessage, InputOutput.InputTypeEnum.Integer), out primeVar)
                    || primeVar > comparedVar)
            {
                InputOutput.TextWriteLine(awareMessage, ConsoleColor.Red);
            }

            return primeVar;
        }

    }
}
