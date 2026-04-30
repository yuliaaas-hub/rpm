using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_6_rpm
{
    public abstract class GraphicObject : IDrawable
    {
        protected IRenderingEngine _engine;
        public GraphicObject(IRenderingEngine engine)
        {
            _engine = engine;
        }
        public abstract void Draw();
        public abstract void Move(float dx, float dy);
    }

    public class Restangle : GraphicObject
    {
        private float _x, _y, _width, _height;

        public Restangle( float x, float y, float w, float h, IRenderingEngine engine) : base(engine)
        {
            _x = x;
            _y = y;
            _width = w;
            _height = h;

        }

        public override void Draw() 
        {
            _engine.RenderRectangle(_x, _y, _width, _height);
        }
        public override void Move(float dx, float dy) 
        {
            _x += dx;
            _y += dy;
            Console.WriteLine($"Прямоугольниз перемещен ({dx}, {dy}). Новые координаты: ({_x}, {_y})");
        }
    }

    public class Elipse : GraphicObject
    {
        private float _x, _y, _radiusX, _radiusY;

        public Elipse( float x, float y, float rx, float ry, IRenderingEngine engine) : base(engine)
        {
            _x = x;
            _y = y;
            _radiusX = rx;
            _radiusY = ry;

        }

        public override void Draw()
        {
            _engine.RenderRectangle(_x, _y, _radiusX, _radiusY);
        }
        public override void Move(float dx, float dy)
        {
            _x += dx;
            _y += dy;
            Console.WriteLine($"круг перемещен ({dx}, {dy}). Новые координаты: ({_x}, {_y})");
        }
    }

    public class Line : GraphicObject
    {
        private float _x1, _y1, _x2, _y2;

        public Line( float x1, float y1, float x2, float y2, IRenderingEngine engine) : base(engine)
        {
            _x1 = x1;
            _y1 = y1;
            _x2 = x2;
            _y2 = y2;

        }

        public override void Draw()
        {
            _engine.RenderRectangle(_x1, _y1, _x2, _y2);
        }
        public override void Move(float dx, float dy)
        {
            _x1 += dx;
            _y1 += dy;
            _x2 += dx;
            _y2 += dy;
            Console.WriteLine($"Линия перемещен ({dx}, {dy}). Новые координаты: ({_x1},{_y1}) - ({_x2},{_y2})");
        }
    }
}
