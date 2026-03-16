using System.Collections.Generic;

public interface IDataService
{
    void Save(GameData data, bool overwrite = true);
    GameData Load(string fileName);
    void Delete(string fileName);
    IEnumerable<string> ListSaves();
}
