using System;
using System.Reflection;
namespace CoolCalc
{
  class Program
  {
    static void Main(string[] args)
    {
      if (!CommandLineArgsAreValid(args))
      {
        Console.WriteLine("Usage: CoolCalc [number] [operator] [number]");
        Console.WriteLine("");
        Console.WriteLine("where");
        Console.WriteLine("[number] = a valid .Net double");
        Console.WriteLine("[operator] = a basic arithmatic operator of +, -, *, and /");
        Console.WriteLine("");
        Console.WriteLine("Example: CoolCalc 2 + 3");
        return;
      }

      var num1 = double.Parse(args[0]);
      var num2 = double.Parse(args[2]);
      var op = GetIOperation(args[1]);

      var coolCalc = new Calculator(op);
      Console.WriteLine(coolCalc.Execute(num1, num2));

      WaitForUserToHitReturn();
    }

    #region Infrastructure code - you can ignore

    private static bool CommandLineArgsAreValid(string[] args)
    {
      if (args.Length != 3)
      {
        return false;
      }
      double result;
      if (!double.TryParse(args[0], out result))
      {
        return false;
      }
      if (!double.TryParse(args[2], out result))
      {
        return false;
      }
      return true;
    }

    private static IOperation GetIOperation(string symbol)
    {
      if (symbol.Length != 1) BadOperatorSyntax(symbol);
      var lib = Assembly.LoadFrom("CoolCalcLib.dll");
      foreach (var type in lib.GetTypes())
      {
        if (type.GetInterface("IOperation") != null)
        {
          var op = (IOperation)Activator.CreateInstance(type);
          if (op.Symbol == symbol)
            return op;
        }
      }
      BadOperatorSyntax(symbol);
      return null;
    }

    private static void BadOperatorSyntax(string symbol)
    {
      throw new ArgumentOutOfRangeException(symbol, "Arithmatic symbol not recognized.");
    }

    private static void WaitForUserToHitReturn()
    {
      Console.ReadLine();
    }
    #endregion

  }
}
