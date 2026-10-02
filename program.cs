====================================================
Assignment 10
====================================================


----------------------------------------------------
Q1: Optimized Bubble Sort
----------------------------------------------------
// idea: stop early if a full pass makes no swaps (already sorted)
// this turns the best case from O(n^2) into O(n)

static void OptimizedBubbleSort(int[] arr)
{
    int n = arr.Length;

    for (int i = 0; i < n - 1; i++)
    {
        bool swapped = false;

        for (int j = 0; j < n - i - 1; j++)
        {
            if (arr[j] > arr[j + 1])
            {
                (arr[j], arr[j + 1]) = (arr[j + 1], arr[j]);
                swapped = true;
            }
        }

        if (!swapped)
            break; // no swaps happened -> array is already sorted
    }
}


----------------------------------------------------
Q2: Generic Range<T> class
----------------------------------------------------
using System;

class Range<T> where T : IComparable<T>
{
    private T min;
    private T max;

    public Range(T min, T max)
    {
        this.min = min;
        this.max = max;
    }

    public bool IsInRange(T value)
    {
        return value.CompareTo(min) >= 0 && value.CompareTo(max) <= 0;
    }

    public dynamic Length()
    {
        // dynamic used here so this works with numeric types like int, double, etc.
        dynamic maxVal = max;
        dynamic minVal = min;
        return maxVal - minVal;
    }
}

// usage:
// Range<int> r = new Range<int>(5, 20);
// Console.WriteLine(r.IsInRange(10)); // true
// Console.WriteLine(r.Length());      // 15


----------------------------------------------------
Q3: Reverse an ArrayList in-place (no built-in Reverse)
----------------------------------------------------
using System.Collections;

static void ReverseArrayList(ArrayList list)
{
    int left = 0;
    int right = list.Count - 1;

    while (left < right)
    {
        object temp = list[left];
        list[left] = list[right];
        list[right] = temp;

        left++;
        right--;
    }
}


----------------------------------------------------
Q4: Return a new list with only even numbers
----------------------------------------------------
using System.Collections.Generic;

static List<int> GetEvenNumbers(List<int> numbers)
{
    List<int> evens = new List<int>();

    foreach (int n in numbers)
    {
        if (n % 2 == 0)
            evens.Add(n);
    }

    return evens;
}


----------------------------------------------------
Q5: FixedSizeList<T>
----------------------------------------------------
using System;

class FixedSizeList<T>
{
    private T[] items;
    private int count;

    public FixedSizeList(int capacity)
    {
        items = new T[capacity];
        count = 0;
    }

    public void Add(T item)
    {
        if (count >= items.Length)
            throw new InvalidOperationException("List is full, cannot add more elements.");

        items[count] = item;
        count++;
    }

    public T Get(int index)
    {
        if (index < 0 || index >= count)
            throw new IndexOutOfRangeException("Invalid index.");

        return items[index];
    }
}


----------------------------------------------------
Q6: First non-repeated character (index) in a string
----------------------------------------------------
using System.Collections.Generic;

static int FirstNonRepeatedCharIndex(string s)
{
    Dictionary<char, int> charCount = new Dictionary<char, int>();

    foreach (char c in s)
    {
        if (charCount.ContainsKey(c))
            charCount[c]++;
        else
            charCount[c] = 1;
    }

    for (int i = 0; i < s.Length; i++)
    {
        if (charCount[s[i]] == 1)
            return i;
    }

    return -1; // no non-repeated character found
}
