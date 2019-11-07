using System;
using System.Text;
namespace dev_cs {
    public class Backjoon_1920 {
        public Backjoon_1920() {
            int n = Convert.ToInt32(Console.ReadLine());
            string[] temp_a = Console.ReadLine().Split(" ");
            int[] A = new int[n];
            
            for (int i = 0; i < n; i++) {
                A[i] = Convert.ToInt32(temp_a[i]);
            }
            int m = Convert.ToInt32(Console.ReadLine());
            string[] temp_b = Console.ReadLine().Split(" ");
            int[] B = new int[m];
            for (int i = 0; i < m; i++) {
                B[i] = Convert.ToInt32(temp_b[i]);
            }
            Array.Sort(A);
            bool flag = false;
            int left = 0;
            int right = n-1;    
            int mid = (left + right) / 2;
            StringBuilder sb = new StringBuilder();
            for(int i = 0; i < m; i++) {// 필수
                while(right-left >= 0) {// 이걸 줄이자
                    if(A[mid] == B[i]) {
                        sb.Append(1+"\n");
                        flag = true;
                        break;
                    }
                    if (B[i] < A[mid]) {
                        right = mid-1;
                    } else if (B[i] > A[mid]) {
                        left = mid+1;
                    }
                    mid = (left+right)/2;
                }
                if(!flag) {
                    sb.Append(0+"\n");
                }
                flag = false;
                left = 0;
                right = n-1;
                mid = (left+right)/2;
            }
            Console.WriteLine(sb.ToString());
        }
    }
}