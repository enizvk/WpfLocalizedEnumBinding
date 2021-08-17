using System.ComponentModel;
using LocalizedEnumBindingExample.Attributes;
using LocalizedEnumBindingExample.Converters;

namespace LocalizedEnumBindingExample.Enums
{
    [TypeConverter(typeof(EnumDescriptionConverter))]
    public enum PatientStatus
    {
        [EnumItemDescription(ResourceName = nameof(SR.PatientStatus_Urgent), ResourceType = typeof(SR))]
        Urgent,

        [EnumItemDescription(ResourceName = nameof(SR.PatientStatus_Severe), ResourceType = typeof(SR))]
        Severe,

        [EnumItemDescription(ResourceName = nameof(SR.PatientStatus_Mild), ResourceType = typeof(SR))]
        Mild,

        [EnumItemDescription(ResourceName = nameof(SR.PatientStatus_ForConsulting), ResourceType = typeof(SR))]
        ForConsulting
    }
}