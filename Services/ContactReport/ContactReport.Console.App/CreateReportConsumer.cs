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
        private readonly AppDbContext _context;
   

        public CreateReportConsumer(AppDbContext context)
        {
            _context = context;
        }

        public Task Consume(ConsumeContext<CreateReportMessage> context)
        {
            
            var message = context.Message;

            var userReport = _context.UserReports.FirstOrDefault(x => x.Id == message.ReportId);
            
            if(userReport != null)
            {
                userReport.ReportStatus = ReportStatus.Completed;
                userReport.ExcelPath = $"{userReport.Id} excel path completed";
                _context.SaveChanges();

                System.Console.WriteLine($"completed report {message.ReportId}");
                string jsonString = JsonSerializer.Serialize(context.Message);
            }

            return Task.CompletedTask;
        }
    }
}
