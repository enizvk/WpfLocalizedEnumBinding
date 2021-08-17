using System;
using System.ComponentModel;

namespace LocalizedEnumBindingExample.Converters
{
    public class EnumDescriptionConverter : EnumConverter
    {
        public EnumDescriptionConverter(Type type)
            : base(type) { }

        public override object? ConvertTo(ITypeDescriptorContext context,
                                          System.Globalization.CultureInfo culture,
                                          object? value,
                                          Type destinationType)
        {
            if (destinationType != typeof(string))
                return base.ConvertTo(context, culture, value, destinationType);

            string? val = value?.ToString();
            
            if (string.IsNullOrEmpty(val))
                throw new ArgumentNullException(nameof(value),"Converter string value should not be null");

            if (value?.GetType().GetField(val) is not { } fi)
                return string.Empty;

            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            return attributes.Length > 0 && !string.IsNullOrEmpty(attributes[0].Description)
                ? attributes[0].Description
                : val;
        }
    }
}