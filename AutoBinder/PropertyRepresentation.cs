using System;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace AutoBinder
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

            objecPanel.ValueTextBox = textBox;

            //else
            //{
            //    objecPanel.Children.Add(new TextBlock { Text = "Not supported property" });
            //}
        }
    }
}