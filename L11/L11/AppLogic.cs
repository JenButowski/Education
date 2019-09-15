using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace L11
{
    static class AppLogic
    {
        private static void ReturnResult(ElementsCollections elementsCollections)
        {
            var cone = CreateCone(elementsCollections);

            try
            {
                for(int i = 0; i < elementsCollections.LogicElements.Capacity - 1; i++)
                {
                    if(elementsCollections.LogicElements[i].GetType() == new CheckBox().GetType())
                    {
                        var checktbox = (CheckBox)elementsCollections.LogicElements[i];
                        if(checktbox.IsChecked != false)
                        {
                            if (checktbox.Name == "Mass" && cone != null)
                            {
                                MessageBox.Show(cone.GetMass().ToString());
                                break;
                            }
                            else if (checktbox.Name == "Volume" && cone != null)
                            {
                                MessageBox.Show(cone.GetVolume().ToString());
                                break;
                            }
                            else
                                throw new Exception("No data");
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private static Cone CreateCone(ElementsCollections elementsCollections)
        {
            try
            {
                double radius = 0;
                double hight = 0;
                double density = 0;

                if (IsRightData(elementsCollections) != false)
                {
                    for(int i = 0; i < elementsCollections.TextBoxes.Capacity - 1; i++)
                    {
                        var textbox = (TextBox)elementsCollections.TextBoxes[i];
                        if (textbox.Name == "Radius")
                            radius = double.Parse(textbox.Text);
                        else if(textbox.Name == "Hight")
                            hight = double.Parse(textbox.Text);
                        else
                            density = double.Parse(textbox.Text);
                    }
                    return new Cone(hight, radius, density);
                }
            }
            catch
            {
            }
            return null;
        }

        private static bool IsRightData(ElementsCollections elementsCollections)
        {
            try
            {
                for (int i = 0; i < elementsCollections.TextBoxes.Capacity - 1;)
                {
                    var textbox = (TextBox)elementsCollections.TextBoxes[i];
                    if (textbox.Text != "")
                        i++;
                    else
                        throw new Exception();
                }
            }
            catch
            {
                MessageBox.Show("Неккоректно введены данные");
            }
            return true;
        }

        public static void AddEvent(ElementsCollections elementsCollections)
        {
            for(int i = 0; i < elementsCollections.LogicElements.Capacity - 1; i++)
            {
                if(elementsCollections.LogicElements[i].GetType() == new Button().GetType())
                {
                    var button = (Button)elementsCollections.LogicElements[i];
                    button.Click += (somthing, args) => { ReturnResult(elementsCollections); };
                    elementsCollections.LogicElements[i] = button;
                }
            }
        }
    }
}
