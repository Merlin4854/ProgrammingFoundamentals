// See https://aka.ms/new-console-template for more information

int V1  = 0; 
int V2 = 0;

Console.WriteLine("inserire 2 valori");

V1 = int.Parse(Console.ReadLine());
V2 = int.Parse(Console.ReadLine());

int V3 = V2;
V2 = V1;
V1 = V3;//con luso di V3 ho effetuato lo Swap delle due variabili

Console.WriteLine("il valore di V1 adesso è " + V1 + " e il valore di V2 adesso è " + V2);
