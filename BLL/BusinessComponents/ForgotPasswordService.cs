using BLL.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using DAL.Repositories;
using BLL.Mappers;
namespace BLL.BusinessComponents
{
    public class ForgotPasswordService
    {
        private PasswordResetTokenRepository _passwordResetTokenRepository;
        private readonly UserService _userService;
        public ForgotPasswordService()
        {
            _userService = new UserService();
            _passwordResetTokenRepository = new PasswordResetTokenRepository();
        }
        public string GenerateResetToken(string username)
        {
            var (user, email) = _userService.GetUserAndEmailByUsername(username);

            if (user == null || string.IsNullOrEmpty(email))
            {
                return null;
            }
            string token = new Random().Next(100000, 999999).ToString();
            DateTime expr = DateTime.Now.AddHours(1);
            Console.WriteLine($"User: {user.UserId}{user.Username}, Email: {email}");
            Console.WriteLine($"Generated Token: {token}");

            var passwordResetToken = new PasswordResetTokenDTO
            {
                UserId = user.UserId,
                ExpiryDate = expr,
                Token = token,
                CreatedAt = DateTime.Now
            };
            var passwordResetTokenEntity = PasswordResetTokenMapper.ToEntity(passwordResetToken);
            _passwordResetTokenRepository.Add(passwordResetTokenEntity);

            SendResetPasswordEmail(email, token);


            return token;
        }

        public void SendResetPasswordEmail(string email, string token)
        {
            try
            {
                var fromAddress = new MailAddress("vubaonguyen65@gmail.com", "CoffeeApp");
                var toAddress = new MailAddress(email);
                const string subject = "Đặt lại mật khẩu";
                const string fromPassword = "ysoehjheshpovghk"; 
                string body = $"Mã xác nhận của bạn là :<b>{token}</b>. Mã này có hiệu lực trong 1 giờ.";
                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                };

                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true
                })
                {
                    smtp.Send(message);
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi khi gửi email
                Console.WriteLine($"Lỗi khi gửi email: {ex.Message}");
            }
        }

    }
}
