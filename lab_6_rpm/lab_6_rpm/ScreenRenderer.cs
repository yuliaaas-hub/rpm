using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_6_rpm
{
    // Интерфейс реализатора (способ отрисовки)
    public interface IRenderingEngine
    {
        void BeginRender();
        void EndRender();
        void RenderRectangle(float x, float y, float width, float
        height);

        void RenderEllipse(float x, float y, float radiusX, float radiusY);

        void RenderLine(float x1, float y1, float x2, float y2);
    }

    // Конкретная реализация 1: экранный рендеринг
    public class ScreenRenderer : IRenderingEngine
    {
        public void BeginRender()
        {
            Console.WriteLine("[Screen] Начало рендеринга");
        }

        public void EndRender()
        {
            Console.WriteLine("[Screen] Конец рендеринга");
        }

        public void RenderRectangle(float x, float y, float
        width, float height)
        {
            Console.WriteLine($"[Screen] Прямоугольник ({x},{y}) размер { width} x{ height} ");
        }

        public void RenderEllipse(float x, float y, float radiusX, float radiusY)

        {

            Console.WriteLine($"[Screen] Эллипс ({x},{y}) радиусы { radiusX},{ radiusY} ");
        
}

        public void RenderLine(float x1, float y1, float x2, float y2)
        {
            Console.WriteLine($"[Screen] Линия от ({x1},{y1}) до ({ x2},{ y2})");
        }
    }

    public class PrintRenderer : IRenderingEngine
    {
        public void BeginRender()
        {
            Console.WriteLine("[Print] Начало рендеринга");
        }

        public void EndRender()
        {
            Console.WriteLine("[Print] Конец рендеринга");
        }

        public void RenderRectangle(float x, float y, float
        width, float height)
        {
            Console.WriteLine($"[Print] Прямоугольник ({x},{y}) размер {width} x{height} ");
        }

        public void RenderEllipse(float x, float y, float radiusX, float radiusY)

        {

            Console.WriteLine($"[Print] Эллипс ({x},{y}) радиусы {radiusX},{radiusY} ");

        }

        public void RenderLine(float x1, float y1, float x2, float y2)
        {
            Console.WriteLine($"[Print] Линия от ({x1},{y1}) до ({x2},{y2})");
        }
    }
}
