namespace WhiteSoftTask.View
{
    public class WriteToFile : IViewData
    {
        string _path;

        public WriteToFile(string path)
        {
            _path = path;
        }

        public void ViewResult(string result)
        {
            File.WriteAllText(_path, result);
        }
    }
}
