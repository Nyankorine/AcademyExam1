using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Esercitazione.Entities;

namespace Esercitazione.Utils
    {
    public static class FunzioniFileSystem
    {
        public static string CreaStrutturaPerConservazioniDati(Product[] elenco)
        {
            //Compongo il percorso della cartella di lavoro
            var workingFolder = AppDomain.CurrentDomain.BaseDirectory;

            const string DataFolderName = "Prodotti";
            const string DataBaseFileName = "elencoprodotti.txt";

            //Compilazione del percorso della folder
            var folderPath = Path.Combine(workingFolder, DataFolderName);

            //Se non eiste, la creo
            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            //Composizione del percorso del file database
            string databasePath = Path.Combine(folderPath, DataBaseFileName);
            return databasePath;
        }
        public static void ScritturaSuFileDati(string databasePath, Product[] elenco, int index)
        {
            //Se il file NON esiste, lo creo vuoto
            if (!File.Exists(databasePath))
            {
                //Creazione del file
                using (StreamWriter writer = File.CreateText(databasePath))
                {
                    writer.WriteLine(elenco[index].Code + " " + elenco[index].Name);
                    writer.Close();
                }
                Console.WriteLine("File Creato");
            }
            else
            {
                using (StreamWriter writer = File.AppendText(databasePath))
                {
                    writer.WriteLine(elenco[index].Code + " " + elenco[index].Name);
                    writer.Close();
                }
                Console.WriteLine("Elemento Aggiunto al file");
            }
        }
        public static void LeggiStrutturaDaFileDati(string databasePath)
        {
            //Predispongo una lista dei dati di uscita
            List<string> datiDiUscita = new List<string>();
            string readLine;         
                //Tento la lettura
            using (StreamReader reader = File.OpenText(databasePath))
             {
                do
                {
                    //Lettura della riga corrente del file
                    readLine = reader.ReadLine();
                    datiDiUscita.Add(readLine);
                }
                while (readLine != null) ;
            }

             //Ritorno la lista come array
             string[] arrayDiUscita = new string[datiDiUscita.Count];
            Console.WriteLine("");
                //Itero la lista e aggiungo i valori nell'array
                for (int i = 0; i < datiDiUscita.Count; i++)
                {
                    arrayDiUscita[i] = datiDiUscita[i];
                    Console.WriteLine(arrayDiUscita[i]);
                }
        }
    }
}