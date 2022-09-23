namespace UIConsole.MatchDay
{
    using System;

    public class Program
    {
        public static void Main()
        {
            long[] nextLE = { 6, 8, 0, 1, 3 };
            Console.WriteLine("Next Larger Element");
            nextLargerElement(nextLE, 5);
        }

        public static long[] nextLargerElement(long[] arr, int n)
        {
            //Your code here
            long[] _arr = arr;
            long[] _nextLargerElement = new long[n];
            //int arrcount = 0;
            long nextBig = 0;

            for (int i = 0; i < _arr.Length; i++)
            {
                Console.WriteLine("Round:" + i);
                for (int j = i + 1; j < _arr.Length; j++)
                {
                    if (_arr[j] > _arr[i])
                    {
                        nextBig = _arr[j];
                        _nextLargerElement[i] = nextBig;
                        break;
                    }
                    else
                    {
                        nextBig = -1;
                        _nextLargerElement[i] = nextBig;
                    }
                    Console.WriteLine(_arr[i] + " : " + _arr[j] + " : " + nextBig);

                    //arrcount++;
                }
            }
            foreach (var item in _nextLargerElement)
            {
                Console.WriteLine("Item: " + item);
            }

            return _nextLargerElement;
        }

        public long[] nextLargerElement2(long[] arr, int n)
        {
            //Your code here
            long[] _arr = arr;
            List<long> _arr2 = arr.ToList<long>();

            long[] _nextLargerElement = new long[n];
            long nextBig = 0;

            for (int i = 0; i < _arr.Length; i++)
            {
                for (int j = i + 1; j < _arr2.Count; j++)
                {
                    if (_arr[j] > _arr[i])
                    {
                        nextBig = _arr[j];
                        _nextLargerElement[i] = nextBig;
                        break;
                    }
                    else
                    {
                        nextBig = -1;
                        _nextLargerElement[i] = nextBig;
                    }
                }
            }
            return _nextLargerElement;
        }


        public static long[] nextLargerElement3(long[] arr, int n)
        {
            //Your code here
            long[] _arr = arr;
            var _arr2 = new ArraySegment<long>(arr, 1, n - 1);
            long[] _nextLargerElement = new long[n];
            int arrCount = 1;

            for (int i = 0; i < _arr.Length; i++)
            {
                Console.WriteLine("Round:" + i);
                foreach (long exibitB in _arr2)
                {
                    if (exibitB > _arr[i])
                    {
                        _nextLargerElement[i] = exibitB;
                        break;
                    }
                    else
                    {
                        _nextLargerElement[i] = -1;
                    }
                    Console.WriteLine(_arr[i] + " : " + exibitB);
                }
                arrCount++;
            }
            foreach (var item in _nextLargerElement)
            {
                Console.WriteLine("Item: " + item);
            }

            return _nextLargerElement;
        }

        public static long[] nextLargerElement4(long[] arr, int n)
        {
            //Your code here
            long[] _arr = arr;
            var _arr2 = new ArraySegment<long>(_arr, 1, n - 1);
            long[] _nextLargerElement = new long[n];
            int arrCount = 0;
            foreach (var item in _arr2)
            {
                Console.Write(item + ", ");
            }

            for (int i = 0; i < _arr.Length; i++)
            {
                Console.WriteLine("Round:" + i);
                for (int j = _arr2.Offset + arrCount; j < _arr2.Count + 1; j++)
                {
                    Console.WriteLine("Check:" + _arr[i] + " against " + _arr2.Array[j]);
                    if (_arr2.Array[j] > _arr[i])
                    {
                        _nextLargerElement[i] = _arr2.Array[j];
                        Console.WriteLine("Write:" + _arr2.Array[j]);
                        break;
                    }
                    else
                    {
                        _nextLargerElement[i] = -1;
                        Console.WriteLine("Write: -1");
                    }
                }
                arrCount++;
            }
            foreach (var item in _nextLargerElement)
            {
                Console.WriteLine("Item: " + item);
            }

            return _nextLargerElement;
        }

        public static long[] nextLargerElement5(long[] arr, int n)
        {
            //Your code here
            long[] _arr = arr;
            var _arr2 = new ArraySegment<long>(_arr, 1, n - 1);
            long[] _nextLargerElement = new long[n];
            int arrCount = 0;
            foreach (var item in _arr2)
            {
                Console.Write(item + ", ");
            }

            for (int i = 0; i < _arr.Length; i++)
            {
                Console.WriteLine("\nRound:" + i);
                Console.WriteLine("\nStart :" + arrCount);
                if (i >= n - 1)
                {
                    _nextLargerElement[i] = -1;
                    Console.WriteLine("End of Array");
                    break;
                }
                Array.ForEach<long>(_arr, h => Console.WriteLine(h));

                for (int j = _arr2.Offset + arrCount; j < _arr2.Count + 1; j++)
                {
                    Console.Write("Check:" + _arr[i] + " against " + _arr2.Array[j]);

                    if (_arr2.Array[j] > _arr[i])
                    {
                        _nextLargerElement[i] = _arr2.Array[j];
                        Console.Write(" Write:" + _arr2.Array[j] + "\n");
                        break;
                    }
                    else
                    {
                        _nextLargerElement[i] = -1;
                        Console.Write(" No:" + _nextLargerElement[i] + "\n");
                    }
                }
                arrCount++;
                Console.WriteLine("End:" + arrCount);
            }
            foreach (var item in _nextLargerElement)
            {
                Console.WriteLine("Item: " + item);
            }

            return _nextLargerElement;
        }
    }

    public static class Extensions
    {
        /// <summary>
        /// Get the array slice between the two indexes.
        /// ... Inclusive for start index, exclusive for end index.
        /// </summary>
        public static T[] Slice<T>(this T[] source, int start, int end)
        {
            // Handles negative ends.
            if (end < 0)
            {
                end = source.Length + end;
            }
            int len = end - start;

            // Return new array.
            T[] res = new T[len];
            for (int i = 0; i < len; i++)
            {
                res[i] = source[i + start];
            }
            return res;
        }
    }
}

