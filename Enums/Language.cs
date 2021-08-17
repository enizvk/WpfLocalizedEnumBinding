using System.ComponentModel;
using LocalizedEnumBindingExample.Attributes;
using LocalizedEnumBindingExample.Converters;

namespace LocalizedEnumBindingExample.Enums
{
    [TypeConverter(typeof(EnumDescriptionConverter))]
    public enum Language
    {
        [EnumItemDescription("English")]
        En,
        
        [EnumItemDescription("Bulgarian")]
        Bg
    }
}
