using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] Slider progressSlider;
    public void LoadScene(int sceneIndex)
    {
            StartCoroutine(LoadAsynchronously(sceneIndex));
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    private IEnumerator LoadAsynchronously(int sceneIndex)
    { 
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        while (!operation.isDone)
        {
            if (progressSlider != null)
            {
                float progress = Mathf.Clamp01(operation.progress / 0.9f);
                progressSlider.value = progress;
            }
            yield return null;
        }
    }
}
