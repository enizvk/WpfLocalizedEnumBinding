# WPF Enum binding and localization example #

Simple example project on how to bind enums directly in XAML and use resource strings to get localised strings without any external dependancies.

### Key points ###


* `SR.resx` is the default app language resource file
* `SR.bg-BG.resx` is an additional language resource file.
* you can add as many as you need

All resource files should be compiled with "PublicResXFileCodeGenerator" tool. 
This is required because by default all resource keys are marked with internal modifier. 
We need to make them public to be able to use them across our project.

Add "PublicResXFileCodeGenerator" to `Custom tool` section in resource file properties 

 You can use [ResXManager](https://marketplace.visualstudio.com/items?itemName=TomEnglert.ResXManager) extension to ease your work with localized strings

## Quick tips  ##

**EnumBindingSourceExtension** will convert and bind enum values to ItemSource property of any control.

*Syntax:*

`ItemsSource="{Binding Source={mvvm:EnumBindingSource {x:Type yourEnumNamespace:YourEnumType}}}"`

Enums should be decorated with **EnumDescriptionConverter** 

Enum items should be should be decorated with **EnumItemDescriptionAttribute**  .It will handle localization logic. 

*Syntax:*


```

[TypeConverter(typeof(EnumDescriptionConverter))]
public enum YourEnumType
{
    [EnumItemDescription("Hello will be shown in WPF")] 
	Hello,
	
	[EnumItemDescription("WORLD will be shown in WPF")] 
	World,
} 

```


## Localized approach ##

```
[TypeConverter(typeof(EnumDescriptionConverter))]
public enum YourEnumType
{
    [EnumItemDescription(ResourceName = nameof(SR.Hello_will_be_shown_in_WPF), ResourceType = typeof(SR))]
	Hello,
	
	[EnumItemDescription(ResourceName = nameof(SR.World_will_be_shown_in_WPF), ResourceType = typeof(SR))]
	World,
} 

```
