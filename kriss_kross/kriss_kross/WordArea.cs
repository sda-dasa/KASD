using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Drawing.Text;
using static System.Windows.Forms.AxHost;
using System.Threading;
using System.Security.Cryptography.X509Certificates;
using System.Collections.Specialized;

namespace krisskross
{
    public class WordArea
    {
        private ArrayWord<Word> mainWordArea;
        private List<ArrayWord<Word>> allWordArea; //
        /**
         * Ширина и высота схемы
         */
        private int width;
        private int height;
        
        /**
         * Исходные слова 
         */
        private List<string> rawWords;
        private int numberOfWord;
        private int sizeWordArea = 1000;
        private int intersectWordArea = 0;
        private double density = 0.0;

        public SuccessDegree Success { get; private set; } = SuccessDegree.None;

        private static int STARTX = 50; // стартовая позици для отрисовки схемы крисс-кросс
        private static int STARTY = 50;

        List<(int, int)> matrix = new List<(int, int)>();


        private double alpha = 0.0;

        public WordArea() { }

        public WordArea(string[] wordsmas)
        {
            ReadWords(wordsmas);

            if (Success == SuccessDegree.ListIsWrong) return;

            allWordArea = new List<ArrayWord<Word>>();

            alpha = 1.0 / Math.Pow(1.4, numberOfWord);

            string first = rawWords.First();

            rawWords.RemoveAt(0);

            Word firstWord = new Word(first, Orientation.HORIZ, 0, 0);
            ArrayWord<Word> firstWordArea = new ArrayWord<Word>();
            firstWordArea.Add(firstWord);

            WordsBackTracking(firstWordArea, rawWords);

            foreach (ArrayWord<Word> word in allWordArea) AssignCoordinate(word);

            if (mainWordArea == null || mainWordArea.Count == 0) 
            { 
                Success = SuccessDegree.SchemeIsNotCreated; 
                return; 
            } // не удалось построить схему

            width = (mainWordArea.Width + 10) * CharCell.CELL_SIZE;
            height = (mainWordArea.Height + 10) * CharCell.CELL_SIZE;

            //DrawCrossword();

            Success = SuccessDegree.AllRight;


        }
        
        /**
         *  Перебор всех слов с возвратом (Backtracking) 
         *  Составляет схему крисс-кросс
         */
        private void WordsBackTracking(ArrayWord<Word> wordArea, List<string> words)
        {
            
            if (Accept(wordArea))
            {
                ArrayWord<Word> tempWordArea = new ArrayWord<Word>(wordArea);
                CopyArrayWord(tempWordArea, wordArea); // copyarray
                allWordArea.Add(tempWordArea);
                mainWordArea = tempWordArea;
                return;
            }

            if (Reject(wordArea, words)) return;

            for (int i = 0; i < words.Count; i++)
            {
                List<string> tempWords = new List<string>(words);
                string newWord = tempWords[i];
                tempWords.RemoveAt(i);
                AddNewWord(wordArea, tempWords, newWord);
            }
        }
        /**
         * Добавляет новое слово, если это возможно
         */
        private void AddNewWord(ArrayWord<Word> wordArea, List<string> words, string newWord)
        {
            Word existentWord;
            for (int k = 0; k < wordArea.Count; k++)
            {
                existentWord = wordArea [k];
                ///сравниваем символы в новом и уже занесенном словах
                for (int i = 0; i < existentWord.Length; i++)
                {
                    for (int j = 0; j < newWord.Length; j++)
                    {
                        if (existentWord.Get(i).Value == newWord[j])
                        {
                            int newOrient = Invert(existentWord.Orient);

                            int newWordCoord = existentWord.Get(i).VariableCoord;

                            int initialVariableCoord = existentWord.WordCoord - j;

                            Word word = new Word(newWord, newOrient, newWordCoord, initialVariableCoord);

                            ///если слово "проходит" проверку - добавляем его
                            int interCount = wordArea.IntersectCount;

                            if (Check(wordArea, word, existentWord.WordCoord))
                            {
                                wordArea.Add(word);
                                ///сохраняем смещение относительно (0,0) сохранив предыдущие
                                
                                int minX = wordArea.MinX;

                                int minY = wordArea.MinY;

                                if (existentWord.Orient == Orientation.HORIZ) wordArea.MinY = initialVariableCoord;

                                else wordArea.MinX = initialVariableCoord;

                                ///запускаем косвенную рекурсию			                        
                                WordsBackTracking(wordArea, words);

                                ///убираем последнее добавленное слово
                                wordArea.RemoveAt(wordArea.Count - 1);

                                wordArea.Reset();

                                wordArea.MinX = minX;

                                wordArea.MinY = minY;

                                wordArea.IntersectCount = interCount;


                            }


                        }



                    }




                }




            }


        }




        /**
         *  Отклоняет потенциально не оптимальные частичные решения
         */
        private bool Reject(ArrayWord<Word> wordArea, List<string> words)
        {

            ///площадь текущей схемы не больше площади полного решения		       
            int currentSize = SizeWordArea(wordArea); // 
            if (currentSize >= sizeWordArea) return true;

            ///плотность текущей схемы не меньше плотности полного решения	
            
            double currentDensity = (double)wordArea.IntersectCount / currentSize;

            if (currentDensity + alpha < density) return true;

            ///средняя длина слов в схеме меньше чем средняя длина оставшихся слов
            ///
            double averageLengthWA = (double)SumWordLength(wordArea) / wordArea.Count;

            int sumLengthWL = 0;

            foreach (string str in words) sumLengthWL += str.Length;

            double averageLengthWL = (double)sumLengthWL / words.Count;
            if (averageLengthWA >= averageLengthWL) return true;

            return false;
        }
        /**
         *  Проверяет является ли схема решением
         */
        private bool Accept(ArrayWord<Word> wordArea)
        {
            if (wordArea.Count == numberOfWord)
            {
                int currentSize = SizeWordArea(wordArea); // 
                double currentDensity = (double)wordArea.IntersectCount / currentSize;
                if (currentDensity > density)
                {
                    intersectWordArea = wordArea.IntersectCount;
                    sizeWordArea = currentSize;
                    density = currentDensity;
                    return true;
                }
                else return false;
            }
            else return false;
        }
        /**
         * Проверяет возможность добавления нового слова в найденное место	 
         * orient - ориентация добавляемого слова + находит число пересечений со словом
         */
        private bool Check(ArrayWord<Word> wordArea, Word newWord, int intersect)
        {
            int intersectCount = wordArea.IntersectCount;
            int orient = newWord.Orient;
            int newWordCoord = newWord.WordCoord;
            int newFirst = newWord.First;
            int newLast = newWord.Last;

            foreach (Word word in wordArea)
            {
                int existFirst = word.First;
                int existLast = word.Last;
                ///проверяем все слова в этом же положении что и добавляемое
                if (word.Orient == orient)
                {
                    if (word.WordCoord == newWordCoord - 1 || word.WordCoord == newWordCoord + 1)
                    {
                        if (!((newFirst == existLast) && (newFirst == intersect)) &&
                             !((newLast == existFirst) && (newLast == intersect)))
                            if (Intersect(newFirst, newLast, existFirst, existLast))
                                return false;
                    }
                    else
                    if (word.WordCoord == newWordCoord)
                    {
                        if (Intersect(newFirst - 1, newLast + 1, existFirst, existLast))
                            return false;
                    }
                }
                ///и в противоположном
                else
                {
                    ///слова лежащие непосредственно в координах добавляемого слова
                    if (Range(newFirst, newLast, word.WordCoord))
                    {
                        for (int i = 0; i < word.Length; i++)
                        {
                            for (int j = 0; j < newWord.Length; j++)
                            {
                                if (word.Get(i).VariableCoord == newWordCoord && newWord.Get(j).VariableCoord == word.WordCoord)
                                    if (word.Get(i).Value != newWord.Get(j).Value) return false;
                                    else intersectCount++;
                            }
                        }
                        if ((existFirst == newWordCoord + 1) || (existLast == newWordCoord - 1))
                            return false;
                    }
                    ///слова лежащие по бокам от добавляемого слова
                    if (word.WordCoord == newFirst - 1 || word.WordCoord == newLast + 1)
                    {
                        if (Range(existFirst, existLast, newWordCoord))
                            return false;
                    }
                }



            }

            if (wordArea.IntersectCount == intersectCount) wordArea.IntersectCount = ++intersectCount;
            else wordArea.IntersectCount = intersectCount;
            return true;



        }
        /**
         * Проверяет пересекаются ли 2 отрезка [a,b] и [c,d]	     
         */
        private bool Intersect(int a, int b, int c, int d)
        {
            return Range(a, b, c) || Range(a, b, d) || Range(c, d, a) || Range(c, d, b);
        }
        /**
         * Проверяет принадлежит ли х отрезку [a,b]	
         */
        private bool Range(int a, int b, int x)
        {
            return (x >= a) && (x <= b);
        }


        
        private void CopyArrayWord(ArrayWord<Word> toCopy, ArrayWord<Word> source)
        {
            foreach(Word item in source) toCopy.Add(item);  
        }



        public class WrongListException : Exception
        {
            public WrongListException(string message) : base(message) { }
        }


        private class ForCompare : IComparer<string>
        {
            public ForCompare() { }

            public int Compare(string s1, string s2)
            {
                if (s1 == s2)
                    throw new WrongListException("Список слов не должен включать повторяющихся слов");
                int res = 0;
                if (s1.Length < s2.Length) 
                    res = -1;
                else
                {
                    if (s1.Length > s2.Length)
                        res =  1;
                    else
                        for (int i = 0; i < s1.Length; i++)
                        {
                            if (s1[i] < s2[i]) { res = -1; break; }
                            else
                            {
                                if (s1[i] > s2[i]) { res = 1; break; }
                                
                            }
                        }

                }

                return res;

            }
        }




        public static char FindCommonLetters(List<string> sortedStrings)
        {
            if (sortedStrings == null || sortedStrings.Count <= 2)
            {
                return default; // Возвращаем пустой список для пустого или null списка
            }

            int listLength = sortedStrings.Count;
            int n = (int)Math.Ceiling((double)listLength / 2); // Округляем в большую сторону
            List<char> result = new List<char>();
            HashSet<char> foundLettersforN = new HashSet<char>(); // Для отслеживания найденных букв
            HashSet<char> foundLettersBiggerN = new HashSet<char>(); // Для отслеживания найденных букв

            // Проверяем для n-1, n, n+1 (если это возможно)
            for (int offset = 0; offset <= 1; offset++)
            {
                int currentN = n + offset;
                if (currentN > 0 && currentN <= listLength)
                {
                    for (int i = 0; i <= listLength - currentN; i++)
                    {
                        string[] subArray = sortedStrings.GetRange(i, currentN).ToArray();
                        if (subArray.Length == 0) continue;
                        // Получаем уникальные буквы из первой строки подмассива
                        foreach (char firstStrChar in subArray[0].Distinct())
                        {
                            bool foundInAll = true;
                            // Проверяем, есть ли буква в остальных строках подмассива
                            for (int j = 1; j < subArray.Length; j++)
                            {
                                if (!subArray[j].Contains(firstStrChar))
                                {
                                    foundInAll = false;
                                    break;
                                }
                            }
                            if (currentN > n)
                            {
                                if (foundInAll && !foundLettersBiggerN.Contains(firstStrChar))
                                {
                                    result.Add(firstStrChar);
                                    foundLettersBiggerN.Add(firstStrChar);
                                }
                            }
                            else
                            {
                                if (foundInAll && !foundLettersforN.Contains(firstStrChar))
                                {
                                    result.Add(firstStrChar);
                                    foundLettersforN.Add(firstStrChar);
                                }
                            }

                        }
                    }
                }
            }

            char answer = default;

            if (foundLettersforN.Count > 0)
            {
                if (foundLettersforN.Count > 1 && foundLettersBiggerN.Count > 0)
                {
                    foreach (char firstLetter in foundLettersforN)
                        foreach (char secondLetter in foundLettersBiggerN)
                            if (firstLetter == secondLetter) { return firstLetter; }

                }
                if (answer == default || foundLettersBiggerN.Count == 0)
                {
                    answer = foundLettersforN.First();
                }
            }

            return answer;


        }






        private void ReadWords(string[] wordsmas)
        {
            // нужна сортировка - приоритет - слово наименьшей длины, стоящее выше по алфавиту
            ForCompare cmp = new ForCompare();
            
            rawWords = new List<string>();
            
            foreach (string word in wordsmas) 
                rawWords.Add(word.ToLower());

            try {
                rawWords.Sort(cmp);
            }
            catch (WrongListException ex) { 
                Success = SuccessDegree.ListIsWrong; return;
            }
            char added = FindCommonLetters(rawWords);

            if (added != default) rawWords.Insert(0, added.ToString());
            numberOfWord = rawWords.Count;

        }


        private int SizeWordArea(ArrayWord<Word> wordArea)
        {
            if (wordArea.Count == 0) return 0;
            //Iterator<Word> wordAreaIter = wordArea.iterator();
            int minX = 0;
            int minY = 0;
            int maxX = 0;
            int maxY = 0;

            foreach (Word word in wordArea)
            {
                int wordCoord = word.WordCoord;
                int first = word.First;
                int last = word.Last;
                if (word.Orient == Orientation.HORIZ)
                {
                    if (wordCoord < minY) minY = wordCoord;
                    if (wordCoord > maxY) maxY = wordCoord;
                    if (first < minX) minX = first;
                    if (last > maxX) maxX = last;
                }
                else
                {
                    if (wordCoord < minX) minX = wordCoord;
                    if (wordCoord > maxX) maxX = wordCoord;
                    if (first < minY) minY = first;
                    if (last > maxY) maxY = last;
                }
            }
            int width = maxX - minX + 1;

            int height = maxY - minY + 1;

            wordArea.Width = width;

            wordArea.Height = height;

            return (width * height);


        }

        private int Invert(int orient)
        {
            if (orient == Orientation.HORIZ) return Orientation.VERTIC;
            else return Orientation.HORIZ;
        }


        private int SumWordLength(ArrayWord<Word> wordArea)
        {
            int result = 0;

            foreach (Word wordAreaIter in wordArea)
                result += wordAreaIter.Length;
            return result;

        }



        private (int, int) GetMinXYinArea(ArrayWord<Word> wordArea)
        {
            int minx = 0; int miny = 0;
            for( int i = 0; i < wordArea.Count; i++)
            {
                if (wordArea[i].Orient == Orientation.VERTIC)
                {
                    if (wordArea[i].WordCoord < minx) minx = wordArea[i].WordCoord;
                    if (wordArea[i].First < miny) miny = wordArea[i].First;
                }
                else
                {
                    if (wordArea[i].First < minx) minx = wordArea[i].First;
                    if (wordArea[i].WordCoord < miny) miny = wordArea[i].WordCoord;
                }
            }
            return (minx, miny);

        }


        // устанавливает допустимые значения координат
        private void AssignCoordinate(ArrayWord<Word> wordArea)
        {
            int minx = GetMinXYinArea(wordArea).Item1; int miny = GetMinXYinArea(wordArea).Item2;
            foreach (Word wordAreaIter in wordArea) 
                wordAreaIter.IncreaseCoordinate(minx - 2, miny - 2);

            wordArea.Reset();

        }



        public void DrawCrossword(Graphics g)
        {
            if (mainWordArea.Count >= 3) mainWordArea.RemoveAt(0);

            for (int k = 0; k < mainWordArea.Count; k++)
            {
                for (int i = 0; i < mainWordArea[k].Length; i++)
                {
                    // Получаем координаты для каждой буквы
                    int x = STARTX; int y = STARTY;
                    if (mainWordArea[k].Orient == Orientation.HORIZ)
                    {
                        x = STARTX + (mainWordArea[k].First + i) * CharCell.CELL_SIZE;
                        y = STARTY + mainWordArea[k].WordCoord * CharCell.CELL_SIZE;

                    }
                    else
                    {
                        y = STARTY + (mainWordArea[k].First + i) * CharCell.CELL_SIZE;
                        x = STARTX + mainWordArea[k].WordCoord * CharCell.CELL_SIZE;

                    }

                    // Рисуем квадрат для клетки
                    g.FillRectangle(Brushes.White, x, y, CharCell.CELL_SIZE, CharCell.CELL_SIZE);
                    g.DrawRectangle(Pens.Black, x, y, CharCell.CELL_SIZE, CharCell.CELL_SIZE);

                }


            }

        }



        private int GetWordIndex(string word)
        {

            for (int i = 0; i < mainWordArea.Count; i++)
            {
                if (mainWordArea[i].ToString() == word) return i;
            }
            return -1;

        }


        public bool Anima(Graphics g, string wordsmas_k, int i)
        {

            int k = GetWordIndex(wordsmas_k);

            int x = STARTX; int y = STARTY;

            if (mainWordArea[k].Orient == Orientation.HORIZ)
            {
                x = STARTX + (mainWordArea[k].First + i) * CharCell.CELL_SIZE;
                y = STARTY + mainWordArea[k].WordCoord * CharCell.CELL_SIZE;

            }
            else
            {
                y = STARTX + (mainWordArea[k].First + i) * CharCell.CELL_SIZE;
                x = STARTY + mainWordArea[k].WordCoord * CharCell.CELL_SIZE;

            }


            if (matrix.Contains((x, y))) return false;

            using (Font font = new Font("Arial", 16))
            {
                g.DrawString(mainWordArea[k].Get(i).Value.ToString(),
                    font, Brushes.Black, x, y);
            }
            
            matrix.Add((x, y));
            return true;

        }








        public enum SuccessDegree
        {
            None = -1,
            ListIsWrong = 0,
            SchemeIsNotCreated = 1,
            AllRight = 2,

        }


    }



}
