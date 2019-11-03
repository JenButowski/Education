using L11;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace L11_T3
{
    class GUILogic
    {
        public static SquareMatrix GetMatrix(int n, string[] values)
        {
            var matrix = new SquareMatrix(n);
            var counter = 0;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (values.Length > counter)
                    {
                        matrix.MatrixView[i, j] = double.Parse(values[counter]);
                        counter++;
                    }
                }
            }

            return matrix;
        }

        public static string[] GetValues(ElementsCollections elementsCollection, string textboxName)
        {
            foreach(var element in elementsCollection.TextBoxes)
            {
                var textbox = (TextBox)element;

                if(!string.IsNullOrEmpty(textbox.Text) && textbox.Name == textboxName)
                {
                    var values = textbox.Text.Split(' ');
                    return values;
                }
            }

            return null;
        }

        public static void PrintResult(SquareMatrix matrix, ElementsCollections elementsCollection)
        {
            foreach(var element in elementsCollection.TextBoxes)
            {
                var textbox = (TextBox)element;

                if(textbox.Name == "Result")
                {
                    textbox.Text = GetStringResult(matrix);
                }
            }           
        }

        private static string GetStringResult(SquareMatrix matrix)
        {
            string result = "";

            foreach(var element in matrix.MatrixView)
            {
                result = $"{result} {element}";
            }

            return result;
        }
    }
}
