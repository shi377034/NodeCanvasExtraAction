using UnityEditor;
using System.Reflection;
using System.Linq;
using UnityEngine;
using System.Collections.Generic;
using NodeCanvas.Framework;
using NodeCanvas.Editor;

namespace ParadoxNotion.Design
{
    public class TexturePropertyNameDrawer : AttributeDrawer<TexturePropertyNameAttribute>
    {
        public override object OnGUI(GUIContent content, object instance)
        {
            var targetField = context.GetType().GetField(attribute.fieldName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (targetField != null)
            {
                var fieldValue = targetField.GetValue(context);
                if(fieldValue is BBParameter)
                {
                    fieldValue = ((BBParameter)fieldValue).value;
                }
                List<object> options = new List<object>();
                object selected = instance;
                if(instance is BBParameter)
                {
                    selected = ((BBParameter)instance).value;
                }
                if (fieldValue is Material)
                {
                    foreach (var name in ((Material)fieldValue).GetTexturePropertyNames())
                    {
                        options.Add(name);
                    }
                    if (instance is BBParameter)
                    {
                        ((BBParameter)instance).value = EditorUtils.Popup(content, selected, options);
                        return instance;
                    }
                    return EditorUtils.Popup(content, selected, options);
                }else if(fieldValue is Renderer)
                {
                    foreach(var name in ((Renderer)fieldValue).materials.Select(x => x.GetTexturePropertyNames()))
                    {
                        options.AddRange(name);
                    }
                    if (instance is BBParameter)
                    {
                        ((BBParameter)instance).value = EditorUtils.Popup(content, selected, options);
                        return instance;
                    }
                    return EditorUtils.Popup(content, selected, options);
                }       
            }
            return MoveNextDrawer();
        }
    }
    public class ShowIfEnumDrawer : AttributeDrawer<ShowIfEnumAttribute>
    {
        public override object OnGUI(GUIContent content, object instance)
        {
            var targetField = context.GetType().GetField(attribute.fieldName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (targetField != null)
            {
                var fieldValue = (int)System.Convert.ChangeType(targetField.GetValue(context), typeof(int));
                if ((fieldValue & attribute.checkValue) <= 0)
                {
                    return instance; //return instance without any editor (thus hide it)
                }
            }
            return MoveNextDrawer();
        }
    }
}