namespace PL.Console
{
    public static class Out
    {
        public static void Print(object value)
        { 
            System.Console.WriteLine(InString.ToSting(value));
        }
        
        public static void Print<T>(T[,] matrix)
        {
            System.Console.WriteLine(InString.MatrixToStr(matrix, -1));
        }
        public static void Print(params object[] vars)
        {
            string str = string.Empty;
            foreach (var item in vars)
                str += InString.ToSting(item) + " ";
            System.Console.WriteLine(str);
        }
    }
}
