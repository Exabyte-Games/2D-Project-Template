namespace Game.Utilities
{
    using UnityEngine;

    /// <summary>
    /// Similar to a singleton but instead of destroying any new instances, it overrides the current instance. Useful for resetting the state and saves doing it manually.
    /// </summary>
    public abstract class StaticInstance<T> : MonoBehaviour where T : MonoBehaviour
    {
        public static T Instance { get; private set; }

        protected virtual void Awake() => Instance = this as T;

        protected virtual void OnApplicationQuit()
        {
            Instance = null;
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// A MonoBehaviour that will maintain a single instance. Will destroy any new instances created, leaving the original instance intact. Can reference in static environments.
    /// </summary>
    public abstract class Singleton<T> : StaticInstance<T> where T : MonoBehaviour
    {
        protected override void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
            }

            base.Awake();
        }
    }

    /// <summary>
    /// A persistent version of a singleton. This will survive through scene loads. Perfect for system classes which require stateful, persustent data.
    /// </summary>
    public abstract class PersistentSingletion<T> : Singleton<T> where T : MonoBehaviour
    {
        protected override void Awake()
        {
            base.Awake();
            DontDestroyOnLoad(gameObject);
        }
    }
}
