// Decompiled with JetBrains decompiler
// Type: MyUtility.Mail
// Assembly: MyUtility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9de928c05a3c751e
// MVID: 59ECCB6B-F93C-42F8-9F4A-1BDFB8E4814F
// Assembly location: F:\_pro_\AspNetMVC\MyWork\AtlasAmar\AtlasAmar\AtlasAmar\Helpers\MyUtility.dll

using log4net;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Reflection;

namespace MyUtility
{
  public static class Mail
  {
    private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
    private static string smtpUrl = "mail.domaintak.com";
    private static string smtpPort = "25";
    private static string email = "info@domaintak.com";
    private static string pass = "Password";

    public static bool SendMail(string to, string subject, string body, bool isBodyHtml, List<Attachment> attachments = null)
    {
      try
      {
        string path = Basic.AssemblyDirectory + "\\Email.txt";
        if (System.IO.File.Exists(path))
        {
          string[] strArray1 = System.IO.File.ReadAllText(path).Split(';');
          string[] strArray2 = strArray1[0].Split(':');
          int index1 = 0;
          MyUtility.Mail.smtpUrl = strArray2[index1];
          int index2 = 1;
          MyUtility.Mail.smtpPort = strArray2[index2];
          MyUtility.Mail.email = strArray1[1];
          MyUtility.Mail.pass = strArray1[2];
        }
        else
          System.IO.File.WriteAllText(path, string.Format("{0}:{1};{2};{3}", (object) MyUtility.Mail.smtpUrl, (object) MyUtility.Mail.smtpPort, (object) MyUtility.Mail.email, (object) MyUtility.Mail.pass));
        return MyUtility.Mail.SendMail(MyUtility.Mail.email, to, subject, body, isBodyHtml, attachments);
      }
      catch (Exception ex)
      {
        ExceptionReport.log(ex, "");
        throw new Exception("Email file not configured correctly.\r\n" + ex.Message);
      }
    }

    public static bool SendMail(string from, string to, string subject, string body, bool isBodyHtml, List<Attachment> attachments = null)
    {
      MailMessage mailMessage = new MailMessage()
      {
        From = new MailAddress(from)
      };
      mailMessage.To.Add(new MailAddress(to));
      mailMessage.Subject = subject;
      mailMessage.Body = body;
      mailMessage.IsBodyHtml = isBodyHtml;
      if (!attachments.IsNull() && attachments.Count > 0)
      {
        foreach (Attachment attachment in attachments)
          mailMessage.Attachments.Add(attachment);
      }
      SmtpClient smtpClient = new SmtpClient(MyUtility.Mail.smtpUrl, MyUtility.Mail.smtpPort.ToInt());
      NetworkCredential networkCredential1 = new NetworkCredential(MyUtility.Mail.email, MyUtility.Mail.pass);
      string smtpUrl = MyUtility.Mail.smtpUrl;
      smtpClient.Host = smtpUrl;
      int num1 = 0;
      smtpClient.DeliveryMethod = (SmtpDeliveryMethod) num1;
      int num2 = 0;
      smtpClient.UseDefaultCredentials = num2 != 0;
      NetworkCredential networkCredential2 = networkCredential1;
      smtpClient.Credentials = networkCredential2;
      int num3 = MyUtility.Mail.smtpPort.ToInt();
      smtpClient.Port = num3;
      MailMessage message = mailMessage;
      smtpClient.Send(message);
      return true;
    }
  }
}
