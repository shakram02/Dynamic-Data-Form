using System.Collections.Generic;
using System.Windows;

namespace DynamicDataFormSample
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            List<SimpleClass> objects = new List<SimpleClass>(10);

            for (int i = 0; i < 10; i++)
            {
                objects.Add(new SimpleClass() { Name = "Name" + i, Number = i });
            }
            //DataGrid.ItemsSource = objects;
            this.DataContext = SimpleObject;
        }

        public SimpleClass SimpleObject { get; set; } = new SimpleClass();



        private void button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"Name:{SimpleObject.Name}, Number:{SimpleObject.Number}, IsTrue:{SimpleObject.IsTrue}");
        }
    }

    public class SimpleClass
    {
        public string Name { get; set; } = "Simp";
        public int Number { get; set; } = 23;
        public bool IsTrue { get; set; } = true;
    }
}
