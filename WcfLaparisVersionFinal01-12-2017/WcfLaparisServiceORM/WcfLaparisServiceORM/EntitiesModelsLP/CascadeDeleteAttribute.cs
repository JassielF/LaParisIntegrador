using System;

namespace WcfLaparisServiceORM.EntitiesModelsLP
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class CascadeDeleteAttribute : Attribute { }
}