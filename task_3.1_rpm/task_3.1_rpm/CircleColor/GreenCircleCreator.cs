using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task_3._1_rpm.Creators;
using System.Windows.Media;

namespace task_3._1_rpm.CircleColor
{
    public class GreenCircleCreator : CircleCreator
    {
        public override Circle CreateCircle() => new Circle { Color = Color.FromRgb(0,255,0) };
    }
}
