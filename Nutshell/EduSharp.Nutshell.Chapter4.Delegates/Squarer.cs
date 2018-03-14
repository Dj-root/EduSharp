using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduSharp.Nutshell.Chapter4.Delegates
{
    class Squarer:ITransformer
    {
        public int Transform(int x) => x * x;
    }
}
