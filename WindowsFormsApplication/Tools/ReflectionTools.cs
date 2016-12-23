using System;
using System.Reflection;

namespace Tools
{
    public class ReflectionTools
    {

        /// <summary>
        /// 获取指定Dll中的指定对象类型
        /// </summary>
        /// <param name="startupPath"></param>
        /// <param name="dllFileName">>DLL文件名(如:abc)</param>
        /// <param name="typeName">类型名称(如：People)</param>
        /// <returns></returns>
        public static Type GetTypeObject(String startupPath, String dllFileName, String typeName)
        {
            Assembly assembly = Assembly.LoadFile(String.Format(@"{0}\{1}.dll", startupPath, dllFileName));
            Type type = assembly.GetType(typeName);
            return type;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="startupPath"></param>
        /// <param name="dllFileName"></param>
        /// <param name="typeName"></param>
        /// <returns></returns>
        public static Object GetConstructor(String startupPath, String dllFileName, String typeName) {
            Type type = GetTypeObject(startupPath, dllFileName, typeName);

            ConstructorInfo constructor = type.GetConstructor(System.Type.EmptyTypes);
            if (constructor == null)
                throw new MissingMethodException("No public constructor defined for this object");

            return constructor.Invoke(null);
        }
    }
}
