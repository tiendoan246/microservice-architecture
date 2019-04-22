using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Common
{
    public interface IHandle<in T> where T : Event
    {
    }
}
