using UnityEngine;
using UnityEngine.SceneManagement;

public class transitionScene : MonoBehaviour
{
    public string sceneToLoad;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Teleport();
        }
    }

    void Teleport()
{
    GetComponent<Collider>().enabled = false;
    
    SceneManager.LoadScene(sceneToLoad);
}
}