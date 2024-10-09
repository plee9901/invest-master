using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Something;
using api.Models;

namespace api.Mappers
{
    public static class SomethingMapper
    {
        public static SomethingDto ToSomethingDto(this Something somethingModel) 
        {
            return new SomethingDto
            {
                Id = somethingModel.Id,
                SomethingName = somethingModel.SomethingName
            };
        }

        public static Something ToSomethingFromCreateDto(this CreateSomethingDto somethingDto)
        {
            return new Something 
            {
                SomethingName = somethingDto.SomethingName
            };
        }
    }
}