using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        // Inizializzazione dei giocatori
        Giocatore giocatore1 = new Giocatore();
        Giocatore giocatore2 = new Giocatore();

        // Numero desiderato di turni
        int numeroTurniDesiderato = 3;

        // Ciclo di gioco
        while (true)
        {
            // Turno del giocatore 1
            Console.WriteLine($"Turno del Giocatore 1 - Risorse: {giocatore1.Risorse}");
            EseguiTurno(giocatore1, giocatore2);

            // Verifica condizioni di vittoria/sconfitta
            if (VerificaFinePartita(giocatore1, giocatore2, numeroTurniDesiderato))
                break;

            // Turno del giocatore 2
            Console.WriteLine($"Turno del Giocatore 2 - Risorse: {giocatore2.Risorse}");
            EseguiTurno(giocatore2, giocatore1);

            // Verifica condizioni di vittoria/sconfitta
            if (VerificaFinePartita(giocatore1, giocatore2, numeroTurniDesiderato))
                break;
        }

        Console.WriteLine("Fine del gioco.");
    }

    static void EseguiTurno(Giocatore giocatoreAttuale, Giocatore avversario)
    {
        // Incrementa il numero di turni del giocatore attuale
        giocatoreAttuale.NumeroTurni++;

        // Mostra opzioni disponibili
        Console.WriteLine("Opzioni: 1. Crea un'unità, 2. Attacca un'unità, 3. Altre azioni");
        int scelta;

        string input = Console.ReadLine();

        if (int.TryParse(input, out scelta))
        {
            switch (scelta)
            {
                case 1:
                    // Crea un'unità
                    Console.WriteLine("Scegli un'unità da creare: 1. Soldato (300 risorse), 2. Arciere (150 risorse), 3. Cavaliere (500 risorse)");
                    int sceltaUnita;

                    string inputUnita = Console.ReadLine();

                    if (int.TryParse(inputUnita, out sceltaUnita))
                    {
                        CreaUnita(giocatoreAttuale, sceltaUnita);
                    }
                    else
                    {
                        Console.WriteLine("Scelta non valida.");
                    }
                    break;
                case 2:
                    // Attacca un'unità
                    AttaccaUnita(giocatoreAttuale, avversario);
                    break;
                case 3:
                    // Altre azioni (puoi implementare ulteriori azioni qui)
                    break;
                default:
                    Console.WriteLine("Scelta non valida.");
                    break;
            }
        }
        else
        {
            Console.WriteLine("Input non valido. Inserisci un numero intero.");
        }

        // Aggiorna lo stato del gioco
        MostraStatoGioco(giocatoreAttuale, avversario);
    }

    static void CreaUnita(Giocatore giocatore, int tipoUnita)
    {
        Unita nuovaUnita = null;

        switch (tipoUnita)
        {
            case 1:
                // Soldato
                nuovaUnita = new Unita { Nome = "Soldato", Costo = 300, Forza = 5 };
                break;
            case 2:
                // Arciere
                nuovaUnita = new Unita { Nome = "Arciere", Costo = 150, Forza = 2 };
                break;
            case 3:
                // Cavaliere
                nuovaUnita = new Unita { Nome = "Cavaliere", Costo = 500, Forza = 10 };
                break;
            default:
                Console.WriteLine("Tipo di unità non valido.");
                return;
        }

        // Verifica se il giocatore ha abbastanza risorse per creare l'unità
        if (nuovaUnita != null && giocatore.Risorse >= nuovaUnita.Costo)
        {
            // Sottrai il costo delle risorse
            giocatore.Risorse -= nuovaUnita.Costo;

            // Aggiungi l'unità alla lista delle unità del giocatore
            giocatore.UnitList.Add(nuovaUnita);

            Console.WriteLine($"Hai creato un {nuovaUnita.Nome}! - Risorse rimanenti: {giocatore.Risorse}");
        }
        else
        {
            Console.WriteLine("Risorse insufficienti per creare questa unità.");
        }
    }

    static void AttaccaUnita(Giocatore attaccante, Giocatore difensore)
    {
        // Verifica se entrambi i giocatori hanno almeno un'unità
        if (attaccante.UnitList.Count > 0 && difensore.UnitList.Count > 0)
        {
            // Trova l'unità con la massima forza nell'attaccante
            Unita unitaAttaccante = attaccante.UnitList.OrderByDescending(u => u.Forza).First();

            // Trova l'unità con la minima forza nel difensore
            Unita unitaDifensore = difensore.UnitList.OrderBy(u => u.Forza).First();

            // Esegui l'attacco
            if (unitaAttaccante.Forza > unitaDifensore.Forza)
            {
                // L'attaccante elimina completamente l'unità difensore
                difensore.UnitList.Remove(unitaDifensore);

                Console.WriteLine($"{unitaAttaccante.Nome} dell'attaccante ha attaccato e eliminato {unitaDifensore.Nome} del difensore!");
            }
            else
            {
                // L'attaccante muore, la forza dell'unità difensore viene dimezzata
                attaccante.UnitList.Remove(unitaAttaccante);
                unitaDifensore.Forza /= 2;

                Console.WriteLine($"{unitaAttaccante.Nome} dell'attaccante ha attaccato, ma è stato eliminato. {unitaDifensore.Nome} del difensore ha la forza dimezzata!");
            }
        }
        else
        {
            Console.WriteLine("Entrambi i giocatori devono avere almeno un'unità per eseguire un attacco.");
        }
    }

    static void MostraStatoGioco(Giocatore giocatore1, Giocatore giocatore2)
    {
        Console.WriteLine("Stato del Gioco:");
        Console.WriteLine($"Giocatore 1 - Risorse: {giocatore1.Risorse}, Unità: {giocatore1.UnitList.Count}, Turni: {giocatore1.NumeroTurni}");
        MostraUnitaGiocatore(giocatore1);

        Console.WriteLine();

        Console.WriteLine($"Giocatore 2 - Risorse: {giocatore2.Risorse}, Unità: {giocatore2.UnitList.Count}, Turni: {giocatore2.NumeroTurni}");
        MostraUnitaGiocatore(giocatore2);

        Console.WriteLine();
    }

    static void MostraUnitaGiocatore(Giocatore giocatore) //non so perche ma le unita si invertono anche se poi alla fine il contegio dei punti va bene, è solo un bug visivo
    {
        Console.WriteLine("Unità:");

        if (giocatore.UnitList.Count == 0)
        {
            Console.WriteLine("Nessuna unità.");
        }
        else
        {
            // Inverti l'ordine delle unità prima di mostrarle
            foreach (var unita in giocatore.UnitList.Reverse<Unita>()) //l'ho aggiunto per provare a risolvere il problema menzionato sopra ma esso rimane
            {
                Console.WriteLine($"- {unita.Nome} (Forza: {unita.Forza}, Costo: {unita.Costo} risorse)");
            }
        }
    }

    static bool VerificaFinePartita(Giocatore giocatore1, Giocatore giocatore2, int numeroTurniDesiderato)
    {
        // Verifica se entrambi i giocatori hanno raggiunto o superato il numero desiderato di turni
        if (giocatore1.NumeroTurni >= numeroTurniDesiderato && giocatore2.NumeroTurni >= numeroTurniDesiderato)
        {
            // Verifica la forza totale degli eserciti per determinare il vincitore
            int forzaTotaleGiocatore1 = CalcolaForzaTotale(giocatore1);
            int forzaTotaleGiocatore2 = CalcolaForzaTotale(giocatore2);

            if (forzaTotaleGiocatore1 > forzaTotaleGiocatore2)
            {
                Console.WriteLine("Il Giocatore 1 ha vinto! Congratulazioni!");
                return true;
            }
            else if (forzaTotaleGiocatore2 > forzaTotaleGiocatore1)
            {
                Console.WriteLine("Il Giocatore 2 ha vinto! Congratulazioni!");
                return true;
            }
            else
            {
                Console.WriteLine("La partita è finita in pareggio, entrambi i giocatori hanno la stessa forza totale.");
                return true;
            }
        }

        return false;
    }

    static int CalcolaForzaTotale(Giocatore giocatore)
    {
        int forzaTotale = 0;
        foreach (var unita in giocatore.UnitList)
        {
            forzaTotale += unita.Forza;
        }
        return forzaTotale;
    }
}

class Giocatore
{
    public int Risorse { get; set; } = 1000;
    public List<Unita> UnitList { get; } = new List<Unita>();
    public int NumeroTurni { get; set; } = 0;
}

class Unita
{
    public string Nome { get; set; } = string.Empty;
    public int Costo { get; set; }
    public int Forza { get; set; }
}
