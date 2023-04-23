using System;

namespace Sandbox
{
    public interface IAlter
    {
        bool allowOnlyOne {get;}        string alterKey {get;}        string alterCategoryName {get;}    }
    
    public interface IAlterOptions<T>
    {
        AlterOption<T>[] options {get;}    }
    
    [Serializable]
    public class AlterOption<T>
    {
        public string name;
        public string key;

        public T value;
        public Action<T> callback;
    }
}