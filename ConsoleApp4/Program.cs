
namespace ConsoleApp4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Calculate();
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"В калькуляторе произошла ошибка: {ex.Message}");
            }
        }
        static void Sum(int a, int b)
        {
            var sum = a + b;
            Console.WriteLine($"Ответ: {sum}");
            if (sum == 13)
                throw new ArgumentException();
        }
        static void Sub(int a, int b)
        {
            var sub = a - b;
            Console.WriteLine($"Ответ: {sub}");
            if (sub == 13)
                throw new ArgumentException();
        }
        static void Mul(int a, int b)
        {
            var mul = a * b;
            Console.WriteLine($"Ответ: {mul}");
            if (mul == 13)
                throw new ArgumentException();
        }
        static void Div(int a, int b)
        {
            if (b == 0)
                throw new DivideByZeroException();
            var div = a / b;
            Console.WriteLine($"Ответ: {div}");
            if (div == 13)
                throw new ArgumentException();
        }

        static void Calculate()
        {
            try
            {
                int a, b;
                string c;
                string inputArr = "";
                bool v = false;
                string[] arr = new string[3];

                do
                {
                    try
                    {
                        arr = Console.ReadLine().Split();
                        inputArr = string.Join(" ", arr);

                        if (inputArr == "stop")
                            break;
                    }
                    catch (IndexOutOfRangeException)
                    {
                        Console.WriteLine("Индекс элемента массива или коллекции находится вне диапазона допустимых значений");
                    }

                    try
                    {
                        a = int.Parse(arr[0]);
                    }
                    catch(FormatException)
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Операнд {arr[0]} не является числом");
                        Console.ResetColor();
                        a = 0;
                        v = true;
                    }
                    catch (IndexOutOfRangeException ex)
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.WriteLine(ex.Message);
                        Console.ResetColor();
                        a = 0;
                        v = true;
                    }

                    try
                    {
                        c = arr[1];
                        if (c != "+" && c != "-" && c != "*" && c != "/")
                        {
                            throw new ArgumentException(arr[1]);
                            
                        }
                        if (c == " ")
                        {
                            throw new IndexOutOfRangeException();
                        }
                    }
                    catch (ArgumentException)
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.WriteLine($"Я пока не умею работать с оператором {arr[1]}");
                        Console.ResetColor();
                        c = null;
                        v = true;
                    }
                    catch (IndexOutOfRangeException)
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.WriteLine($"Укажите в выражении оператор: +, -, *, /");
                        Console.ResetColor();
                        c = null;
                        v = true;
                    }

                    try
                    {
                        b = int.Parse(arr[2]);
                    }
                    catch (FormatException)
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Операнд {arr[2]} не является числом");
                        Console.ResetColor();
                        b = 0;
                        v = true;
                    }
                    catch (IndexOutOfRangeException ex)
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.WriteLine(ex.Message);
                        Console.ResetColor();
                        b = 0;
                        v = true;
                    }

                    try
                    {
                        if (arr.Length != 3)
                            throw new FormatException();
                    }
                    catch (FormatException)
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.WriteLine("Выражение некорректное, попробуйте написать в формате \r\n a + b \r\n a * b \r\n a - b \r\n a / b");
                        Console.ResetColor();
                    }

                    if (!v)
                    {
                        switch (c)
                        {
                            case "+":
                                try
                                {
                                    Sum(a, b);
                                }
                                catch(ArgumentException)
                                {
                                    Console.BackgroundColor = ConsoleColor.Green;
                                    Console.WriteLine("вы получили ответ 13!");
                                    Console.ResetColor();
                                }
                                break;
                            case "-":
                                try
                                {
                                    Sub(a, b);
                                }
                                catch(ArgumentException)
                                {
                                    Console.BackgroundColor = ConsoleColor.Green;
                                    Console.WriteLine("вы получили ответ 13!");
                                    Console.ResetColor();
                                }
                                break;
                            case "*":
                                try
                                {
                                    Mul(a, b);
                                }
                                catch(ArgumentException)
                                {
                                    Console.BackgroundColor = ConsoleColor.Green;
                                    Console.WriteLine("вы получили ответ 13!");
                                    Console.ResetColor();
                                }
                                break;
                            case "/":
                                try
                                {
                                    Div(a, b);  
                                }
                                catch (DivideByZeroException)
                                {
                                    Console.BackgroundColor = ConsoleColor.Magenta;
                                    Console.WriteLine("Деление на ноль");
                                    Console.ResetColor();
                                }
                                catch (ArgumentException)
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
            catch(OverflowException)
            {
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.WriteLine("Результат выражения вышел за границы int");
                Console.ResetColor();
            }
            catch(Exception ex)
            {
                Console.WriteLine("Я не смог обработать ошибку");
                    throw new Exception(ex.ToString());              
            }
        }
    }
}