using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//build and run will run it's own web server
public class Menu : PersistentSingleton<Menu>
{
    [SerializeField] private Button saveBtn;
    [SerializeField] private Button loadBtn;
    private void Start()
    {
        saveBtn.onClick.AddListener(()=>
        {
            SaveLoadSystem.Instance.gameData.fileName = "Menu";
            SaveLoadSystem.Instance.gameData.sceneName = "SampleScene";
            SaveLoadSystem.Instance.Save();
        });
        loadBtn.onClick.AddListener(()=>SaveLoadSystem.Instance.Load("Menu"));
    }
    // public void StartPlayGameAdditive()
    // {
    //     SceneManager.LoadScene("SampleScene", LoadSceneMode.Additive);
    // }
    // public void StartPlayGameSingle()
    // {
    //     SceneManager.LoadScene("SampleScene");
    // }
}