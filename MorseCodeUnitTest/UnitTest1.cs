using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MorseLibrary;
using System.IO;
using MorseCode;
using System.Collections.Generic;

namespace MorseCodeUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMorseEncoderWithValue()
        {
            string solution = "..-. .-. .- -. --.. .--- .- --. - .. -- -.- --- -- .--. .-.. . - - ...- . .-. .-- .- .... .-. .-.. --- ... - . -. - .- -..- .. --.- ..- . .-. -.. ..- .-. -.-. .... -... .- -.-- . .-. -. .---- ..--- ...-- ....- ..... -.... --... ---.. ----. ----- ";
            Morse morse = new Morse();
            string result = morse.EncodeMessage("Franz jagt im komplett verwahrlosten Taxi quer durch Bayern. 1234567890");
            Assert.IsTrue(result == solution);
        }

        [TestMethod]
        public void TestMorseEncoderWithWrongValue()
        {

            string wrongSolution = "- . ... - - . -..- -";
            Morse morse = new Morse();
            string result = morse.EncodeMessage("test text");
            Assert.IsFalse(result == wrongSolution);
        }
        [TestMethod]
        public void TestMorseEncoderWithFileCorrect()
        {
            string solution = ".-.. --- .-. . -- .. .--. ... ..- -- -.. --- .-.. --- .-. ... .. - .- -- . - ";
            string filePath = AppDomain.CurrentDomain.BaseDirectory + "\\correcttestfile.txt";
            string result = Program.EncodeMessageByFileInput(new Morse(), filePath);

            Assert.IsTrue(result == solution);
        }
        [TestMethod]
        public void TestMorseEncoderWithFileIncorrect()
        {
            string solution = "-.. .. . ... .. ... - -.. . .-. - . -..- - -.. . .-. .. -. -.-. --- .-. .-. . -.- - --. . .-- . .-. - . - .-- . .-. -.. . -. ... --- .-.. .-.. - .";
            string filePath = AppDomain.CurrentDomain.BaseDirectory + "\\incorrexttestfile.txt";
            string result = Program.EncodeMessageByFileInput(new Morse(), filePath);

            Assert.IsFalse(result == solution);
        }
        [TestMethod]
        public void IsExceptionHandled()
        {
            Morse morse = new Morse();
            try
            {
                morse.EncodeMessage(",.-");
            }
            catch (KeyNotFoundException)
            {
                Assert.Fail();
            }

        }
    }
}
