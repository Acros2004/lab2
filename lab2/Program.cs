using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2 
{
    internal class Program
    {
        public static bool FindAbiturient(int average, int count, int amount)
        {
            int amountMarks = average * count;
            if (amountMarks > amount) return true;
            return false;

        }

        public static bool GetBadAbiturient(int[] marks)
        {
            for (int i = 0; i < marks.Length; i++)
            {
                if (marks[i] < 4) return true;
            }
            return false;
        }
        class Abiturient
        {
           
           
            public int GetAverage(int[] mark)
            {
                int count = 0;
                for(int i=0; i < mark.Length; i++)
                {
                    count += mark[i]; 
                }
                return count / mark.Length;
            }
            public static int GetMin(int[] mark)
            {
                int min = mark[0];
                for (int i = 1; i < mark.Length; i++)
                {
                    if (min > mark[i])
                        min = mark[i];
                }
                return min;
            }
            public static int GetMax(int[] mark)
            {
                int max = mark[0];
                for (int i = 1; i < mark.Length; i++)
                {
                    if (max < mark[i])
                        max = mark[i];
                }
                return max;
            }
            public override string ToString()
            {
                return _surname;
            }
            public override bool Equals(object? input)
            {
                if (input is Abiturient && input != null)
                {
                    Abiturient tempCustomer = (Abiturient)input;
                    if (this.Name == tempCustomer.Name && this.Surname == tempCustomer.Surname && this.MiddleName == tempCustomer.MiddleName)
                    {
                        return true;
                    }
                }
                return false;
            }
            public bool Validation(string str)
            {
                for (int i = 0; i < str.Length; i++)
                {
                    if (str[i] >= '0' && str[i] <= '9')
                    {
                        Console.WriteLine("Некорректный ввод данных ФИО");
                        return false;
                    }
                }
                return true;
            }
            public static void AddCount(ref int a, out int b)
            {
                b = 10;
                a++;
            }
            public static void ShowCount()
            {
                Console.WriteLine($"Количество созданных объектов составляет {count}");
            }
            public override int GetHashCode()
            {
                int hash = 0;
                Random rand = new Random(); 
                for(int i = 0; i < _surname.Length; i++)
                {
                    hash += _surname[i];
                }
                hash += rand.Next(100, 99999);
                return (int)Math.Abs(hash);
            }
            
            public void Print()
            {
                Console.WriteLine($"-------------------------------------------------\nId: {_id}\nName: {_name}\nSurname: {_surname}\nMiddlename: {_middlename}\nNumber: {_number}\nMarks:");
                foreach(int i in _marks)
                {
                    Console.Write($"{i} ");
                }
                Console.WriteLine($"Средний балл равен {_average}\nМинимальный балл равен {_min}\nМаксимальный балл равен {_max}") ;
                Console.WriteLine("\n-------------------------------------------------");
            }
    
            public int _id;
            private string? _name;
            private string? _surname;
            private string? _middlename;
            private string? _adress;
            private long? _number;
            private int[] _marks;
            public static int count = 0;
            public static int primer = 0;
            public readonly string info = "приватный конструктор";
            public const string constStr = "Indefined";
            public int _max;
            public int _min;
            public int _average;
            public int ID
            {
                get { return _id; }
                private set 
                { 
                    _id = GetHashCode();
                }
            }
            public string Name
            {
                get { return _name ; }
                set
                {
                    if (Validation(value)) _name = value;
                }
            }
            public string Surname
            {
                get { return _surname; }
                set
                {
                    if(Validation(value)) _surname = value;
                }
            }
            public string MiddleName
            {
                get { return _middlename; }
                set
                {
                    if (Validation(value)) _middlename = value;
                }
            }
            public string Adress
            {
                get { return _adress; }
                set { _adress = value; }
            }
            public long Number
            {
                get { return (long)_number; }
                set
                {
                    bool flag = true;
                    ushort count = 0;
                    long number = value;
                    while (number != 0)
                    {
                        number /= 10;
                        count++;
                    }
                    if (count != 12)
                    {
                        Console.WriteLine("Номер некорректен\n");
                        flag = false;
                    }
                    int codeOfBelarus = (int)(value / (long)Math.Pow(10, 9));
                    int codeOfOperator = (int)(value / (long)Math.Pow(10, 7) - codeOfBelarus * 100);

                    if (codeOfBelarus == 375 && (codeOfOperator == 33 || codeOfOperator == 29
                    || codeOfOperator == 44 || codeOfOperator == 25)) _number = value;
                    else
                    {
                        Console.WriteLine("Номер некорректен\n");
                        flag = false;
                    }
                    if (flag) _number = value;
                }
            }
            public int[] Marks
            {
                get { return _marks; }
                set
                {
                    int count = value.Length;
                    bool flag = true;
                    for (int i = 0; i < count; i++)
                    {
                        if (value[i] <= 0 && value[i] >= 10)
                        {
                            Console.WriteLine("Оценка не входит в диапазон" + value[i]);
                            flag = false;
                        }
                    }
                    if (flag)
                    {
                        _marks = new int[count];
                        for (int i = 0; i < count; i++)
                        {
                            _marks[i]= value[i];
                        }
                    }
                }
            }
           
            public Abiturient() : this(123)
            {
                Name = "Nikita";
                Surname = constStr;
                ID = 0;
                MiddleName = "Sergeevich";
                Adress = "Leningradskaya 43";
                Number = 375299615342;
                Marks = new[] { 3, 7, 8, 10 };
                _average = GetAverage(_marks);
                _min = GetMin(_marks);
                _max = GetMax(_marks);
                AddCount(ref count, out primer);
                ShowCount();
            }
            public Abiturient(string name, string surname, string middlename, string adress, long number, int[] marks)
            {
                Name = name;
                Surname = surname;
                ID = 0;
                MiddleName = middlename;
                Adress = adress;
                Number = number;
                Marks = marks;
                _average = GetAverage(_marks);
                _min = GetMin(_marks);
                _max = GetMax(_marks);
                AddCount(ref count, out primer);
                ShowCount();
            }
            public Abiturient(long number, int[] marks)
            {
                Name = constStr;
                Surname = constStr;
                ID = 0;
                MiddleName = constStr;
                Adress = constStr;
                Number = number;
                Marks = marks;
                _average = GetAverage(_marks);
                _min = GetMin(_marks);
                _max = GetMax(_marks);
                AddCount(ref count, out primer);
                ShowCount();
            }
            public Abiturient(string name, long number, int[] marks)
            {
                Name = name;
                Surname = constStr;
                ID = 0;
                MiddleName = constStr;
                Adress = constStr;
                Number = number;
                Marks = marks;
                _average = GetAverage(_marks);
                _min = GetMin(_marks);
                _max = GetMax(_marks);
                AddCount(ref count, out primer);
                ShowCount();
            }
            static Abiturient()
            {
                Console.WriteLine("Программа показывает информацию о абитуриентах");
            }
            private Abiturient(int a)
            {
                Console.WriteLine(a+info);
            }
        }
        static void Main(string[] args)
        {
            int amount, flag = 0;
            Abiturient abFirst = new Abiturient();
            abFirst.Print();
            Abiturient abSecond = new Abiturient("Maks", "Ivanov", "Vladimirovich", "Vostochnaya 25", 375293491047, new int[] { 1, 3, 5, 7, 9 });
            abSecond.Print();
            Abiturient abThird = new Abiturient(375293681122, new int[] { 10, 10, 10, 10, 10 });
            abThird.Print();
            abFirst.Surname = "Karebo";
            abFirst.Print();
            Abiturient[] abiturients = new Abiturient[] { abFirst, abSecond, abThird };
            Console.WriteLine("Следующие абитуриенты имеют плохую оценку");
            foreach(Abiturient person in abiturients)
            {
                if (GetBadAbiturient(person.Marks))
                {
                    person.Print();
                    flag = 1;
                }
            }
            if (flag == 0)
            {
                Console.WriteLine("Не найдено");
            }
            flag = 0;
            Console.WriteLine("Введите примерную сумму балов ");
            amount = Convert.ToInt32(Console.ReadLine());
            foreach(Abiturient person in abiturients)
            {
                if (FindAbiturient(person._average, person.Marks.Length, amount))
                {
                    person.Print();
                    flag = 1;
                }
            }
            if (flag == 0) Console.WriteLine("Не найдено");

            Console.WriteLine($"Сравнение {abSecond.ID} с {abThird.ID}:\t{abSecond.Equals(abThird)}");
            abThird.Name = "Maks";
            abThird.Surname = "Ivanov";
            abThird.MiddleName = "Vladimirovich";
            abThird.Print();
            Console.WriteLine($"Сравнение {abSecond.ID} с {abThird.ID}(с изменениями):\t{abSecond.Equals(abThird)}");
            Console.WriteLine($"Вызвал метод ToString  {abFirst.ToString()}");
            Gun myGun = new Gun();
            myGun.Shoot();
            myGun.Reload();
            myGun.Reload();
            myGun.Shoot();
            myGun.Shoot();
        }
    }
}