using UnityEngine;

public abstract class PersistentSingleton<T> : MonoBehaviour where T : Component
{
    //abstract classes cannot be made into a component, forcing inheritance
    //looks for a component within each game object and all of their childs within the hierarchy
    //if no component, it will create one
    protected static T instance;
    public static T Instance
    {
        get
        {
            instance = FindAnyObjectByType<T>();
            if (instance == null)
            {
                GameObject g = new GameObject(typeof(T).Name + "Generated");
                instance = g.AddComponent<T>();
            }
            return instance;
        }
    }
    protected virtual void Awake(){ InitialiseSingleton(); }
    protected virtual void InitialiseSingleton()
    {
        if (instance == null)
        {
            instance = this as T; //this instance is moved to a global scene
            DontDestroyOnLoad(gameObject);
        }
        else //if moving to a new scene and a similar object is inside, replace it with the singleton
            if (instance != this) { Destroy(gameObject); } 
    }
}
