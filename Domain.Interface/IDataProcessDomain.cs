﻿using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interface
{
   public interface IDataProcessDomain
    {
        bool InsertDataFile(DataFileUser dataFileuser);
    }
}
