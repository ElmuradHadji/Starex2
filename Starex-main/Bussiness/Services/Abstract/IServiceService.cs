using Entities.DTOs.ServiceDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Services.Abstract
{
    public interface IServiceService
    {
        List<ServiceGetDto> GetAll();
        ServiceGetDto GetById(int id);
        void Create(ServicePostDto ServicePostDto);
        void Update(ServiceUpdateDto ServiceUpdateDto);
        void Delete(int id);
        void ModifyActivation(int id);

    }
}
