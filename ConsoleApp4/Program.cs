
namespace ConsoleApp4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Calculate();
            Console.ReadKey();
        }

        static void Sum(int a, int b)
        {
            var sum = a + b;
            Console.WriteLine($"Ответ: {sum}");
            // кейс 6
            if (sum == 13)
                throw new Exception();
        }
        static void Sub(int a, int b)
        {
            var sub = a - b;
            Console.WriteLine($"Ответ: {sub}");
            // кейс 6
            if (sub == 13)
                throw new Exception();
        }
        static void Mul(int a, int b)
        {
            var mul = a * b;
            Console.WriteLine($"Ответ: {mul}");
            // кейс 6
            if (mul == 13)
                throw new Exception();
        }
        static void Div(int a, int b)
        {
            // Кейс 5
            if (b == 0)
                throw new DivideByZeroException();
            var div = a / b;
            Console.WriteLine($"Ответ: {div}");
            // кейс 6
            if (div == 13)
                throw new Exception();
        }

        static void Calculate()
        {
            try
            {
                int a, b;
                char c;
                string inputArr = "";
                bool v = false;

                string[] arr = new string[3]; // ToDo не работает

                do
                {
                    try
                    {
                        arr = Console.ReadLine().Split();
                    }
                    catch (IndexOutOfRangeException)
                    {
                        Console.WriteLine("Индекс элемента массива или коллекции находится вне диапазона допустимых значений");
                    }
                    try
                    {
                        if (arr.Length != 3)
                            throw new ArgumentException("Выражение некорректное, попробуйте написать в формате \r\n a + b \r\n a * b \r\n a - b \r\n a / b");
                    }
                    catch(ArgumentException ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }

                    inputArr = string.Join(" ", arr);

                    if (inputArr == "stop")
                        break;

                    try
                    {
                        a = int.Parse(arr[0]);
                    }
                    catch
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Операнд {arr[0]} не является числом");
                        Console.ResetColor();
                        a = 0;
                        v = true;
                    }

                    try
                    {
                        c = char.Parse(arr[1]);
                        if (c != '+' && c != '-' && c != '*' && c != '/')
                        {
                            throw new ArgumentException($"Я пока не умею работать с оператором {c}");
                        }
                        //if (c == '\0')
                        //{
                        //    throw new ArgumentException($"Укажите в выражении оператор: +, -, *, /");
                        //}
                    }
                    catch (ArgumentException e)
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.WriteLine(e.ToString());
                        Console.ResetColor();
                        c = '0';
                        v = true;
                    }
                    try
                    {
                        b = int.Parse(arr[2]);
                    }
                    catch
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Операнд {arr[2]} не является числом");
                        Console.ResetColor();
                        b = 0;
                        v = true;    
                    }
                    if(!v)
                    {
                        switch (c)
                        {
                            case '+':
                                try
                                {
                                    Sum(a, b); // сложение
                                }
                                catch
                                {
                                    Console.BackgroundColor = ConsoleColor.Green;
                                    Console.WriteLine("вы получили ответ 13!");
                                    Console.ResetColor();
                                }
                                break;
                            case '-':
                                try
                                {
                                    Sub(a, b); // вычитание
                                }
                                catch
                                {
                                    Console.BackgroundColor = ConsoleColor.Green;
                                    Console.WriteLine("вы получили ответ 13!");
                                    Console.ResetColor();
                                }
                                break;
                            case '*':
                                try
                                {
                                    Mul(a, b); // умножение
                                }
                                catch
                                {
                                    Console.BackgroundColor = ConsoleColor.Green;
                                    Console.WriteLine("вы получили ответ 13!");
                                    Console.ResetColor();
                                }
                                break;
                            case '/':
                                try
                                {
                                    Div(a, b); // деление   
                                }
                                catch (DivideByZeroException)
                                {
                                    Console.BackgroundColor = ConsoleColor.Magenta;
                                    Console.WriteLine("Деление на ноль");
                                    Console.ResetColor();
                                }
                                catch (Exception)
                                {
                                    Console.BackgroundColor = ConsoleColor.Green;
                                    Console.WriteLine("вы получили ответ 13!");
                                    Console.ResetColor();
                                }

                                break;

                            default: throw new ArgumentException();
                        }
                    }
                }
                while (true);
            }
            // кейс 7 
            catch(Exception) // ToDo некорректно срабатывает
            {
                Console.WriteLine("Я не смог обработать ошибку");
            }
        }
    }
}