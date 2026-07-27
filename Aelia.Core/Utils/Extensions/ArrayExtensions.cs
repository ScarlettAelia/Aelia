using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using System.Text;

namespace Aelia.Core.Utils.Extensions;

public static class ArrayExtensions
{
    /// <summary>
    /// Checks if a <see cref="IEnumerable"/> is null or empty
    /// </summary>
    /// <typeparam name="T">Arbitrary type</typeparam>
    /// <param name="objects">Collection to test</param>
    /// <returns><b>true</b> if <paramref name="objects"/> is null or length is 0</returns>
    public static bool IsNullOrEmpty<T>([NotNullWhen(false)] this IEnumerable<T> objects)
    {
        return objects == null || !objects.Any();
    }

    /// <summary>
    /// Remove items from a array of type T at indicies
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="array"></param>
    /// <param name="removeAt"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    public static T[] RemoveItemsAt<T>(this T[] array, int[] removeAt)
    {
        int[] removeAtHash = [.. removeAt.Distinct().Order()];

        // MAYDO: allow for negative indicies to mean "work backwards"?
        if (removeAtHash.Any(i => i < 0)) throw new ArgumentException("Cannot remove at indicies that don't exist");
        if (removeAtHash.IsNullOrEmpty()) return array;
        if (removeAtHash.Max() > array.Length) Debug.WriteLine("One or more requested indexes are out of range for the input array");
        

        int newLength = array.Length - removeAtHash.Length;

        T[] newArray = new T[newLength];

        int rm = 0;
        int i = 0;
        int j = 0;

        while (i < array.Length)
        {
            // if index is not in the remove list, add it to output
            if (i != removeAtHash[rm] && i < newLength)
            {
                newArray[j] = array[i];
                j++;
            }
            // otherwise add one to the remove array index
            else
            {
                rm++;
            }
            i++;
        }

        return newArray;
    }
    public static T[] RemoveItemsAt<T>(this T[] array, int removeAt) => RemoveItemsAt(array, [removeAt]);

    public static void ResizeToLarger<T, S>(ref T[] array1, ref S[] array2)
    {
        if (array1.Length == array2.Length) return;

        if (array1.Length > array2.Length)
            Array.Resize(ref array2, array1.Length);
        else
            Array.Resize(ref array1, array2.Length);
    }

    #region Operators

    public static T[] Add<T, S>(this T[] left, S[] right, bool requireSameSizeArray = true) where T : IAdditionOperators<T, S, T>
    {
        if (left.Length != right.Length)
        {
            if (requireSameSizeArray)
                throw new ArgumentException();
            else
                ResizeToLarger(ref left, ref right);
        }

        T[] output = new T[left.Length];

        for (int i = 0; i < left.Length; i++)
        {
            output[i] = left[i] + right[i];
        }

        return output;
    }

    public static T[] Subtract<T, S>(this T[] left, S[] right, bool requireSameSizeArray = true) where T : ISubtractionOperators<T, S, T>
    {
        if (left.Length != right.Length)
        {
            if (requireSameSizeArray)
                throw new ArgumentException();
            else
                ResizeToLarger(ref left, ref right);
        }

        T[] output = new T[left.Length];

        for (int i = 0; i < left.Length; i++)
        {
            output[i] = left[i] - right[i];
        }

        return output;
    }

    public static T[] Multiply<T, S>(this T[] left, S[] right, bool requireSameSizeArray = true) where T : IMultiplyOperators<T, S, T>
    {
        if (left.Length != right.Length)
        {
            if (requireSameSizeArray)
                throw new ArgumentException();
            else
                ResizeToLarger(ref left, ref right);
        }

        T[] output = new T[left.Length];

        for (int i = 0; i < left.Length; i++)
        {
            output[i] = left[i] * right[i];
        }

        return output;
    }

    public static T[] Divide<T, S>(this T[] left, S[] right, bool requireSameSizeArray = true) where T : IDivisionOperators<T, S, T>
    {
        if (left.Length != right.Length)
        {
            if (requireSameSizeArray)
                throw new ArgumentException();
            else
                ResizeToLarger(ref left, ref right);
        }

        T[] output = new T[left.Length];

        for (int i = 0; i < left.Length; i++)
        {
            output[i] = left[i] / right[i];
        }

        return output;
    }

    #endregion Operators
}
