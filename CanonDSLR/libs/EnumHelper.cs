using System;
using System.ComponentModel;
using System.Reflection;
using System.Collections.Generic;
using com.aperis.CanonDSLR.CanonSDK;

namespace EOSControl.Helpers
{

    public static class EnumHelper
    {

        public static String GetDescriptionAttribute(this Enum myEnum)
        {

            var _EnumType   = myEnum.GetType();
            var _MemberInfo = _EnumType.GetMember(myEnum.ToString());

            if (_MemberInfo != null && _MemberInfo.Length > 0)
            {

                var attrs = _MemberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                
                if (attrs != null && attrs.Length > 0)
                    return ((DescriptionAttribute) attrs[0]).Description;

            }

            return myEnum.ToString();

        }

        public static Object GetEnumValue(String myValue, Type myType)
        {

            var names = Enum.GetNames(myType);

            foreach (var name in names)
                if (GetDescriptionAttribute((Enum) Enum.Parse(myType, name)).Equals(myValue))
                    return Enum.Parse(myType, name);

            throw new ArgumentException("The string is not a description or value of the specified enum.");

        }


        public static IEnumerable<String> FillList(PropertyDescription myPropertyDescription, Type myType)
        {

            var _List = new List<String>();

            for (int i = 0; i < myPropertyDescription.NumElements; i++)
            {

                var enumName = Enum.GetName(myType, myPropertyDescription.PropDesc[i]);
                if (enumName != null)
                {
                    var _Enum = (Enum) Enum.Parse(myType, enumName);
                    _List.Add(EnumHelper.GetDescriptionAttribute(_Enum));
                }

            }

            return _List;

        }

        public static IEnumerable<KeyValuePair<String, String>> FillMap(PropertyDescription myPropertyDescription, Type myType)
        {

            var _Map = new List<KeyValuePair<String, String>>();

            for (int i = 0; i < myPropertyDescription.NumElements; i++)
            {

                var enumName = Enum.GetName(myType, myPropertyDescription.PropDesc[i]);

                if (enumName != null)
                {
                    Enum en = (Enum) Enum.Parse(myType, enumName);
                    _Map.Add(new KeyValuePair<String, String>(en.ToString(), EnumHelper.GetDescriptionAttribute(en)));
                }

            }

            return _Map;

        }


        //public static String GetDescr(this Av myAv)
        //{
        //    return EnumHelper.GetDescription(myAv);
        //}

    }
}