namespace PL.Console
{
    public static class Out
    {
        public static void Print(object value)
        { 
            System.Console.WriteLine(StringConvertor.ToSting(value));
        }
        
        public static void Print<T>(T[,] matrix)
        {
            System.Console.WriteLine(StringConvertor.MatrixToString(matrix, -1));
        }
        public static void Print(params object[] vars)
        {
            string str = string.Empty;
            foreach (var item in vars)
                str += StringConvertor.ToSting(item) + " ";
            System.Console.WriteLine(str);
        }
    }
}
