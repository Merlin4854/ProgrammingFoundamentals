
int Voto = 0;
Console.WriteLine("inserire il voto");
string Grade = Console.ReadLine(); //se inserisco delle lettere non funziona, numeri con virgola
if (int.TryParse(Grade, out Voto))
{
    Console.WriteLine("Inserire SOLO input numerici");
    return;
}

if (Voto >= 0 && Voto <=100)
{
    if (Voto >= 90)
    {
        Console.WriteLine("Eccellente");
    }
    else if (Voto >= 70 && Voto <= 89)
    {
         Console.WriteLine("Buono");
    }
    else if (Voto >= 50 && Voto <= 69)
    {
         Console.WriteLine("Sufficiente");
    }
    else
    {
        Console.WriteLine("insufficiente");
    }
}
else
{
    Console.WriteLine("Valore inserito NON valido");
}

