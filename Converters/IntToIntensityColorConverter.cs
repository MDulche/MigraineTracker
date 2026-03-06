using System.Globalization;

namespace MigraineTracker.Converters
{
    public class IntToIntensityColorConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is not int intensity) return Colors.Transparent;
            return intensity <= 3 ? Color.FromArgb("#34D399")
                 : intensity <= 6 ? Color.FromArgb("#FBBF24")
                 : Color.FromArgb("#F87171");
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
            => throw new NotImplementedException();
    }
}
