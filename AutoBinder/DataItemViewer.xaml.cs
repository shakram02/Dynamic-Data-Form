using System.Windows;
using System.Windows.Controls;

namespace AutoBinder
{
    /// <summary>Interaction logic for UserControl1.xaml</summary>
    public partial class AutoBinder : UserControl
    {
        public AutoBinder()
        {
            InitializeComponent();

            DataContextChanged += DisplayPanel_DataContextChanged;
        }

        private void DisplayPanel_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            PropertyCreator creator = new PropertyCreator(e.NewValue,MainGrid);

            // Add each string to a label faced by a text box
            MainGrid = creator.ObjectGrid;
        }
    }
}