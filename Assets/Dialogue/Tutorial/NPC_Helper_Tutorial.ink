-> main

=== main ===
OH OH!
Finalmente ci incontriamo
La mia voce e' riuscita a guidarti fin qui
Hai bisogno che ti ricordi qualcosa?
    +[Si]
        ->YesAnswer("Si!")
    +[No]
        ->NoAnswer("No")

=== YesAnswer(choice) ===
{choice}
Ricorda ...
W/A/S/D per muoverti
k per interagire
L per lasciare l'oggetto preso
X per visualizzare le informazioni
per raccogliere qualcosa camminaci sopra
per sconfiggere un nemico, cammina vicino con una spada
per aprire una porta, cammina vicino con una chiave
Questo e' tutto, alla prossima!
-> DONE

=== NoAnswer(choice) ===
{choice}
OH OH! 
Mi fa piacere che ti ricordi tutto!
Alla prossima allora!
-> DONE

-> END