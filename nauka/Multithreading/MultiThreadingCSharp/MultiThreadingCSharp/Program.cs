namespace MultiThreadingInCSharp
{
    public delegate void SumOfNumberCallbackDelegate(int SumOfNum);

    class Program
    {
        public static void DisplaySumOfNo(int Sum)
        {
            Console.WriteLine("The sum of number is: " + Sum);
        }

        static void Main(string[] args)
        {
            SumOfNumberCallbackDelegate _callback = new SumOfNumberCallbackDelegate(DisplaySumOfNo);
            int max = 10;
            NumberHelper _helper = new NumberHelper(max, _callback);
            ThreadStart obj = new ThreadStart(_helper.ShowNumbers);

            Thread t = new Thread(obj);
            t.Start();
            Console.ReadLine();
        }
    }
    public class NumberHelper
    {
        private int _Number;
        SumOfNumberCallbackDelegate _callbackDelegate;
        public NumberHelper(int num, SumOfNumberCallbackDelegate @delegate)
        {
            _Number = num;
            _callbackDelegate = @delegate;
        }

        public void ShowNumbers()
        {
            int sum = 0;
            for (int i = 0; i < _Number; i++)
            {
                sum = sum + i;
            }

            if (_callbackDelegate != null)
                _callbackDelegate(sum);
        }

    }
}
