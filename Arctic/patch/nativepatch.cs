using System;
using System.Reflection;
using System.Runtime.InteropServices;
using UnhollowerBaseLib;

namespace Arctic.patch
{
    class nativepatch
    {
        public static unsafe TDelegate Patch<TDelegate>(MethodInfo targetMethod, MethodInfo patch) where TDelegate : Delegate
        {
            
            var method = *(IntPtr*)(IntPtr)UnhollowerUtils.GetIl2CppMethodInfoPointerFieldForGeneratedMethod(targetMethod).GetValue(null);
            // ^ Gets the original C++ method from VRChat
            MelonLoader.MelonUtils.NativeHookAttach((IntPtr)(&method), patch!.MethodHandle.GetFunctionPointer());
            // ^ Attaches our patch to it
            return Marshal.GetDelegateForFunctionPointer<TDelegate>(method);

            // ^ Associates the original method to the delegate so we can call it inside the patching if needed
        }

        public static void nativepatches()
        {
            //NativeMethodInfoPtr_Method_Private_Void_APIUser_1
            // runab = Patch<afk>(typeof(VRC.Animation.VRCMotionState).GetProperty("prop_Boolean_3").GetSetMethod(), typeof(nativepatch).GetMethod(nameof(runafk), BindingFlags.NonPublic | BindingFlags.Static));
            // runab = Patch<afk>(typeof(VRC.Animation.VRCMotionState).GetProperty("prop_Boolean_3").SetMethod, typeof(nativepatch).GetMethod(nameof(runafk), BindingFlags.NonPublic | BindingFlags.Static));
            // runab = Patch<afk>(typeof(VRC.Animation.VRCMotionState).GetProperty("prop_Boolean_3").GetMethod, typeof(nativepatch).GetMethod(nameof(runafk), BindingFlags.NonPublic | BindingFlags.Static));
            // runab = Patch<Itemspickup>(typeof(VRC.SDKBase.VRC_Pickup).GetProperty("pickupable").GetSetMethod(), typeof(nativepatch).GetMethod(nameof(Runpickup), BindingFlags.NonPublic | BindingFlags.Static));
            //  runab = Patch<Itemspickup>(typeof(VRC.SDKBase.VRC_Pickup).GetProperty("pickupable").SetMethod, typeof(nativepatch).GetMethod(nameof(Runpickup), BindingFlags.NonPublic | BindingFlags.Static));
            // runab = Patch<Itemspickup>(typeof(VRC.SDK3.Components.VRCPickup).GetProperty("pickupable").GetSetMethod(), typeof(nativepatch).GetMethod(nameof(Runpickup), BindingFlags.NonPublic | BindingFlags.Static));
            //  runab = Patch<Itemspickup>(typeof(VRC.SDKBase.VRC_Pickup).GetProperty("pickupable").GetMethod, typeof(nativepatch).GetMethod(nameof(Runpickup), BindingFlags.NonPublic | BindingFlags.Static));

            // usrjng = Patch<usrjoin>(typeof(VRC.UI.FriendsListManager).GetMethod("Method_Private_Void_APIUser_1"), typeof(nativepatch).GetMethod(nameof(jiusr), BindingFlags.NonPublic | BindingFlags.Static));
            // usrjng = Patch<usrjoin>(typeof(VRC.UI.FriendsListManager).GetMethod("NativeMethodInfoPtr_Method_Private_Void_APIUser_1"), typeof(nativepatch).GetMethod(nameof(jiusr), BindingFlags.NonPublic | BindingFlags.Static));

        }

        private static IntPtr Runpickup(IntPtr instance, bool Bool, IntPtr nativeMethodInfoPtr)
        {


            return runab(instance, Bool, nativeMethodInfoPtr);
        }

        private static IntPtr jiusr(IntPtr instance, VRC.Core.APIUser __0, IntPtr nativeMethodInfoPtr)
        {
            //Style.Consoles.consolelogger(Bool);

            // Style.Consoles.consolelogger(__0.prop_String_1);
            return usrjng(instance, __0, nativeMethodInfoPtr);
        }

        private delegate IntPtr Itemspickup(IntPtr instance, bool Bool, IntPtr nativeMethodInfoPtr);

        private static Itemspickup runab;

        private delegate IntPtr usrjoin(IntPtr instance, VRC.Core.APIUser __0, IntPtr nativeMethodInfoPtr);
        private static usrjoin usrjng;

    }
}
