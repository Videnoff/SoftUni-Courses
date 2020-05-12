using System;
using System.Linq;
using System.Reflection;
using ValidationAttributes.Attributes;

namespace ValidationAttributes.Utilities
{
    public static class Validator
    {
        /// <summary>
        /// Checks all object's properties for custom attributes and if all custom attributes are valid, then the whole object is valid
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>

        public static bool IsValid(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            Type objType = obj.GetType();

            PropertyInfo[] properties = objType.GetProperties();

            /*
             * If all properties are valid with their custom attributes -> Object is Valid
             */
            /*
             * If one property is not valid for one of it's custom attributes -> Object is not Valid
             */
            foreach (var propertyInfo in properties)
            {
                MyValidationAttribute[] attributes = propertyInfo
                    .GetCustomAttributes()
                    .Where(ca => ca is MyValidationAttribute)
                    .Cast<MyValidationAttribute>()
                    .ToArray();

                foreach (var attribute in attributes)
                {
                    if (!attribute.IsValid(propertyInfo.GetValue(obj)))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}