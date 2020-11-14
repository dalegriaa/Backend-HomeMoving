using Domain.Entity;
using Domain.Interface;
using Infrastructure.Interface;

namespace Domain.Core
{
    public class DataProcessDomain : IDataProcessDomain
    {
        private readonly IDataProcessRepository _dataProcessRepository;

        public  DataProcessDomain(IDataProcessRepository dataProcessRepository)
        {
            _dataProcessRepository = dataProcessRepository;
        }
        public bool InsertDataFile(DataFileUser dataFileuser)
        {
            return _dataProcessRepository.InserDataFile(dataFileuser);
        }
    }
}
