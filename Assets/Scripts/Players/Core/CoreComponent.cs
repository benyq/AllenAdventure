using UnityEngine;

namespace Players.Core
{
    public class CoreComponent : MonoBehaviour
    {
        protected Core core;

        protected virtual void Awake()
        {
            core = transform.parent.GetComponent<Core>();
            if(core == null) { Debug.LogError("There is no Core on the parent"); }
            core.AddComponent(this);
        }
        
        protected T TryGet<T>(T value, string name)
        {
            if(value != null)
            {
                return value;
            }

            Debug.LogError(typeof(T) + " not implemented on " + name);
            return default;
        }
    }
}