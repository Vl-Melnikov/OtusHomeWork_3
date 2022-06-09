
namespace ConsoleApp4
{
    class CheckResultExeption : ArgumentException
    {    
        public CheckResultExeption()
        {

        }
    }

    class CheckOperatorExeption : ArgumentException 
    {
        public CheckOperatorExeption() 
        {

        }
    }
    class CheckLengthExeption : ArgumentException
    {
        public CheckLengthExeption()
        {

        }
    }
    class CheckNullOperatorExeption : ArgumentException
    {
        public CheckNullOperatorExeption()
        {

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
        static void Sum(int a, int b)
        {
            var sum = a + b;
            Console.WriteLine($"Ответ: {sum}");
            if (sum == 13)
                throw new CheckResultExeption();
        }
        static void Sub(int a, int b)
        {
            var sub = a - b;
            Console.WriteLine($"Ответ: {sub}");
            if (sub == 13)
                throw new CheckResultExeption();
        }
        static void Mul(int a, int b)
        {
            var mul = a * b;
            Console.WriteLine($"Ответ: {mul}");
            if (mul == 13)
                throw new CheckResultExeption();
        }
        static void Div(int a, int b)
        {             
            var div = a / b;
                throw new DivideByZeroException();
            Console.WriteLine($"Ответ: {div}");
            if (div == 13)
                throw new CheckResultExeption();
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

                        arr = text.Split().Length <= 3 ? text.Split() : throw new CheckLengthExeption();

                        a = int.Parse(arr[0]);
                        c = arr[1];
                        if (c != "+" && c != "-" && c != "*" && c != "/")
                        {
                            throw new CheckOperatorExeption();
                        }
                        if (arr[1] == null)
                        {
                            throw new CheckNullOperatorExeption();
                        }

                        b = int.Parse(arr[2]);
                   
                    }
                    catch(FormatException)
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Операнд {arr[0]} или {arr[2]} не является числом"); // ToDo как передать опереатора?
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
                    catch (CheckOperatorExeption ex)
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.WriteLine($"Я пока не умею работать с оператором {arr[1]}");
                        Console.ResetColor();
                        canCalculate = false;
                    }
                    catch (CheckNullOperatorExeption) // ToDo не работает
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.WriteLine($"Укажите в выражении оператор: +, -, *, /");
                        Console.ResetColor();
                        canCalculate = false;
                    }
                    catch (CheckLengthExeption)
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
                                catch(CheckResultExeption)
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
                                catch(CheckResultExeption)
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
                                catch(CheckResultExeption)
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
                                catch (CheckResultExeption)
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