using System;
using System.Reflection;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

[Flags]
public enum SingletonFlags
{
    None = 0,

     
    NoAutoInstance = 1 << 0,

     
    HideAutoInstance = 1 << 1,

     
    NoAwakeInstance = 1 << 2,

     
    PersistAutoInstance = 1 << 3,

     
    DestroyDuplicates = 1 << 4,
}

[BaseTypeRequired(typeof(MonoSingleton<>))]
[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
public sealed class ConfigureSingletonAttribute : Attribute
{
    public SingletonFlags Flags {get;}
    public ConfigureSingletonAttribute(SingletonFlags flags) { }}

[DefaultExecutionOrder(-200)]
public abstract class MonoSingleton : MonoBehaviour
{
}

public abstract class MonoSingleton<T> : MonoSingleton
    where T : MonoSingleton<T>
{

    protected virtual void Awake() { }
    protected virtual void OnEnable() { }
    protected virtual void OnDestroy() { }}
