﻿namespace Lab_3
{
    /// <summary>
    /// Класс проверки типов данных.
    /// </summary>
    public static class TypeChecker
    {
        /// <summary>
        /// Метод, проверяющий тип данных на целочисленность.
        /// </summary>
        /// <param name="type">Проверяемый тип данных.</param>
        /// <returns></returns>
        public static bool IsIntegerType(Type type)
        {
            return
                type == typeof(sbyte) ||
                type == typeof(byte) ||
                type == typeof(short) ||
                type == typeof(ushort) ||
                type == typeof(int) ||
                type == typeof(uint) ||
                type == typeof(long) ||
                type == typeof(ulong);
        }

        /// <summary>
        /// Метод, проверяющий, является ли тип данных числовым.
        /// </summary>
        /// <param name="type">Проверяемый тип данных.</param>
        /// <returns></returns>
        public static bool IsNumericType(Type type)
        {
            return type.IsPrimitive && (
                type == typeof(byte) ||
                type == typeof(sbyte) ||
                type == typeof(short) ||
                type == typeof(ushort) ||
                type == typeof(int) ||
                type == typeof(uint) ||
                type == typeof(long) ||
                type == typeof(ulong) ||
                type == typeof(float) ||
                type == typeof(double) ||
                type == typeof(decimal)
            );
        }
    }
}
