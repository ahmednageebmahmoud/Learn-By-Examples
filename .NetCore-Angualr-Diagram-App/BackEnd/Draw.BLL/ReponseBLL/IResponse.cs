﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draw.BLL.ReponseBLL
{
    public interface IResponse<T>
    {
        bool IsSuccess { get; }
        string Message { get; }
        T Result { get; }



    }
}
