using System;
using System.Text;
namespace dev_cs {
    public class Baekjoon_10816 {
        int[] A;
        int[] res;
        int[] chk = new int[20000001];
        public Baekjoon_10816() {
            int n = Convert.ToInt32(Console.ReadLine());
            string[] temp_d = Console.ReadLine().Split(" ");
            A = new int[n];
            for (int i = 0; i < n; i++) {
                A[i] = Convert.ToInt32(temp_d[i]);
            }
           Array.Sort(A);

           int m = Convert.ToInt32(Console.ReadLine());
           res = new int[m];
           temp_d = Console.ReadLine().Split(" ");

           StringBuilder sb = new StringBuilder();
           for (int i = 0; i < m; i++) { // m번 반복해서
               int val = Convert.ToInt32(temp_d[i]);    // B를 배열에 담지는 않고 바로 사용
               if(chk[val + 10000000] != 0) {
                   res[i] = res[chk[val + 10000000]];
               } else {
                   res[i] = FindValue(0, n-1, val); // 값이 없으면 찾아옴
                   chk[val + 10000000] = i; // 그 때의 인덱스
               }
               sb.Append(res[i] + " ");
           }
           Console.WriteLine(sb.ToString());
        }
        // 재귀를 사용하지 않아서인지 전의 방법으론 계속된 시간초과를 유발함 ㅠㅠ
        int FindValue(int left, int right, int val) {
            int value;
            if(left <= right) {
                int mid_value = (left + right) / 2;
                if(val == A[mid_value]) {
                    value = 1;
                    value += FindValue(left, mid_value-1, val); // 재귀를 사용해서 값이 같은 다른 원소 찾기(인덱스 더 작은 쪽)
                    value += FindValue(mid_value + 1, right, val); // 재귀를 사용해서 값이 같은 다른 원소 찾기(인덱스 더 큰 쪽)
                    return value;
                } else {
                    if (val > A[mid_value]) {   // 중간보다 클 때 탐색하기 (+1,-1) 하는 이유는 mid값 포함하지 않기 위해서
                        return FindValue(mid_value+1, right, val);
                    } else if (val < A[mid_value]) {    // 중간보다 작을 때 탐색하기
                        return FindValue(left, mid_value-1, val);
                    }
                }
            }
            return 0;
        }
    }
}