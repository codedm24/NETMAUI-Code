﻿//using AuthenticationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp_XAML
{
    internal class NamedColor
    {
        public string? Name { get; private set; }
        public string? FriendlyName { get; private set; }
        public Color?  Color { get; private set; }
        
        public float Red => Color.Red;
        public float Green => Color.Green;
        public float Blue => Color.Blue;

        public static IEnumerable<NamedColor> All {  get; private set; }

        static NamedColor()
        { 
            List<NamedColor> all = new List<NamedColor>();
            StringBuilder stringBuilder = new StringBuilder();

            foreach (FieldInfo fieldInfo in typeof(Colors).GetRuntimeFields())
            {
                if (fieldInfo.IsPublic &&
                    fieldInfo.IsStatic &&
                    fieldInfo.FieldType == typeof(Color))
                {
                    string name = fieldInfo.Name;
                    stringBuilder.Clear();
                    int index = 0;

                    foreach (char ch in name)
                    {
                        if (index != 0 && char.IsUpper(ch))
                        { 
                            stringBuilder.Append(' ');
                        }
                        stringBuilder.Append(ch);
                        index++;
                    }

                    NamedColor namedColor = new NamedColor()
                    {
                        Name = name,
                        FriendlyName = stringBuilder.ToString(),
                        Color = fieldInfo?.GetValue(null) as Color
                    };

                    all.Add(namedColor);
                }
            }
            all.TrimExcess();
            All = all;
        }

        public static string GetNearestColorName(Color inputColor)
        {
            NamedColor? closestColor = null;
            double closestDistance = double.MaxValue;

            foreach (NamedColor namedColor in All)
            {
                if (namedColor.Color == null) continue;

                // Calculate the Euclidean distance between RGB values
                double distance = Math.Sqrt(
                    Math.Pow(namedColor.Red - inputColor.Red, 2) +
                    Math.Pow(namedColor.Green - inputColor.Green, 2) +
                    Math.Pow(namedColor.Blue - inputColor.Blue, 2));

                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestColor = namedColor;
                }
            }

            return closestColor?.Name ?? "Unknown";
        }
    }


}
