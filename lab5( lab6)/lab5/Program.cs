﻿using System;
using System.Text;
using System.Collections.Generic;
using System.Collections;

namespace Cars
{
    class Program
    {
        static void Main(string[] args)
        {
            //int Weight, MaxWeight;
            //int PassengerSeats;
            //int TankCapacity;
            //int TrunkVolume;
            //double FuelFlow;
            //int MaxSpeed;
            
            
            //do
            //{
            //    Console.WriteLine("Введите вес автомобиля : ");
            //    tmp = Console.ReadLine();
            //} while (!int.TryParse(tmp, out Weight));

            //do
            //{
            //    Console.WriteLine("Введите грузоподъемность автомобиля : ");
            //    tmp = Console.ReadLine();
            //} while (!int.TryParse(tmp, out MaxWeight));

            //MaxWeight += Weight;

            //do
            //{
            //    Console.WriteLine("Введите кол-во пассажирских мест в автомобиле : ");
            //    tmp = Console.ReadLine();
            //} while (!int.TryParse(tmp, out PassengerSeats));

            //do
            //{
            //    Console.WriteLine("Введите объем бака автомобиля : ");
            //    tmp = Console.ReadLine();
            //} while (!int.TryParse(tmp, out TankCapacity));
        
            //do
            //{
            //    Console.WriteLine("Введите расход топлива на 100 километров : ");
            //    tmp = Console.ReadLine();
            //} while (!double.TryParse(tmp, out FuelFlow));

            //do
            //{
            //    Console.WriteLine("Введите максимальную скорость автомобиля : ");
            //    tmp = Console.ReadLine();
            //} while (!int.TryParse(tmp, out MaxSpeed));
            string tmp;
            Cars cars = new Cars(3);
            cars[0] = new Lamborgini(" Aventador", 1550, 2300, 2, 80,  14, 270);
            cars[1] = new Tesla(" Model X", 2400, 3300, 5, 100000, 1500, 250);
            cars[2] = new McLaren(" 720s", 1350, 2100, 2, 80, 12, 340);
            ArrayList CarList = new ArrayList
            {
                cars[0],
                cars[1],
                cars[2]
            };
            
            CarList.Sort();
            Console.WriteLine("Отсортировано по возрастанию скорости:");
            foreach (Car i in CarList)
            {
                Console.WriteLine(" " + i);

            }
            int car = 0;
            while (car < 1 || car > 3)
            {
                Console.WriteLine("1 - Lamborghini\n" +
                    "2 - Tesla\n" +
                    "3 - McLaren\n");
                do
                {
                    Console.Write("Ваш выбор: ");
                    tmp = Console.ReadLine();
                } while (!int.TryParse(tmp, out car) || (car < 0) || (car > 3));
            }
            Console.Clear();
            int request = 1;

            while (request > 0)
            {
                Console.WriteLine("1 - Информация про автомобиль\n" +
                                "2 - Проверить топливо(заряд)\n" +
                                "3 - Поехали\n" +
                                "4 - Слить топливо/ разрядить\n" +
                                "5 - доЗаправить\n" +
                                "6 - Заправить\n" +
                                "0 - Выход");
                tmp = Console.ReadLine();
                int.TryParse(tmp, out request);
                Console.Clear();
                double x;
                switch (request)
                {
                    case 1:
                        cars[car-1].ShowInfo();
                        break;
                    case 2:
                        if (car == 2)
                        {
                            Console.WriteLine("Батарея заряжена на {0} mA/h", cars[car - 1].CurrentFuelVolume);
                        }
                        else
                        {
                            Console.WriteLine("В баке {0} л. топлива", cars[car - 1].CurrentFuelVolume);
                        }
                        break;
                    case 3:
                        Console.WriteLine("Введите расстояние в километрах ");
                        tmp = Console.ReadLine();
                        double.TryParse(tmp, out x);
                        cars[car-1].Move(x);
                        if (car == 2)
                        {
                            Console.WriteLine("Батарея заряжена на {0} mA/h", cars[car - 1].CurrentFuelVolume);
                        }
                        else
                        {
                            Console.WriteLine("В баке {0} л. топлива", cars[car - 1].CurrentFuelVolume);
                        }
                        break;
                    case 4:
                        tmp = Console.ReadLine();
                        double.TryParse(tmp, out x);
                        x = cars[car-1].DrainFuel(x);
                        break;
                    case 5:
                        cars[car-1].FillUpTank();
                        break;
                    case 6:
                        tmp = Console.ReadLine();
                        double.TryParse(tmp, out x);
                        cars[car-1].FillUpTank(x);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}