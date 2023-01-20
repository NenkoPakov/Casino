namespace Casino.Attributes
{
    public class StringValueAttribute : Attribute
    {
        public string Value { get; init; }

        public StringValueAttribute(string value)
        {
            Value = value;
        }
    }
}
