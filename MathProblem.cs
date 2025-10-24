namespace KolmVormid
{
    public class MathProblem
    {
        public int A;
        public int B;
        public Problem Type;

        public MathProblem(int a, int b, Problem type)
        {
            A = a;
            B = b;
            Type = type;
        }

        public MathProblem(Problem type)
        {
            Type = type;
        }

        public int Solve()
        {
            switch (Type)
            {
                case Problem.Plus:
                    return A + B;
                case Problem.Minus:
                    return A - B;
                case Problem.Multiply:
                    return A * B;
                case Problem.Divide:
                    return A / B;
            }

            return 0;
        }
    }

    public enum Problem
    {
        Plus, Minus, Multiply, Divide
    }
}
