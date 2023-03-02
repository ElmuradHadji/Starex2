using AutoMapper;
using Bussiness.Services.Abstract;
using Core.Entities.Concrete;
using Core.Entities.DTOs.SettingDTOs;
using Core.Utilities.Exceptions;
using DataAccess.Repositories.Abstarct;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Services.Concrete
{
    public class SettingService: ISettingService
    {
        private readonly ISettingRepository _settingRepository;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;

        public SettingService(ISettingRepository settingRepository, IMapper mapper, IWebHostEnvironment env)
        {
            _settingRepository = settingRepository;
            _mapper = mapper;
            _env = env;
        }




        public List<SettingGetDto> GetAll()
        {
            List<SettingGetDto> list = new List<SettingGetDto>();
            return _settingRepository.GetAll().Count is not 0 ? _mapper.Map<List<SettingGetDto>>(_settingRepository.GetAll()) : list;
        }

        public SettingGetDto GetById(int id)
        {
            SettingGetDto settingGetDto = new SettingGetDto();
            if (_settingRepository.Get(p => p.Id == id) is not null)
            {
                settingGetDto = _mapper.Map<SettingGetDto>(_settingRepository.Get(p => p.Id == id));

            }
            return settingGetDto;
        }




        public void Update(SettingUpdateDto settingUpdateDto)
        {
            Setting setting = _settingRepository.Get(p => p.Logo == settingUpdateDto.Logo);
            if (setting is null)
                throw new NotFoundException("Data tapılmadı");
            setting.Logo = settingUpdateDto.Logo;
            setting.Phone = settingUpdateDto.Phone;
            setting.Adress = settingUpdateDto.Adress;
            _settingRepository.Update(setting);
            _settingRepository.Save();
        }

    }
}
