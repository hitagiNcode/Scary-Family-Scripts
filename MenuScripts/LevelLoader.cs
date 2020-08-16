using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    public enum CutScene { NoScene, DrinkCola, NewspaperRush};
    public CutScene selectedCutScene = CutScene.DrinkCola;

    public static LevelLoader Instance { get; private set; }

    public GameObject loadingScreen;
    public Slider slider;
    public Text progressText;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void StartGameLevel()
    {
        StartCoroutine(LoadAsynchoronously(1));
    }

    IEnumerator LoadAsynchoronously(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        loadingScreen.SetActive(true);
        while (operation.isDone == false)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progress;
            progressText.text = progress * 100f + "%";
            yield return null;
        }
    }



    public void SelectSceneAndStartGame(int scenenumber)
    {
        switch (scenenumber)
        {
            case 0:
                selectedCutScene = CutScene.NoScene;
                StartGameLevel();
                break;
            case 1:
                selectedCutScene = CutScene.DrinkCola;
                StartGameLevel();
                break;
            case 2:
                selectedCutScene = CutScene.NewspaperRush;
                StartGameLevel();
                break;
            default:
                
                break;
        }
        
    }


}
