
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

                string[] arr = new string[3]; // ToDo не работает

                int i = 0;
                do
                {
                    //Console.WriteLine("Введите значение: ");
                    try
                    {
                        arr = Console.ReadLine().Split();
                    }
                    catch (IndexOutOfRangeException)
                    {
                        Console.WriteLine("Индекс элемента массива или коллекции находится вне диапазона допустимых значений");
                    }

                    inputArr = string.Join(" ", arr);

                    if (inputArr == "stop")
                        break;

                    a = int.Parse(arr[0]);
                    c = char.Parse(arr[1]);
                    // кейс 1
                    try
                    {
                        if (c == ' ') // ToDo пока не работает
                        {
                            throw new ArgumentException("Укажите в выражении оператор: +, -, *, /");
                        }
                    }
                    catch (ArgumentException e)
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.WriteLine(e.ToString());
                        Console.ResetColor();
                    }
                    // кейс 2
                    try
                    {
                        if (c != '+' && c != '-' && c != '*' && c != '/')
                        {
                            throw new ArgumentException($"Я пока не умею работать с оператором{ c}");
                        }
                    }
                    catch (ArgumentException e)
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.WriteLine(e.ToString());
                        Console.ResetColor();
                    }
                    b = int.Parse(arr[2]);

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
                    i++;
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