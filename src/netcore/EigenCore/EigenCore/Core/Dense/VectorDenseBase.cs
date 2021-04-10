﻿using System;
using System.Text;
using System.Text.RegularExpressions;

namespace EigenCore.Core.Dense
{
    public class VectorDenseBase<T> : VBufferDense<T>
    {
        protected virtual int MaxElements => 20;

        protected static Random _random = default(Random);

        private static int GeLengthInfo(string valuesString)
        {
            string trimmedLine = Regex.Replace(valuesString, @"\s+", " ").Trim();
            string[] splitline = trimmedLine.Split(" ");
            return splitline.Length;
        }

        private static T[] StringToFlatValues(string valuesString, Func<string, T> parser)
        {
            var length = GeLengthInfo(valuesString);
            var inputValues = new T[length];

            string trimmedLine = Regex.Replace(valuesString, @"\s+", " ").Trim();
            string[] splitline = trimmedLine.Split(" ");;

            for(int index = 0; index < length; index++)
            {
                inputValues[index] = parser(splitline[index]);
            }

            return inputValues;
        }


        public static void SetRandomState(int seed)
        {
            _random = new Random(seed);
        }

        public T Get(int index) => _values[index];

        public T Set(int index, T value) => _values[index] = value;

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(GetType().Name + ", " + Length + ":\n");
            stringBuilder.Append('\n');

            for(int i =0; i<Length; i++)
            {
                if(i > MaxElements)
                {
                    stringBuilder.Append("...");
                    return stringBuilder.ToString().Trim();
                }

                stringBuilder.AppendFormat("{0:G3} ", _values[i]);
            }

            return stringBuilder.ToString().Trim();
        }


        public VectorDenseBase(string valuesString, Func<string, T> parser)
            : base(() => StringToFlatValues(valuesString, parser))
        {
        }

        public VectorDenseBase(T[] values) : base(values)
        {
        }
    }
}
