using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Templates.Adapter
{
    public interface IWriterLogger
    {
        void Log(string message);
        void Error(string message);
        void Warn(string message);
    }
}
