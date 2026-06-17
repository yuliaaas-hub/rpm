using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using task_3._1_rpm.CircleColor;
using task_3._1_rpm.Creators;
using task_3._1_rpm.SquareColor;
using task_3._1_rpm.TriangleColor;

namespace task_3._1_rpm
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ColorComboBox.SelectedIndex = 0;
            CreateFigures("Красный");
        }

        private void ColorComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Получаем выбранный элемент
            if (ColorComboBox.SelectedItem is ComboBoxItem selectedItem)
            {
                string color = selectedItem.Content.ToString();
                CreateFigures(color);
            }
        }

        private void CreateFigures(string color)
        {
            // Очищаем панель с фигурами
            ShapesPanel.Children.Clear();

            // Создаём фабрику в зависимости от выбранного цвета
            CircleCreator circleCreator;
            SquareCreator squareCreator;
            TriangleCreator triangleCreator;

            switch (color)
            {
                case "Красный":
                    circleCreator = new RedCircleCreator();
                    squareCreator = new RedSquareCreator();
                    triangleCreator = new RedTriangleCreator();
                    break;

                case "Синий":
                    circleCreator = new BlueCircleCreator();
                    squareCreator = new BlueSquareCreator();
                    triangleCreator = new BlueTriangleCreator();
                    break;

                case "Зеленый":
                    circleCreator = new GreenCircleCreator();
                    squareCreator = new GreenSquareCreator();
                    triangleCreator = new GreenTriangleCreator();
                    break;

                default:
                    return;
            }

            // Создаём фигуры через фабричные методы и добавляем на панель
            ShapesPanel.Children.Add(circleCreator.CreateCircle().CreateUIElement(80));
            ShapesPanel.Children.Add(squareCreator.CreateSquare().CreateUIElement(80));
            ShapesPanel.Children.Add(triangleCreator.CreateTriangle().CreateUIElement(80));
        }
    }
}