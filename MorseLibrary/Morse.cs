using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorseLibrary
{
    public class Morse
    {
        private Dictionary<char, string> morseTokens;

        public Morse()
        {
            this.morseTokens = new Dictionary<char, string>();
            this.InitializeMorseCodes();
        }

        private void InitializeMorseCodes()
        {
            this.morseTokens.Add('0', "-----");
            this.morseTokens.Add('1', ".----");
            this.morseTokens.Add('2', "..---");
            this.morseTokens.Add('3', "...--");
            this.morseTokens.Add('4', "....-");
            this.morseTokens.Add('5', ".....");
            this.morseTokens.Add('6', "-....");
            this.morseTokens.Add('7', "--...");
            this.morseTokens.Add('8', "---..");
            this.morseTokens.Add('9', "----.");
            this.morseTokens.Add('A', ".-");
            this.morseTokens.Add('B', "-...");
            this.morseTokens.Add('C', "-.-.");
            this.morseTokens.Add('D', "-..");
            this.morseTokens.Add('E', ".");
            this.morseTokens.Add('F', "..-.");
            this.morseTokens.Add('G', "--.");
            this.morseTokens.Add('H', "....");
            this.morseTokens.Add('I', "..");
            this.morseTokens.Add('J', ".---");
            this.morseTokens.Add('K', "-.-");
            this.morseTokens.Add('L', ".-..");
            this.morseTokens.Add('M', "--");
            this.morseTokens.Add('N', "-.");
            this.morseTokens.Add('O', "---");
            this.morseTokens.Add('P', ".--.");
            this.morseTokens.Add('Q', "--.-");
            this.morseTokens.Add('R', ".-.");
            this.morseTokens.Add('S', "...");
            this.morseTokens.Add('T', "-");
            this.morseTokens.Add('U', "..-");
            this.morseTokens.Add('V', "...-");
            this.morseTokens.Add('W', ".--");
            this.morseTokens.Add('X', "-..-");
            this.morseTokens.Add('Y', "-.--");
            this.morseTokens.Add('Z', "--..");
        }

        public string EncodeMessage(string messageToTranslate)
        {
            string sol = "";
            foreach (char messageChar in messageToTranslate)  //ein string ist ein char array, foreach geht jeden Wert eines arrays durch
            {
                try
                {
                    sol += this.morseTokens[messageChar.ToString().ToUpper()[0]] + " ";
                }
                catch (KeyNotFoundException) {
                    Console.WriteLine("Ein Zeichen ist kann nicht encoded werden:   " + messageChar);
                }
            }

            /*for (int i = 0; i < messageToTranslate.Length; i++){
                sol += this.morseTokens[messageToTranslate[i]];
            }*/
            return sol;
        }
    }
}
