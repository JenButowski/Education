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

namespace L11_T3
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            ElementsCollections elementsCollection = new ElementsCollections(grid.Children);
            var button = (Button)elementsCollection.LogicElements.Last();
            button.Click += (something, args) => 
            {
                var matrix_1 = GUILogic.GetMatrix(3, GUILogic.GetValues(elementsCollection, "AMatrix"));
                var matrix_2 = GUILogic.GetMatrix(3, GUILogic.GetValues(elementsCollection, "BMatrix"));

                var Tmatrix_1 = TransposeMethod.Transpose(matrix_1);
                var Tmatrix_2 = TransposeMethod.Transpose(matrix_2);

                var result = MatrixSum.GetSum(Tmatrix_1, Tmatrix_2);
                GUILogic.PrintResult(result, elementsCollection);
            };            
        }
    }
}
