using System;
class TrapezoidalRule {
  static void Main() {
    //Console.WriteLine("Hello World");
      Func<double, double> f=(double x)=> -x*x+9;
      var answ=TrapezoidalRule.Solve(f, -3, 3,0.1);
      Console.WriteLine(answ); //answer
      
      //Func<double, double> f=(double x)=> -x*x+9;
      //Console.WriteLine(f(2.9)); //it is function no answer
  }
    public static double Solve(Func<double, double>f, double a, double b, double dx){
        double nac_x=a;
        double s_trap=0;
        for (int i=0; i< (b-a)/dx; i++) {
            double si=(f(nac_x)+f(nac_x+dx))*0.5*dx;
            nac_x=nac_x+dx;
            s_trap+=si;
        return s_trap;
        }
    }
}
public class MyScalarFunc{
    public static double calc(double x){
        return -x*x+9;
    }
}