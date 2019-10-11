using System;
using Esercitazione.Procedures;
using Esercitazione.Utils;

namespace Esercitazione
{
    class Program
    {
        static void Main(string[] args)
        {

         /*Si chiede di creare un app console in .NET Framework Core 3.0 che in fase di esecuzione richieda l’inserimento 
         * di un numero compreso da 1 e 10; dopo la lettura del numero, dovranno essere creati un pari numero di oggetti 
         * “prodotto” (classe Product), ciascuno dei quali caratterizzato da codice (alfanumerico, campo “Code”) e nome 
         * (campo “Name”). Una volta terminato l’inserimento dei prodotti, gli stessi devono essere stampati a video e scritti 
         * all’interno di un file di testo in modo tale da poter essere facilmente riletti (la funzione di rilettura non è richiesta).*/
         Console.WriteLine("**************************");
         Console.WriteLine("***   ESERCITAZIONE    ***");
         Console.WriteLine("**************************");
         FunzioniProdotto.InserisciNumProdottiEMostra();
        }
    }
}
