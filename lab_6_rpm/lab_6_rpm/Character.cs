using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_6_rpm
{
    public class Character
    {
        public char _symbol; // сам символ
        public string _font; // шрифт
        public int _fontSize; // размер шрифтра
        public int positionX; // положение по X
        public int positionY; // положение по Y

        public Character(char symbol, string font, int fontsize)
        {
            _symbol=symbol;
            _font=font;
            _fontSize=fontsize;

        }
    }
}
