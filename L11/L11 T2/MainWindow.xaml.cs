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
using L11;

namespace L11_T2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            ElementsCollections collection = new ElementsCollections(GridName.Children);
            AddEvent(collection);
        }

        private void AddEvent(ElementsCollections collections)
        {
            var button = (Button)collections.LogicElements.FirstOrDefault();
            button.Click += (something, args) => {
                var values = GetNumericValues(collections);
                GaussMethod.MainMethod(values);
            };
        }

        private double[,] GetNumericValues(ElementsCollections collections)
        {
            var result = new double[3, 4];
            var counter = 0;

            for(int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    var textbox = (TextBox)collections.TextBoxes[counter];
                    result[i,j] = double.Parse(textbox.Text);
                    counter++;
                }
            }

            return result;
        }
    }
}
