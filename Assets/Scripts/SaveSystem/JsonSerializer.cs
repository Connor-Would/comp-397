using UnityEngine;

public class JsonSerializer : ISerializer
{
    string ISerializer.Serialize<T>(T obj)
    {
        return JsonUtility.ToJson(obj, true); //pretty print json
    } //meaning it will be formatted with indentation and line breaks

    T ISerializer.Deserialize<T>(string json)
    {
        return JsonUtility.FromJson<T>(json);
    }
}