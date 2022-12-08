using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoDrom
{
    abstract class Vehicle
    {
        // исключения для классов наследников
        protected Exception OutOfMaxBorder = new Exception("Исключение, превышена максимальна граница");
        protected Exception NonBellowZero = new Exception("Исключение, введенное значение не может быть отрицательным!");

        protected int price, maxspeed, year;

        // свойство Стоимость
        public int Price
        {
            get { return price; }
            set { if (value > 0) price = value; }
        }
        // свойство Максимальная скорость
        public int Maxspeed
        {
            get { return maxspeed; }
            set { if (value > 0) maxspeed = value; }
        }
        // свойство Год выпуска
        public int Year
        {
            get { return year; }
            set { if (value <= DateTime.Today.Year) year = value; }
        }

        //конструктор класа!!!

        public Vehicle(int price, int maxspeed, int year)
        {
            this.Price = price;
            this.Maxspeed = maxspeed;
            this.Year = year;
        }


    }

    
    class Bicycle : Vehicle
    {
        //оригинальное поле для байков
        public int MaxPassengers { get; set; }

        //конструктор + конструктор базового класса
        public Bicycle(int prise, int maxspeed, int year, int MaxPassengers) : base(prise, maxspeed, year)
        {
            this.MaxPassengers = MaxPassengers;
        }

    }

    class Car : Vehicle
    {
        //оригинальное поле для авто
        public int Power { get; set; }


        //конструктор + унаследованный конструктор
        public Car(int prise, int maxspeed, int year, int Power)
            : base(prise, maxspeed, year)
        {
            this.Power = Power;
        }
    }

    class Lorry : Vehicle
    {
        public int MaxCapacity { get; set; }

        public Lorry(int prise, int maxspeed, int year, int MaxCapacity)
            : base(prise, maxspeed, year)
        {
            this.MaxCapacity = MaxCapacity;
        }
    }

    class Garrage
    {
        public List<Lorry> lorrys = new List<Lorry>();
        public List<Car> cars = new List<Car>();
        public List<Bicycle> bicycles = new List<Bicycle>();

        public void AddLorry()
        {
            int prise = 0, maxspeed = 0, year = 0, MaxCapacity = 0;
            Console.WriteLine("Введите цену:");
            try
            {
                prise = Convert.ToInt32(Console.ReadLine());
            }
            catch { }
            Console.WriteLine("Введите максимальную скорость");
            try
            {
                maxspeed = Convert.ToInt32(Console.ReadLine());
            }
            catch { }
            Console.WriteLine("Введите год:");
            try
            {
                year = Convert.ToInt32(Console.ReadLine());
            }
            catch { }
            Console.WriteLine("Введите грузоподьемность");
            try
            {
                MaxCapacity = Convert.ToInt32(Console.ReadLine());
            }
            catch { }
            lorrys.Add(new Lorry(prise, maxspeed, year, MaxCapacity));
        }

        public void AddCar()
        {
            int prise = 0, maxspeed = 0, year = 0, Power = 0;
            Console.WriteLine("Введите цену:");
            try
            {
                prise = Convert.ToInt32(Console.ReadLine());
            }
            catch { }
            Console.WriteLine("Введите максимальную скорость");
            try
            {
                maxspeed = Convert.ToInt32(Console.ReadLine());
            }
            catch { }
            Console.WriteLine("Введите год:");
            try
            {
                year = Convert.ToInt32(Console.ReadLine());
            }
            catch { }
            Console.WriteLine("Введите мощьность:");
            try
            {
                Power = Convert.ToInt32(Console.ReadLine());
            }
            catch { }
            cars.Add(new Car(prise, maxspeed, year, Power));
        }

        public void AddBicycle()
        {
            int prise = 0, maxspeed = 0, year = 0, MaxPassengers = 0;
            Console.WriteLine("Введите цену:");
            try
            {
                prise = Convert.ToInt32(Console.ReadLine());
            }
            catch { }
            Console.WriteLine("Введите максимальную скорость");
            try
            {
                maxspeed = Convert.ToInt32(Console.ReadLine());
            }
            catch { }
            Console.WriteLine("Введите год:");
            try
            {
                year = Convert.ToInt32(Console.ReadLine());
            }
            catch { }
            Console.WriteLine("Введите количество пасажиров:");
            try
            {
                MaxPassengers = Convert.ToInt32(Console.ReadLine());
            }
            catch { }
            bicycles.Add(new Bicycle(prise, maxspeed, year, MaxPassengers));
        }

        public void GetAllLorry()
        {
            foreach (Lorry lorry in lorrys)
            {
                Console.WriteLine("Цена: {0}, Максимальная скорость: {1}, Год: {2}, Максимальная грузоподьемность: {3};", lorry.Price, lorry.Maxspeed, lorry.Year, lorry.MaxCapacity);
            }
        }

        public void GetAllCar()
        {
            foreach (Car car in cars)
            {
                Console.WriteLine("Цена: {0}, Максимальная скорость: {1}, Год: {2}, Мощьность: {3};", car.Price, car.Maxspeed, car.Year, car.Power);
            }
        }

        public void GetAllBicycle()
        {
            foreach (Bicycle bicycle in bicycles)
            {
                Console.WriteLine("Цена: {0}, Максимальная скорость: {1}, Год: {2}, Максимум пасажиров: {3};", bicycle.Price, bicycle.Maxspeed, bicycle.Year, bicycle.MaxPassengers);
            }
        }

    }

    class Program
    {

        static void Main(string[] args)
        {
            Garrage garrage = new Garrage();

            while (true)
            {
                int i = 0;
                Console.WriteLine(@"Выберите нужное Вам действие:
1. Добавить в список велосипед;
2. Добавить в список машину;
3. Добавить в список грузовик;
4. Посмотреть велосипеды в гараже;
5. Посмотреть все машины из списка;
6. Посмотреть все грузовики из списка;
7. Выход.");
                try
                {
                    i = Convert.ToInt32(Console.ReadLine());
                }
                catch { }
                switch (i)
                {
                    case 1: garrage.AddBicycle(); break;
                    case 2: garrage.AddCar(); break;
                    case 3: garrage.AddLorry(); break;
                    case 4: Console.WriteLine("Велосипеды:"); garrage.GetAllBicycle(); break;
                    case 5: Console.WriteLine("Машины:"); garrage.GetAllCar(); break;
                    case 6: Console.WriteLine("Грузовики:"); garrage.GetAllLorry(); break;
                    case 7: return;
                    default: Console.WriteLine(""); break;
                }
            }
        }
    }
}
