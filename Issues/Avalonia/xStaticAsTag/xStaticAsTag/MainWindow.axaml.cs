using System;
using System.Collections.Generic;
using System.Linq;
using Avalonia;
using Avalonia.Controls;

namespace xStaticAsTag;

public partial class MainWindow : Window
{
    private IEnumerable<ValuesType> values = Enumerable.Empty<ValuesType>();

    public static readonly DirectProperty<MainWindow, IEnumerable<ValuesType>> ValuesProperty =
        AvaloniaProperty.RegisterDirect<MainWindow, IEnumerable<ValuesType>>(
            nameof(Values),
            o => o.Values,
            (o, v) => o.Values = v);

    public IEnumerable<ValuesType> Values
    {
        get => values;
        set => SetAndRaise(ValuesProperty, ref values, value);
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