# 
De nieuwe DEV challenge!
Deze keer gaat het om en programma die in staat is speciale priem getallen op te sporen:
        Write a program that takes L and R as input and displays the number of prime numbers that lie between L and R (L and R inclusive) and can be represented as sum of two consecutive prime numbers + 1.
        Example:
        Case 1:
            For the input provided as follows:
            1 20
            Output of the program will be:
            2
        Explanation
            13 is a prime number which can be expressed like 5+7+1.
            19 is a prime number which can be expressed like 7+11+1.
            So output is {13,19}.
            Note that 5 and 7 are consecutive primes. Similarly 7 and 11 are consecutive primes.
        Case 2:
            For the input provided as follows:
            1 10
            Output of the program will be:
            0
        Explanation
            No prime numbers lie between 1 and 10 that can be represented as sum of two consecutive prime numbers + 1, hence 0 is displayed.

De oplossing dient uiteraard te voldoen aan het bovenstaande. Om echter onderling verglijk makkelijk mogelijk te maken hierbij nog wat additionele spelregels:
    Code dient te worden geschreven in C#.
    De echte solver dient in een losse library te zitten.
        De library dient een .NET Standard 2.1 library te zijn.
    De library moet de volgende public method bevatten 
        public static List<int> Solve(int L, int R) --> Hierbij dient de set aan correcte oplossingen als output gegeven te worden ter onderlinge verificatie/verglijking.
    Het uiteindelijke doel is om zo snel als mogelijk tot een (correct) antwoord te komen.
    Je mag zo vaak een antwoord opsturen als je zelf wil. Ik houdt de tijden bij van elke gegeven oplossing en zet deze op een plek waar iedereen aan kan komen.
Code aub inleveren bij mij en voor vragen kan je uiteraard ook bij mij aankloppen.
Kleine aanpassing in de beschrijving met betrekking tot het 1e voorbeeld. Deze is iets aangepast om netjes in lijn te zijn met de extra spelregels die we intern hanteren.