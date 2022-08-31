using Common.Global.Business.Validation;
using Common.Global.DataService;
using Common.Global.Exceptions;
using Contact.Business.Interfaces;
using Contact.Business.Services.UserInformationServices.Dtos;
using Contact.Business.Services.UserInformationServices.Validators;
using Contact.Business.Services.UserServices.Dtos;
using Contact.Business.Services.UserServices.Validations;
using Contact.Data.Entities;
using Contact.Data.Repositories.Interfaces;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Business.Services.UserInformationServices
{
    public class UserInformationService : IUserInformationService
    {
        private readonly IUserInformationRepository _userInformationRepository;
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UserInformationService(IUserRepository userRepository, IUserInformationRepository userInformationRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _userInformationRepository = userInformationRepository;
            _unitOfWork = unitOfWork;
        }

        public void Add(AddUserInformationDto addDto)
        {
            ValidationTool.Validate(typeof(AddUserInformationValidator), addDto);
            var userEntity = _userRepository.Find(addDto.UserId);
            if (userEntity == null) throw new CustomException(CustomExceptionCodes.NotFound);
            var entity = addDto.Adapt<UserInformation>();
            _userInformationRepository.Add(entity);
            _unitOfWork.Commit();
        }

        public void Delete(Guid id)
        {
            var entity = _userInformationRepository.Find(id);
            if (entity == null) throw new CustomException(CustomExceptionCodes.NotFound);
            _userInformationRepository.Delete(entity);
        }

        public UserInformationDto GetById(Guid id)
        {
            var entity = _userInformationRepository.Find(id);
            if (entity == null) throw new CustomException(CustomExceptionCodes.NotFound);
            var dto = entity.Adapt<UserInformationDto>();
            return dto;
        }

        public List<UserInformationDto> GetListByUserId(Guid id)
        {
            return _userInformationRepository.ToQueryable().Where(x => x.UserId == id).ProjectToType<UserInformationDto>().ToList();
        }

        public void Update(UpdateUserInformationDto updateDto)
        {
            ValidationTool.Validate(typeof(UpdateUserInformationValidator), updateDto);
            var entity = _userInformationRepository.Find(updateDto.Id);
            if (entity == null) throw new CustomException(CustomExceptionCodes.NotFound);
            updateDto.Adapt(entity);
            _userInformationRepository.Update(entity);
            _unitOfWork.Commit();
        }

    }
}
