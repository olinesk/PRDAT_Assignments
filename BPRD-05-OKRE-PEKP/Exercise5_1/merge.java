package Exercise5_1;

import java.util.*;

public class merge{

    public static int[] mergesort(int[] xs, int[] ys)
    {
        int[] result = new int[xs.length + ys.length];

        System.arraycopy(xs, 0, result, 0, xs.length);
        System.arraycopy(ys, 0, result, xs.length, ys.length);

        Arrays.sort(result);

        return result;
    }

    public static void main(String[] args) {
        int[] xs = {3, 5, 12};
        int[] ys = {2, 3, 4, 7};

        int[] sorted = merge.mergesort(xs, ys);

        System.out.println(Arrays.toString(sorted));
    }
}