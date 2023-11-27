// See https://aka.ms/new-console-template for more information

int V1 = 0;
int V2 = 0;
int V3 = 0;
int V4 = 0;
int som = 0;
int sot = 0;
int pro = 0;
int obj = 42;

Console.WriteLine("inserire 4 valori");

V1 = int.Parse(Console.ReadLine());
V2 = int.Parse(Console.ReadLine());
V3 = int.Parse(Console.ReadLine());
V4 = int.Parse(Console.ReadLine());

som = V1 + V2;
sot = V3 - V4;
pro = som * sot;

switch (pro)
{
	case 42:
		Console.WriteLine("il risultato è 42");
		break;
	default:
		Console.WriteLine("il risultato NON è 42");
		break;
}

bool Parita = (pro % 2==0);

Console.WriteLine($"{pro} is {(Parita ? "Pari" : "dispari")}");
