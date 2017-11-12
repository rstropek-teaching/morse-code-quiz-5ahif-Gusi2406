using System;
using MorseLibrary;
using System.IO;

namespace MorseCode
{
    public class Program
    {
        static void Main(string[] args)
        {
            bool key3Pressed = false;
            string key;
            Morse morse = new Morse();
            Console.ForegroundColor = ConsoleColor.White;
            while (!key3Pressed)
            {
                Console.WriteLine("Morse encoder");
                Console.WriteLine("1. Text der kodiert werden soll eingaben.");
                Console.WriteLine("2. Pfad zu einer Datei die kodiert werden soll eingeben.");
                Console.WriteLine("3. Programm beenden");
                Console.Write("Auswahl: ");
                key = Console.ReadLine();

                if (key == "1")
                {
                    EncodeMessageByUserInput(morse);

                }
                if (key == "2")
                {
                    EncodeMessageByFileInput(morse);

                }
                if (key == "3")
                {
                    key3Pressed = true;
                }
            }
        }

        public static string EncodeMessageByFileInput(Morse morse, string pathToFile = null)
        {
            string encodedText = null;
            Console.Write("Pfad zur Datei die kodiert werden soll: ");
            if (pathToFile == null)
            {
                pathToFile = Console.ReadLine();
            }
            try
            {
                Console.WriteLine("Kodierter Text: ");
                using (FileStream fs = File.Open(pathToFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                using (BufferedStream bs = new BufferedStream(fs))
                using (StreamReader sr = new StreamReader(bs))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        Console.WriteLine("neue Junk");
                        encodedText = morse.EncodeMessage(line);
                        Console.WriteLine(encodedText);
                    }
                    Console.WriteLine();
                }
            }
            catch (IOException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Die angegebene Datei wurde nicht gefunden");
                Console.ForegroundColor = ConsoleColor.White;
            }
            return encodedText;
        }

        private static void EncodeMessageByUserInput(Morse morse)
        {
            Console.Write("Zu kodierender Text: ");
            string textToEncode = Console.ReadLine();
            Console.Write("Kodierter Text: " + morse.EncodeMessage(textToEncode));
            Console.WriteLine();
        }
    }
}
