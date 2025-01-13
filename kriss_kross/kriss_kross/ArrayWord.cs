using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace krisskross
{
    public class ArrayWord<E> : List<E>
    {

        //private int minCoordX = 0;

        public int MinX { get;  set; } = 0;

        public int MaxX { get;  set; } = 0;

        public int MinY {  get;  set; } = 0;

        public int MaxY { get;  set; } = 0;

        public int Width { get;  set; } = 0;

        public int Height { get;  set; } = 0;

        public int IntersectCount { get;  set; } = 0;


        public ArrayWord() : base(0) { }

        public ArrayWord(int initialCapacity) : base(initialCapacity) { }
        
        public ArrayWord(ArrayWord<Word> arrayWord) : base (arrayWord.Count)
        {
            //super(arrayWord.size());
            MinX = arrayWord.MinX;
            MinY = arrayWord.MinY;
            Width = arrayWord.Width;
            Height = arrayWord.Height;
            IntersectCount = arrayWord.IntersectCount;
        }
        
        
        public void Reset() { MinX = 0; MinY = 0; }




    }
}
