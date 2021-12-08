using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Numerics;


namespace Lab_3
{
    // Program
    class Program
    {
        static void ConsoleWiteRed(string str)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(str);
            Console.ForegroundColor = ConsoleColor.White;
        }

        static void ConsoleWiteBlue(string str)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(str);
            Console.ForegroundColor = ConsoleColor.White;
        }

        static void ConsoleWiteGreen(string str)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(str);
            Console.ForegroundColor = ConsoleColor.White;
        }

        static void ConsoleWiteYellow(string str)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(str);
            Console.ForegroundColor = ConsoleColor.White;
        }

        static void Interp(V2DataArray array)
        {
            ConsoleWiteGreen("____FirstDerivative____:\n\n");
            ConsoleWiteYellow("\n____Error_Code_If_One_Accures_or_\"double_derivatieves\"____:\n\n");
            bool res = array.FirstDerivative();
            ConsoleWiteYellow("\n____DoubleDerivatives_res____:\n\n");
            Console.WriteLine(res);
            ConsoleWiteYellow("\n\n____FirstDerivativeSpline____:\n\n");
            if (res)
            {
                for (int i = 0; i < array.OxCount; i++)
                {
                    for (int j = 0; j < array.OyCount; j++)
                    {
                        Console.WriteLine(array.FirstDerivativeSplineAt(i, j));
                    }
                }
            }
            else
            {
                Console.WriteLine("NULL");
            }
            ConsoleWiteGreen("\n\n____FirstDerivative_1D____:\n\n");
            ConsoleWiteYellow("\n____Error_Code_If_One_Accures_or_\"double_derivatieves\"____:\n\n");
            res = array.FirstDerivative_1D();
            ConsoleWiteYellow("\n____DoubleDerivatives_1D_res____:\n\n");
            Console.WriteLine(res);
            ConsoleWiteYellow("\n\n____FirstDerivative1DSpline____:\n\n");
            if (res)
            {
                for (int i = 0; i < array.OxCount; i++)
                {
                    for (int j = 0; j < array.OyCount; j++)
                    {
                        Console.WriteLine(array.FirstDerivativeSplineAt(i, j));
                    }
                }
            }
            else
            {
                Console.WriteLine("NULL");
            }
            ConsoleWiteGreen("\n\n____FirstDerivativeLeftAt____:\n\n");
            for (int i = 0; i < array.OxCount; i++)
            {
                for (int j = 0; j < array.OyCount; j++)
                {
                    Complex? res1 = array.FirstDerivativeLeftAt(i, j);
                    if (res1 != null)
                    {
                        Console.WriteLine(res1);
                    }
                    else
                    {
                        Console.WriteLine("NULL");
                    }
                }
            }
            ConsoleWiteGreen("\n\n____FirstDerivativeRightAt____:\n\n");
            for (int i = 0; i < array.OxCount; i++)
            {
                for (int j = 0; j < array.OyCount; j++)
                {
                    Complex? res1 = array.FirstDerivativeRightAt(i, j);
                    if (res1 != null)
                    {
                        Console.WriteLine(res1);
                    }
                    else
                    {
                        Console.WriteLine("NULL");
                    }
                }
            }
        }

        static void Interp1()
        {
            Vector2 vector_1 = new(0.4f, 1f);
            V2DataArray array = new("Array", DateTime.Now, 6, 1, vector_1, FuncV2Complex.FuncV2Complex_1);
            ConsoleWiteBlue("____Array____:\n\n");
            Console.WriteLine(array.ToLongString("F4"));
            Interp(array);
        }

        static void Interp2()
        {
            Vector2 vector_1 = new(0.25f, 1f);
            V2DataArray array = new("Array", DateTime.Now, 9, 2, vector_1, FuncV2Complex.FuncV2Complex_1);
            ConsoleWiteBlue("____Array____:\n\n");
            Console.WriteLine(array.ToLongString("F4"));
            Interp(array);
        }

        static void Main()
        {
            ConsoleWiteRed("____Interp1____:\n\n");
            Interp1();
            ConsoleWiteRed("\n\n========================\n\n");
            //ConsoleWiteRed("____Interp2____:\n\n");
            //Interp2();
            //ConsoleWiteRed("\n\n========================\n\n");
        }
    }
}
