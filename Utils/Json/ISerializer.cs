namespace Utils.Json
{
    public interface ISerializer
    {
        T Deserialize<T>(string input);
        string Serialize<T>(T input); 
    }
}
