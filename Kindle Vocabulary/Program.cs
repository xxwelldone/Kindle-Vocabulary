﻿using System;
using System.Globalization;
using Kindle_Vocabulary.Entities;

namespace Kindle_Vocabulary
{
    internal class Program
    {
        static void Main(string[] args)
        {

            String path = @"C:\Users\Wesley\OneDrive\Área de Trabalho\My Clippings.txt";
            String outpath = @"C:\Users\Wesley\OneDrive\Área de Trabalho\VocabularyBuilder.txt";

            List<String> originalData = File.ReadAllLines(path).ToList();
            List<String> words = new List<String>();
            List<String> book = new List<String>();
            List<DateTime> addedOn = new List<DateTime>();
            String keyword = "Added on ";





            List<Vocabulary> vocabulary = new List<Vocabulary>();

            for (int i = 0; i < originalData.Count; i++)
            {
                int indexOfAddedOn = originalData[i].IndexOf(keyword);


                if (!(indexOfAddedOn < 0))
                {

                    String temporaryDate = originalData[i].Substring(indexOfAddedOn + keyword.Length);
                    DateTime date = DateTime.Parse(temporaryDate);
                    //addedOn.Add(originalData[i].Substring(indexOfAddedOn + keyword.Length));
                    addedOn.Add(date);


                }

                if (originalData[i] == "==========")
                {
                    words.Add(originalData[i - 1]);
                    book.Add(originalData[i - 4]);

                }


            }

            List<string> wordsTreated = words.ConvertAll(v => v.EndsWith('\'') || v.EndsWith('?') || v.EndsWith('.') || v.EndsWith(',') || v.EndsWith(':') ? v.Remove(v.Length - 1) : v);
            //wordsTreated.RemoveAll(word => word.Contains(' '));
            for (int i = 0; i < wordsTreated.Count; i++)
            {
                vocabulary.Add(new Vocabulary(wordsTreated[i], book[i], addedOn[i]));
                //Console.WriteLine(vocabulary[i]);
            }
           
            vocabulary.RemoveAll((v) => v.Word.Contains(' '));
            vocabulary.Sort((v1, v2) => v1.AddedOn.CompareTo(v2.AddedOn));
            vocabulary.ForEach(v => { Console.WriteLine(v); });

            vocabulary.ForEach(word => { Console.WriteLine(word); });

            List<String> lines = vocabulary.ConvertAll(vocab => vocab.ToString());
            File.WriteAllLines(outpath, lines);










        }
    }
}

