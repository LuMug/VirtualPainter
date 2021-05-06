using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
// Author: Zeno Darani

    ///<summary>
    /// La classe <c>FileManager</c> contiene funzionalità per il caricamento ed il
    /// salvataggio di texture in formato JPG e PNG.
    /// </summary>
    public class FileManager
    {
        /// <summary>
        /// Indica la modalità di scrittura da usare quando si instanzia un oggetto
        /// FileManager.
        /// </summary>
        public const int WRITE_MODE = 0;
        /// <summary>
        /// Indica la modalità di lettura da usare quando si instanzia un oggetto
        /// FileManager.
        /// </summary>
        public const int READ_MODE = 1;
        /// <summary>
        /// Il percorso del file.
        /// </summary>
        private string path;
        public string Path
        {
            get { return path; }
            set { path = value; }
        }
        /// <summary>
        /// La modalità con cui il file è aperto.
        /// <para>Se mode = 0 l'istanza è in modalità scrittura</para>
        /// <para>Se mode = 1 l'istanza è in modalità lettura</para>
        /// </summary>
        private int mode;
        public int Mode
        {
            get { return mode; }
        }

        /// <summary>
        /// Instanzia un oggetto FileManager con le sue caratteristiche.
        /// </summary>
        /// <param name="path">Il percorso del file da salvare o caricare.</param>
        /// <param name="mode">La modalità con cui l'oggetto verrà istanziato.</param>
        public FileManager(string path, int mode)
        {
            Path = path;
            this.mode = mode;
        }

        /// <summary>
        /// Ricava una texture dal file JPEG o PNG definito dalla proprietà path. 
        /// </summary>
        /// <returns>La texture ricavata dall'immagine</returns>
        /// <exception cref="System.IO.FileNotFoundException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public Texture2D GetTexture()
        {
            if (Mode == READ_MODE)
            {
                Texture2D tex = new Texture2D(2, 2);
                if (!File.Exists(Path))
                {
                    throw new System.IO.FileNotFoundException(
                        "Il percorso indicato non esiste o non è attualmente raggiungibile." +
                        " Assicurarsi di avere i prvilegi necessari."
                    );
                }
                byte[] imageBytes = File.ReadAllBytes(Path);
                tex.LoadImage(imageBytes);
                return tex;
            }
            else
            {
                throw new InvalidOperationException(
                    "L'istanza dell'oggeto è in modalità write." +
                    "Per ricavare una texture instanziare in modalità read."
                );
            }
        }

        /// <summary>
        /// Salva una texture in formato JPG nel percorso designiato.
        /// </summary>
        /// <param name="tex">La texture da salvare come immagine.</param>
        /// <exception cref="InvalidOperationException"></exception>
        public void SaveTextureJPG(Texture2D tex)
        {
            if (Mode == WRITE_MODE)
            {
                byte[] imageBytes = ImageConversion.EncodeToJPG(tex);
                File.WriteAllBytes(Path, imageBytes);
            }
            else
            {
                throw new InvalidOperationException(
                    "L'istanza dell'oggeto è in modalità read." +
                    "Per ricavare una texture instanziare in modalità write."
                );
            }
        }
        /// <summary>
        /// Salva una texture in formato PNG nel percorso designiato.
        /// </summary>
        /// <param name="tex">La texture da salvare come immagine.</param>
        /// <exception cref="InvalidOperationException"></exception>
        public void SaveTexturePNG(Texture2D tex)
        {
            if (Mode == WRITE_MODE)
            {
                byte[] imageBytes = ImageConversion.EncodeToPNG(tex);
                File.WriteAllBytes(Path, imageBytes);
            }
            else
            {
                throw new InvalidOperationException(
                    "L'istanza dell'oggeto è in modalità read." +
                    "Per ricavare una texture instanziare in modalità write."
                );
            }
        }
    }
