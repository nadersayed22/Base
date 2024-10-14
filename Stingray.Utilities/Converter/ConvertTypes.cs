using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StingRay.Utility.Converter
{
    public class ConvertTypes
    {
        public static object[][] ConvertArray(object[,] input)
        {
            object[][] output = new object[input.GetLength(0)][];
            for (int i = 0; i < input.GetLength(0); i++)
            {
                output[i] = new object[input.GetLength(1)];
                for (int j = 0; j < input.GetLength(1); j++)
                {
                    output[i][j] = input[i, j];
                }
            }
            return output;
        }
         public static object[][] ConvertArray(object[] arrays)
        {
            // TODO: Validation and special-casing for arrays.Count == 0
            object[][] ret = new object[arrays.GetLength(0)][];
            for (int i = 0; i < arrays.Length; i++)
            {
                if (arrays[i].GetType() == typeof(double[]))
                {
                    double[] res = (double[])arrays[i];
                    object[] object_array = new object[res.Length];
                    res.CopyTo(object_array, 0);
                    ret[i] = object_array;
                }
                else if (arrays[i].GetType() == typeof(double?[]))
                {
                    double?[] res = (double?[])arrays[i];
                    object[] object_array = new object[res.Length];
                    res.CopyTo(object_array, 0);
                    ret[i] = object_array;
                }
                else if (arrays[i].GetType() == typeof(int[]))
                {
                    int[] res = (int[])arrays[i];
                    object[] object_array = new object[res.Length];
                    res.CopyTo(object_array, 0);
                    ret[i] = object_array;
                }
                else if (arrays[i].GetType() == typeof(int?[]))
                {
                    int?[] res = (int?[])arrays[i];
                    object[] object_array = new object[res.Length];
                    res.CopyTo(object_array, 0);
                    ret[i] = object_array;
                }
                else if (arrays[i].GetType() == typeof(Int32[]))
                {
                    Int32[] res = (Int32[])arrays[i];
                    object[] object_array = new object[res.Length];
                    res.CopyTo(object_array, 0);
                    ret[i] = object_array;
                }
                else if (arrays[i].GetType() == typeof(Int32?[]))
                {
                    Int32?[] res = (Int32?[])arrays[i];
                    object[] object_array = new object[res.Length];
                    res.CopyTo(object_array, 0);
                    ret[i] = object_array;
                }
                else if (arrays[i].GetType() == typeof(Int64[]))
                {
                    Int64[] res = (Int64[])arrays[i];
                    object[] object_array = new object[res.Length];
                    res.CopyTo(object_array, 0);
                    ret[i] = object_array;
                }
                else if (arrays[i].GetType() == typeof(Int64?[]))
                {
                    Int64?[] res = (Int64?[])arrays[i];
                    object[] object_array = new object[res.Length];
                    res.CopyTo(object_array, 0);
                    ret[i] = object_array;
                }
                else if (arrays[i].GetType() == typeof(long[]))
                {
                    long[] res = (long[])arrays[i];
                    object[] object_array = new object[res.Length];
                    res.CopyTo(object_array, 0);
                    ret[i] = object_array;
                }
                else if (arrays[i].GetType() == typeof(long?[]))
                {
                    long?[] res = (long?[])arrays[i];
                    object[] object_array = new object[res.Length];
                    res.CopyTo(object_array, 0);
                    ret[i] = object_array;
                }
                else if (arrays[i].GetType() == typeof(string[]))
                {
                    string[] res = (string[])arrays[i];
                    object[] object_array = new object[res.Length];
                    res.CopyTo(object_array, 0);
                    ret[i] = object_array;
                }
                else
                {
                    ret[i] = (object[])arrays[i];
                }

            }
            return ret;
        }

    }
}
