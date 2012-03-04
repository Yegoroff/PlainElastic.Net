using System;
using System.Linq.Expressions;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Mappings
{
    /// <summary>
    /// Builds a mapping that allows to map inner JSON object. 
    /// http://www.elasticsearch.org/guide/reference/mapping/object-type.html
    /// </summary>
    public class Object<T>: ObjectBase<T,Object<T>>
    {

    }
}