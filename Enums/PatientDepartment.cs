using System.ComponentModel;
using LocalizedEnumBindingExample.Attributes;
using LocalizedEnumBindingExample.Converters;

namespace LocalizedEnumBindingExample.Enums
{
    [TypeConverter(typeof(EnumDescriptionConverter))]
    public enum PatientDepartment
    {
        [EnumItemDescription("Emergency")] 
        E1,
        
        [EnumItemDescription("Cardiology")] 
        C2,
        
        [EnumItemDescription("Urology")] 
        Urology,
        
        [EnumItemDescription("Neurology South Building")] 
        Neurology,

        [EnumItemDescription("Traumatology")]
        Traumatology
    }
}