namespace bludotnet
module carta =

    type Rank =
        |As
        |Dois
        |Tres
        |Quatro
        |Cinco
        |Seis
        |Sete
        |Oito
        |Nove
        |Dez
        |Valete
        |Dama
        |Rei

    let valorDoRank rank =
      match rank with
        |As -> 1
        |Dois -> 2
        |Tres -> 3
        |Quatro -> 4
        |Cinco -> 5
        |Seis -> 6
        |Sete -> 7
        |Oito -> 8
        |Nove -> 9
        |Dez -> 10
        |Valete -> 11
        |Dama -> 12
        |Rei -> 13

    type Naipe =
        |Ouros
        |Copas
        |Paus
        |Espadas

    type Carta = { Rank : Rank; Naipe : Naipe }

    let compareCarta carta1 carta2 =
        if (valorDoRank carta1) < (valorDoRank carta2) then -1 
        elif (valorDoRank carta1) > (valorDoRank carta2) then 1
        else 0 

 
    let getRank valor = 
        match valor with
            |1 -> As 
            |2 -> Dois
            |3 -> Tres
            |4 -> Quatro 
            |5 -> Cinco  
            |6 -> Seis  
            |7 -> Sete  
            |8 -> Oito  
            |9 -> Nove  
            |10 -> Dez  
            |11 -> Valete 
            |12 -> Dama  
            |13 -> Rei  
            |_ -> failwith "erro"