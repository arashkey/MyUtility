using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Mail;

namespace MyUtility
{
    public static class Mail
    {

        private static string _smtpUrl = "mail.domain.com"
            , _smtpPort = "25", _email = "info@domain.com", _pass = "Password";

        public static bool SendMail(string to, string subject, string body, bool isBodyHtml, List<Attachment> attachments = null)
        {
            try
            {
                var filePath = Basic.AssemblyDirectory + "\\" + "Email.txt";
                if (File.Exists(filePath))
                {
                    var data = File.ReadAllText(filePath);

                    var datas = data.Split(';');

                    var smtpDatas = datas[0].Split(':');

                    _smtpUrl = smtpDatas[0];

                    _smtpPort = smtpDatas[1];

                    _email = datas[1];

                    _pass = datas[2];
                }
                else
                {
                    File.WriteAllText(filePath, $"{_smtpUrl}:{_smtpPort};{_email};{_pass}");
                }

                return SendMail(_email, to, subject, body, isBodyHtml, attachments);
            }
            catch (Exception ex)
            {
                ExceptionReport.log(ex);
                throw new Exception("Email file not configured correctly.\r\n" + ex.Message);
            }
        }

        public static bool SendMail(string from, string to, string subject, string body, bool isBodyHtml, List<Attachment> attachments = null)
        {
            var message = new MailMessage { From = new MailAddress(from) };
            message.To.Add(new MailAddress(to));
            message.Subject = subject;
            message.Body = body;
            message.IsBodyHtml = isBodyHtml;

            if (attachments != null && !attachments.IsNull() && attachments.Count > 0)
            {
                foreach (var attachment in attachments)
                {
                    message.Attachments.Add(attachment);
                }
            }
            var smtp = new SmtpClient(_smtpUrl, _smtpPort.ToInt());

            var smtpUser = new NetworkCredential(_email, _pass);

            smtp.Host = _smtpUrl;

            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

            smtp.UseDefaultCredentials = false;

            smtp.Credentials = smtpUser;

            smtp.Port = _smtpPort.ToInt();

            smtp.Send(message);

            /**********/

            return true;
        }

    }
}
