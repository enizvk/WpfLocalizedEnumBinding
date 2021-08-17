using System;
using System.ComponentModel;
using LocalizedEnumBindingExample.MVVM;

namespace LocalizedEnumBindingExample.Attributes
{

    /// <summary>
    /// Specifies a description for a property or event with localisation support
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public sealed class EnumItemDescriptionAttribute : DescriptionAttribute
    {
        private Type? _resType;
        private string? _resName;
        private readonly LocalizableString _localisedDescirption = new("label_loc");

        public EnumItemDescriptionAttribute() : this(string.Empty)
        {
        }

        public EnumItemDescriptionAttribute(string description)
        {
            DescriptionValue = description;
        }

        public string? ResourceName
        {
            get => _resName;
            set
            {
                if (_resName == value)
                    return;

                _resName = value;
                _localisedDescirption.Value = value;
            }
        }

        public Type? ResourceType
        {
            get => _resType;
            set
            {
                if (_resType == value)
                    return;

                _resType = value;
                _localisedDescirption.ResourceType = value;
            }
        }

        public override string Description
        {
            get
            {
                try
                {
                    if (!string.IsNullOrEmpty(_resName) && !string.IsNullOrEmpty(_resType?.FullName))
                        return _localisedDescirption.GetLocalizableValue();
                }
                catch (Exception e)
                {
#if DEBUG
                    throw new Exception($"Cannot get localisation string for enum: {ResourceName}", e);
#else
                    return DescriptionValue;
#endif
                }

                return DescriptionValue;
            }
        }
    }
}