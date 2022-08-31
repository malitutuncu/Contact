using Common.Contracts.Report;
using Common.Global.DataService;
using Contact.Business.Interfaces;
using Contact.Business.Services.UserServices.Dtos;
using Contact.Data.Entities;
using Contact.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Business.Services.UserReportServices
{
    public class UserReportService : IUserReportService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserReportRepository _userReportRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UserReportService(IUserRepository userRepository, IUserReportRepository userReportRepository, IUnitOfWork unitOfWork)
        {
            _userReportRepository = userReportRepository;
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task RequestReportAsync(Guid userId)
        {
            var entity = new UserReport
            {
                UserId = userId
            };
            _userReportRepository.Add(entity);
            _unitOfWork.Commit();

            await CreateReportPublisher.PublishAsync(entity.Id);
        }
    }
}
