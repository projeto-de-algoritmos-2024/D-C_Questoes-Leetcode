// Sort-and-Count(L) {
//     if list L has one element
//     return 0 and the list L
//
//     Divide the list into two halves A and B
//         (rA, A) <- Sort-and-Count(A)
//         (rB, B) <- Sort-and-Count(B)
//         (rB, L) <- Merge-and-Count(A, B)
//     return r = rA + rB + r and the sorted list L
// }

public class Solution {
    static void Merge(int[] listL, int esq, int meio, int dir)
    {
        int tamA = meio - esq + 1;
        int tamB = dir - meio;
        
        int[] tempA = new int[tamA];
        int[] tempB = new int[tamB];
        
        for (int i = 0; i < tamA; i++) tempA[i] = listL[esq + i];

        for (int j = 0; j < tamB; j++) tempB[j] = listL[meio + 1 + j];

        int iEsq = 0, iDir = 0, pos = esq;

        while (iEsq < tamA && iDir < tamB)
        {
            if (tempA[iEsq] > tempB[iDir])
            {
                listL[pos] = tempB[iDir];
                iDir++;
            }
            else
            {
                listL[pos] = tempA[iEsq];
                iEsq++;
            }
            pos++;
        }
        
        while (iEsq < tamA)
        {
            listL[pos] = tempA[iEsq];
            iEsq++;
            pos++;
        }
        
        while (iDir < tamB)
        {
            listL[pos] = tempB[iDir];
            iDir++;
            pos++;
        }
    }
    
    public static void MergeAndCount(int[] listL, int esq, int dir)
    {
        if (esq >= dir) return 0;

        int meio = esq + (dir - esq) / 2;

        MergeAndCount(listL, esq, meio);
        MergeAndCount(listL, meio + 1, dir);

        Merge(listL, esq, meio, dir);
    }
}

class Program
{
    static void Main(string[] args)
    {
        int[] array = [1,3,2,3,1];

        Console.WriteLine("Array original:");
        Console.WriteLine(string.Join(" ", array));

        Console.WriteLine("\nArray ordenado:");
        Console.WriteLine(string.Join(" ", array));
    }
}