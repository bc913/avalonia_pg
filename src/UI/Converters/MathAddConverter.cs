using System;
using System.Globalization;
using Avalonia.Data.Converters;

namespace Bcan.Pg.UI.Converters;

public class MathAddConverter : IValueConverter
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="value">TThe value which is provided by the binding</param>
    /// <param name="targetType"></param>
    /// <param name="parameter">Optional</param>
    /// <param name="culture"></param>
    /// <returns></returns>
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return (decimal?)value + (decimal?)parameter;
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return (decimal?)value - (decimal?)parameter;
    }
}