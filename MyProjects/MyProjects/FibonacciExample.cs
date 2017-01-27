namespace MyProjects
{
    public class FibonacciExample
    {
        private const int SECOND = 2;
        public int Calculate(int n)
        {
            int result = 1;
            if (n > 1)
            {
                result = Calculate(n - 1) + Calculate(n - SECOND);
            }

            return result;
        }
    }
}