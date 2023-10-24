using Avalonia.Controls;
using Avalonia.Interactivity;

namespace FocusNumericUpDown;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void OnClickFocusTextBox(object? sender, RoutedEventArgs e)
    {
        TextBox.Focus();
    }

    private void OnClickFocusButton(object? sender, RoutedEventArgs e)
    {
        Button.Focus();
    }

    private void OnClickFocusCheckBox(object? sender, RoutedEventArgs e)
    {
        CheckBox.Focus();
    }

    private void OnClickFocusNumericUpDown(object? sender, RoutedEventArgs e)
    {
        NumericUpDown.Focus();
    }
}