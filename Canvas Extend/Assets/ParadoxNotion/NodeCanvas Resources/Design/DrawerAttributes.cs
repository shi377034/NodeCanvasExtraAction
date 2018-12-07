using UnityEngine;
using System.Collections;
using System;

namespace ParadoxNotion.Design
{
    [AttributeUsage(AttributeTargets.Field)]
    public class TexturePropertyNameAttribute: DrawerAttribute
    {
        readonly public string fieldName;
        public TexturePropertyNameAttribute(string fieldName)
        {
            this.fieldName = fieldName;
        }
    }
    public class ShowIfEnumAttribute: DrawerAttribute
    {
        readonly public string fieldName;
        readonly public int checkValue;
        public ShowIfEnumAttribute(string fieldName,int checkValue)
        {
            this.fieldName = fieldName;
            this.checkValue = checkValue;
        }
    }
}
