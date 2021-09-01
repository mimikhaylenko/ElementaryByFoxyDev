using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public interface IUserInteracting
    {
        T ReadParameter<T>(string parameterName);
    }
}
