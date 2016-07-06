using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;

namespace DynamicDataForm
{
    public class PropertyCreator
    {
        private readonly Object _target;
        private readonly StackPanel objStackPanel;

        private List<Type> SupportedTypes = new List<Type>
        {
            typeof(string), typeof(int)
        };

        /// <summary>Creates a view for a given object</summary>
        /// <param name="target">Object that will be represented in the view</param>
        /// <param name="objStackPanel">
        /// The grid that contains user controls representing the object's properties
        /// </param>
        public PropertyCreator(Object target, StackPanel objStackPanel)
        {
            _target = target;
            this.objStackPanel = objStackPanel;
            GenerateView();
        }

        public PropertyCreator(Object target) : this(target, new StackPanel())
        {

        }

        private void GenerateView()
        {
            // Read the properties of the new object Define the property types
            List<PropertyInfo> props = _target.GetType().GetProperties().Where(p => p.CanRead).ToList();

            int propCount = 0;
            foreach (PropertyInfo prop in props)
            {
                PropertyRepresentation pr = new PropertyRepresentation(prop, _target);

                Grid propertyGrid = new Grid();
                propertyGrid.ColumnDefinitions.Add(new ColumnDefinition());
                propertyGrid.ColumnDefinitions.Add(new ColumnDefinition());
                propertyGrid.Margin = new Thickness(5);

                //_objGrid.RowDefinitions.Add(new RowDefinition());
                var propertyUserControl = pr.GetUserControl();

                Grid.SetColumn(propertyUserControl.NameTextBlock, 0);
                Grid.SetColumn(propertyUserControl.ValueRepresenter, 1);

                Grid.SetRow(propertyUserControl.NameTextBlock, 0);
                Grid.SetRow(propertyUserControl.ValueRepresenter, 1);


                propertyGrid.Children.Add(propertyUserControl.NameTextBlock);
                propertyGrid.Children.Add(propertyUserControl.ValueRepresenter);

                objStackPanel.Children.Add(propertyGrid);
            }
        }

        public StackPanel ObjectGrid => objStackPanel;
    }
}