using System;
using System.Collections.Generic;

namespace Test4
{
    class Program
    {
        static void Main()
        {
            List<int[]> A = CreateGraphic();
            List<int[]> B = CreateGraphic();
            bool exit = false;
            int option;
            while (!exit) //3.Пользователь выбирает операцию: пересечение графиков А и В, объединение графиков А и В, разность графиков А и В, симметрическая разность графиков А и В, инверсия графика А, композиция графиков А и В, выход из программы.
            {
                Console.Clear();
                PrintGraphic(A, "A");
                PrintGraphic(B, "B");
                Console.WriteLine("\n1 - Intersection\n2 - Union\n3 - Difference\n4 - Symmetric difference\n5 - Inversion\n6 - Composition\n0 - Exit\n");
                Console.Write("Input option: ");
                while (!int.TryParse(Console.ReadLine(), out option)) ;
                switch (option)
                {
                    case 1: // Если пользователь выбирает пересечение графиков А и В, переходим к пункту 4
                        PrintGraphic(Intersection(A, B), "Intersection(A, B)");
                        Console.Write("Press any key...");
                        Console.ReadKey(true);
                        break;
                    case 2: // Если пользователь выбирает объединение графиков А и В, переходим к пункту 5
                        PrintGraphic(Union(A, B), "Union(A, B)");
                        Console.Write("Press any key...");
                        Console.ReadKey(true);
                        break;
                    case 3: // Если пользователь выбирает разность графиков А и В, переходим к пункту 6
                        PrintGraphic(Difference(A, B), "Difference(A, B)");
                        Console.Write("Press any key...");
                        Console.ReadKey(true);
                        break;
                    case 4: // Если пользователь выбирает симметрическую разность графиков А и В, переходим к пункту 7
                        PrintGraphic(SymmetricDifference(A, B), "Symmetric difference(A, B)");
                        Console.Write("Press any key...");
                        Console.ReadKey(true);
                        break;
                    case 5: // Если пользователь выбирает инверсию графика А, переходим к пункту 8
                        PrintGraphic(Inversion(A), "Inversion(A)");
                        Console.Write("Press any key...");
                        Console.ReadKey(true);
                        break;
                    case 6: // Если пользователь выбирает композицию графиков А и В, переходим к пункту 9
                        PrintGraphic(Composition(A, B), "Composition(A, B)");
                        Console.Write("Press any key...");
                        Console.ReadKey(true);
                        break;
                    case 0: // Если пользователь выбирает выход из программы, завершаем работу программы
                        exit = true;
                        break;
                    default:
                        Console.Write("Incorrect option, press any key...");
                        Console.ReadKey(true);
                        break;
                }
            }
        }

        static List<int[]> Intersection(List<int[]> a, List<int[]> b) // 4. Найдём пересечение графиков А и В
        {
            List<int[]> C = new List<int[]>(); // Создаём пустой график С
            for (int i = 0; i < a.Count; i++)
            {
                for (int j = 0; j < b.Count; j++)
                {
                    if (a[i][0] == b[j][0] && a[i][1] == b[j][1]) C.Add(a[i]); // Если 1-я и 2-я компоненты из i-й пары графика А соответственно равны 1-й и 2-й компонентам из j-й пары графика В, то заносим эту пару в график С
                }
            }
            return C; // график С – пересечение графиков А и В
        }

        static List<int[]> Union(List<int[]> a, List<int[]> b) // 5. Найдём объединение графиков А и В
        {
            List<int[]> D = Intersection(a, b); // 5.1 Создаём график D, равное результату операции пересечения графиков А и В
            List<int[]> E = a; // Создаём график E, равный графику А
            for (int i = 0; i < b.Count; i++)
            {
                for (int j = 0; j < D.Count; j++) // 5.5.4
                {
                    if (b[i][0] == D[j][0] && b[i][1] == D[j][1]) break; // Если 1-я и 2-я компоненты из i-й пары графика B соответственно равны 1-й и 2-й компонентам из j-й пары графика D, то переходим к пункту 5.5.4.
                    if (j == D.Count - 1) E.Add(b[i]); // Если j равно мощности графика D, то заносим i-ю пару графика B в график E и переходим к пункту 5.5.4
                }
            }
            return E; // график E – объединение графиков А и В
        }

        static List<int[]> Difference(List<int[]> a, List<int[]> b) // 6. Найдём разность графиков А и В
        {
            List<int[]> F = Intersection(a, b); // Создаём график F, равный результату операции пересечения графиков А и В
            List<int[]> G = new List<int[]>(); // Создаём пустой график G
            for (int i = 0; i < a.Count; i++)
            {
                for (int j = 0; j < F.Count; j++) // 6.5.4
                {
                    if (a[i][0] == F[j][0] && a[i][1] == F[j][1]) break; // Если 1-я и 2-я компоненты из i-й пары графика A соответственно равны 1-й и 2-й компонентам из j-й пары графика F, то переходим к пункту 6.5.4
                    if (j == F.Count - 1) G.Add(a[i]); // Если j равно мощности графика F, то заносим i-ю пару графика А в график G и переходим к пункту 6.5.4
                }
            }
            return G; // график G – разность графиков А и В
        }

        static List<int[]> SymmetricDifference(List<int[]> a, List<int[]> b) // Найдём симметрическую разность графиков А и В
        {
            List<int[]> H = Difference(a, b); // Создаём график H равный результату операции разности графиков А и В
            List<int[]> K = Difference(b, a); // Создаём график K равный результату операции разности графиков В и А
            List<int[]> L = Union(a, b); // Создаём график L равный результату операции объединения графиков H и K
            return L; // график L – симметрическая разность графиков А и В
        }

        static List<int[]> Inversion(List<int[]> a) // Найдём инверсию графика А
        {
            List<int[]> V = new List<int[]>(); // Создам пустой график V.
            for (int i = 0; i < a.Count; i++) 
            {
                int[] b = new int[] { a[i][1], a[i][0] }; // Создаём пару b, первая и вторая компоненты которой соответственно равны второй и первой компонентам i-й пары графика А
                V.Add(b); // Заносим пару b в график V
            }
            return V; // График V – инверсия графика А
        }

        static List<int[]> Composition(List<int[]> a, List<int[]> b) // 9. Найдём композицию графиков А и В
        {
            List<int[]> Z = new List<int[]>(); // Создаём пустой график Z
            for (int i = 0; i < a.Count; i++)
            {
                for (int j = 0; j < b.Count; j++) // 9.7
                {
                    if (a[i][1] == b[j][0]) // Если вторая компонента i-й пары графика A не равна первой компоненте j-й пары графика B, переходим к пункту 9.7
                    {
                        int[] d = new int[] { a[i][0] , b[j][1] }; // Составляем пару d, где первая и вторая компоненты соответственно равны первой компоненте i-й пары графика A и второй компоненте j - й пары графика B
                        Z.Add(d); // Добавляем пару d в график Z
                    }
                }
            }
            return Z; // График Z – композиция графиков A и B
        }

        static List<int[]> CreateGraphic()
        {
            int power, element;
            int[] pair = new int[2];
            List<int[]> result = new List<int[]>();
            Console.Write("Input power: ");
            while (!int.TryParse(Console.ReadLine(), out power) && power < 11) ; // Пользователь выбирает мощность n графика А, строго меньше 11.Если выбрана мощность больше либо равная 11, необходимо повторить ввод.
            for (int i = 0; i < power; i++) // Пользователь вводит n пар графика А, элементы которых строго меньше 300. Если введён элемент больше либо равный 300, необходимо повторить ввод данного элемента
            {
                pair = new int[2];
                element = 301;
                for (int j = 0; j < 2; j++)
                {
                    while (!int.TryParse(Console.ReadLine(), out element) && element < 300) ;
                    pair[j] = element;
                }
                result.Add(pair);
            }
            return result;
        }

        static void PrintGraphic(List<int[]> g, string name)
        {
            Console.Write(name + " = ");
            if (g != null && g.Count > 0)
            {
                Console.Write("{ ");
                Console.Write("<" + g[0][0] + ", " + g[0][1] + ">");
                for (int i = 1; i < g.Count; i++) Console.Write(", <" + g[i][0] + ", " +  g[i][1] + ">");
                Console.Write(" } ");
            }
            else Console.WriteLine("{ } ");
        }
    }
}