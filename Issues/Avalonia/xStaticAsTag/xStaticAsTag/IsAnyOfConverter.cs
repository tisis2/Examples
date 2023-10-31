using System;
using System.Collections;
using System.Globalization;
using System.Linq;
using Avalonia;
using Avalonia.Data.Converters;

namespace xStaticAsTag;

public class IsAnyOfConverter : AvaloniaObject, IValueConverter
{
    public static readonly StyledProperty<IEnumerable> ValuesProperty =
        AvaloniaProperty.Register<IsAnyOfConverter, IEnumerable>(nameof(Values));

    public IEnumerable Values
    {
        get => GetValue(ValuesProperty);
        set => SetValue(ValuesProperty, value);
    }

    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return value is ValuesType.B;

        // return Values.OfType<object>()
        //     .Any(e => e.GetType() == value!.GetType()
        //               && e == value);
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}