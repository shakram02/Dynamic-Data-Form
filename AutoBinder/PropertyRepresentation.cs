using System;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;

namespace DynamicDataForm
{
    internal class PropertyRepresentation
    {
        private readonly PropertyInfo _property;
        private readonly PropertyUserControl objecPanel;
        private readonly PropertyType propType;
        private Object _bindingSource;

        public PropertyUserControl GetUserControl()
        {
            GenerateUserControl();
            return objecPanel;
        }

        internal PropertyRepresentation(PropertyInfo property, Object bindingSource)
        {
            objecPanel = new PropertyUserControl();
            this._property = property;
            _bindingSource = bindingSource;
        }

        private void GenerateUserControl()
        {
            objecPanel.NameTextBlock = new TextBlock { Text = _property.Name };

            // TODO manage different properties Int32, Boolean, String TODO add support for generics
            if (_property.PropertyType.Name == "Boolean")
            {
                CheckBox checkBox = new CheckBox();

                var binding = new Binding
                {
                    Source = _bindingSource,
                    Path = new PropertyPath(_property.Name),
                    Mode = BindingMode.TwoWay,  // Error two way binding requires Path or XPath
                    NotifyOnSourceUpdated = true,
                    NotifyOnTargetUpdated = true
                };
                // The target
                checkBox.SetBinding(ToggleButton.IsCheckedProperty, binding);

                objecPanel.ValueRepresenter = checkBox;
            }
            else
            {
                TextBox textBox = new TextBox();
                // The binding
                var binding = new Binding
                {
                    Source = _bindingSource,
                    Path = new PropertyPath(_property.Name),
                    Mode = BindingMode.TwoWay,  // Error two way binding requires Path or XPath
                    NotifyOnSourceUpdated = true,
                    NotifyOnTargetUpdated = true
                };

                // The target
                textBox.SetBinding(TextBox.TextProperty, binding);

                objecPanel.ValueRepresenter = textBox;
            }

            //else
            //{
            //    objecPanel.Children.Add(new TextBlock { Text = "Not supported property" });
            //}
        }
    }
}