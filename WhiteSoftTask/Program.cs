using System.Net;
using System.Text.Json;
using WhiteSoftTask;

const string ApiData = @"https://raw.githubusercontent.com/thewhitesoft/student-2022-assignment/main/data.json";
const string ApiReplacement = @"https://raw.githubusercontent.com/thewhitesoft/student-2022-assignment/main/replacement.json";
const string ResultFileName = "result.json";

string GetDataFromApi(string ApiUri)
{
    WebRequest requestData = WebRequest.Create(ApiUri);
    WebResponse responseData = requestData.GetResponse();
    Stream dataStream = responseData.GetResponseStream();
    StreamReader readerData = new(dataStream);
    return readerData.ReadToEnd();
} 

List<Replacement> ReplacementsArrayToList(Replacement[]? replacements)
{
    List<Replacement> replacementsList = new List<Replacement>();

    foreach (var replacement in replacements)
    {
        replacementsList.RemoveAll(x => x.replacement == replacement.replacement);
        replacementsList.Add(replacement);
    }

    return replacementsList;
}

List<string> RepareMessages(string[]? allMessages, List<Replacement> replacements)
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

string messagesData = GetDataFromApi(ApiData);
string replacmentsData = GetDataFromApi(ApiReplacement);

string[]? allMessages = JsonSerializer.Deserialize<string[]>(messagesData);
Replacement[]? allReplacements = JsonSerializer.Deserialize<Replacement[]>(replacmentsData);

List<Replacement> orderedReplacements = new List<Replacement>();
List<string> resultMessages = new List<string>();

orderedReplacements = ReplacementsArrayToList(allReplacements);
orderedReplacements = orderedReplacements.OrderByDescending(x => x.replacement.Length).ToList();

resultMessages = RepareMessages(allMessages, orderedReplacements);

string result = JsonSerializer.Serialize(resultMessages, new JsonSerializerOptions()
{
    WriteIndented = true
});

Console.WriteLine(result);
File.WriteAllText(ResultFileName, result);