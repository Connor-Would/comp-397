//data service inherits from this interface
using System.Collections;

public interface ISerializer
{
    string Serialize<T>(T obj);
    T Deserialize<T>(string json);//deserialize string to object
} //can also use xml or binary, but json is human readable