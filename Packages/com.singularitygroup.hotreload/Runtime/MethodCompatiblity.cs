﻿
using System;
using System.Reflection;

namespace SingularityGroup.HotReload {
    static class MethodCompatiblity {
        internal static bool AreMethodsCompatible(MethodBase previousMethod, MethodBase patchMethod) { 
            var previousConstructor  = previousMethod as ConstructorInfo;
            var patchConstructor = patchMethod as ConstructorInfo;
            if(previousConstructor != null && !ReferenceEquals(patchConstructor, null)) {
                return AreConstructorsCompatible(previousConstructor, patchConstructor);
            }
            var previousMethodInfo = previousMethod as MethodInfo;
            var patchMethodInfo = patchMethod as MethodInfo;
            if(!ReferenceEquals(previousMethodInfo, null) && !ReferenceEquals(patchMethodInfo, null)) {
                return AreMethodInfosCompatible(previousMethodInfo, patchMethodInfo);
            }
            return false;
        }
            
        static bool AreMethodBasesCompatible(MethodBase previousMethod, MethodBase patchMethod) {
            if(previousMethod.Name != patchMethod.Name) {
                return false;
            }
            //Declaring type of patch method is different from the target method but their full name (namespace + name) is equal
            if(previousMethod.DeclaringType.FullName != patchMethod.DeclaringType.FullName) {
                return false;
            }
            //Check in case type parameter overloads to distinguish between: void M<T>() { } <-> void M() { }
            if(previousMethod.IsGenericMethodDefinition != patchMethod.IsGenericMethodDefinition) {
                return false;
            }
            
            var prevParams = previousMethod.GetParameters();
            var patchParams = patchMethod.GetParameters();
            ArraySegment<ParameterInfo> patchParamsSegment;
            if(previousMethod.IsStatic || previousMethod.Name.Contains("<") && !patchMethod.IsStatic) {
                patchParamsSegment = new ArraySegment<ParameterInfo>(patchParams);
            } else {
                //Special case: patch method for an instance method is static and has an explicit this parameter.
                //If the patch method doesn't have any parameters it is not compatible.
                if(patchParams.Length == 0) {
                    return false;
                }
                //this parameter has to be the declaring type
                if(patchParams[0].ParameterType != previousMethod.DeclaringType) {
                    return false;
                }
                //Ignore the this parameter and compare the remaining ones.
                patchParamsSegment = new ArraySegment<ParameterInfo>(patchParams, 1, patchParams.Length - 1);
            }
            return CompareParameters(new ArraySegment<ParameterInfo>(prevParams), patchParamsSegment);
        }
        
        static bool CompareParameters(ArraySegment<ParameterInfo> x, ArraySegment<ParameterInfo> y) {
            if(x.Count != y.Count) {
                return false;
            }
            for (var i = 0; i < x.Count; i++) {
                if(x.Array[i + x.Offset].ParameterType != y.Array[i + y.Offset].ParameterType) {
                    return false;
                }
            }
            return true;
        }
            

        static bool AreConstructorsCompatible(ConstructorInfo x, ConstructorInfo y) {
            return AreMethodBasesCompatible(x, y);
        }
            
        static bool AreMethodInfosCompatible(MethodInfo x, MethodInfo y) {
            return AreMethodBasesCompatible(x, y) && x.ReturnType == y.ReturnType;
        }
    }
}