# 493. Reverse Pairs

### Link Questão: [493. Reverse Pairs](https://leetcode.com/problems/reverse-pairs/description/)

#### Nível: Difícil

#### Linguagem utilizada: C#

---

## Resultado Juiz Eletrônico (LeetCode)

<center>

![Resultado](../../assets/accepted_hard_1.png)

![Resultado Detalhado](../../assets/details_hard_1.png)

</center>

## Resumo

- O problema consiste em encontrar o número de Pares Invertidos em um array.

- Um par `(i, j)` é considerado invertido quando: `i é menor que j`, e o valor `array[i] é maior que (2 * array[j])`.

- Tendo isso em mente, é possível utilizar o algoritmo de Contagem de Inversões estudado em sala, juntamente com algumas modificações (o estudado em sala conta as inversões, não os pares), para encontrar a quantidade de pares invertidos.

## Solução

### Arquivo: [493.Reverse_Pairs.cs](./493.Reverse_Pairs.cs)

### Código em C#:

```cs
public class Solution {
    static int Merge(int[] listL, int esq, int meio, int dir)
    {
        int inversoes = 0;
        int k = meio + 1;
        
        for (int i = esq; i <= meio; i++)
        {
            while (k <= dir && listL[i] > (2L * listL[k]))
            {
                k++;
            }
            inversoes += (k - meio - 1);
        }
        
        int tamA = meio - esq + 1;
        int tamB = dir - meio;
        
        int[] tempA = new int[tamA];
        int[] tempB = new int[tamB];
        
        for (int i = 0; i < tamA; i++) tempA[i] = listL[esq + i];

        for (int j = 0; j < tamB; j++) tempB[j] = listL[meio + 1 + j];

        int iEsq = 0, iDir = 0, pos = esq;

        while (iEsq < tamA && iDir < tamB)
        {
            if (tempA[iEsq] <= tempB[iDir])
            {
                listL[pos] = tempA[iEsq];
                iEsq++;
            }
            else
            {
                listL[pos] = tempB[iDir];
                iDir++;
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

        return inversoes;
    }
    
    public static int MergeAndCount(int[] listL, int esq, int dir)
    {
        if (esq >= dir) return 0;

        int meio = esq + (dir - esq) / 2;

        int inversoes = MergeAndCount(listL, esq, meio) + MergeAndCount(listL, meio + 1, dir);

        inversoes += Merge(listL, esq, meio, dir);

        return inversoes;
    }

    public static int SortAndCount(int[] listL)
    {
        if(listL.Length == 1) return 0;
        
        return MergeAndCount(listL, 0, listL.Length - 1);
    }
    
    public int ReversePairs(int[] nums) {
        return Solution.SortAndCount(nums);
    }
}
```