using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Range
{
    class Program
    {
        static void Main()
        {
            try
            {
                string fileName = "Range.txt";
                string firstWord = "day"; 
                string secondWord = "today";
                string fword = firstWord.ToLower();
                string sword = secondWord.ToLower();
                StreamReader sr = new StreamReader(fileName);
                String file = sr.ReadToEnd();//считывание
                sr.Close();
                String line = file.ToLower();
                List<string> words = line.Split(' ').ToList<string>();
                int i = 0;
                List<int> fwords = new List<int>();
                List<int> swords = new List<int>();
                int? minRange = null;
                int? maxRange = null;
                foreach (string word in words)
                {
                    if (word == " ")
                    {
                        words.Remove(word);
                    }
                    
                }//удаление двойных пробелов(второй пробел при данном сплите считается словом)
                foreach (string word in words)//запоминание индексов искомых слов
                {
                    if (word == fword)
                    {
                        fwords.Add(i);
                    }
                    if (word == sword)
                    {
                        swords.Add(i);
                    }
                    i++;
                }
                if (fwords.Max() - swords.Min() > swords.Max() - fwords.Min())
                {
                    maxRange = fwords.Max() - swords.Min();
                }
                else
                {
                    maxRange = swords.Max() - fwords.Min();
                }//поиск максимума 
                {
                    int k = 0;
                    int j = 0;
                    minRange = Math.Abs(fwords[k] - swords[j]);
                    while (k < fwords.Count && j < swords.Count)
                    {
                        int x = fwords[k] - swords[j];
                        if (x < 0)
                        {
                            x = -x;
                            k++;
                        }
                        else if (x > 0)
                        {
                            j++;
                        }
                        if (x < minRange)
                        {
                            minRange = x;
                        }
                    }
                }//поиск минимума (алгоритм слияния)
                if (minRange != null)
                {
                    Console.WriteLine($"min = {minRange-1}");
                }
                else
                {
                    Console.Write($"");
                }
                if (maxRange != null)
                    Console.WriteLine($"max = {maxRange-1}");
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }

    }
}
  //if(word == fword)
  //                  {
  //                      isFindedF = true;
  //                      if (isFindedS)// если было найдено оба слова, проверяем длины диапазонов
  //                      {
  //                          if (maxRange<itMax || maxRange == null)
  //                          {
  //                              maxRange = itMax;
  //                          }
  //                          if(minRange > itMin || minRange == null)
  //                          {
  //                              minRange = itMin;
  //                          }
  //                      }
  //                      itMin = 0;
  //                      isFindedS = false;
  //                  }
  //                  else if (word == sword)
  //                  {
  //                      isFindedS = true;
  //                      if (isFindedF)// если было найдено оба слова, проверяем длины диапазонов
  //                      {
  //                          if (maxRange<itMax || maxRange == null)
  //                          {
  //                              maxRange = itMax;
  //                          }
  //                          if (minRange > itMin || minRange == null)
  //                          {
  //                              minRange = itMin;
  //                          }
  //                      }
  //                      itMin = 0;
  //                      isFindedF = false;
  //                  }
  //                  //если было встречено одно из искомых слов считаем диапазон, иначе нет необходимсоти
  //                  if (isFindedF || isFindedS)
  //                  {
  //                      itMax++;
  //                      itMin++;
  //                  }