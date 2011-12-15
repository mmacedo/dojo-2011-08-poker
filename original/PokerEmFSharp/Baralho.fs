namespace bludotnet
module baralho=
    type Baralho() = 
        let mutable _d : Carta list = Nil
        
        member x.Inicializa() =
            let lista = List.map (fun n -> { Rank = (getRank n); Naipe = Copas }) [1..13]
            let naipes = [carta.Copas; 
                          carta.Espadas; 
                          carta.Ouros; 
                          carta.Paus]
            for c = 0 to 12 do
                for n = 0 to 3 do
                    let carta = {Rank = (getRank c); 
                                 Naipe = naipes.[n]}
                    _d <- carta :: _d

        
        