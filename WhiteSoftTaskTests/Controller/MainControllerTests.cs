using Microsoft.VisualStudio.TestTools.UnitTesting;
using WhiteSoftTask.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.Json;
using Utils.Web;

namespace WhiteSoftTask.Controller.Tests
{
    [TestClass()]
    public class MainControllerTests
    {
        const string expected = "[\r\n  \"Two roads diverged in a yellow wood,\",\r\n  \"Robert Frost poetAnd sorry I could not travel both\",\r\n  \"And be one traveler, long I stood\",\r\n  \"And looked down one as far as I could\",\r\n  \"To where it bent in the undergrowth;\",\r\n  \"Then took the other, as just as fair,\",\r\n  \"And having perhaps the better claim,\",\r\n  \"Because it was grassy and wanted wear;\",\r\n  \"Though as for that the passing there\",\r\n  \" them really about the same,\",\r\n  \"And both that morning equally lay\",\r\n  \"In leaves no step had trodden black.\",\r\n  \"Oh, I kept the first for another day!\",\r\n  \"Yet knowing how way leads on leads on to way,\",\r\n  \"I doubted if I should ever come back.\",\r\n  \"I shall be telling this with a sigh\",\r\n  \"Somewhere ages and ages hence:\",\r\n  \"Two roads diverged in a wood, and I\",\r\n  \"I took the one less traveled by,\",\r\n  \"And that has made all the difference.\"\r\n]";

        [TestMethod()]
        public void NewtonHttpTest()
        {
            //arrange
            var controller = new MainController(new NewtonSerializer(), new HttpClientRequest());

            //act
            var actual = controller.SolveProblem();

            //assert
            Assert.AreEqual(expected, actual);            
        }

        [TestMethod()]
        public void NewtonOldWebTest()
        {
            //arrange
            var controller = new MainController(new NewtonSerializer(), new OldWebRequest());

            //act
            var actual = controller.SolveProblem();

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SystemHttpTest()
        {
            //arrange
            var controller = new MainController(new SystemSerializer(), new HttpClientRequest());

            //act
            var actual = controller.SolveProblem();

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SystemOldWebTest()
        {
            //arrange
            var controller = new MainController(new SystemSerializer(), new OldWebRequest());

            //act
            var actual = controller.SolveProblem();

            //assert
            Assert.AreEqual(expected, actual);
        }
    }
}