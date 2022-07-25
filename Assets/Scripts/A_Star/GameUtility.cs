using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace GameUtility
{    
    public class Inspector
    {
        [CanEditMultipleObjects]
        [CustomEditor(typeof(MonoBehaviour), true)]
        public class MonoBehaviourCustomEditor : UnityEditor.Editor
        {
            public override void OnInspectorGUI()
            {
                base.DrawDefaultInspector();

                InspectorGUIToFunctionButton();
            }

            void InspectorGUIToFunctionButton()
            {
                var type = target.GetType();
                var methods = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
                foreach (var method in methods)
                {
                    var attribute = method.GetCustomAttributes(typeof(Inspector.Button), true);
                    if(0 >= attribute.Length)
                        continue;

                    if (GUILayout.Button(method.Name))
                    {
                        ((MonoBehaviour)target).Invoke(method.Name,0f);
                    }
                }
            }
        }
        [AttributeUsage(AttributeTargets.Method)]
        public class Button : Attribute
        {
        }
    }

    public class Camera
    {
        
    }
}

