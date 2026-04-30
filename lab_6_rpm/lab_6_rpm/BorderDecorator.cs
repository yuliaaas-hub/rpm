using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_6_rpm
{
    // Декоратор рамки
    public class BorderDecorator : DrawableDecorator
    {
        private int _borderWidth;

        public BorderDecorator(IDrawable wrappee, int borderWidth) : base(wrappee)

        {
            _borderWidth = borderWidth;
        }

        public override void Draw()
        {
            base.Draw();
            Console.Write($" [Рамка толщиной {_borderWidth}]");
        }
    }

    public class ShadowDecorator : DrawableDecorator
    {
        private int _ShadowWidth;

        public ShadowDecorator(IDrawable wrappee, int shWidth) : base(wrappee)

        {
            _ShadowWidth = shWidth;
        }

        public override void Draw()
        {
            base.Draw();
            Console.Write($" [Рамка толщиной {_ShadowWidth}]");
        }
    }

    public class TransparencyDecorator : DrawableDecorator
    {
        private int _transparencyWidth;

        public TransparencyDecorator(IDrawable wrappee, int trWidth) : base(wrappee)

        {
            _transparencyWidth = trWidth;
        }

        public override void Draw()
        {
            base.Draw();
            Console.Write($" [Рамка толщиной {_transparencyWidth}]");
        }
    }
}
