using System;
using System.Collections;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

namespace WPFStaticAsTag;

[ContentProperty(nameof(Values))]
public class IsAnyOfConverter : DependencyObject, IValueConverter
{
    public static readonly DependencyProperty ValuesProperty = DependencyProperty.Register(
        nameof(Values), typeof(IList), typeof(IsAnyOfConverter), new PropertyMetadata(new ArrayList()));

    public IList Values
    {
        get { return (IList)GetValue(ValuesProperty); }
        set { SetValue(ValuesProperty, value); }
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