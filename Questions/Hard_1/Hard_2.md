# 315. Count of Smaller Numbers After Self

### Link Questão: [315. Count of Smaller Numbers After Self](https://leetcode.com/problems/count-of-smaller-numbers-after-self/description/)

#### Nível: Difícil

#### Linguagem utilizada: Java

---

## Resultado Juiz Eletrônico (LeetCode)



## Resumo

- O problema consiste em encontrar a quantidade de números menores que ele mesmo do lado direito.

- Dado um array inteiro `nums`, retorne um array inteiro `counts` onde `counts[i]` é o número de elementos menores à direita de `nums[i]`.

- A resolução utiliza o algoritmo de contagem de inversões, uma modificação do Merge Sort que, além de ordenar o vetor, calcula quantos elementos menores existem à direita de cada posição no vetor original. Para isso, o algoritmo armazena a posição original de cada elemento e atualiza a contagem de elementos menores durante o processo de mesclagem. Assim, cada elemento mantém sua posição e quantidade de inversões mesmo após o vetor ser ordenado, permitindo obter o resultado desejado de forma eficiente.

## Solução

### Arquivo: [315. Count of Smaller Numbers After Self](./315.Count_of_Smaller_Numbers_After_Self.java)

### Código em Java:

