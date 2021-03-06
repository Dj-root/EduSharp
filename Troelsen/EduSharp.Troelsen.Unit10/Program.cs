﻿using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EduSharp.Unit10;

namespace EduSharp.Troelsen.Unit10
{

    class Program
    {
        public delegate void MyGenericDelegate<T>(T arg);

        static void Main(string[] args)
        {
            Console.WriteLine("***** Simple Delegate Example *****\n");

            BinaryOp b = new BinaryOp(SimpleMath.Add);
            Console.WriteLine("10 + 10 is {0}", b(10, 10));

            //            CompilerError Error
            //            BinaryOp b2=new BinaryOp(SimpleMath.SquareNumber);

            DisplayDelegateInfo(b);

            //            SimpleMath m = new SimpleMath();
            //            BinaryOp b2 = new BinaryOp(m.Add);


            Console.WriteLine("***** Delegate as event enablers*****\n");

            Car c1 = new Car("SlugBug", 100, 10);
            c1.RegisterWithCarEngine(new Car.CarEngineHandler(OnCarEngineEvent));
            //            c1.RegisterWithCarEngine(new Car.CarEngineHandler(OnCarEngineEvent2));


            Car.CarEngineHandler handler2 = new Car.CarEngineHandler(OnCarEngineEvent2);
            c1.RegisterWithCarEngine(handler2);


            Console.WriteLine("***** Speeding up *****");
            for (int i = 0; i < 6; i++)
            {
                c1.Accelerate(20);
            }

            c1.UnRegisterWithCarEngine(handler2);
            Console.WriteLine("***** Speeding up *****");
            for (int i = 0; i < 6; i++)
            {
                c1.Accelerate(20);
            }



            Console.WriteLine("\n***** Delegate as event enablers*****\n");
            Car c2 = new Car();
            c2.RegisterWithCarEngine(CallMeHere);

            Console.WriteLine("***** Speeding up *****");
            for (int i = 0; i < 6; i++)
            {
                c2.Accelerate(20);
            }

            c2.UnRegisterWithCarEngine(CallMeHere);
            for (int i = 0; i < 6; i++)
            {
                c2.Accelerate(20);
            }


            Console.WriteLine("\n***** Generic Delegates *****\n");
            MyGenericDelegate<string> strTarget = new MyGenericDelegate<string>(StringTarget);
            strTarget("Some string data");

            MyGenericDelegate<int> intTarget = new MyGenericDelegate<int>(IntTarget);
            intTarget(9);

            Console.WriteLine("\n***** Fun with Action and Func *****\n");
            Action<string, ConsoleColor, int> actionTarget = new Action<string, ConsoleColor, int>(DisplayMessage);
            actionTarget("Action Message!", ConsoleColor.DarkYellow, 5);

            Func<int, int, int> funcTarget = new Func<int, int, int>(SimpleMath.Add);
            int result = funcTarget.Invoke(40, 40);
            Console.WriteLine("40 + 40 = {0}", result);

            Func<int, int, string> funcTarget2 = new Func<int, int, string>(SimpleMath.SumToString);
            string sum = funcTarget2(90, 300);
            Console.WriteLine(sum);

            Console.WriteLine("\n***** Fun with Lambdas *****\n");
            TraditionalDelegateSyntax();
            AnonymousMethodSyntax();
            LambdaExpressionSyntax();

            Console.WriteLine("\n***** Fun with Lambdas with Params*****\n");
            SimpleMath mm = new SimpleMath();
            mm.SetMathHendler((msg, rslt)=>{ Console.WriteLine("Message: {0}, Result: {1}", msg, rslt); });

            mm.AddLambda(10,10);

            
            Console.ReadLine();
        }

        public static void TraditionalDelegateSyntax()
        {
            List<int> list = new List<int>();
            list.AddRange(new int[] { 20, 1, 4, 8, 9, 44 });

            Predicate<int> callback = IsEvenNumber;
            List<int> evenNumbers = list.FindAll(callback);

            Console.WriteLine("Here is your even numbers:");
            foreach (int evenNumber in evenNumbers)
            {
                Console.Write("{0}\t", evenNumber);
            }

            Console.WriteLine();
        }

        public static void AnonymousMethodSyntax()
        {
            List<int> list = new List<int>();
            list.AddRange(new int[] { 20, 1, 4, 8, 9, 44 });

            List<int> evenNumbers = list.FindAll(delegate (int i) { return (i % 2) == 0; });

            Console.WriteLine("Here is your even numbers:");
            foreach (int evenNumber in evenNumbers)
            {
                Console.Write("{0}\t", evenNumber);
            }

            Console.WriteLine();
        }

        public static void LambdaExpressionSyntax()
        {
            List<int> list = new List<int>();
            list.AddRange(new int[] { 20, 1, 4, 8, 9, 44 });

            List<int> evenNumbers = list.FindAll(i=>(i%2)==0);

            Console.WriteLine("Here is your even numbers:");
            foreach (int evenNumber in evenNumbers)
            {
                Console.Write("{0}\t", evenNumber);
            }

            Console.WriteLine();
        }


        static bool IsEvenNumber(int i)
        {
            return (i % 2) == 0;
        }

        static void NewCar_AboutToBlow(string msg)
        {
            //            throw NotImplementedException();
        }

        public static void CarAboutToBlow(object sender, CarEventArgs e)
        {
            if (sender is CarEvent)
            {
                CarEvent c = (CarEvent)sender;
                Console.WriteLine("Critical Message from {0}: {1}", c.PetName, e.msg);
            }
            //            Console.WriteLine("{0} says: {1}",sender, e.msg);
        }

        public static void CarIsAlmostDoomed(string msg)
        {
            Console.WriteLine("=> Critical Message from Car: {0}", msg);
        }

        public static void CarExploded(string msg)
        {
            Console.WriteLine(msg);
        }

        static void CallWhenExploded(string msg)
        {
            Console.WriteLine(msg);
        }

        static void CallHereToo(string msg)
        {
            Console.WriteLine(msg);
        }

        static void DisplayMessage(string msg, ConsoleColor txtColor, int printCount)
        {
            ConsoleColor previous = Console.ForegroundColor;
            Console.ForegroundColor = txtColor;

            for (int i = 0; i < printCount; i++)
            {
                Console.WriteLine(msg);
            }

            Console.ForegroundColor = previous;
        }

        static void IntTarget(int arg)
        {
            Console.WriteLine("++arg is: {0}", ++arg);
        }


        static void StringTarget(string arg)
        {
            Console.WriteLine("arg in upper case is: {0}", arg.ToUpper());
        }

        static void CallMeHere(string msg)
        {
            Console.WriteLine("=> Message from Car: {0}", msg);
        }
        public static void OnCarEngineEvent(string msg)
        {
            Console.WriteLine("\n***** Message From Car Object *****");
            Console.WriteLine("=> {0}", msg);
            Console.WriteLine("***********************************");
        }

        public static void OnCarEngineEvent2(string msg)
        {
            Console.WriteLine("=> {0}", msg.ToUpper());
        }



        static void DisplayDelegateInfo(Delegate delObj)
        {
            foreach (Delegate d in delObj.GetInvocationList())
            {
                Console.WriteLine("Method Name: {0}", d.Method);
                Console.WriteLine("Type Name: {0}", d.Target);
            }
        }
    }
}
