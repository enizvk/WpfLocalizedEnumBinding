using System;

namespace LocalizedEnumBindingExample.MVVM
{
    public class EnumBindingSourceExtension : System.Windows.Markup.MarkupExtension
    {
        private readonly Type? _type;

        public EnumBindingSourceExtension() { }

        public EnumBindingSourceExtension(Type enumType)
        {
            EnumType = enumType;
        }

        public Type? EnumType
        {
            get => _type;
            init
            {

                if (value == _type)
                    return;

                if (value is not null)
                {
                    Type t = Nullable.GetUnderlyingType(value) ?? value;

                    if (!t.IsEnum)
                        throw new ArgumentException("Not an enum type");
                }

                _type = value;
            }
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            if (_type is null)
                throw new InvalidOperationException("Enum type is not specified.");

            Type t = Nullable.GetUnderlyingType(_type) ?? _type;
            Array values = Enum.GetValues(t);

            if (t == _type)
                return values;

            //Return enum values as array
            Array tmp = Array.CreateInstance(t, values.Length + 1);
            values.CopyTo(tmp, 1);
            return tmp;

        }
    }
}
