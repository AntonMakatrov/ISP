using System;



namespace lab3
{
    class Car
    {
        static protected uint amount ;
        protected readonly uint id;
        protected string brand;
        protected string model;
        protected uint yearOfRelease;
        protected string color;
        protected uint fuelCapacity;
        protected uint currentFuel;
        protected uint fuelUsage;
        protected uint weight;
        protected uint horsepower;
        protected uint distance;



        public Car(uint weight, uint yearOfRelease, uint fuelCapacity, uint currentFuel, 
                    uint fuelUsage, string brand, string model, string color, uint horsepower)
        {
            id = amount + 1;
            this.weight = weight;
            this.yearOfRelease = yearOfRelease;
            this.fuelCapacity = fuelCapacity;
            if (currentFuel > fuelCapacity)
            {
                Console.WriteLine("Your max level of fuel is smaller. We fully tank up your car.");
                this.currentFuel = fuelCapacity;
            }
            else
            {
                this.currentFuel = currentFuel;
            }
            this.fuelUsage = fuelUsage;
            this.brand = brand;
            this.model = model;
            this.color = color;
            this.horsepower = horsepower;

        }

        public uint Horsepower
        {
            get => horsepower;
            set => horsepower = value;
        }

        public string Model
        {
            get => model;
            set => model = value;
        }
        public string Color
        {
            get => color;
            set => color = value;
        }

        public uint FuelUsage
        {
            get => fuelUsage;
            set => fuelUsage = value;
        }

        public Car()
        {
            id = amount + 1;
        }

        public uint Id
        {
            get => id;
        }

        public uint Weight
        {
            get => weight;
            set => weight = value;
        }

        public uint YearOfRelease
        {
            get => yearOfRelease;
            set => yearOfRelease = value;
        }

        public uint FuelCapacity
        {
            get => fuelCapacity;
            set => fuelCapacity = value;
        }

        public uint CurrentFuel
        {
            get => currentFuel;
            set => currentFuel = value;
        }

        public string Brand
        {
            get => brand;
            set => brand = value;
        }
        public void ChangeBrand(string brand)
        {
            Brand = brand;
        }
        public void ChangeModel(string model)
        {
            Model = model;
        }
        public void ChangeColor(string color)
        {
            Color = color;
        }
        public void HorsepowerCheck()
        {
            if (Horsepower < 150) Console.WriteLine("Oh, man, something needs to change");
            else if (Horsepower >= 150 && Horsepower <= 300) Console.WriteLine("Pretty normal automobile");
            else if (Horsepower > 300) Console.WriteLine("Wow, your car is awesome!!");
        }
        public void Upgrade(uint money)
        {
            Random rnd = new Random();
            uint ciq = (uint)rnd.Next(0, (int)money / 10 + 1);
            Console.WriteLine($"You've boosted your car by {ciq} hp");
            Horsepower += ciq;
        }
        public void Move(uint distance)
        {
            if(distance * fuelUsage / 100 > this.currentFuel)
            {
                Console.WriteLine("Not enough fuel");
                return;
            }
            this.currentFuel -= distance * fuelUsage / 100;
        }
         public void FillUpTank(uint currentFuel)
        {
            
            if (currentFuel <= 0)
                return;
            if (this.currentFuel + currentFuel > FuelCapacity)
            {
                Console.WriteLine("You fill too much!!");
                return;
            }
            else
            {
                this.currentFuel += currentFuel;
                Console.WriteLine("There is {0} l in tank", this.currentFuel);
            }
        }
        public uint this[uint parameters]
        {
            set
            {
                switch (parameters)
                {
                    case 1:
                        weight = value;
                        break;
                    case 2:
                        horsepower = value;
                        break;
                    case 3:
                        yearOfRelease = value;
                        break;
                    case 4:
                        fuelCapacity = value;
                        break;
                    case 5:
                        fuelUsage = value;
                        break;
                }
            }
        }
        public void Info()
        {
            Console.WriteLine($"Id: {id}\nBrand: {brand}. Model: {model}\n" +
                              $"Year of release: {yearOfRelease}\n" +
                              $"Color: {color}\nWeight: {weight}\n" +
                              $"Number of horsepower: {horsepower}\n" +
                              $"Fuel usage: {fuelUsage}\n" +
                              $"Current fuel level: " +
                              $"{(float)currentFuel / fuelCapacity * 100}%.\n\n\n");
        }




        class Program
        {
            static uint InputChecker()
            {
                string n;
                for (; ; )
                {
                    n = Console.ReadLine();
                    bool check = UInt32.TryParse(n, out uint ni);
                    if (check && (ni > 0)) return ni;
                    Console.Clear();
                    Console.WriteLine("Incorrect input. Try again: ");
                }
                
            }
            public static void Main()
            {
                Car venicle;
                uint weight, fuelCapacity, currentFuel, fuelUsage, horsepower, yearOfRelease;
                string brand, model, color;
                
                Console.WriteLine("Enter brand: ");
                brand = Console.ReadLine();
                Console.Clear();
                Console.WriteLine("Enter model: ");
                model = Console.ReadLine();
                Console.Clear();
                Console.WriteLine("Enter the year of release: ");
                yearOfRelease = InputChecker();
                Console.Clear();
                Console.WriteLine("Enter the color: ");
                color = Console.ReadLine();
                Console.Clear();
                Console.WriteLine("Enter weight");
                weight = InputChecker();
                Console.Clear();
                Console.WriteLine("Enter the number of horsepower: ");
                horsepower = InputChecker();
                Console.Clear();
                Console.WriteLine("Enter fuel capacity");
                fuelCapacity = InputChecker();
                Console.Clear();
                Console.WriteLine("Enter current fuel");
                currentFuel = InputChecker();
                Console.Clear();
                Console.WriteLine("Enter fuel usage");    
                fuelUsage = InputChecker();
                Console.Clear();

                venicle = new Car(weight, yearOfRelease, fuelCapacity, currentFuel, fuelUsage, brand, model, color, horsepower);
                
                for (; ; )
                {
                    Console.WriteLine("1 - Get info\n" +
                                      "2 - Change brand and model\n" +
                                      "3 - Change the parameters\n" + 
                                      "4 - Upgrade your venicle\n" +
                                      "5 - Steepen of coolness\n" +
                                      "6 - Drive\n" + 
                                      "7 - Fill up your tank\n" +
                                      "Enter anything else to exit\n");
                    uint x = InputChecker();
                    switch (x)
                    {
                        case 1:
                            Console.Clear();
                            venicle.Info();                                                 
                            break;
                        case 2:
                            Console.Clear();
                            Console.WriteLine("1 - Change Brand\n" +
                                              "2 - Change Model\n" +
                                              "3 - Change Color\n" +
                                              "Enter anything else to exit\n ");
                            uint decision = InputChecker();
                            
                            switch (decision)
                            {
                                case 1:
                                    string NewBrand = Console.ReadLine();
                                    venicle.ChangeBrand(NewBrand);
                                    break;
                                case 2:
                                    string NewModel = Console.ReadLine();
                                    venicle.ChangeModel(NewModel);
                                    break;
                                case 3:
                                    string NewColor = Console.ReadLine();
                                    venicle.ChangeColor(NewColor);
                                    break;
                                
                            }

                            Console.Clear();
                            break;
                        case 3:
                            Console.Clear();
                            Console.WriteLine("1 - Change weight");
                            Console.WriteLine("2 - Change horsepower");
                            Console.WriteLine("3 - Change the year of release");
                            Console.WriteLine("4 - Change fuel capacity");
                            Console.WriteLine("5 - Change fuel usage");
                           
                            uint parameter = InputChecker();
                            venicle[parameter] = InputChecker();
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case 4:
                            Console.Clear();
                            Console.WriteLine("Enter money:");
                            uint money;
                            money = InputChecker();
                            venicle.Upgrade(money);
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case 5:
                            Console.Clear();
                            venicle.HorsepowerCheck();
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case 6:
                            Console.Clear();
                            Console.WriteLine("Enter the distance in kilometers");
                            uint dist = InputChecker();
                            venicle.Move(dist);
                            break;
                        case 7:
                            Console.Clear();
                            Console.WriteLine("Fill up tank in l");
                            uint fuel = InputChecker();
                            venicle.FillUpTank(fuel); ;
                            break;

                        default:
                            System.Environment.Exit(0);
                            break;
                    }
                }
            }
        }
    }
}