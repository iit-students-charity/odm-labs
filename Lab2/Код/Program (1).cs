using System;
using System.Collections.Generic;

namespace ForTests
{
    class Program
    {
        static int[] U;
        
        static void Main()
        {
            int option, addOpt;
            bool exit = false;
            /* пункт 1 */ int[] s1 = NewSet("A"), /* пункт 2 */ s2 = NewSet("B");
            U = Union(s1, s2);

            while (!exit) //3 Пользователь выбирает операцию: пересечение множеств А и В, объединение множеств А и В, разность множеств А и В, симметрическая разность множеств А и В, дополнение множества А, декартово произведение множеств А и В, выход из программы.
            {
                Console.Clear();
                PrintSet(s1, "s1");
                PrintSet(s2, "s2");
                Console.WriteLine("1 - New sets\n2 - Intersection\n3 - Union\n4 - Difference\n5 - Symmetric difference\n6 - Addition\n7 - Cartesian product\n0 - Exit\n");
                Console.Write("Input option: ");
                while (!int.TryParse(Console.ReadLine(), out option)) ;
                switch (option)
                {
                    case 1: 
                        s1 = NewSet("A");
                        s2 = NewSet("B");
                        U = Union(s1, s2);
                        break;
                    case 2: // 3.1 Если пользователь выбирает пересечение множеств А и В, переходим к пункту 4
                        Console.Write("Press any key...");
                        Console.ReadKey(true);
                        break;
                    case 3: // 3.2 Если пользователь выбирает объединение множеств А и В, переходим к пункту 5
                        PrintSet(Union(s1, s2), "Union(s1, s2)");
                        Console.Write("Press any key...");
                        Console.ReadKey(true);
                        break;
                    case 4: // 3.3 Если пользователь выбирает разность множеств А и В, переходим к пункту 6
                        PrintSet(Difference(s1, s2), "Difference(s1, s2)");
                        Console.Write("Press any key...");
                        Console.ReadKey(true);
                        break;
                    case 5: // 3.4 Если пользователь выбирает симметрическую разность множеств А и В, переходим к пункту 7
                        PrintSet(SymmetricDifference(s1, s2), "Symmetric difference(s1, s2)");
                        Console.Write("Press any key...");
                        Console.ReadKey(true);
                        break;
                    case 6: // 3.5 Если пользователь выбирает дополнение множества, переходим к пункту 8
                	PrintSet(Addition(s1), "Addition(s1)");
                        Console.Write("Press any key...");
                        Console.ReadKey(true);
                        break;
                    case 7: // 3.6 Если пользователь выбирает декартово произведение множеств А и В, переходим к пункту 9
                        PrintSetByPairs(CartesianProduct(s1, s2), "Cartesian product(s1, s2)");
                        Console.Write("Press any key...");
                        Console.ReadKey(true);
                        break;
                    case 0: // 3.7 Если пользователь выбирает выход из программы, завершаем работу программы
                        exit = true;
                        break;
                    default:
                        Console.Write("Incorrect option, press any key...");
                        Console.ReadKey(true);
                        break;
                }
            }
        }

        static int[] NewSet(string name)
        {
            int opt = 0, element = 0;
            Console.WriteLine("1 - Manual input\n2 - Input by formula\n"); // Пользователь выбирает способ задания множества А(B): перечислением или высказыванием.
            Console.Write("Input option: "); 
            int[] result = null;
            while (!int.TryParse(Console.ReadLine(), out opt) && (opt != 1 || opt != 2)) ; // Получаем выбор способа ввода пользователя 
            switch (opt)
            {
                case 1:	// Если выбран способ задания перечислением, то:
                    Console.Write("Input power of set: "); // Пользователь выбирает мощность множества А(B), строго меньше 10. 
                	int powerOfSet = 0;
                	while (!int.TryParse(Console.ReadLine(), out powerOfSet) && powerOfSet < 10) ; // Если выбрана мощность больше либо равная 10, необходимо повторить ввод.
                	result = new int[powerOfSet];
                    for (int i = 0; i < powerOfSet; i++)
                    {
                        while (!int.TryParse(Console.ReadLine(), out element) && element < 300) ; // Пользователь вводит элементы множества А(B), строго меньше 300. Если введён элемент больше либо равный 300, необходимо повторить ввод данного элемента.
                        result[i] = element;
                    }
                    break;
                case 2: // Если выбран способ задания множества высказыванием, то а = 2x^2, где а – элемент, задающийся высказыванием.
                	result = new int[10];
                	if (name == "A")
                	{
                		for (int i = 1; i <= 10; i++) // х = 1, (1.2.2)Если х равен 10, то переходим к пункту 2. Увеличиваем х на единицу. Переходим к пункту 1.2.2.
                        {
                            result[i-1] = 2 * i * i; // Вычисляем значение элемента а по формуле а = 2x^2 и заносим его во множество А.
                        }
                	}
                	else if (name == "B") // Если выбран способ задания множества высказыванием, то b = 5x-4, где b – элемент, задающийся высказыванием. // Переходим к пункту 2.2.2
                	{
                		for (int i = 1; i <= 10; i++) // х = 1, Если х равен 10, то переходим к пункту 3. Увеличиваем х на единицу.
                        {
                            result[i-1] = 5 * i + 3; // Вычисляем значение элемента b по формуле b = 5x-4 и заносим его во множество А.
                        }
                	}
                    break;
            }
            return result;
        }

        static int[] Intersection(int[] s1, int[] s2) // 4. Найдём пересечение множеств А и В:
        {
            List<int> list = new List<int>(); // 4.1 Создаём пустое множество С.

            for (int i = 0; i < s1.Length; i++) // 4.2 i = 0. // 4.7 Увеличиваем i на единицу. // 4.8 Если значение i меньше или равно мощности множества А, то переходим к пункту 4.3
            {
                for (int j = 0; j < s2.Length; j++) // 4.3 j = 0. // 4.5 Увеличиваем j на единицу. // 4.6 Если значение j меньше или равно мощности множества B, то переходим к пункту 4.4
                {
                    if (s1[i] == s2[j]) list.Add(s1[i]); // 4.4 Если i-й элемент из множества А равен j-му элементу из множества В, то заносим его во множество С.
                }
            }
            int[] result = list.ToArray(); // - Множество С – пересечение множеств А и В, выводим его на экран.
            return result;
        }

        static int[] Union(int[] s1, int[] s2) // 5. Найдём объединение множеств А и В:
        {
            int[] i12 = Intersection(s1, s2); //Множество D – пересечение множеств А и В.
            List<int> list = new List<int>(s1); // 5.2 Создаём множество E, равное множеству А.

            if (i12.Length == 0) 
                for (int i = 0; i < s2.Length; i++) 
                    list.Add(s2[i]);

            for (int i = 0; i < s2.Length; i++) // 5.3 i = 1. // 5.4 j = 1. // 5.5.4 Если i равно мощности множества В, переходим к пункту 5.9, иначе увеличиваем i на единицу, переходим к пункту 5.4.
            {
                for (int j = 0; j < i12.Length; j++) // 5.5.3 увеличиваем j на единицу и переходим к пункту 5.5.1.
                {
                    if (s2[i] == i12[j]) break; // 5.5.1 Если i-й элемент множества В равен j-у элементу D, то переходим к пункту 5.5.4
                    if (j == i12.Length - 1) list.Add(s2[i]); // 5.5.2 Если j равно мощности множества D, то заносим i-й элемент множества В во множество E и переходим к пункту 5.5.4
                }
            }

            int[] result = list.ToArray(); // - Множество E – объединение множеств А и В, выводим его на экран.
            return result; // 5.9 Переходим к пункту 3.
        }

        static int[] Difference(int[] s1, int[] s2) // 6. Найдём разность множеств А и В:
        {
            int[] i12 = Intersection(s1, s2); // 6.1 Создаём множество F, равное результату операции пересечения множеств А и В:
            List<int> list = new List<int>(); // 6.2 Создаём пустое множество G.

            if (i12.Length == 0)
                for (int i = 0; i < s1.Length; i++)
                    list.Add(s1[i]);


            for (int i = 0; i < s1.Length; i++)  // 6.4 j = 1 // 6.5.4 Если i равно мощности множества В, переходим к пункту 6.6, иначе увеличиваем i на единицу, переходим к пункту 6.4.
                for (int j = 0; j < i12.Length; j++) // 6.3 i = 1. // 6.5.3 увеличиваем j на единицу, переходим к пункту 6.5.1.
                {
                    if (s1[i] == i12[j]) // 6.5.1 Если i-й элемент множества В равен j-у элементу множества F, то переходим к пункту 6.5.4
                        break;
                    if (j == i12.Length - 1) // 6.5.2 Если j равно мощности множества F, то заносим i-й элемент множества А во множество G и переходим к пункту 6.5.4
                        list.Add(s1[i]);
                }

            int[] result = list.ToArray(); // - Множество G – разность множеств А и В, выводим его на экран.
            return result; // 6.6. Переходим к пункту 3.
        }

        static int[] Addition(int[] s1) // Найдём дополнение множества А:
        {
            return Difference(U, s1); // 8.1 Создаём множество W равное результату операции разности универсального множества U, определённого выше, и множества А:
        }

        static int[] SymmetricDifference(int[] s1, int[] s2) // Найдём симметрическую разность множеств А и В:
        {
            return Union(Difference(s1, s2), Difference(s2, s1)); //Создаём множество L равное результату операции объединения множеств H (H – разность множеств А и В.) и K (K – разность множеств B и A.):
        }

        static int[] CartesianProduct(int[] s1, int[] s2) // 9. Найдём декартово произведение множеств А и В:
        {
            List<int> list = new List<int>(); // 9.1 Создаём пустое множество P.

            for (int i = 0; i < s1.Length; i++) // 9.2 i = 1. // 9.4.5 Увеличиваем i на единицу. // 9.4.6 Если i меньше или равна мощности множества A, переходим к пункту 9.3, иначе далее по алгоритму.
                for (int j = 0; j < s2.Length; j++) // 9.3 j = 1. // 9.4.3 Увеличиваем j на единицу. // 9.4.4 Если j меньше или равна мощности множества В, переходим к пункту 9.4.1, иначе далее по алгоритму.
                {
                    list.Add(s1[i]); // 9.4.1 Записываем i-й элемент множества А на первую позицию кортежа.
                    list.Add(s2[j]); // 9.4.2 Записываем j-й элемент множества B на вторую позицию кортежа. // Заносим полученный кортеж во множество P.
                }

            int[] result = list.ToArray(); // - Множество P – декартово произведение множеств А и В, выводим его на экран
            return result; // 9.5 Переходим к пункту 3.
        }

        static void PrintSet(int[] set, string name) // вывод множества на экран
        {
            Console.Write(name + " = ");
            if (set != null && set.Length > 0)
            {
                Console.Write("{ ");
                Console.Write(set[0]);
                for (int i = 1; i < set.Length; i++)
                {
                    Console.Write(", " + set[i]);
                }
                Console.WriteLine(" }");
            }
            else Console.WriteLine("{ }");
        }

        static void PrintSetByPairs(int[] set, string name) // вывод множества кортежей длины 2 на экран
        {
            if (set.Length % 2 != 0)
            {
                PrintSet(set, name);
                return;
            }

            Console.Write(name + " = ");
            if (set != null && set.Length > 0)
            {
                Console.Write("{ ");
                for (int i = 0; i < set.Length; i++)
                {
                    if (i % 2 == 0)
                        Console.Write("<");

                    Console.Write(set[i]);

                    if (i % 2 == 0 && i != set.Length)
                        Console.Write(", ");
                    if (i % 2 != 0 && i != set.Length - 1)
                        Console.Write(">, ");
                    if (i % 2 != 0 && i == set.Length - 1)
                        Console.Write(">");
                }
                Console.WriteLine(" }");
            }
            else Console.WriteLine("{ }");
        }
    }
}
