using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
