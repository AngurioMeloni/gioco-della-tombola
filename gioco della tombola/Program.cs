using System;
using System.Collections.Generic;
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
            int TabRow = 9,TabColumn = 10;
            int CartRow = 3, CartColumn = 5;
            //dichiarazione delle variabili per il posizionamento del tabellone e cartelle
            int xT = 40, yT = 1, xCart1 = 20, yCart1 = 15, xCart2 = 40, yCart2 = 15;
            //dichiarazione del random
            Random r = new Random();
            //dichiarazione matrici
            int[,] tabella = new int[TabRow, TabColumn];
            int[,] Cartella1 = new int[CartRow, CartColumn];
            int[,] Cartella2= new int[CartRow, CartColumn];
            //funzione della stampa della tabella
        }
    }
}
