using System;

namespace newton
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Input a->");
            var a_str = Console.ReadLine();
            var a = double.Parse(a_str);

            Console.Write("Input dx");
            var dx_str = Console.ReadLine();
            var dx = double.Parse(dx_str);

            Console.Write("Input eps");
            var eps_str = Console.ReadLine();
            var eps = double.Parse(eps_str);

            Console.Write("Input x0");
            var x0_str = Console.ReadLine();
            var x0 = double.Parse(x0_str);

           
            double x = Method( x0, dx, a, eps);
            Console.WriteLine(x);
        
        }
        static double Func(double x, double a)
        {
            return x * x * x - a;
        }
        static double NextX(double a, double dx, double x0)
        {
            return x0  - (Func(x0, a) / ((Func(x0 + dx, a) - Func(x0, a)) / dx));
        }

        static double Method( double x0, double dx,  double a, double eps)
        {
            double x = x0;
            double y = 0;
            double next_y = 0;
            do
            {
                y = Func(x, a);

                var next_x = NextX(a, dx, x);
                
                next_y = Func(next_x, a);
                //x_prev = x0;
                //x_curr = tmp;

                x = next_x;

                Console.WriteLine(x.ToString("F6"), next_y);
            } while (Math.Abs(y - next_y) <= eps);
            return y;

        }
    }
}
