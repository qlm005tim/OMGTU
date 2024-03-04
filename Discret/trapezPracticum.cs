class TrapezoidalRule {
  static void Main() {
      Func<double, double> f=(double x)=> -x*x+9;
      var answ=TrapezoidalRule.Solve(f, -3, 3,0.1);
      Console.WriteLine(answ); //answer
      
      Console.WriteLine(f(2.9)); //it is function no answer
  }
    public static double Solve(Func<double, double>f, double a, double b, double dx){
        eps=1E-7;
        if ((Math.Abs(b-a)>=-eps || dx<=eps || (a+b+dx)%1!=0){
            throw new ArgumentException ("Неверные данные");
        }
        double nac_x=a;
        double s_trap=0;
        for (int i=0;  i<Convert.ToInt32((b-a)/dx); i++) {
            double nac_x=a+i*dx;
            double si=(f(nac_x)+f(nac_x+dx))*0.5*dx;
     
            s_trap+=si;}
        return s_trap;
    }
}
//public class MyScalarFunc{
    //public static double calc(double x){
        //return -x*x+9;
    //}
//}