using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.ComponentModel;
using System.Reflection;
using static System.Console;
using static System.Object;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace LinkedListDisordered
{
 
    public class ShallowOrDeepCopy
    {
        public static object VerifyAndCopy(object data)
        {
            if (data is ICloneable)
            {
                return DeepCopy(data);
            }
            else
            {
                return data;
            }
        }

        public static object DeepCopy(object data)
        {
            try
            {
                Type type = data.GetType();
                MethodInfo method = type.GetMethod("Clone");
                return method.Invoke(data, null);
            }
            catch (TargetException)
            {
            }
            catch (MissingMethodException)
            {
            }
            catch (MemberAccessException)
            {
            }

            return null;
        }
    }
}

