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
            //dichiarazioni variabili, matrici per le cartelle , array di bool
            int numero, x, y = 2;
            Random r = new Random();
            bool[] T = new bool[90];
            int V1 = 0, V2 = 0;
            int[,] C1 = new int[9, 3];
            int[,] C2 = new int[9, 3];
            Console.SetCursorPosition(23, 0);
            Console.WriteLine("Tabellone");
            for (int i = 0; i < 9; i++) //ciclo di stampa per il tabellone
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
                for (int i2 = 0; i2 < 3; i2++) //ciclo per far scrivere e far cambiare di colore la scritta dei numeri sul tabellone
                {
                    Console.SetCursorPosition(x, y);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(numero);
                    Thread.Sleep(1);
                    Console.SetCursorPosition(x, y);
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine(numero);
                    Thread.Sleep(1);
                }
                //richiamo alla funzione di verifica della presenza dei numeri estratti nella prima cartella
                FV1();
                //richiamo alla funzione di verifica della presenza dei numeri estratti nella seconda cartella
                FV2();
                //richiamo alla funzione di controllo tombola
                ControlT();
                Thread.Sleep(100);
            }
            int Estrazione() //funzione di estrazione dei numeri che verranno poi scritti nel tabellone
            {
                int Estr;
                do
                {
                    Estr = r.Next(1, 91);           //generazione di numero casuale
                } while (T[Estr - 1] == true);      //ciclo che verifica che il numero non sia ancora stato estratto
                T[Estr - 1] = true;                 //salva il numero estratto attraverso l'array booleano 
                return Estr;                        //ritorno del valore estratto
            }
            int Fx()    //funzione che calcola il valore della x
            {
                if (numero / 10 == 0)               //controllo che il numero abbia sia minore di dieci controlllando la sua decina
                {
                    x = 10 + (numero % 10 * 3);     //calcolo della variabile x
                }
                else                                 //else che da delle istruzioni nel caso il numero sia maggiore di dieci 
                {
                    if (numero % 10 != 0)             //verifica che il numero non sia multiplo di 10
                    {
                        x = 11 + (numero % 10 * 3 - 1); //calcolo della variabile x
                    }
                    else
                    {
                        x = 11 + numero / (numero / 10) * 3 - 1;    //calcolo della variabile x
                    }
                }
                return x;           //ritorno della variabile x
            }
            
            int Fy() //funzione che calcola il valore della variabile y
            {
                if (numero / 10 == 0)       //controllo che il numero abbia sia minore di dieci controlllando la sua decina
                {
                    y = 2;                 //calcolo della variabile y
                }
                else                         //else che da delle istruzioni nel caso il numero sia maggiore di dieci 
                {
                    if (numero % 10 != 0)
                    {
                        y = 2 + numero / 10;    //calcolo della variabile y
                    }
                    else
                    {
                        y = 1 + numero / 10;    //calcolo della variabile y
                    }
                }
                return y;   //ritorno della variabile y
            }
            int GC1() //funzione che serve per la generazione della cartella del giocatore 1
            {
                bool[] Array90 = new bool[90]; //dichiarazione dell'array di bool
                int Valore;                     //dichiarazione della variabile Valore
                for (int i = 0; i < 3; i++)
                {
                    bool[] ArrayDecine = new bool[10];  //array di controllo delle decine dei numeri estratti
                    for (int i2 = 0; i2 < 5; i2++)      //ciclo per l'estrazione del numero casuale
                    {
                        do
                        {
                            Valore = r.Next(1, 91); //numero casuale
                            if (Valore == 90)   //if per l'eccezione del numero 90 che si incolonna nella 8 decina
                            {
                                i2--;
                            }
                        } while (Array90[Valore - 1] == true || ArrayDecine[Valore / 10] == true);  // verifica che il numero non venga ripetuto e che la decina stessa non venga
                        Array90[Valore - 1] = true;         //salvataggio del numero generato come  già presente 
                        ArrayDecine[Valore / 10] = true;    //salvataggio la decina del numero generato come già presente 
                        if (Valore == 90)                  //if per l'eccezione del numero 90 che si incolonna nella 8 decina
                        {
                            C1[8, i] = 90;              //assegnazione del valore 90 nell'ottava colonna
                        }
                        else
                        {
                            C1[Valore / 10, i] = Valore;    //assegnazione del valore all'apposita colonna
                        }
                    }
                    for (int i3 = 0; i3 < 9; i3++)
                    {
                        ArrayDecine[i3] = false;        //false per l'array booleano all'interno delle decine per la generazione della nuova riga
                    }
                }
                return 0;
            }
            int GC2()                                    //funzione che serve per la generazione della cartella del giocatore 2
            {

                bool[] Array90 = new bool[90];          //dichiarazione dell'array di bool
                int Valore;                                //dichiarazione della variabile Valore
                for (int i = 0; i < 3; i++)
                {
                    bool[] ArrayDecine = new bool[10];  //array di controllo delle decine dei numeri estratti
                    for (int i2 = 0; i2 < 5; i2++)      //ciclo per l'estrazione del numero casuale
                    {
                        do
                        {
                            Valore = r.Next(1, 91);        //numero casuale
                            if (Valore == 90)               //if per l'eccezione del numero 90 che si incolonna nella 8 decina
                            {
                                i2--;
                            }
                        } while (Array90[Valore - 1] == true || ArrayDecine[Valore / 10] == true);      // verifica che il numero non venga ripetuto e che la decina stessa non venga
                        Array90[Valore - 1] = true;                             //salvataggio del numero generato come  già presente 
                        ArrayDecine[Valore / 10] = true;                         //salvataggio la decina del numero generato come già presente 
                        if (Valore == 90)                                  //if per l'eccezione del numero 90 che si incolonna nella 8 decina
                        {
                            C2[8, i] = 90;                                  //assegnazione del valore 90 nell'ottava colonna
                        }
                        else
                        {
                            C2[Valore / 10, i] = Valore;                     //assegnazione del valore all'apposita colonna
                        }
                    }
                    for (int i3 = 0; i3 < 9; i3++)  
                    {
                        ArrayDecine[i] = false;       //false per l'array booleano all'interno delle decine per la generazione della nuova riga
                    }
                }
                return 0;
            }
            void FC1() //funzione per la stampa della cartella del primo giocatore
            {
                x = 0;      //valore x
                y = 12;       //valore y
                Console.SetCursorPosition(x, y); //posizionamento della scrita della cartella del primo giocatore
                Console.WriteLine("Cartella del primo giocatore ");
                y++;//incremento di y 
                for (int i = 0; i < 5; i++)         //ciclo per la stampa delle righe di separazione tra una riga e l'altra
                {
                    x = 0;
                    y++;
                    if (i % 2 == 1)             //if per la stampa dei trattini
                    {
                        Console.SetCursorPosition(x, y);
                        Console.WriteLine("-------------------------");
                    }
                    else
                    {
                        Console.SetCursorPosition(x, y);        
                        for (int i2 = 0; i2 < 9; i2++)          //ciclo per la stampa deii valori della cartella
                        {
                            if (C1[i2, i / 2 + i % 2] != 0)
                            {
                                Console.Write($"{C1[i2, i / 2 + i % 2]} ");
                            }
                            else
                            {
                                if (i2 == 0)
                                {
                                    Console.Write("  ");    //stampa di 2 spazi
                                }
                                else
                                {
                                    Console.Write("   ");   //stampa di 3 spazi
                                }
                            }
                        }
                        Console.WriteLine();    
                    }
                }
            }
            void FC2()  //funzione per la stampa della cartella del primo giocatore
            {
                x = 30;     //valore x
                y = 12;     //valore y
                Console.SetCursorPosition(x, y);        //posizionamento della scrita della cartella del primo giocatore
                Console.WriteLine("Cartella del secondo giocatore ");
                y++;    //incremento di y 
                for (int i = 0; i < 5; i++)     //ciclo per la stampa delle righe di separazione tra una riga e l'altra
                {
                    x = 30;
                    y++;
                    if (i % 2 == 1)     //if per la stampa dei trattini
                    {
                        Console.SetCursorPosition(x, y);
                        Console.WriteLine("-------------------------");
                    }
                    else
                    {
                        Console.SetCursorPosition(x, y);
                        for (int i2 = 0; i2 < 9; i2++)      //ciclo per la stampa deii valori della cartella
                        {
                            if (C2[i2, i / 2 + i % 2] != 0)
                            {
                                Console.Write($"{C2[i2, i / 2 + i % 2]} ");
                            }
                            else
                            {
                                if (i2 == 0)
                                {
                                    Console.Write("  ");     //stampa di 2 spazi
                                }
                                else
                                {
                                    Console.Write("   ");   //stampa di 3 spazi
                                }
                            }
                        }
                        Console.WriteLine();
                    }
                }
            }
            int FV1()   //funzione di controloo della presenza dei numeri estratti all'interno della cartella del giocatore 1
            {
                x = 0;  //valore x
                y = 14; //valore y
                for (int k = 0; k < 3; k++) //ciclo di identificazione
                {
                    for (int j = 0; j < 9; j++)
                    {
                        if (C1[j, k] == numero) //condizione di verifica del numero estratto
                        {
                            if (j == 0) 
                            {
                                x = 0;
                            }
                            else
                            {
                                x += j * 3 - 1; //calcolo della x
                            }
                            y += k * 2;     //calcolo della y
                            V1++;   //incremento della variabile che verificherà poi la tombola nella prima cartella
                            Console.SetCursorPosition(x, y);//impostare la posizione a x e y
                            Console.BackgroundColor = ConsoleColor.Green;//impostare il colore dello sfondo a verde
                            Console.Write(numero);//output del numero
                            Console.BackgroundColor = ConsoleColor.Black;//impostare il colore dello sfondo a nero  
                        }
                    }
                }
                return V1; //ritorno della variabile di verifica della tombola
            }

            int FV2()   //funzione di controloo della presenza dei numeri estratti all'interno della cartella del giocatore 1
            {
                x = 30; //valore x
                y = 14; //valore y
                for (int k = 0; k < 3; k++) //ciclo di identificazione
                {
                    for (int j = 0; j < 9; j++)
                    {
                        if (C2[j, k] == numero) //condizione di verifica del numero estratto
                        {
                            if (j == 0)
                            {
                                x = 30; //valore x
                            }
                            else
                            {
                                x += j * 3 - 1; //calcolo della x
                            }
                            y += k * 2;  //calcolo della y
                            V2++;   //incremento della variabile che verificherà poi la tombola nella seconda cartella 
                            Console.SetCursorPosition(x, y);    //impostare la posizione a x e y
                            Console.BackgroundColor = ConsoleColor.Yellow;  //impostare il colore dello sfondo a giallo
                            Console.Write(numero);//output del numero
                            Console.BackgroundColor = ConsoleColor.Black;   //impostare il colore dello sfondo a nero

                        }
                    }
                }
                return V2;  //ritorno della variabile di verifica della tombola
            }
            int ControlT()  //funzione per il controllo della tombola
            {
                if (V1 == 15 && V2 == 15)   //condizione che verifica la possibilità che tutte e due le cartelle hanno fatto tombola contemporaneamente
                {
                    Console.SetCursorPosition(0, 20);  //posizionamento della scritta successiva
                    Console.Write("Entrambi i giocatori hanno vinto");
                    Console.SetCursorPosition(0, 0);
                    Environment.Exit(1);    //fine del programma
                    return 0;
                }
                else if (V1 == 15)
                {
                    Console.SetCursorPosition(0, 20);   //posizionamento della scritta successiva
                    Console.Write("Il giocatore 1 ha fatto tombola");
                    Console.SetCursorPosition(0, 0);
                    Environment.Exit(1);    //fine del programma
                    return 0;
                }
                else if (V2 == 15)
                {
                    Console.SetCursorPosition(30, 20);  //posizionamento della scritta successiva
                    Console.Write("Il giocatore 2 ha fatto tombola");
                    Console.SetCursorPosition(0, 0);
                    Environment.Exit(1);     //fine del programma
                    return 0;
                }
                return 0;
            }
        }
    }
}






