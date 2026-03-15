using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using task_3._2_rpm.Figures;

namespace task_3._2_rpm.FactoryColors
{
    public class BlueFactory : IFigureFactory
    {
        public Circle CreateCircle() => new Circle
        {
            Color =
        Colors.Blue
        };
        public Square CreateSquare() => new Square
        {
            Color =
        Colors.Blue
        };
        public Triangle CreateTriangle() => new Triangle
        {
            Color
        = Colors.Blue
        };
    }
}
