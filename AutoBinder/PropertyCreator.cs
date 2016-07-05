using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Controls;

namespace AutoBinder
{
    public class PropertyCreator
    {
        private readonly Object _target;
        private readonly Grid _objGrid;

        private List<Type> SupportedTypes = new List<Type>
        {
            typeof(string), typeof(int)
        };

        /// <summary>Creates a view for a given object</summary>
        /// <param name="target">Object that will be represented in the view</param>
        /// <param name="objGrid">
        /// The grid that contains user controls representing the object's properties
        /// </param>
        public PropertyCreator(Object target, Grid objGrid)
        {
            _target = target;
            _objGrid = objGrid;
            GenerateView();
        }

        public PropertyCreator(Object target) : this(target, new Grid())
        {

        }

        private void GenerateView()
        {
            // Read the properties of the new object Define the property types
            List<PropertyInfo> props = _target.GetType().GetProperties().Where(p => p.CanRead).ToList();

            Grid propertyGrid = new Grid();
            propertyGrid.ColumnDefinitions.Add(new ColumnDefinition());
            propertyGrid.ColumnDefinitions.Add(new ColumnDefinition());

            // 2 columns for a tabular view
            _objGrid.ColumnDefinitions.Add(new ColumnDefinition());
            _objGrid.ColumnDefinitions.Add(new ColumnDefinition());

            int propCount = 0;
            foreach (PropertyInfo prop in props)
            {
                PropertyRepresentation pr = new PropertyRepresentation(prop, _target);
                _objGrid.RowDefinitions.Add(new RowDefinition());
                _objGrid.RowDefinitions.Add(new RowDefinition());
                var propertyUserControl = pr.GetUserControl();

                Grid.SetColumn(propertyUserControl.NameTextBlock, 0);
                Grid.SetColumn(propertyUserControl.ValueTextBox, 1);

                Grid.SetRow(propertyUserControl.NameTextBlock, propCount);
                Grid.SetRow(propertyUserControl.ValueTextBox, propCount);

                _objGrid.Children.Add(propertyUserControl.NameTextBlock);
                _objGrid.Children.Add(propertyUserControl.ValueTextBox);
                propCount++;
            }
        }

        public Grid ObjectGrid => _objGrid;
    }
}