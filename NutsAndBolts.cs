using System.Collections;
using System;

public class NutsAndBolts : IEnumerable
{
    public static void Main(string[] args)
    {
        int[] nuts = {1, 4, -12, 5, 9, 3, 18, -3};
        int[] bolts = {-3, 1, 4, -12, 18, 3, 9, 5};

        NutsAndBolts nutsAndBolts = new NutsAndBolts(nuts, bolts);

        Console.WriteLine("Original pairs:");
        foreach (var @out in nutsAndBolts)
        {
            Console.WriteLine(@out);
        }

        nutsAndBolts.Sort();
        
        Console.WriteLine("Sorted pairs:");
        foreach (var @out in nutsAndBolts)
        {
            Console.WriteLine(@out);
        }
    }
    
    private readonly int[] _nuts;
    private readonly int[] _bolts;

    public NutsAndBolts(int[] nuts, int[] bolts)
    {
        _nuts = nuts;
        _bolts = bolts;
    }

    public void Sort(){
        MatchNutsAndBolts(_nuts, _bolts, 0, _nuts.Length - 1);
    }

    private static void MatchNutsAndBolts(int[] nuts, int[] bolts, int lo, int hi)
    {
        if (lo >= hi) return;

        int nutPosition = Partition(nuts, lo, hi, bolts[hi]);
        int boltPosition = Partition(bolts, lo, hi, nuts[nutPosition]);
        //nutPosition == boltPosition

        MatchNutsAndBolts(nuts, bolts, lo, nutPosition - 1);
        MatchNutsAndBolts(nuts, bolts, nutPosition + 1, hi);
    }

    private static int Partition(int[] array, int lo, int hi, int element)
    {
        int i = lo, j = hi;
        while (true)
        {
            while (array[i] < element)
            {
                i++;
                if (i == hi) break;
            }
            while (array[j] > element)
            {
                j--;
                if (j == lo) break;
            }
            if (i >= j) break;
            Exchange(array, i, j);
        }
        return j;
    }

    private static void Exchange(int[] array, int i, int j)
    {
        int tmp = array[i];
        array[i] = array[j];
        array[j] = tmp;
    }

    public IEnumerator GetEnumerator()
    {
        int n = 0;
        while (n < _nuts.Length)
        {
            yield return $"{_nuts[n]} -> {_bolts[n]}";
            n++;
        }
    }
}