using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfLearn
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (this.FindResource("human") is Human h)
            {
                MessageBox.Show(h.Child.Name);
            }
        }
    }

    [TypeConverter(typeof(NameToHumanTypeconverter))]
    public class Human
    {
        public string Name { get; set; }
        public Human Child { get; set; }
    }

    public class NameToHumanTypeconverter : TypeConverter
    {
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            string name = value.ToString();
            Human child = new Human
            {
                Name = name
            };
            return child;
        }
    }
}