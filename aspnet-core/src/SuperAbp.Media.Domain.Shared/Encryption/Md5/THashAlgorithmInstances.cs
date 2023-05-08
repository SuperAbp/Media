using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;

namespace Lzez.Tendering.Util.Encryption.Md5
{
    public static class THashAlgorithmInstances<THashAlgorithm> where THashAlgorithm : HashAlgorithm
    {
        /// <summary>
        /// 线程静态变量。
        /// 即：这个变量在每个线程中都是唯一的。
        /// 再结合泛型类实现了该变量在不同泛型或不同的线程先的变量都是唯一的。
        /// 这样做的目的是为了避开多线程问题。
        /// </summary>
        [ThreadStatic]
        private static THashAlgorithm instance;

        public static THashAlgorithm Instance => instance ?? Create(); // C# 语法糖，低版本可以改为 { get { return instance != null ? instance : Create(); } }

        /// <summary>
        /// 寻找 THashAlgorithm 类型下的 Create 静态方法，并执行它。
        /// 如果没找到，则执行 Activator.CreateInstance 调用构造方法创建实例。
        /// 如果 Activator.CreateInstance 方法执行失败，它会抛出异常。
        /// </summary>
        [MethodImpl(MethodImplOptions.NoInlining)]
        private static THashAlgorithm Create()
        {
            var createMethod = typeof(THashAlgorithm).GetMethod(
                nameof(HashAlgorithm.Create), // 这段代码同 "Create"，低版本 C# 可以替换掉
                BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly,
                Type.DefaultBinder,
                Type.EmptyTypes,
                null);

            if (createMethod != null)
            {
                instance = (THashAlgorithm)createMethod.Invoke(null, new object[] { });
            }
            else
            {
                instance = Activator.CreateInstance<THashAlgorithm>();
            }

            return instance;
        }
    }
}