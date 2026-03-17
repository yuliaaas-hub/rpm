using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task_3._1_rpm.Creators;
using System.Windows.Media;

namespace task_3._1_rpm.SquareColor
{
    public class RedSquareCreator : SquareCreator
    {
        public override Square CreateSquare() => new Square { Color = Color.FromRgb(255,0,0) };
    }
}
