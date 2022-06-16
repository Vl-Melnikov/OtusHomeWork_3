
namespace ConsoleApp4
{
    class ResultExeption : ArgumentException
    {    
        public ResultExeption()
        {

        }
    }

    class CperatorExeption : ArgumentException 
    {
        public CperatorExeption() 
        {

        }
    }
    class LengthExeption : ArgumentException
    {
        public LengthExeption()
        {

        }
    }
    class NullOperatorExeption : ArgumentException
    {
        public NullOperatorExeption()
        {

        }
    }
    class MyFormatException : FormatException
    {
        public string ProblemData { get; private set; }
        public MyFormatException(string? message, Exception innerException, string? problemData) : base(message, innerException)
        {
            ProblemData = problemData;
        }
    }
    
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
        public static int MyTryParse(string input)
        {
            try
            {
                return int.Parse(input);
            }
            catch (FormatException ex)
            {
                var exp = new MyFormatException("", ex, input);
                exp.Data.Add("input", input);
                throw exp;
            }
        }
        static void Sum(int a, int b)
        {
            var sum = checked(a + b); // проверим на переполнение
            Console.WriteLine($"Ответ: {sum}");
            if (sum == 13)
                throw new ResultExeption();
        }
        static void Sub(int a, int b)
        {
            var sub = a - b;
            Console.WriteLine($"Ответ: {sub}");
            if (sub == 13)
                throw new ResultExeption();
        }
        static void Mul(int a, int b)
        {
            var mul = a * b;
            Console.WriteLine($"Ответ: {mul}");
            if (mul == 13)
                throw new ResultExeption();
        }
        static void Div(int a, int b)
        {             
            var div = a / b;
            Console.WriteLine($"Ответ: {div}");
            if (div == 13)
                throw new ResultExeption();
        }

        static void Calculate()
        {
            try
            {
                var a = 0;
                var b = 0;
                var c = "";
                bool canCalculate = true;
                string[] arr = new string[3];
                var text = "";

                do
                {
                    try
                    {
                        canCalculate = true;

                        text = Console.ReadLine();
                        if (text == "stop")
                            break;

                        arr = text.Split();
                        if(arr.Length < 3)
                            throw new NullOperatorExeption();
                        if(arr.Length > 3)
                            throw new LengthExeption();

                        a = MyTryParse(arr[0]);
                        c = arr[1];
                        if (c != "+" && c != "-" && c != "*" && c != "/")
                        {
                            throw new CperatorExeption();
                        }
                        b = MyTryParse(arr[2]);
                    }
                    catch (MyFormatException ex)
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Операнд {ex.ProblemData} не является числом");
                        Console.ResetColor();
                        canCalculate = false;
                    }
                    catch (IndexOutOfRangeException ex)
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.WriteLine(ex.Message);
                        Console.ResetColor();
                        canCalculate = false;
                    }
                    catch (CperatorExeption)
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.WriteLine($"Я пока не умею работать с оператором {arr[1]}");
                        Console.ResetColor();
                        canCalculate = false;
                    }
                    catch (NullOperatorExeption)
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.WriteLine($"Укажите в выражении оператор: +, -, *, /");
                        Console.ResetColor();
                        canCalculate = false;
                    }
                    catch (LengthExeption)
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.WriteLine("Выражение некорректное, попробуйте написать в формате \r\n a + b \r\n a * b \r\n a - b \r\n a / b");
                        Console.ResetColor();
                        canCalculate = false;
                    }

                    if (canCalculate)
                    {
                        switch (c)
                        {
                            case "+":
                                try
                                {
                                    Sum(a, b);
                                }
                                catch(ResultExeption)
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
                                catch(ResultExeption)
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
                                catch(ResultExeption)
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
                                catch (ResultExeption)
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
            catch (OverflowException)
            {
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.WriteLine("Результат выражения вышел за границы int");
                Console.ResetColor();
            }
            catch(Exception)
            {
                Console.WriteLine("Я не смог обработать ошибку");
                throw;            
            }
        }
    }
}