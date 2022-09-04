using Common.Contracts.Report;
using Common.Global.DataService;
using Contact.Data.Context;
using Contact.Data.Entities;
using Contact.Data.Enums;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ContactReport.Console.App
{
    public class CreateReportConsumer : IConsumer<CreateReportMessage>
    {
        private readonly IRepository<UserReport> _userReportRepository;
        private readonly IUnitOfWork _unitOfWork;
   

        public CreateReportConsumer(IRepository<UserReport> userReportRepository, IUnitOfWork unitOfWork)
        {
            _userReportRepository = userReportRepository;
            _unitOfWork = unitOfWork;
        }

        public Task Consume(ConsumeContext<CreateReportMessage> context)
        {
            
            var message = context.Message;


            
            var userReport = _userReportRepository.Get(x => x.Id == message.ReportId);


            userReport.ReportStatus = ReportStatus.Completed;
            userReport.ExcelPath = $"{userReport.Id} excel path completed";

            _userReportRepository.Update(userReport);
            _unitOfWork.Commit();

            System.Console.WriteLine($"completed report {message.ReportId}");
            string jsonString = JsonSerializer.Serialize(context.Message);
            return Task.CompletedTask;
        }
    }
}
