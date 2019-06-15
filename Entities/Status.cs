using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public enum Status
    {
        //статуси процесу підготовки та виконання завдання (підготовка, в процесі, готово, помилка)
        Preparation = 1,
        InProcess,
        Done,
        Fail
    }
}
