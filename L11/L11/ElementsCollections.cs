using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace L11
{
    public class ElementsCollections
    {
        public List<UIElement> TextBoxes { get; } = new List<UIElement>();

        public List<UIElement> LogicElements { get; } = new List<UIElement>();

        public ElementsCollections(UIElementCollection collection)
        {
            FillinTextBoxes(collection);
            FillinLogicElements(collection);
        }

        private void FillinTextBoxes(UIElementCollection elementCollection)
        {
            try
            {
                foreach(var element in elementCollection)
                {
                    if (element.GetType() == new TextBox().GetType())
                        TextBoxes.Add((UIElement)element);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FillinLogicElements(UIElementCollection elementCollection)
        {
            try
            {
                foreach (var element in elementCollection)
                {
                    if (element.GetType() == new Button().GetType() || element.GetType() == new CheckBox().GetType())
                        LogicElements.Add((UIElement)element);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
