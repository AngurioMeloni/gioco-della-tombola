using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gioco_della_tombola
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //dichiarazioni delle variabili per la dimensione delle cartelle e del tabellone
            int TabRow = 9, TabColumn = 10;
            int TabN = 1;
            int CartRow = 3, CartColumn = 9;
            //dichiarazione delle variabili per il posizionamento del tabellone e cartelle
            int xT = 40, yT = 1, xC1 = 20, yC1 = 13, xC2 = 76, yC2 = 13;
            //dichiarazione delle matrici
            int[,] tabella = new int[TabRow, TabColumn];
            int[,] C1 = new int[CartColumn, CartRow];
            int[,] C2 = new int[CartRow, CartColumn];
            //richiamo della funzione per la tabella
            Tabella();
            //richiamo alla funzione di caricamento della prima tabella
            GC1();
            //richiamo delle funzione di stampa per la prima cartella
            FC1();
            //richiamo delle funzione di stampa per la seconda cartella
            FC2();
            //richiamo della funzione di estrazione
            Es();
            Console.ReadKey();
            //funzione della stampa della tabella
            void Tabella()
            {
                Console.SetCursorPosition(50, 0);
                Console.WriteLine("Tabellone");
                for (int i = 0; i < TabRow; i++)
                {
                    Console.WriteLine();
                    Console.SetCursorPosition(xT, yT);
                    for (int i2 = 0; i2 < TabColumn; i2++)
                    {
                        tabella[i, i2] = TabN;
                        Console.Write(tabella[i, i2].ToString("D2") + " ");
                        TabN++;
                    }
                    yT++;
                }
            }
            int GC1()
            {
                int numero;
                Random r = new Random();
                bool[] t = new bool[90];
                for (int a = 0; a < 3; a++)
                {
                    bool[] arrayD = new bool[10];
                    for (int a2 = 0; a2 < 5; a2++)
                    {
                        do
                        {
                            numero = r.Next(1, 91);
                            if (numero == 90)
                            {
                                a2--;

                            }

                        } while (t[numero - 1] == true || arrayD[numero / 10] == true);
                        t[numero - 1] = true;
                        arrayD[numero / 10] = true;
                        if (numero == 90)
                        {
                            C1[8, a] = 90;
                        }
                        else
                        {
                            C1[numero / 10, a] = numero;
                        }
                        for (int b = 0; b < CartColumn; b++)
                        {
                            arrayD[b] = false;
                        }

                    }
                }
                return 0;
            }
            void FC1()
            {
                Console.SetCursorPosition(xC1, yC1);
                Console.WriteLine("Cartella del primo giocatore");
                yC1++;
                for (int i = 0; i < 5; i++)
                {
                    xC1 = 0;
                    yC1++;
                    if (i % 2 == 1)
                    {
                        Console.SetCursorPosition(xC1, yC1);
                        Console.WriteLine("------------------------------");
                    }
                    else
                    {
                        Console.SetCursorPosition(xC1, yC1);
                        for (int i2 = 0; i2 < CartColumn; i2++)
                        {
                            if (C1[i2, i / 2 + i % 2] != 0)
                            {
                                Console.Write(C1[i2, i / 2 + i % 2]);
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
                Console.SetCursorPosition(68, 11);
                Random rnd = new Random();
                Console.WriteLine("Cartella del secondo giocatore");
                for (int i = 0; i < CartRow; i++)
                {
                    Console.WriteLine();
                    Console.SetCursorPosition(xC2, yC2);
                    for (int i2 = 0; i2 < CartColumn; i2++)
                    {
                        for (int j = 1; j <= 10; j++)
                        {
                            C2[i, i2] = rnd.Next(1, 91);
                        }
                        Console.Write(C2[i, i2].ToString("D2") + " ");
                    }
                    yC2++;
                }
            }
            void Es()
            {

            }

        }
    } 
}


   

