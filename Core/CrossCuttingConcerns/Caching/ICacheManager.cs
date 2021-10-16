using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Caching
{
    public interface ICacheManager
    {
        T Get<T>(string key);

        object Get(string key); // bu generic method değil type custing yapmak lazım
        void Add(string key, object value, int duration);

        bool IsAdd(string key); // cache'de var mı ?
        void Remove(string key); // cache'den uçurma
        void RemoveByPattern(string pattern); // mesela isminin içerisinde get,category vb. geçeni uçur 
    }
}
