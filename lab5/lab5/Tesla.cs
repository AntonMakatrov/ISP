using System;
using System.Collections.Generic;
using System.Text;

namespace Cars
{
    sealed class Tesla : Car
    {
        public Tesla(string CarModel, int Weight, int MaxWeight, int PassengerSeats, int TankCapacity,  double FuelFlow, int MaxSpeed) :
            base(Weight, MaxWeight, PassengerSeats, TankCapacity, FuelFlow, MaxSpeed)
        {
            Brand = "Tesla";
            Model = CarModel;
        }

        public override void FillUpTank()
        {
            if (Fuel == TankCapacity)
                Console.WriteLine("Аккумулятор полностью заряжен");
            else
            {
                Console.WriteLine("Дозаряжено {0} mA/h., Аккумулятор полностью заряежн", TankCapacity - Fuel);
                Fuel = TankCapacity;
            }
        }

        public override void FillUpTank(double Fuel)
        {
            if (Fuel <= 0)
                return;

            if (this.Fuel + Fuel >= TankCapacity)
            {
                this.Fuel = TankCapacity;
                if (TankCapacity - this.Fuel - Fuel < 0)
                    Console.WriteLine("Аккумулятор полностью заряжен, остаток электричества : {0} mA/h.", Fuel + this.Fuel - TankCapacity);
                else
                    Console.WriteLine("Аккумулятор полностью заряжен");
                this.Fuel = TankCapacity;
            }
            else
            {
                this.Fuel += Fuel;
                Console.WriteLine("Аккумулятор заряжен до {0} mA/h.", this.Fuel);
            }
        }

        public override double DrainFuel(double Fuel)
        {
            if (Fuel >= this.Fuel)
            {
                Console.WriteLine("Передано {0} mA/h. заряда, аккумулятор разряжен", this.Fuel);
                Fuel = this.Fuel;
                this.Fuel = 0;
                return Fuel;
            }
            else
            {
                Console.WriteLine("Передано {0} mA/h. заряда, в аккумуляторе осталось {1} mA/h.", Fuel, this.Fuel - Fuel);
                this.Fuel -= Fuel;
                return Fuel;
            }
        }
        public override void ShowInfo()
        {
            Console.WriteLine("Объем батареи : {0}  mA/h\n" +
                "Расход батареи : {1}  mA/h на 100 км.\n" +
                "Масса автомобиля : {2} т.\n" +
                "Грузоподъемность : {3} кг.\n" +
                "Максимальная скорость : {4} км/ч\n" +
                "Кол-во пассажирских мест : {5}\n" +
                "Идентификационный номер : {6}\n" +
                "Название автомобиля : {7}", TankCapacity, FuelFlow, Weight / 1000.0, MaxWeight - Weight, MaxSpeed, PassengerSeats, IdentificationNumber, Brand + Model);
        }
    }
}