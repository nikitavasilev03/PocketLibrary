using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public static class InString
    {
        public static readonly string NewLine = Environment.NewLine;

        public static string ToSting(object obj)
        {
            if (obj is System.Collections.IEnumerable && !(obj is string))
                return EnumerableToString(obj as System.Collections.IEnumerable);
            return obj.ToString();
        }

        public static string EnumerableToString(System.Collections.IEnumerable enumerable)
        {
            string str = string.Empty;
            foreach (var item in enumerable)
            {
                str += ToSting(item);
                if (item is System.Collections.IEnumerable && !(item is string))
                    str += NewLine;
                else
                    str += " ";
            }
            if (str != "")
            {
                if (str[str.Length - 1] == ' ')
                    str = str.Remove(str.Length - 1, 1);
                else if (str[str.Length - 2] == '\r' && str[str.Length - 1] == '\n')
                    str = str.Remove(str.Length - 1, 1).Remove(str.Length - 2, 1);
            }
            return "[" + str + "]";
        }

        public static string MatrixToStr<T>(T[,] matrix)
        {
            string s = string.Empty;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                    s += matrix[i, j] + " ";
                if (i == matrix.GetLength(0) - 1)
                    break;
                s += "\n\r";
            }
            return s;
        }

        public static string MatrixToStr<T>(T[,] matrix, int key)
        {
            if (key == 0) return MatrixToStr(matrix);
            string s = string.Empty;
            string str = string.Empty; int count = 0;
            if (key == -1)
                for (int i = 0; i < matrix.GetLength(0); i++)
                    for (int j = 0; j < matrix.GetLength(1); j++)
                        if (matrix[i, j].ToString().Length > key)
                            key = matrix[i, j].ToString().Length;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    str = string.Empty;
                    count = matrix[i, j].ToString().Length;
                    if (key - count > 0)
                        for (int k = 0; k < key - count; k++)
                            str += " ";
                    str += " ";
                    s += str + matrix[i, j];
                }
                if (i == matrix.GetLength(0) - 1)
                    break;
                s += "\n";
            }
            return s;
        }
    }
}
