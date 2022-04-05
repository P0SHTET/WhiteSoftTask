using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
