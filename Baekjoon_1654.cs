using System;
namespace dev_cs {
    public class Baekjoon_1654 {
        
        public Baekjoon_1654() {
            string[] temp_a = Console.ReadLine().Split(" ");
            int n = Convert.ToInt32(temp_a[0]);
            long need = Convert.ToInt64(temp_a[1]);
            long[] a = new long[n];
            for(long i = 0; i < n; i++) {
                a[i] = Convert.ToInt64(Console.ReadLine());
            }
            Array.Sort(a);
            long size = a.Length;
            long right = a[size-1];
            long left = 1;
            long mid, res = 0;
            while(right - left >= 0) {
                mid = (left+right)/2;

                long count = 0;
                for (int i =0; i < size; i++) {
                    count += a[i] / mid;
                }
                if (count < need)
                {
                    right = mid - 1;
                } else if (count >= need)
                {
                    if(res < mid) {
                        res = mid;
                    }
                    left = mid + 1;
                }
            }
            Console.WriteLine(res);
        }

    }
}