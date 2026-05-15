using UnityEngine;

public class AmbientMusic : MonoBehaviour
{
    private static AmbientMusic instance;

    void Awake()
{
    if (instance != null && instance != this)
    {
        Destroy(this.gameObject);
        return;
    }

    instance = this;

    transform.SetParent(null); 
    
    DontDestroyOnLoad(this.gameObject);
}
}