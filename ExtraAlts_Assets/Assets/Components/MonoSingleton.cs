using System;
using System.Reflection;
using JetBrains.Annotations;
using UnityEngine;

[Flags]
public enum SingletonFlags
{
    None = 0,

    // Instance will not be created automatically.
    NoAutoInstance = 1 << 0,

    // Automatically created instances will be hidden.
    HideAutoInstance = 1 << 1,

    // The singleton instance will not be overridden by Awake calls.
    NoAwakeInstance = 1 << 2,

    // Automatically crated instances will survive scene unloads.
    PersistAutoInstance = 1 << 3,

    // Duplicate instances will be destroyed on Awake.
    DestroyDuplicates = 1 << 4,
}

[BaseTypeRequired(typeof(MonoSingleton<>))]
[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
public sealed class ConfigureSingletonAttribute : Attribute
{
    public SingletonFlags Flags { get; }

    public ConfigureSingletonAttribute(SingletonFlags flags)
    {
        Flags = flags;
    }
}

[DefaultExecutionOrder(-200)]
public abstract class MonoSingleton : MonoBehaviour
{
}

public abstract class MonoSingleton<T> : MonoSingleton
    where T : MonoSingleton<T>
{
    static T instance;

    static readonly SingletonFlags flags;

    static MonoSingleton()
    {
        var attr = typeof(T).GetCustomAttribute<ConfigureSingletonAttribute>();
        flags    = attr?.Flags ?? SingletonFlags.None;
    }

    static T Initialize()
    {
        if (flags.HasFlag(SingletonFlags.NoAutoInstance))
            return FindObjectOfType<T>();

        var gameObject = new GameObject(typeof(T).FullName);
        var singleton  = gameObject.AddComponent<T>();

        if (flags.HasFlag(SingletonFlags.HideAutoInstance))
            gameObject.hideFlags = HideFlags.HideAndDontSave;

        if (flags.HasFlag(SingletonFlags.PersistAutoInstance))
            DontDestroyOnLoad(gameObject);

        return singleton;
    }

    public static T Instance
    {
        get           => instance ? instance : (instance = Initialize());
        protected set => instance = value;
    }

    protected virtual void Awake()
    {
        if (instance && flags.HasFlag(SingletonFlags.DestroyDuplicates))
        {
            Destroy(this);
            return;
        }

        if (flags.HasFlag(SingletonFlags.NoAwakeInstance))
            return;

        // Don't allow disabled duplicates to hijack primary instance status.
        // TODO: Should this be configurable?
        if (instance && instance.isActiveAndEnabled && !isActiveAndEnabled)
            return;

        Instance = (T)this;
    }
}
