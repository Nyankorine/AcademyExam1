using System;
using System.Collections.Generic;
using System.Text;
using Esercitazione.Utils;
using Esercitazione.Procedures;
using Esercitazione.Entities;

namespace Esercitazione.Procedures
{
    public static class FunzioniProdotto
    {
        public static void InserisciNumProdottiEMostra()
        {
            //Richiedo il numero di prodotti da inserire
            Console.Write("Quanti prodotti vuoi inserire (da 1 a 10)? ");
            int totalProduct = ConsoleUtils.LeggiNumeroInteroDaConsole(1, 10);

            //Richiamo la funzione che genera i prodotti
            //Dimensionamento dei prodotti
            Product[] elencoprodotti = new Product[totalProduct];

            //Itero per il numero di persone richiesto
            for (int index = 0; index < totalProduct; index++)
            {
                //Richiamo una funzione a cui passo l'elenco
                //e l'indice corrente e questa mi aggiunge i prodotti
                AggiungiProdottiInPosizione(elencoprodotti, index);               
            }

            //Itero l'elenco e stampo a video
            StampaProdotti(elencoprodotti);
            string Path = FunzioniFileSystem.CreaStrutturaPerConservazioniDati(elencoprodotti);
            FunzioniFileSystem.LeggiStrutturaDaFileDati(Path);

            //Cerimonia finale
            ConsoleUtils.ConfermaUscita();
        }

        
        private static void StampaProdotti(Product[] elenco)
        {
            Console.WriteLine("*** Visualizzazione elenco prodotti***");
            for (var index = 0; index < elenco.Length; index++)
            {
                int x = index + 1;
                Console.WriteLine("Prodotto " + x + ":" + $" {elenco[index].Code}, {elenco[index].Name}");
            }
        }

        private static void AggiungiProdottiInPosizione(Product[] elenco, int index)
        {
            // Richiedo il codice prodotto e il nome
            int x = index + 1;
            Console.Write("Codice prodotto " + x + ": ");
            var cod= Console.ReadLine();
            Console.Write("Nome " + x + ": ");
            var name = Console.ReadLine();

            //Creo oggetto Prodotto da inserire nell'elenco
            Product prod = new Product
            {
                Code = cod,
                Name = name
            };

            elenco[index] = prod;
            string Path = FunzioniFileSystem.CreaStrutturaPerConservazioniDati(elenco);
            FunzioniFileSystem.ScritturaSuFileDati(Path,elenco,index);
        }
    }
}

