using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Interface
{
    public interface IDataProcessRepository
    {
        bool InserDataFile(DataFileUser dataFileUser);
    }
}
