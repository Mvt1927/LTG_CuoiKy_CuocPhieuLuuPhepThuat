using System;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts
{
    [AttributeUsage(
        AttributeTargets.Property | 
        AttributeTargets.Field |
        AttributeTargets.Method
    )]
    public class ConditionalShowAttribute : PropertyAttribute
    {
        public string ConditionalField { get; private set; }
        public bool ConditionValue { get; private set; }

        public ConditionalShowAttribute(string conditionalField, bool conditionValue)
        {
            this.ConditionalField = conditionalField;
            this.ConditionValue = conditionValue;
        }
    }
}

