using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Mail;

namespace MyUtility
{
    public static class Mail
    {
        //private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private static string smtpUrl = "mail.domaintak.com", smtpPort = "25", email = "info@domaintak.com", pass = "Password";

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

                    smtpUrl = smtpDatas[0];

                    smtpPort = smtpDatas[1];

                    email = datas[1];

                    pass = datas[2];
                }
                else
                {
                    File.WriteAllText(filePath, string.Format("{0}:{1};{2};{3}", smtpUrl, smtpPort, email, pass));
                }

                return SendMail(email, to, subject, body, isBodyHtml, attachments);
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

            if (!attachments.IsNull() && attachments.Count > 0)
            {
                foreach (var attachment in attachments)
                {
                    message.Attachments.Add(attachment);
                }
            }
            //var smtp = new SmtpClient("mail.tajala.com", 25);
            var smtp = new SmtpClient(smtpUrl, smtpPort.ToInt());

            //            var smtpUser = new NetworkCredential("support@tajala.com", "6SnaqVjf6TS9iqm");
            var smtpUser = new NetworkCredential(email, pass);

            //            smtp.Host = "mail.tajala.com";
            smtp.Host = smtpUrl;

            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

            smtp.UseDefaultCredentials = false;

            smtp.Credentials = smtpUser;

            smtp.Port = smtpPort.ToInt();

            smtp.Send(message);

            /**********/

            return true;
        }

    }
}
