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
            int CartRow = 3, CartColumn = 5;
            //dichiarazione delle variabili per il posizionamento del tabellone e cartelle
            int xT = 40, yT = 1, xC1 = 20, yC1 = 13, xC2 = 76, yC2 = 13;
            //dichiarazione delle matrici
            int[,] tabella = new int[TabRow, TabColumn];
            int[,] C1 = new int[CartRow, CartColumn];
            int[,] C2 = new int[CartRow, CartColumn];
            //richiamo della funzione per la tabella
            Tabella(TabRow, TabColumn, tabella, xT, yT, TabN);
            //richiamo delle funzione per la prima cartella
            FC1(C1, xC1, yC1, CartRow, CartColumn);
            //richiamo delle funzione per la seconda cartella
            FC2(C2, xC2, yC2, CartRow, CartColumn);
            Console.ReadKey();  
        }
        //funzione della stampa della tabella
        static void Tabella(int TabRow, int TabColumn, int[,] tabella, int xT, int yT, int TabN)
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
        static void FC1(int[,] C1, int xC1, int yC1, int CartRow, int CartColumn)
        {
            Console.SetCursorPosition(13, 11);
            Random r = new Random();
            Console.WriteLine("Cartella del primo giocatore");
            for (int i = 0; i < CartRow; i++)
            {
                Console.WriteLine();
                Console.SetCursorPosition(xC1, yC1);

                for (int i2 = 0; i2 < CartColumn; i2++)
                {
                    C1[i, i2] = r.Next(1, 91);
                    Console.Write(C1[i, i2].ToString("D2") + " ");
                    for (int j = 1; j <= 10; j++)
                    {
                        C1[i, i2] = r.Next(1, 91);
                        yC1++;
                    }
                }
            }
        }
        static void FC2(int[,] C2, int xC2, int yC2, int CartRow, int CartColumn)
        {
            Console.SetCursorPosition(68, 11);
            Random r = new Random();
            Console.WriteLine("Cartella del secondo giocatore");
            for (int i = 0; i < CartRow; i++)
            {
                Console.WriteLine();
                Console.SetCursorPosition(xC2, yC2);
                for (int i2 = 0; i2 < CartColumn; i2++)
                {
                    for (int j = 1; j <= 10; j++)
                    {
                        C2[i,i2] =r.Next(1, 91);
                    }
                    Console.Write(C2[i, i2].ToString("D2") + " ");
                }
                yC2++;
            }
        }
   

