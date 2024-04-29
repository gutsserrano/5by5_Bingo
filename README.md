# Bingo

Este jogo de Bingo é um trabalho realizado pela **5by5 Soluções de Software**.

### Regras:

- As cartelas possuem 25 números escritos em ordem aleatória.
- Os números sorteados vão de 1 a 99.
- Se algum jogador completar uma linha, a pontuação para todos passa a valer somente a coluna de qualquer cartela e vice-versa.
- A partir daí, só vale a pontuação de cartela cheia.
- Os sorteios devem acontecer até algum jogador completar a cartela (*BINGO!*).
- Há 3 possibilidades de pontuação:
  - Ao completar uma linha, o jogador recebe 1 ponto.
  - Ao completar uma coluna, o jogador recebe 1 ponto.
  - Ao completar a cartela, o jogador recebe 5 pontos.
- Cada jogador pode ter mais de uma cartela.
- O jogo deve ser capaz de ser jogado por mais de 2 jogadores, onde o usuário informa no início do programa a quantidade de jogadores que ele deseja.

### Lógica de Implementação:

Para a produção deste jogo, pudemos usar apenas os conceitos ensinados até o momento, que consistem em laços de repetição, estruturas condicionais, funções e programação estruturada.

A lógica que eu e alguns colegas de sala desenvolvemos consiste em 3 vetores principais, nos quais os outros se baseiam:

1. **cardsQuantity**: Armazena a quantidade de cartelas que cada jogador terá, onde o índice da tabela representa o jogador (i = 0 = P0, i = 2 = P2, ...).
2. **gameCards**: Armazena todas as cartelas do jogo. Por isso, seu tamanho consiste na soma de todos os valores do "cardsQuantity".
3. **playerReferences**: Armazena o índice do jogador que corresponde à matriz no índice do vetor. Sendo assim, "playerReferences" possui o mesmo tamanho do "gameCards" e seus índices correspondem à mesma pessoa, pois o valor armazenado no "playerReferences" é a pessoa.

Desta forma, tendo um vetor que possui os índices das matrizes e o jogador responsável por esta matriz, fica fácil criar outros vetores que utilizam seu índice como relação do jogador. No caso, existem o "playersPoints" e o "playersNames", que são vetores que armazenam os pontos e os nomes, respectivamente. E seus índices correspondem ao jogador armazenado no "playerReferences".

![autodraw 28_04_2024](https://github.com/gutsserrano/5by5_Bingo/assets/64173743/cb05d458-2030-4e84-9868-971fa999030d)

### Relações:

- **"cardsQuantity" -> "gameCards"**
- **"cardsQuantity" -> "playerReferences"**
- **"playerReferences" -> "playersPoints"**
- **"playerReferences" -> "playersNames"**

"*->*" = cria

## Jogo em Funcionamento

![image](https://github.com/gutsserrano/5by5_Bingo/assets/64173743/4af16e81-d7fe-481d-b2cf-3c1a2473175e)

# Bingo Game (English)

This Bingo game is a project developed by **5by5 Software Solutions**.

### Rules:

- The cards have 25 numbers written in random order.
- The numbers drawn range from 1 to 99.
- If any player completes a line, the score for everyone becomes only the column of any card and vice versa.
- From then on, only the score of a full card counts.
- Draws must continue until a player completes the card (*BINGO!*).
- There are 3 scoring possibilities:
  - Completing a line earns the player 1 point.
  - Completing a column earns the player 1 point.
  - Completing the card earns the player 5 points.
- Each player can have more than one card.
- The game must be able to be played by more than 2 players, where the user informs at the beginning of the program the quantity of players they desire.

### Implementation Logic:

For the production of this game, we could only use the concepts taught so far, which consist of loops, conditional structures, functions, and structured programming.

The logic that my classmates and I developed consists of 3 main vectors, on which the others are based:

1. **cardsQuantity**: Stores the quantity of cards each player will have, where the index of the table represents the player (i = 0 = P0, i = 2 = P2, ...).
2. **gameCards**: Stores all the game's cards. Therefore, its size consists of the sum of all the values of "cardsQuantity".
3. **playerReferences**: Stores the index of the player that corresponds to the matrix in the index of the vector. Thus, "playerReferences" has the same size as "gameCards" and its indices correspond to the same person, as the value stored in "playerReferences" is the person.

Thus, having a vector that has the indices of the matrices and the player responsible for this matrix, it becomes easy to create other vectors that use its index as the player's relationship. In this case, there are "playersPoints" and "playersNames", which are vectors that store the points and names, respectively. And their indices correspond to the player stored in "playerReferences".

(**the image is in the Portuguese version above**)

### Relationships:

- **"cardsQuantity" -> "gameCards"**
- **"cardsQuantity" -> "playerReferences"**
- **"playerReferences" -> "playersPoints"**
- **"playerReferences" -> "playersNames"**

"*->*" = creates

(**the gameplay image is in the Portuguese version above**)
