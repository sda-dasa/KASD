using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace krisskross
{
    public class CharCell
    {

        public int VariableCoord { get; set; }
        public char Value {  get; set; }
        public static int CELL_SIZE = 30;
        /**
         * Конструктор по умолчанию
         */
        public CharCell()
        {
            Value = ' ';
            VariableCoord = 0;
        }
        /**
         * Сoздает новую клетку с символом
         */
        public CharCell(char value, int variableCoord)
        {
            Value = value;
            VariableCoord = variableCoord;
        }
        /**
         * Сoздает новую клетку, копируя существуюшую
         */
        public CharCell(CharCell cell)
        {
            this.Value = cell.Value;
            VariableCoord = cell.VariableCoord;
        }



    }
}
