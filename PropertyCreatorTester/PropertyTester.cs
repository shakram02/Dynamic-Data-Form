using System.Windows.Controls;
using DynamicDataForm;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PropertyCreatorTester
{
    [TestClass]
    public class PropertyTester
    {
        [TestMethod]
        public void TestMethod1()
        {
            PropertyCreator teCreator = new PropertyCreator(new SimpleClass());
            var result = teCreator.ObjectGrid;

            var textBlock = result.Children[0] as TextBlock;
            var textBox = result.Children[1] as TextBox;
            Assert.AreEqual(2, result.Children.Count);
            Assert.AreEqual("Name", textBlock.Text);
            Assert.AreEqual("Simp", textBox.Text);
        }

        [TestMethod]
        public void TestMethod2()
        {
            PropertyCreator teCreator = new PropertyCreator(new SimpleClass());
            var result = teCreator.ObjectGrid;
        }

        private class SimpleClass
        {
            public string Name { get; set; } = "Simp";
            public int Number { get; set; } = 23;
        }
    }
}
