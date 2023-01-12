using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace gioco_della_tombola
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numero, x, y = 2;
            Random r = new Random();
            bool[] T = new bool[90];
            int V1 = 0, V2 = 0;
            int[,] C1 = new int[9, 3];
            int[,] C2 = new int[9, 3];
            Console.SetCursorPosition(50, 0);
            Console.WriteLine("Tabellone");
            for (int i = 0; i < 9; i++)
            {
                x = 13;
                for (int i2 = 0; i2 < 10; i2++)
                {
                    Console.SetCursorPosition(x, y);
                    Console.Write("0");
                    x += 3;
                }
                y++;
            }
            //richiamo alla funzione per la generazione della prima cartella
            GC1();
            //richiamo alla funzione per la generazione della seconda cartella
            GC2();
            //richiamo alla funzione di stampa della prima cartella
            FC1();
            //richiamo alla funzione di stampa della seconda cartella
            FC2();
            for (int i = 0; i < 90; i++)//ciclo di estrazione e controllo 
            {
                numero = Estrazione();
                x = Fx();
                y = Fy();
                for (int i2 = 0; i2 < 3; i2++)
                {
                    Console.SetCursorPosition(x, y);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(numero);
                    Thread.Sleep(500);
                    Console.SetCursorPosition(x, y);
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine(numero);
                    Thread.Sleep(500);
                }
                //richiamo alla funzione di verifica della presenza dei numeri estratti nella prima cartella
                FV1();
                //richiamo alla funzione di verifica della presenza dei numeri estratti nella seconda cartella
                FV2();
                //richiamo alla funzione di controllo tombola
                ControlT();
                Thread.Sleep(200);
            }
            int Estrazione()
            {
                int Estr;
                do
                {
                    Estr = r.Next(1, 91);
                } while (T[Estr - 1] == true);
                T[Estr - 1] = true;
                return Estr;
            }
            int Fx()
            {
                if (numero / 10 == 0)
                {
                    x = 10 + (numero % 10 * 3);
                }
                else
                {
                    if (numero % 10 != 0)
                    {
                        x = 11 + (numero % 10 * 3 - 1);
                    }
                    else
                    {
                        x = 11 + numero / (numero / 10) * 3 - 1;
                    }
                }
                return x;
            }
            int Fy()
            {
                if (numero / 10 == 0)
                {
                    y = 2;
                }
                else
                {
                    if (numero % 10 != 0)
                    {
                        y = 2 + numero / 10;
                    }
                    else
                    {
                        y = 1 + numero / 10;
                    }
                }
                return y;
            }
            int GC1()
            {
                bool[] Array90 = new bool[90];
                int Valore;
                for (int i = 0; i < 3; i++)
                {
                    bool[] ArrayDecine = new bool[10];
                    for (int i2 = 0; i2 < 5; i2++)
                    {
                        do
                        {
                            Valore = r.Next(1, 91);
                            if (Valore == 90)
                            {
                                i2--;
                            }
                        } while (Array90[Valore - 1] == true || ArrayDecine[Valore / 10] == true);
                        Array90[Valore - 1] = true;
                        ArrayDecine[Valore / 10] = true;
                        if (Valore == 90)
                        {
                            C1[8, i] = 90;
                        }
                        else
                        {
                            C1[Valore / 10, i] = Valore;
                        }
                    }
                    for (int i3 = 0; i3 < 9; i3++)
                    {
                        ArrayDecine[i3] = false;
                    }
                }
                return 0;
            }
            int GC2()
            {

                bool[] Array90 = new bool[90];
                int Valore;
                for (int i = 0; i < 3; i++)
                {
                    bool[] ArrayDecine = new bool[10];
                    for (int i2 = 0; i2 < 5; i2++)
                    {
                        do
                        {
                            Valore = r.Next(1, 91);
                            if (Valore == 90)
                            {
                                i2--;
                            }
                        } while (Array90[Valore - 1] == true || ArrayDecine[Valore / 10] == true);
                        Array90[Valore - 1] = true;
                        ArrayDecine[Valore / 10] = true;
                        if (Valore == 90)
                        {
                            C2[8, i] = 90;
                        }
                        else
                        {
                            C2[Valore / 10, i] = Valore;
                        }
                    }
                    for (int i3 = 0; i3 < 9; i3++)
                    {
                        ArrayDecine[i] = false;
                    }
                }
                return 0;
            }
            void FC1()
            {
                x = 0;
                y = 12;
                Console.SetCursorPosition(x, y);
                Console.WriteLine("Cartella del primo giocatore ");
                y++;//incremento di y 
                for (int i = 0; i < 5; i++)
                {
                    x = 0;
                    y++;
                    if (i % 2 == 1)
                    {
                        Console.SetCursorPosition(x, y);
                        Console.WriteLine("-------------------------");
                    }
                    else
                    {
                        Console.SetCursorPosition(x, y);
                        for (int i2 = 0; i2 < 9; i2++)
                        {
                            if (C1[i2, i / 2 + i % 2] != 0)
                            {
                                Console.Write($"{C1[i2, i / 2 + i % 2]} ");
                            }
                            else
                            {
                                if (i2 == 0)
                                {
                                    Console.Write("  ");
                                }
                                else
                                {
                                    Console.Write("   ");
                                }
                            }
                        }
                        Console.WriteLine();
                    }
                }
            }
            void FC2()
            {
                x = 30;
                y = 12;
                Console.SetCursorPosition(x, y);
                Console.WriteLine("Cartella del secondo giocatore ");
                y++;
                for (int i = 0; i < 5; i++)
                {
                    x = 30;
                    y++;
                    if (i % 2 == 1)
                    {
                        Console.SetCursorPosition(x, y);
                        Console.WriteLine("-------------------------");
                    }
                    else
                    {
                        Console.SetCursorPosition(x, y);
                        for (int i2 = 0; i2 < 9; i2++)
                        {
                            if (C2[i2, i / 2 + i % 2] != 0)
                            {
                                Console.Write($"{C2[i2, i / 2 + i % 2]} ");
                            }
                            else
                            {
                                if (i2 == 0)
                                {
                                    Console.Write("  ");
                                }
                                else
                                {
                                    Console.Write("   ");
                                }
                            }
                        }
                        Console.WriteLine();
                    }
                }
            }
            int FV1()
            {
                x = 0;
                y = 14;
                for (int k = 0; k < 3; k++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        if (C1[j, k] == numero)
                        {
                            if (j == 0)
                            {
                                x = 0;
                            }
                            else
                            {
                                x += j * 3 - 1;
                            }
                            y += k * 2;
                            V1++;
                            Console.SetCursorPosition(x, y);//impostare la posizione a x e y
                            Console.BackgroundColor = ConsoleColor.Green;//impostare il colore dello sfondo a magenta
                            Console.Write(numero);//output del numero con sfondo magenta
                            Console.BackgroundColor = ConsoleColor.Black;//impostare il colore dello sfondo a nero  
                        }
                    }
                }
                return V1;
            }

            int FV2()
            {
                x = 30;
                y = 14;
                for (int k = 0; k < 3; k++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        if (C2[j, k] == numero)
                        {
                            if (j == 0)
                            {
                                x = 30;
                            }
                            else
                            {
                                x += j * 3 - 1;
                            }
                            y += k * 2;
                            V2++;
                            Console.SetCursorPosition(x, y);
                            Console.BackgroundColor = ConsoleColor.Yellow;
                            Console.Write(numero);
                            Console.BackgroundColor = ConsoleColor.Black;

                        }
                    }
                }
                return V2;
            }
            int ControlT()
            {
                if (V1 == 15 && V2 == 15)
                {
                    Console.SetCursorPosition(13, 31);
                    Console.Write("Entrambi i giocatori hanno vinto");
                    Console.SetCursorPosition(0, 0);
                    Environment.Exit(1);
                    return 0;
                }
                else if (V1 == 15)
                {
                    Console.SetCursorPosition(0, 30);
                    Console.Write("Il giocatore 1 ha fatto tombola");
                    Console.SetCursorPosition(0, 0);
                    Environment.Exit(1);
                    return 0;
                }
                else if (V2 == 15)
                {
                    Console.SetCursorPosition(30, 30);
                    Console.Write("Il giocatore 2 ha fatto tombola");
                    Console.SetCursorPosition(0, 0);
                    Environment.Exit(1);
                    return 0;
                }
                return 0;
            }
        }
    }
}






