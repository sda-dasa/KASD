using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace krisskross
{

    public struct Orientation
    {
        public static int HORIZ = 0;
        public static int VERTIC = 1;

    }



    public class Word
    {
        private CharCell[] cells;
        //private int orientation;
        //private int wordCoord;
        //private int length;


        public int Orient { get; private set; }
        public int WordCoord { get; private set; }
        public int Length { get; private set; }


        public int First { get { return cells[0].VariableCoord; } private set { cells[0].VariableCoord = value; } }

        public int Last { get { return cells[Length - 1].VariableCoord; } private set { cells[Length - 1].VariableCoord = value; } }

        /**
         * Сoздает новый список
         */
        public Word(string word, int orientation, int wordCord, int initialVariableCoord)
        {

            Orient = orientation;
            WordCoord= wordCord;
            Length = word.Length;
            cells = new CharCell[Length];

            for (int i = 0; i < Length; i++)
            {
                cells[i] = new CharCell(word[i], initialVariableCoord + i);
            }
        }
        /**
         * Сoздает новый список, копируя существующий
         */
        public Word(Word word)
        {

            Orient = word.Orient;
            WordCoord = word.WordCoord;
            Length = word.Length;
            cells = new CharCell[Length];

            for (int i = 0; i < Length; i++)
            {
                cells[i] = new CharCell(word.Get(i));
            }
        }
        /**
         * Отрисовывает слово
         */
        
        /**
         * Увеличивает координаты слова и всех его символов на велечину самого максимального
         * смещения относительно нуля - |minCoordX| и |minCoordY| ( <0 )
         */
        public void IncreaseCoordinate(int minCoordX, int minCoordY)
        {
            if (Orient == Orientation.HORIZ)
            {
                WordCoord -= minCoordY;
                for (int i = 0; i < Length; i++)
                    cells[i].VariableCoord = cells[i].VariableCoord - minCoordX;
            }
            else
            {
                WordCoord -= minCoordX;
                for (int i = 0; i < Length; i++)
                    cells[i].VariableCoord = cells[i].VariableCoord - minCoordY;
            }
        }
        
        public CharCell Get(int i)
        {
            if (i >= 0 && i < Length) return cells[i];
            else return new CharCell();
        }



        public override string ToString()
        {
            string s = string.Empty;
            foreach (CharCell c in cells)
            {
                s += c.Value;
            }
            return s;
        }

    }
}
