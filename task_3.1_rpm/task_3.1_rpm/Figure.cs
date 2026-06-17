using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace task_3._1_rpm
{
    public abstract class Figure
    {
        public Color Color { get; set; }
        // Метод, создающий визуальный элемент для отображения
        public abstract UIElement CreateUIElement(double size = 50);
    }
    
}
