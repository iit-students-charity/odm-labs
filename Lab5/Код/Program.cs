using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Program1
{
    class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;
            int option;

            int[] X = CreateSet(100); // Пользователь задаёт мощность области отправления Х соответствия А. Пользователь вводит элементы области отправления Х.
            int[] Y = CreateSet(100); // Пользователь задаёт мощность области прибытия У соответствия А. Пользователь вводит элементы области прибытия У.
            List <int[]> G = CreateGraphic(X.Length * Y.Length); // Пользователь задаёт мощность графика G соответствия А. Пользователь вводит элементы графика G.
            int[] U = CreateSet(100); // Пользователь задаёт мощность области отправления U соответствия B. Пользователь вводит элементы области отправления U.
            int[] V = CreateSet(100); // Пользователь задаёт мощность области прибытия V соответствия B. Пользователь вводит элементы области прибытия V.
            List<int[]> F = CreateGraphic(U.Length * V.Length); // Пользователь задаёт мощность графика F соответствия B. Пользователь вводит элементы графика F.

            int[] M = CreateSet(X.Length + 1); // Пользователь задаёт мощность множества M. Пользователь вводит элементы множества M.
            int[] N = CreateSet(Y.Length + 1); // Пользователь задаёт мощность множества N. Пользователь вводит элементы множества N.
            int[] W = CreateSet(100); // Пользователь задаёт мощность множества W. Пользователь вводит элементы множества W.
            List<int[]> H = CreateH(G, X.Length * Y.Length); // Множество H заполняется элементами графика G. Пользователь задаёт количество элементов n для добавления к множеству G. Пользователь вводит n пар, которые добавляются в конец множества G.

            // Вывод соответствий на экран
            Console.WriteLine("A = <X, Y, G>");
            PrintSet(X, "X");
            PrintSet(Y, "Y");
            PrintGraphic(G, "G");
            Console.WriteLine("B = <U, V, F>");
            PrintSet(U, "U");
            PrintSet(V, "V");
            PrintGraphic(F, "F");
            PrintSet(M, "M");
            PrintSet(N, "N");
            PrintSet(W, "W");
            PrintGraphic(H, "H");

            int[] Ixu = Intersection(X, U); // Находим множество Ixu = X∩U
            int[] Iyv = Intersection(Y, V); // Находим множество Iyv = Y∩V
            List<int[]> Igf = Intersection(G, F); // Находим график Igf = G∩F
            int[] Uxu = Union(X, U); // Находим множество Uxu = X∪U
            int[] Uyv = Union(Y, V); // Находим множество Uyv = Y∪V
            List<int[]> Ugf = Union(G, F); // Находим график Ugf = G∪F
            int[] Dxu = Difference(X, U); // Находим множество Dxu = X\U
            int[] Dyv = Difference(Y, V); // Находим множество Dyv = Y\V
            List<int[]> Dgf = Difference(G, F); // Находим график Dgf = G\F
            int[] SDxu = SymmetricDifference(X, U); // Находим множество SDxu = XΔU
            int[] SDyv = SymmetricDifference(Y, V); // Находим множество SDyv = YΔV
            List<int[]> SDgf = SymmetricDifference(G, F); // Находим график SDgf = GΔF
            List<int[]> Ig = Inversion(G); // Находим график Ig = G-1
            List<int[]> Cgf = Composition(G, F); // Находим график Cgf = G·F

            while (!exit)
            {
                Console.WriteLine("\n1 - Intersection\n2 - Union\n3 - Difference\n4 - Symmetric difference\n5 - Inversion\n6 - Composition\n7 - Form\n8 - Prototype\n9 - Contraction\n10 - Continuation\n0 - Exit\n");
                Console.Write("Input option: ");
                // Пользователь выбирает выход из программы или операцию над соответствиями: пересечение, объединение, разность, симметрическая разность, инверсия, композиция, образ, прообраз, сужение, продолжение.
                while (!int.TryParse(Console.ReadLine(), out option)) ;
                switch (option)
                {
                    case 1:
                        // Найдём пересечение соответствий А и B
                        Console.WriteLine("C = <Ixu, Iyv, Igf>"); // Формируем новое соответствие <Ixu, Iyv, Igf> и выводим его на экран.
                        PrintSet(Ixu, "Ixu");
                        PrintSet(Iyv, "Iyv");
                        PrintGraphic(Igf, "Igf");
                        break;
                    case 2:
                        // Найдём объединение соответствий А и B
                        Console.WriteLine("C = <Uxu, Uyv, Ugf>"); // Формируем новое соответствие <Uxu, Uyv, Ugf> и выводим его на экран.
                        PrintSet(Uxu, "Uxu");
                        PrintSet(Uyv, "Uyv");
                        PrintGraphic(Ugf, "Ugf");
                        break;
                    case 3:
                        // Найдём разность соответствий А и B
                        Console.WriteLine("C = <Dxu, Dyv, Dgf>"); // Формируем новое соответствие <Dxu, Dyv, Dgf> и выводим его на экран.
                        PrintSet(Dxu, "Dxu");
                        PrintSet(Dyv, "Dyv");
                        PrintGraphic(Dgf, "Dgf");
                        break;
                    case 4:
                        // Найдём симметрическую разность соответствий А и B
                        Console.WriteLine("C = <SDxu, SDyv, SDgf>"); // Формируем новое соответствие <SDxu, SDyv, SDgf> и выводим его на экран.
                        PrintSet(SDxu, "SDxu");
                        PrintSet(SDyv, "SDyv");
                        PrintGraphic(SDgf, "SDgf");
                        break;
                    case 5:
                        // Найдём инверсию соответствия А
                        Console.WriteLine("C = <Y, X, Ig>"); // Формируем новое соответствие <Y, X, Ig> и выводим его на экран.
                        PrintSet(Y, "Y");
                        PrintSet(X, "X");
                        PrintGraphic(Ig, "Ig");
                        break;
                    case 6:
                        // Найдём композицию соответствий А и B
                        Console.WriteLine("C = <X, V, Cgf>"); // Формируем новое соответствие <X, V, Cgf> и выводим его на экран.
                        PrintSet(X, "X");
                        PrintSet(V, "V");
                        PrintGraphic(Cgf, "Cgf");
                        break;
                    case 7:
                        // Найдём образ соответствия множества M при соответствии А
                        PrintSet(Form(G, M), "C");
                        break;
                    case 8:
                        // Найдём прообраз множества N при соответствии А
                        PrintSet(Prototype(G, N), "C");
                        break;
                    case 9:
                        // Найдём сужение соответствия А
                        Console.WriteLine("C = <X, Y, Ifcp>"); // Формируем новое соответствие <X, Y, Ifcp> и выводим его на экран.
                        PrintSet(X, "X");
                        PrintSet(V, "Y");
                        PrintGraphic(Contraction(F, W, Y), "Ifcp");
                        break;
                    case 10:
                        // Найдём продолжение соответствия А
                        Console.WriteLine("C = <X, Y, H>"); // Формируем новое соответствие <X, Y, H> и выводим его на экран.
                        PrintSet(X, "X");
                        PrintSet(Y, "Y");
                        PrintGraphic(H, "H");
                        break;
                    case 0:
                        // Если пользователь выбирает выход из программы, завершаем работу программы.
                        exit = true;
                        break;
                    default:
                        Console.Write("Incorrect option, press any key...");
                        Console.ReadKey(true);
                        break;
                }
            }
        }

        static List<int[]> Contraction(List<int[]> f, int[] w, int[] y)
        {
            List<int[]> Cp = CartesianProduct(w, y); // Найдём декартово произведение множеств W и Y
            return Intersection(f, Cp); // Найдём пересечение графиков F и Сp (Ifcp)
        }

        static int[] Prototype(List<int[]> g, int[] n) 
        {
            List<int> Pa = new List<int>(); // Создаём пустое множество Pa
            for (int i = 0; i < g.Count; i++)
            {
                for (int j = 0; j < n.Length; j++)
                {
                    if (g[i][1] == n[j]) // Если вторая компонента i-й пары графика G равна j-му элементу множества N, то...
                    {
                        Pa.Add(g[i][0]); // Заносим первую компоненту i-й пары графика G во множество Pa
                    }
                }
            }
            return Pa.ToArray();
        }

        static int[] Form(List<int[]> g, int[] m)
        {
            List<int> Fa = new List<int>(); // Создаём пустое множество Fa
            for (int i = 0; i < g.Count; i++)
            {
                for (int j = 0; j < m.Length; j++)
                {
                    if (g[i][0] == m[j]) // Если первая компонента i-й пары графика G равна j-му элементу множества M, то...
                    {
                        Fa.Add(g[i][1]); // ...заносим вторую компоненту i-й пары графика G во множество Fa
                    }
                }
            }
            return Fa.ToArray(); // Множество Fa – образ множества M при соответствии А
        }

        static int[] Intersection(int[] s1, int[] s2)
        {
            List<int> list = new List<int>(); // третье множество

            for (int i = 0; i < s1.Length; i++) // Элемент первого множества сравнивается с каждым элементом второго множества
            {
                for (int j = 0; j < s2.Length; j++)
                {
                    if (s1[i] == s2[j]) list.Add(s1[i]); // В случае их равенства, этот элемент будет записан в третье множество
                }
            }

            int[] result = list.ToArray();
            return result;
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

        static int[] Union(int[] s1, int[] s2)
        {
            int[] i12 = Intersection(s1, s2); // третье множество (пересечение)
            List<int> list = new List<int>(s1); //  четвёртое множество заполняется элементами первого множества.

            if (i12.Length == 0) // Если третье множество пусто, то добавляем к элементам первого множества все элементы второго
                for (int i = 0; i < s2.Length; i++)
                    list.Add(s2[i]);

            for (int i = 0; i < s2.Length; i++)
            {
                for (int j = 0; j < i12.Length; j++) // Элемент второго множества сравнивается с каждым элементом третьего множества. 
                {
                    if (s2[i] == i12[j]) break; // В случае их равенства выбирается следующий элемент второго множества и для него повторяется сравнение
                    if (j == i12.Length - 1) list.Add(s2[i]); // В случае если проверяемый элемент второго множества не равен ни одному элементу из третьего множества, этот элемент записывается в четвёртое множество.
                }
            }

            int[] result = list.ToArray();
            return result;
        }

        static List<int[]> Union(List<int[]> a, List<int[]> b) // 5. Найдём объединение графиков А и В
        {
            List<int[]> D = Intersection(a, b); // 5.1 Создаём график D, равное результату операции пересечения графиков А и В

            List<int[]> E = new List<int[]>(a); // Создаём график E, равный графику А

            if (D.Count == 0)
                for (int i = 0; i < b.Count; i++)
                    E.Add(b[i]);

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

        static int[] Difference(int[] s1, int[] s2)
        {
            int[] i12 = Intersection(s1, s2); // создаём дополнительное множество равное пересечению исходных множеств
            List<int> list = new List<int>(); // создаём пустое множество, которое будет результатом операции разности

            if (i12.Length == 0) // если дополнительное множество пусто, то резльтатом операции будет первое множество
                for (int i = 0; i < s1.Length; i++)
                    list.Add(s1[i]);


            for (int i = 0; i < s1.Length; i++) // сравниваем каждый элемент первого исходного множества с каждым элементом дополнительного множества
                for (int j = 0; j < i12.Length; j++)
                {
                    if (s1[i] == i12[j]) // в случае их равенства этот элемент пропускается и проверка переходит к следующему элементу исходного множества
                        break;
                    if (j == i12.Length - 1) // В случае если проверяемый элемент исходного множества не равен ни одному элементу из дополнительного множества, этот элемент записывается во множество, содержащее результат.
                        list.Add(s1[i]);
                }

            int[] result = list.ToArray();
            return result;
        }

        static List<int[]> Difference(List<int[]> a, List<int[]> b) // 6. Найдём разность графиков А и В
        {
            List<int[]> F = Intersection(a, b); // Создаём график F, равный результату операции пересечения графиков А и В
            List<int[]> G = new List<int[]>(); // Создаём пустой график G

            if (F.Count == 0)
                for (int i = 0; i < a.Count; i++)
                    G.Add(a[i]);

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

        static int[] SymmetricDifference(int[] s1, int[] s2)
        {
            return Union(Difference(s1, s2), Difference(s2, s1)); // находим симметрическую разность через объединение разностей s1\s2 и s2\s1
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
                        int[] d = new int[] { a[i][0], b[j][1] }; // Составляем пару d, где первая и вторая компоненты соответственно равны первой компоненте i-й пары графика A и второй компоненте j - й пары графика B
                        Z.Add(d); // Добавляем пару d в график Z
                    }
                }
            }
            return Z; // График Z – композиция графиков A и B
        }

        static int[] CreateSet(int maxPower)
        {
            int power, element;
            Console.WriteLine("Input power of set");
            while (!int.TryParse(Console.ReadLine(), out power) && power != 0 && power < maxPower) ;
            int[] result = new int[power];
            for (int i = 0; i < power; i++)
            {
                element = 1000;
                while (!int.TryParse(Console.ReadLine(), out element) && element < 101) ;
                result[i] = element;
            }
            return result;
        }

        static List<int[]> CreateGraphic(int maxPower)
        {
            int power, element;
            int[] pair = new int[2];
            List<int[]> result = new List<int[]>();
            Console.Write("Input power of graphic: ");
            while (!int.TryParse(Console.ReadLine(), out power) && power != 0 && power < maxPower) ;
            for (int i = 0; i < power; i++)
            {
                pair = new int[2];
                for (int j = 0; j < 2; j++)
                {
                    element = 1000;
                    while (!int.TryParse(Console.ReadLine(), out element) && element < 101) ;
                    pair[j] = element;
                }
                result.Add(pair);
            }
            return result;
        }
        
        static List<int[]> CreateH(List<int[]> G, int X_Y_Power)
        {
            int power, element;
            int[] pair = new int[2];
            List<int[]> result = new List<int[]>(G); // Множество H заполняется элементами графика G
            Console.Write("Input power for additional elements of graphic H: ");
            while (!int.TryParse(Console.ReadLine(), out power) && power <= (X_Y_Power - G.Count)) ; // Пользователь задаёт количество элементов n для добавления к множеству G.
            for (int i = 0; i < power; i++) // Пользователь вводит n пар, которые добавляются в конец множества G.
            {
                pair = new int[2];
                for (int j = 0; j < 2; j++)
                {
                    element = 1000;
                    while (!int.TryParse(Console.ReadLine(), out element) && element < 101) ;
                    pair[j] = element;
                }
                result.Add(pair);
            }
            return result;
        }

        static List<int[]> CartesianProduct(int[] s1, int[] s2)
        {
            List<int[]> list = new List<int[]>(); // Создаём пустое множество list
            int[] pair = new int[2];

            for (int i = 0; i < s1.Length; i++)
            {
                for (int j = 0; j < s2.Length; j++)
                {
                    pair = new int[2];
                    pair[0] = s1[i]; // Записываем i-й элемент множества А на первую позицию кортежа
                    pair[1] = s2[j]; // Записываем j-й элемент множества B на вторую позицию кортежа
                    list.Add(pair); // Заносим полученный кортеж во множество list
                }
            }
            return list; // Множество list – декартово произведение множеств А и B
        }

        static void PrintGraphic(List<int[]> g, string name) // вывод графика на экран
        {
            Console.Write(name + " = ");
            if (g != null && g.Count > 0)
            {
                Console.Write("{ ");
                Console.Write("<" + g[0][0] + ", " + g[0][1] + ">");
                for (int i = 1; i < g.Count; i++) Console.Write(", <" + g[i][0] + ", " + g[i][1] + ">");
                Console.Write(" } ");
            }
            else Console.WriteLine("{ } ");
        }

        static void PrintSet(int[] set, string name) // вывод множества на экран
        {
            Console.Write(name + " = ");
            if (set != null && set.Length > 0)
            {
                Console.Write("{ ");
                Console.Write(set[0]);
                for (int i = 1; i < set.Length; i++) Console.Write(", " + set[i]);
                Console.WriteLine(" }");
            }
            else Console.WriteLine("{ }");
        }
    }
}
