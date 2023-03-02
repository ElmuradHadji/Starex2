using Entities.DTOs.BranchDTOs;
using Entities.DTOs.DeliveryPointDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Services.Abstract
{
    public interface IDeliveryPointService
    {
        List<DeliveryPointGetDto> GetAll();
        DeliveryPointGetDto GetById(int id);
        void Create(DeliveryPointPostDto deliveryPointPostDto);
        void Update(DeliveryPointUpdateDto deliveryPointUpdateDto);
        void Delete(int id);
        void ModifyActivation(int id);
    }
}
