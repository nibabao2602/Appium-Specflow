using System;

[AttributeUsage(AttributeTargets.Field)]
public class EnumDescriptionAttribute : Attribute
{
    private readonly string[] descriptions;

    public EnumDescriptionAttribute(string[] descriptions)
    {
        this.descriptions = descriptions;
    }

    public string[] Descriptions
    {
        get { return descriptions; }
    }
}

public static class EnumExtensions
{
    public static string[] GetDescriptions(this Enum value)
    {
        var fieldInfo = value.GetType().GetField(value.ToString());

        var attributes = fieldInfo.GetCustomAttributes(
            typeof(EnumDescriptionAttribute), false) as EnumDescriptionAttribute[];

        if (attributes != null && attributes.Length > 0)
        {
            return attributes[0].Descriptions;
        }
        else
        {
            return new string[] { value.ToString() };
        }
    }
}
