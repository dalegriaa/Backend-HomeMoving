using System;

namespace Application.Dto
{
    public class DataFileUserDto
    {
        public Guid Id { get; set; }
        public int DocumentNumber { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
