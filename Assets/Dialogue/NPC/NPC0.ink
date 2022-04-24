-> main

=== main ===
...
Che cosa dici?
    +[Ciao?]
        ->chosen("Ciao?")
    +[Che cosa ci fai qui?]
        ->chosen("Che cosa ci fai qui?")
    +[...]
        -> chosen("...")
        
=== chosen(sentence) ===
{sentence}
...
-> END
    
