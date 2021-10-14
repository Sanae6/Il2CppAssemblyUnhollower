using System;
using System.Reflection;
using System.Reflection.Emit;
using UnhollowerBaseLib.Runtime.VersionSpecific.Type;

namespace UnhollowerBaseLib.Runtime {
    public static class FieldUtils {
        public static unsafe T GetValueField<T>(IntPtr clazz, Il2CppObjectBase obj, string name) where T : unmanaged {
            IntPtr field = IL2CPP.GetIl2CppField(clazz, name);
            if (field == IntPtr.Zero) throw new ArgumentException($"Field {name} is not registered in Il2Cpp");
            T* t = (T*) (IL2CPP.Il2CppObjectBaseToPtrNotNull(obj) + (int) IL2CPP.il2cpp_field_get_offset(field));
            return *t;
        }
        public static unsafe T GetReferenceField<T>(IntPtr clazz, Il2CppObjectBase obj, string name) where T : Il2CppObjectBase {
            IntPtr field = IL2CPP.GetIl2CppField(clazz, name);
            if (field == IntPtr.Zero) throw new ArgumentException($"Field {name} is not registered in Il2Cpp");
            IntPtr ptr = *(IntPtr*)(IL2CPP.Il2CppObjectBaseToPtrNotNull(obj) + (int) IL2CPP.il2cpp_field_get_offset(field));
            return (T) Activator.CreateInstance(typeof(T), ptr);
        }
        public static unsafe void SetReferenceField<T>(IntPtr clazz, Il2CppObjectBase obj, string name, T value) where T : Il2CppObjectBase {
            IntPtr field = IL2CPP.GetIl2CppField(clazz, name);
            if (field == IntPtr.Zero) throw new ArgumentException($"Field {name} is not registered in Il2Cpp");
            *(IntPtr*)(IL2CPP.Il2CppObjectBaseToPtrNotNull(obj) + (int) IL2CPP.il2cpp_field_get_offset(field)) = value.Pointer;
        }
        public static unsafe void SetValueField<T>(IntPtr clazz, Il2CppObjectBase obj, string name, T value) where T : unmanaged {
            IntPtr field = IL2CPP.GetIl2CppField(clazz, name);
            if (field == IntPtr.Zero) throw new ArgumentException($"Field {name} is not registered in Il2Cpp");
            *(T*) (IL2CPP.Il2CppObjectBaseToPtrNotNull(obj) + (int) IL2CPP.il2cpp_field_get_offset(field)) = value;
        }
    }
}