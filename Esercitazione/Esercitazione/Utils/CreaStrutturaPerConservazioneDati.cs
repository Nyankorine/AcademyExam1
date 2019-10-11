using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Esercitazione.Entities;

namespace Esercitazione.Utils
    {
    public static class FunzioniFileSystem
    {
        public static void CreaStrutturaPerConservazioniDati(Product[] elenco, int index)
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
    }
}