using Core.Entities.Concrete;
using Core.Entities.DTOs.UserDTOs;
using Entities.DTOs.AboutDTOs;
using Microsoft.AspNetCore.Mvc;

namespace Bussiness.Services.Abstract
{
    public interface IEmployeeService
    {
        List<AdminGetDto> GetAll();
        AdminGetDto GetById(string id);
        AdminGetDto GetByName(string name);
        //Task Register(AdminRegisterDto adminRegisterDto);
        //void Update(AboutUpdateDto aboutUpdateDto);
        //void Delete(int id);
        //void Login();
        //Task CreateRole();
    }
}
