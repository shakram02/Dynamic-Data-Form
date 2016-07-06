using System.Windows;
using System.Windows.Controls;

namespace DynamicDataForm
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
            PropertyCreator creator = new PropertyCreator(e.NewValue,MainPanel);

            // Add each string to a label faced by a text box
            MainPanel = creator.ObjectGrid;
        }
    }
}