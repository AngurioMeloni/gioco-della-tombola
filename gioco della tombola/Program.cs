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
            int TabN = 1;
            Random r = new Random();
            bool[] T = new bool[90];
            int[,] tabella = new int[9, 10];
            int[,] C1 = new int[9, 3];
            int[,] C2 = new int[9, 3];
            Console.SetCursorPosition(50, 0);
            Console.WriteLine("Tabellone");
            for (int i = 0; i < 9; i++)
            {
                x = 40;
                for (int i2 = 0; i2 < 10; i2++)
                {
                    Console.SetCursorPosition(x, y);
                    tabella[i, i2] = TabN;
                    Console.Write(tabella[i, i2].ToString("D2") + " ");
                    TabN++;
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
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(numero);
                    Thread.Sleep(250);
                    Console.SetCursorPosition(x, y);
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine(numero);
                    Thread.Sleep(250);
                }
                Thread.Sleep(100);
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
                    x = 40 + (numero % 10 * 3);
                }
                else
                {
                    if (numero % 10 != 0)
                    {
                        x = 38 + (numero % 10 * 3 - 1);
                    }
                    else
                    {
                        x = 38 + numero / (numero / 10) * 3 - 1;
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
                x = 25;
                y = 12;
                Console.SetCursorPosition(24, y);
                Console.WriteLine("Cartella del primo giocatore ");
                y++;//incremento di y 
                for (int i = 0; i < 5; i++)
                {
                    x = 25;
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
                x = 58;
                y = 12;
                Console.SetCursorPosition(56, y);
                Console.WriteLine("Cartella del secondo giocatore ");
                y++;
                for (int i = 0; i < 5; i++)
                {
                    x = 58;
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
        }
    }
}
    
    

   

