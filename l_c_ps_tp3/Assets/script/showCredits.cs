using UnityEngine;

public class ShowCredits : MonoBehaviour
{
    public GameObject creditsTextObject;

    private void Start()
    {
        if (creditsTextObject != null)
        {
            creditsTextObject.SetActive(false);
        }
    }

    public void ToggleCredits()
    {
        if (creditsTextObject != null)
        {
            bool isActive = creditsTextObject.activeSelf;
            creditsTextObject.SetActive(!isActive);
        }
    }
}