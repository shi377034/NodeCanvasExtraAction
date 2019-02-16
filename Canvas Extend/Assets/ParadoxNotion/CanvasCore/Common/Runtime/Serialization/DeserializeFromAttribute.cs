using System;

namespace ParadoxNotion.Serialization
{

    public class DeserializeFromAttribute : Attribute
    {
        readonly public string[] previousTypeFullNames;
        public DeserializeFromAttribute(params string[] previousTypeNames) {
            this.previousTypeFullNames = previousTypeNames;
        }
    }
}