using System;
using System.Collections.Generic;
using System.Text;

namespace Cars
{
    abstract class Car : TransportFacility, IComparable
    {
        protected int WheelAxle, Wheels;

        protected Int64 IdentificationNumber;
        protected string Number;
        protected string Model, Brand;

        protected double Fuel;
        protected int TankCapacity;
        protected double FuelFlow;

        public Car() { }
        public Car(int Weight, int MaxWeight, int PassengerSeats, int TankCapacity, double FuelFlow, int MaxSpeed)
        {
            this.Weight = Weight;
            this.MaxWeight = MaxWeight;
            this.PassengerSeats = PassengerSeats;
            this.TankCapacity = TankCapacity;
            this.FuelFlow = FuelFlow;
            this.MaxSpeed = MaxSpeed;

            Fuel = 0;
            MaxDistance = TankCapacity * FuelFlow;
            IdentificationNumber = Math.Abs(GetRand());
        }

        static Int64 GetRand()
        {
            Random rnd = new Random();
            Int64 tmp = (long)((rnd.Next() * rnd.Next()) % 1e18);
            return tmp;
        }


        public virtual void FillUpTank(double Fuel)
        {
            if (Fuel <= 0)
                return;

            if (this.Fuel + Fuel >= TankCapacity)
            {
                this.Fuel = TankCapacity;
                if (TankCapacity - this.Fuel - Fuel < 0)
                    Console.WriteLine("Бак полон, остаток бензина : {0} л.", Fuel + this.Fuel - TankCapacity);
                else
                    Console.WriteLine("Бак полон");
                this.Fuel = TankCapacity;
            }
            else
            {
                this.Fuel += Fuel;
                Console.WriteLine("В баке {0} л. топлива", this.Fuel);
            }
        }

        public virtual void FillUpTank()
        {
            if (Fuel == TankCapacity)
                Console.WriteLine("Бак полон");
            else
            {
                Console.WriteLine("Долито {0} л. топлива, бак полон", TankCapacity - Fuel);
                Fuel = TankCapacity;
            }
        }

        public virtual double DrainFuel(double Fuel)
        {
            if (Fuel >= this.Fuel)
            {
                Console.WriteLine("Слито {0} л. топлива, бак пуст", this.Fuel);
                Fuel = this.Fuel;
                this.Fuel = 0;
                return Fuel;
            }
            else
            {
                Console.WriteLine("Слито {0} л. топлива, в баке осталось {1} л.", Fuel, this.Fuel - Fuel);
                this.Fuel -= Fuel;
                return Fuel;
            }
        }

        public void Move(double distance)
        {
            if (distance * FuelFlow > Fuel)
            {
                Console.WriteLine("Недостаточно топлива");
                return;
            }

            Fuel -= distance * FuelFlow;
        }

        public double CurrentFuelVolume
        {
            get
            {
                return Fuel;
            }
        }

        public int MSpeed
        {
            get
            {
                return MaxSpeed;
            }
        }

        public double MDistance
        {
            get
            {
                return MaxDistance;
            }
        }
        public int CompareTo(object o)
        {
            Car car = (Car)o;
            if (car != null)
            {
                return MaxSpeed.CompareTo(car.MaxSpeed);
            }
            throw new Exception("Cannot compare two cars");
        }
        public virtual void ShowInfo()
        {
            Console.WriteLine("Объем бака : {0}\n" +
                "Расход топлива : {1} л. на 100 км.\n" +
                "Масса автомобиля : {2} т.\n" +
                "Грузоподъемность : {3} кг.\n" +
                "Максимальная скорость : {4} км/ч\n" +
                "Кол-во пассажирских мест : {5}\n" +
                "Идентификационный номер : {6}\n" +
                "Название автомобиля : {7}", TankCapacity, FuelFlow,  Weight / 1000.0, MaxWeight - Weight, MaxSpeed, PassengerSeats, IdentificationNumber, Brand + Model);
        }
    }
}