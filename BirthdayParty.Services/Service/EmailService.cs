using BirthdayParty.Application.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using BirthdayParty.Services.Constants;
using Microsoft.Extensions.Options;
using BirthdayParty.Domain.Payload.Response.OrderDetails;
using BirthdayParty.Application.Service.Common;
using BirthdayParty.Domain.Payload.Response.HostParties;
using BirthdayParty.Domain.Payload.Request.OrderDetails;
using Mysqlx.Crud;

namespace BirthdayParty.Services.Service
{
    public class EmailService : IEmailService
    {
        private readonly EmailSettings _emailSettings;
        private readonly IOrderDetailsService _orderDetailsService;
        private readonly IHostPartyService _hostPartyService;
        private readonly IAccountService _accountService;

        public EmailService(IOptions<EmailSettings> emailSettings
            , IOrderDetailsService orderDetailsService
            , IHostPartyService hostPartyService,
                IAccountService accountService)
        {
            _emailSettings = emailSettings.Value;
            _orderDetailsService = orderDetailsService;
            _hostPartyService = hostPartyService;
            _accountService = accountService;
        }
        public async Task SendEmailAsync(string orderDetailId)
        {
            
            // get order detail
            GetOrderDetailResponse orderDetail 
                = await _orderDetailsService.GetOrderDetailById(orderDetailId);

            string userId = orderDetail.Customer.UserId;
            var account = await _accountService.GetAccountById(userId);
            string toEmail = account.Email;
            string subject = "YOUR ORDER INFOMATION";

            GetHostPartyResponse hostParty = await _hostPartyService
                .GetHostPartyById(orderDetail.PartyPackage?.HostPartyId ?? "123");
            GmailOrderDetailRequest request = new GmailOrderDetailRequest()
            {
                ChildrenName = orderDetail.ChildrenName,
                TotalPrice = orderDetail.TotalPrice,
                StartTime = orderDetail.StartTime,
                EndTime = orderDetail.EndTime,
                ChildrenBirthday = orderDetail.ChildrenBirthday,
                NumberOfChildren = orderDetail.NumberOfChildren,
                OrderDate = orderDetail.Date,
                PackageName = orderDetail.PartyPackage?.Name ?? "Apple",
                HostPartyPhoneNumber = hostParty.PhoneNumber,
            };

            var content = $@"
<!DOCTYPE html>
<html>
<head>
    <style>
        body {{
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
            color: #333;
        }}
        .email-container {{
            width: 600px;
            margin: auto;
            border: 1px solid #ccc;
            border-radius: 5px;
            overflow: hidden;
        }}
        .email-header {{
            background-color: #f4f4f4;
            color: #444;
            padding: 10px;
            text-align: center;
            border-bottom: 1px solid #ddd;
        }}
        .email-body {{
            padding: 20px;
            line-height: 1.6;
        }}
        .email-footer {{
            background-color: #f4f4f4;
            color: #444;
            text-align: center;
            padding: 10px;
            border-top: 1px solid #ddd;
        }}
        .order-detail {{
            background-color: #f9f9f9;
            margin: 15px 0;
            padding: 15px;
            border: 1px solid #eee;
        }}
    </style>
</head>
<body>
    <div class=""email-container"">
        <div class=""email-header"">
            <h2>Order Detail Confirmation</h2>
        </div>
        <div class=""email-body"">
            <p>Dear Customer,</p>
            <p>Thank you for your order. Here are the details of your recent booking:</p>
            <div class=""order-detail"">
                <p><strong>Children's Name:</strong> {request.ChildrenName}</p>
                <p><strong>Total Price:</strong> ${request.TotalPrice}</p>
                <p><strong>Start Time:</strong> {request.StartTime?.ToString("f")}</p>
                <p><strong>End Time:</strong> {request.EndTime?.ToString("f")}</p>
                <p><strong>Children's Birthday:</strong> {request.ChildrenBirthday?.ToString("d")}</p>
                <p><strong>Number of Children:</strong> {request.NumberOfChildren}</p>
                <p><strong>Order Date:</strong> {request.OrderDate?.ToString("d")}</p>
                <p><strong>Package Name:</strong> {request.PackageName}</p>
                <p><strong>Host Party Phone Number:</strong> {request.HostPartyPhoneNumber}</p>
            </div>
            <p>We look forward to providing an unforgettable experience for your party.</p>
            <p>Best regards,</p>
            <p>Your Party Service Team</p>
        </div>
        <div class=""email-footer"">
            <p>Contact us for more information or assistance.</p>
        </div>
    </div>
</body>
</html>
";

            var smtpClient = new SmtpClient(_emailSettings.SmtpServer)
            {
                Port = _emailSettings.SmtpPort,
                Credentials = new NetworkCredential(_emailSettings.SmtpUsername, _emailSettings.SmtpPassword),
                EnableSsl = _emailSettings.SmtpUseSsl,
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress(_emailSettings.SmtpUsername),
                Subject = subject,
                Body = content,
                IsBodyHtml = true,
            };
            mailMessage.To.Add(toEmail);

            await smtpClient.SendMailAsync(mailMessage);
        }
    }
}
