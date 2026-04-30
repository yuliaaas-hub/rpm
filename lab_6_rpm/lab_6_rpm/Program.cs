// See https://aka.ms/new-console-template for more information
using lab_6_rpm;
using System.Drawing;

//Console.WriteLine("Hello, World!");


//IImage img = new ImageProxy("photo.png");
//img.Draw();

Console.WriteLine("====== Flyweight ======");
var charFactory = new CharacterFactory();
var char1 = charFactory.GetCharacter('F', "Arial", 12);
var char2 = charFactory.GetCharacter('A', "Century Gothic", 12);
Console.WriteLine($"Objects created: {charFactory.GetCount()}\n");



Console.WriteLine("===== Proxy =====");
IImage img1 = new ImageProxy("photochka.jpg");
IImage img2 = new ImageProxy("photo.png");

Console.WriteLine($"Width: {img1.GetWidth()}\n");

Console.WriteLine("Draw image:");
img2.Draw();



Console.WriteLine("===== Bridge =====");
IRenderingEngine screen = new ScreenRenderer();
IRenderingEngine printer = new PrintRenderer();

GraphicObject rect = new Restangle(20, 15, 150, 70, screen);
GraphicObject ellipse = new Elipse(25, 35, 60, 20, printer);
GraphicObject line = new Line(24, 25, 26, 27, screen);

rect.Draw();
ellipse.Draw();
line.Draw();



Console.WriteLine("--- Decorator ---");
IDrawable decorated = new BorderDecorator(rect, 3);
decorated = new ShadowDecorator(decorated, 10);
decorated = new TransparencyDecorator(decorated, 200);
decorated.Draw();
