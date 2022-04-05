using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils.Json
{
    public interface ISerializer
    {
        T Deserialize<T>(string input);
        string Serialize<T>(T input); 
    }
}
