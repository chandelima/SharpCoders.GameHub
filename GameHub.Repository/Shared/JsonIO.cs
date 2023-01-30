// TODO: Refactor using System.Text.Json
using Newtonsoft.Json;

namespace GameHub.Repository.Shared;

class JsonIO
{
    private string RepositoryPath;

    public JsonIO(string repositoryPath)
    {
        RepositoryPath = repositoryPath;
    }

    public bool Serialize(Object obj)
    {
        string strJson = JsonConvert.SerializeObject(obj, Formatting.Indented);
        return SaveTxtFile(strJson);
    }

    public T Desserialize<T>()
    {
        string strJson = OpenTxtFile();
        return JsonConvert.DeserializeObject<T>(strJson)!;
    }



    private bool SaveTxtFile(string strJson)
    {
        try
        {
            using (StreamWriter sw = new StreamWriter(RepositoryPath))
                sw.WriteLine(strJson);

            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            return false;
        }
    }

    private string OpenTxtFile()
    {
        string strJson = "";

        try
        {
            using (StreamReader sr = new StreamReader(RepositoryPath))
                strJson = sr.ReadToEnd();
            if (strJson == "")
                strJson = "[]";
        }
        catch (Exception)
        {
            strJson = "[]";
            using (StreamWriter sw = new StreamWriter(RepositoryPath))
                sw.WriteLine(strJson);
        }

        return strJson;
    }
}
