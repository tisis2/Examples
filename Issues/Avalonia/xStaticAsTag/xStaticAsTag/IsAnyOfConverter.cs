using System;
using System.Collections;
using System.Globalization;
using System.Linq;
using Avalonia;
using Avalonia.Data.Converters;
using Avalonia.Metadata;

namespace xStaticAsTag;

public class IsAnyOfConverter : AvaloniaObject, IValueConverter
{
    public static readonly StyledProperty<IEnumerable> ValuesProperty =
        AvaloniaProperty.Register<IsAnyOfConverter, IEnumerable>(nameof(Values), defaultValue:new ArrayList());

    [Content]
    public IEnumerable Values
    {
        get => GetValue(ValuesProperty);
        set => SetValue(ValuesProperty, value);
    }

    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return value is not null && Values.OfType<object>()
            .Any(e =>
            {
                var sameType = e.GetType() == value.GetType();
                var sameValue = e.Equals(value);
                return sameType && sameValue;
            });
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}