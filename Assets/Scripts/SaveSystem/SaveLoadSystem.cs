using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class SaveLoadSystem : PersistentSingleton<SaveLoadSystem>
{ //uses data service to save and load game data
    public GameData gameData;
    IDataService dataService;
    protected override void Awake()
    {
        base.Awake();
        dataService = new FileDataService(new JsonSerializer());
    }
    public void Save() => dataService.Save(gameData);
    public void Load(string gameName)
    {
        gameData = dataService.Load(gameName);
        if (string.IsNullOrWhiteSpace(gameData.sceneName))
            gameData.sceneName = "Level 1"; //scene name if not set
        SceneManager.LoadScene(gameData.sceneName);
    }
    public void Delete(string gameName) => dataService.Delete(gameName);
    public IEnumerable<string> ListAllSaves()
    {
        return dataService.ListSaves();
    }
}