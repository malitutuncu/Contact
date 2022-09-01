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
using System.Text.Json;
using System.Threading.Tasks;

namespace Contact.Business.Services.UserReportServices
{
    public class UserReportService : IUserReportService
    {
        private readonly IRepository<ReportOutboxMessage> _reportOutboxRepository;
        private readonly IUserReportRepository _userReportRepository;
        private readonly IUnitOfWork _unitOfWork;


        public UserReportService(IRepository<ReportOutboxMessage> reportOutboxRepository, IUserReportRepository userReportRepository, IUnitOfWork unitOfWork)
        {
            _userReportRepository = userReportRepository;
            _reportOutboxRepository = reportOutboxRepository;
            _unitOfWork = unitOfWork;
        }

        public void RequestReportAsync(Guid userId)
        {
            var entity = new UserReport
            {
                UserId = userId
            };
            _userReportRepository.Add(entity);

            var payload = JsonSerializer.Serialize(new CreateReportMessage(entity.Id));


            var outboxMessage = new ReportOutboxMessage
            {
                Type = nameof(CreateReportMessage),
                Payload = payload
            };

            _reportOutboxRepository.Add(outboxMessage);

            _unitOfWork.Commit();
        }
    }
}
