namespace WhiteSoftTask.View
{
    public class WriteToConsole : IViewData
    {
        public void ViewResult(string result)
        {
            Console.WriteLine(result);
        }
    }
}
