using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Caching
{
    public interface ICacheManager
    {
        T Get<T>(string key);
        object Get(string key);
        void Add(string key, object value, int duration);

        //cache de var mı kontrolü yapılmakta
        bool IsAdd(string key);
        void Remove(string key);

        //regex yani başı sonu önemli değil içinde get olanlar gibi
        void RemoveByPattern(string key);
    }
}
