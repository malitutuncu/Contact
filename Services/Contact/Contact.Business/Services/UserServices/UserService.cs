using Common.Global.Business.Validation;
using Common.Global.DataService;
using Common.Global.Exceptions;
using Contact.Business.Interfaces;
using Contact.Business.Services.UserServices.Dtos;
using Contact.Business.Services.UserServices.Validations;
using Contact.Data.Entities;
using Contact.Data.Repositories;
using Contact.Data.Repositories.Interfaces;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Business.Services.UserServices
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public void Add(AddUserDto addUserDto)
        {
            ValidationTool.Validate(typeof(AddUserValidator), addUserDto);
            var entity = addUserDto.Adapt<User>();
            _userRepository.Add(entity);
            _unitOfWork.Commit();
        }

        public void Delete(Guid id)
        {
            var entity = _userRepository.Find(id);
            if (entity == null) throw new CustomException(CustomExceptionCodes.NotFound);
            _userRepository.Delete(entity);
        }

        public UserDto GetById(Guid id)
        {
            var entity = _userRepository.Find(id);
            if (entity == null) throw new CustomException(CustomExceptionCodes.NotFound);
            var dto = entity.Adapt<UserDto>();
            return dto;
        }

        public List<UserDto> GetList()
        {
            return _userRepository.ToQueryable().ProjectToType<UserDto>().ToList();
        }

        public void Update(UpdateUserDto updateUserDto)
        {
            ValidationTool.Validate(typeof(UpdateUserValidator), updateUserDto);
            var entity = _userRepository.Find(updateUserDto.Id);
            if (entity == null) throw new CustomException(CustomExceptionCodes.NotFound);
            updateUserDto.Adapt(entity);
            _userRepository.Update(entity);
            _unitOfWork.Commit();
        }

    }
}
