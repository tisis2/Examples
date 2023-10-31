using Avalonia.Controls;

namespace xStaticAsTag2;

public partial class MainWindow : Window
{
    public static readonly string HelloWorld = "Welcome to Avalonia from a static xaml tag!";
    
    public MainWindow()
    {
        InitializeComponent();
    }
}