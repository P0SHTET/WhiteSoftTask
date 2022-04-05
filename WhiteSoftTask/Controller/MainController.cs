using Utils.Json;
using Utils.Web;
using WhiteSoftTask.Model;

namespace WhiteSoftTask.Controller
{
    public class MainController
    {
        private ISerializer _serializer;
        private IWebRequest _webResponseData;

        private const string ApiData = @"https://raw.githubusercontent.com/thewhitesoft/student-2022-assignment/main/data.json";
        private const string ApiReplacement = @"https://raw.githubusercontent.com/thewhitesoft/student-2022-assignment/main/replacement.json";


        public MainController(ISerializer serializer, IWebRequest webResponseData)
        {
            _serializer = serializer;
            _webResponseData = webResponseData;
        }

        public string SolveProblem()
        {
            string messagesData = _webResponseData.GetDataFromUri(ApiData);
            string replacementsData = _webResponseData.GetDataFromUri(ApiReplacement);

            string[]? allMessages = _serializer.Deserialize<string[]>(messagesData);
            ReplacementData[]? allReplacements = _serializer.Deserialize<ReplacementData[]>(replacementsData);

            List<ReplacementData> replacementsList = allReplacements.Distinct()
                                                                    .OrderByDescending(x=>x.replacement.Length)
                                                                    .ToList();

            List<string> resultMsg = RepareMessages(allMessages, replacementsList);

            string resultJson = _serializer.Serialize(resultMsg);

            return resultJson;
        }

        public List<string> RepareMessages(string[]? allMessages, List<ReplacementData> replacements)
        {
            List<string> repairedMessages = new List<string>();

            for (int i = 0; i < allMessages.Length; i++)
                foreach (var repl in replacements)
                    allMessages[i] = allMessages[i].Replace(repl.replacement, repl.source);

            foreach (var message in allMessages)
                if (message is null || message == "") continue;
                else repairedMessages.Add(message);

            return repairedMessages;
        }
    }
}
