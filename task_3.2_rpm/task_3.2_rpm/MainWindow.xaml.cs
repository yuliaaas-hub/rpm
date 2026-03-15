using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using task_3._2_rpm.FactoryColors;


namespace task_3._2_rpm
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        
        private IFigureFactory currentFactory;
        private void comboBox_SelectedIndexChanged(object sender,
        EventArgs e)
        {
            ShapesPanel.Children.Clear();
            string color = ((TextBlock)comboBox.SelectedItem).Text;

            switch (color)
            {
                case "Красный":
                    currentFactory = new RedFactory();
                    break;
                case "Синий":
                    currentFactory = new BlueFactory();
                    break;
                case "Зеленый":
                    currentFactory = new GreenFactory();
                    break;
                //другие цвета
                default:
                    return;
            }

            //Создаем фигуры, используя только абстракцию IFigureFactory
            var circle = currentFactory.CreateCircle();
            var square = currentFactory.CreateSquare();
            var triangle = currentFactory.CreateTriangle();

            ShapesPanel.Children.Add(circle.CreateUIElement());
            ShapesPanel.Children.Add(square.CreateUIElement());
            ShapesPanel.Children.Add(triangle.CreateUIElement());
        }
    }
}
