using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("Вводите команду (help - для справки): ");
                string commandString = Console.ReadLine();
                var separator = new[] { ' ' };
                commandString = commandString.Trim().ToLower();
              
                if (commandString == "exit")
                {
                    break;
                }

                string[] receivedCommands = commandString.Split(separator, StringSplitOptions.RemoveEmptyEntries);

                if (receivedCommands[0] == "help")
                {
                    Console.WriteLine("Программа выполняет арифметические действия над рациональными числами");
                    Console.WriteLine("Список команд:\n" +
                        "add - сложение\n" +
                        "sub - вычитание\n" +
                        "mul - умножение\n" +
                        "div - деление\n" +
                        "exit-выход\n" +
                        "help-помощь");
                    continue;
                }

                if (receivedCommands.Length != 3)
                {
                    Console.WriteLine("Неверный формат ввода, введите <команда> <рациональное число> <рациональное число>");
                    continue;
                }

                Rational first;
                Rational second;

                bool isFirstCorrect = Rational.TryParse(receivedCommands[1], out first);
                bool isSecondCorrect = Rational.TryParse(receivedCommands[2], out second);
                if (!isFirstCorrect && !isSecondCorrect)
                {
                    Console.WriteLine("Числа введенены в неверном формате");
                    continue;
                }

                if (!isFirstCorrect)
                {
                    Console.WriteLine("Число " + receivedCommands[1] +
                                      " введенено в неверном формате");
                    continue;
                }
                
                if (!isSecondCorrect)
                {
                    Console.WriteLine("Число " + receivedCommands[2] +
                                      " введенено в неверном формате");
                    continue;
                }

                Rational result = new Rational();
                switch (receivedCommands[0])
                {
                    
                    case "add":
                        result = first + second;
                        break;

                    case "sub":
                        result = first - second;
                        break;

                    case "mul":
                        result = first * second;
                        break;

                    case "div":
                        try
                        {
                            result = first / second;
                        }
                        catch (DivideByZeroException)
                        {
                            Console.WriteLine("Делить на ноль нельзя");
                            continue;
                        }
                        break;
                    default:
                        Console.WriteLine("Вы ввели некоректную команду");
                        continue;
                }
                Console.WriteLine(result);
            }

        }
    }
}
