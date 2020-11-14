using Application.Dto;
using System;

namespace Application.Main.Factories
{
    public static class DataFileUserFactory
    {
        public static DataFileUserDto GetFileDataUserDto(
            int documentNumber)
        {
            return new DataFileUserDto
            {
                Id = Guid.NewGuid(),
                DocumentNumber = documentNumber,
                CreateDate = DateTime.Now
             
            };
        }
    }
}
