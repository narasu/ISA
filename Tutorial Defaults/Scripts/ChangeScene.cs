using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string sceneToLoad;

    public void OnClick()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}