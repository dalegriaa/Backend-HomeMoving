using Application.Dto;
using Application.Interface;
using Application.Main.Factories;
using AutoMapper;
using Domain.Entity;
using Domain.Interface;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using Transversal.common.Utilities;
using Transversal.Common;

namespace Application.Main
{
    public class DataProcessApplication : IDataProcessApplication
    {
        private readonly IDataProcessDomain _dataProcessDomain;
        private readonly IMapper _mapper;
        public DataProcessApplication(IDataProcessDomain dataProcessDomain,
            IMapper mapper)
        {
            _dataProcessDomain = dataProcessDomain;
            _mapper = mapper;
        }
        public Response<string> InsertDataProcessFile(IFormFile file, int documentNumber)
        {
            // esta entidad contiene toda la informacion del flujo de la app
            var response = new Response<string>();
            try
            {
                List<string> list = ProccesFileToString.FileToString(file);
                DataFileUserDto datafileuserDto = DataFileUserFactory.GetFileDataUserDto(documentNumber);
                var datafileProcess = ProcessDataFile.WorkDayProcessing(list, documentNumber);

                var dataFileUser = _mapper.Map<DataFileUser>(datafileuserDto);
                var InsertData = _dataProcessDomain.InsertDataFile(dataFileUser);

                if (InsertData)
                {
                    response.Data = datafileProcess;
                    response.IsSuccess = true;
                    response.Message = "Successful registration";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }
    }
}

