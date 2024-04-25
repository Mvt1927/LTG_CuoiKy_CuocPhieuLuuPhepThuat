using System;
using System.Reflection;
using System.Runtime.Serialization.Formatters;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts
{

    [CustomPropertyDrawer(typeof(ConditionalShowAttribute))]
    public class ConditionalShowDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            // Check for the ConditionalShowAttribute on the property
            var showIfProp = attribute as ConditionalShowAttribute;
            if (showIfProp != null)
            {
                
                var conditionProperty = fieldInfo.ReflectedType.GetField(showIfProp.ConditionalField);
                Debug.Log(conditionProperty + " " + showIfProp.ConditionalField);
                if (conditionProperty != null)
                {
                    object conditionalProp = conditionProperty.GetValue(property.serializedObject);
                    //    var conditionalProp = conditionProperty.GetValue(property.serializedObject);

                    //    //// Check the value of the conditional field
                    //    //if (conditionalProp.boolValue == showIfProp.ConditionValue)
                    //    //{
                    //    //    // Draw the property if the condition is met
                    //    //    EditorGUI.PropertyField(position, property, label);
                    //    //}
                }

            }
            else
            {
                // Draw the property normally if no attribute is present
                EditorGUI.PropertyField(position, property, label);
            }
        }
    }
}