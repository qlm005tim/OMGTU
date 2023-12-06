дано к мышей из них 1 бел мыши сидят по кругу кот нач сьедать каждую мную с какой кот должен есть каждую м чтобы осталась белая
полный перебор нельзя позицию белой задавать в нач массив нум мышей  с 0
using System;
class Program {
    public static void Main(string[] args) {
        int K = Convert.ToInt32(Console.ReadLine());
        int M = Convert.ToInt32(Console.ReadLine());
        int w = Convert.ToInt32(Console.ReadLine());
        int[] mice = new int[K];

        for (int i = 0; i < K; i++) {
            mice[i] = 0;
        }
        int mark = 0;
        mice[mark] = 1;

        while (mice.Count(c => c == 0) > 0) {
            int mov = 0;
            while (mov != M) {
                ++mark;
                
                if (mark > K - 1) {
                    mark = 0;
                }

                if (mice[mark] == 0) {
                    ++mov;
                }
            }
            mice[mark] = 1;
        }
        int dif = mark - w;
        int res = (K - dif) % K;
        Console.WriteLine("Начинать с: {0}", res);
    }
}
