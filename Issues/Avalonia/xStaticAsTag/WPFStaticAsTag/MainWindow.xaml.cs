using System;
using System.Collections.Generic;
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

namespace WPFStaticAsTag;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public static readonly DependencyProperty ValuesProperty = DependencyProperty.Register(
        nameof(Values), typeof(IEnumerable<ValuesType>), typeof(MainWindow),
        new PropertyMetadata(default(IEnumerable<ValuesType>)));

    public IEnumerable<ValuesType> Values
    {
        get { return (IEnumerable<ValuesType>)GetValue(ValuesProperty); }
        set { SetValue(ValuesProperty, value); }
    }

    public MainWindow()
    {
        InitializeComponent();
        Values = Enum.GetValues<ValuesType>();
    }
}

public enum ValuesType
{
    A,
    B,
    C,
    D
}