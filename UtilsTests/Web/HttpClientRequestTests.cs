using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Utils.Web.Tests
{
    [TestClass()]
    public class HttpClientRequestTests
    {

        [TestMethod()]
        public void GetReplacementDataFromUriTest()
        {
            //arrange
            string str = "[\r\n  {\r\n    \"replacement\": \"Ha-haaa, hacked you\",\r\n    \"source\": \"I doubted if I should ever come back\"\r\n  },\r\n  {\r\n    \"replacement\": \"sdshdjdskfm sfjsdif jfjfidjf\",\r\n    \"source\": \"Somewhere ages and ages hence:\"\r\n  },\r\n  {\r\n    \"replacement\": \"1\",\r\n    \"source\": \"l\"\r\n  },\r\n  {\r\n    \"replacement\": \"Emptry... or NOT!\",\r\n    \"source\": null\r\n  },\r\n  {\r\n    \"replacement\": \"d12324344rgg6f5g6gdf2ddjf\",\r\n    \"source\": \"wood\"\r\n  },\r\n  {\r\n    \"replacement\": \"Random text, yeeep\",\r\n    \"source\": \"took\"\r\n  },\r\n  {\r\n    \"replacement\": \"Bla-bla-bla-blaaa, just some RANDOM tExT\",\r\n    \"source\": null\r\n  },\r\n  {\r\n    \"replacement\": \"parentheses - that is a smart word\",\r\n    \"source\": \"the better claim\"\r\n  },\r\n  {\r\n    \"replacement\": \"sdshdjdskfm sfjsdif jfjfidjf\",\r\n    \"source\": \"Somewhere ages and ages hence:\"\r\n  },\r\n  {\r\n    \"replacement\": \"Emptry... or NOT!\",\r\n    \"source\": \"Had worn\"\r\n  },\r\n  {\r\n    \"replacement\": \"Skooby-dooby-doooo\",\r\n    \"source\": \"knowing how way leads on\"\r\n  },\r\n  {\r\n    \"replacement\": \"sdshdjdskfm sfjsdif jfjfidjf\",\r\n    \"source\": \"Somewhere ages and ages hence:\"\r\n  },\r\n  {\r\n    \"replacement\": \"An other text\",\r\n    \"source\": null\r\n  },\r\n  {\r\n    \"replacement\": \"Skooby-dooby-doooo\",\r\n    \"source\": \"knowing how way\"\r\n  }\r\n]\r\n";
            string apiReplacement = @"https://raw.githubusercontent.com/thewhitesoft/student-2022-assignment/main/replacement.json";
            var client = new HttpClientRequest();

            //act
            var result = client.GetDataFromUri(apiReplacement);

            //assert

            Assert.AreEqual(str, result);
        }

        [TestMethod()]
        public void GetSourceDataFromUriTest()
        {
            //arrange
            string str = "[\n  \"Two roads diverged in a yellow d12324344rgg6f5g6gdf2ddjf,\",\n  \"Robert Frost poetAnd sorry I cou1d not trave1 both\",\n  \"An other text\",\n  \"And be one trave1er, long I stood\",\n  \"And 1ooked down one as far as I cou1d\",\n  \"Bla-bla-bla-blaaa, just some RANDOM tExT\",\n  \"To where it bent in the undergrowth;\",\n  \"Then Random text, yeeep the other, as just as fair,\",\n  \"And having perhaps parentheses - that is a smart word,\",\n  \"Bla-bla-bla-blaaa, just some RANDOM tExT\",\n  \"Because it was grassy and wanted wear;\",\n  \"An other text\",\n  \"An other text\",\n  \"Though as for that the passing there\",\n  \"Emptry... or NOT! them rea11y about the same,\",\n  \"And both that morning equally lay\",\n  \"In 1eaves no step had trodden b1ack.\",\n  \"Oh, I kept the first for another day!\",\n  \"Yet Skooby-dooby-doooo 1eads on to way,\",\n  \"Ha-haaa, hacked you.\",\n  \"An other text\",\n  \"I shall be te11ing this with a sigh\",\n  \"sdshdjdskfm sfjsdif jfjfidjf\",\n  \"Two roads diverged in a d12324344rgg6f5g6gdf2ddjf, and I\",\n  \"I Random text, yeeep the one less traveled by,\",\n  \"And that has made a11 the difference.\",\n  \"Bla-bla-bla-blaaa, just some RANDOM tExT\"\n]\n";
            string apiData = @"https://raw.githubusercontent.com/thewhitesoft/student-2022-assignment/main/data.json";
            var client = new HttpClientRequest();

            //act
            var result = client.GetDataFromUri(apiData);

            //assert

            Assert.AreEqual(str, result);
        }
    }
}