using System;
using System.Net.Mail;

namespace EmailSender
{
    class Program
    {
        static void Main(string[] args)
        {
            string select; string user; string paswd;
            string receiver; string mailbody = ""; string subj;
            Console.WriteLine("Select the email client you want to use \n");
            Console.WriteLine("1 for gmail");
            Console.WriteLine("2 for yahoo");
            Console.WriteLine("3 for Hotmail");
            Console.WriteLine("Any other number for custom email");
            select = Console.ReadLine();

            Console.WriteLine("Enter your username");
            user = Console.ReadLine();

            Console.WriteLine("Enter your password");
            paswd = Console.ReadLine();
            
            Console.WriteLine("Enter receivers email address");
            receiver = Console.ReadLine();

            Console.WriteLine("Enter the message subject");
            subj = Console.ReadLine();

            Console.WriteLine("Enter your message");
            mailbody = Console.ReadLine();


            Program p = new Program();
            EmailAccount myacc = new EmailAccount();
            int inSel = int.Parse(select);
            myacc = p.BuildEmailaccount(inSel, user, paswd);

            MyMailMessage msg = new MyMailMessage();
            msg.receiverEmail = receiver;
            msg.message = mailbody;
            msg.senderEmail = user;
            msg.subject = subj;
            string opmesg = p.sendmail(myacc, msg);

            Console.WriteLine(opmesg);
            Console.WriteLine("Hello World!");
        }

        string sendmail(EmailAccount account, MyMailMessage msg){
             try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient(account.smtp);

                mail.From = new MailAddress(account.username);
                mail.To.Add(msg.receiverEmail);
                mail.Subject = msg.subject;
                mail.Body = msg.message;

                SmtpServer.Port = account.port;
                SmtpServer.Credentials = new System.Net.NetworkCredential(account.username, account.password);
                SmtpServer.EnableSsl = account.isSSL;

                SmtpServer.Send(mail);
                return "mail Send";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
    
    
    EmailAccount BuildEmailaccount(int type, string username, string password,
     string smtp = "smtp.live.com", int port = 587, bool isSSL = false){
        EmailAccount myacc = new EmailAccount();
        switch (type){
            case 1:
            myacc.smtp = "smtp.gmail.com";
            myacc.port = 587;
            myacc.isSSL = true;
            myacc.username = username;
            myacc.password = password;
            //return myacc;
            break;
            case 2:
            myacc.smtp = "smtp.mail.yahoo.com";
            myacc.port = 465;
            myacc.isSSL = true;
            myacc.username = username;
            myacc.password = password;
            //return myacc;
            break;
            case 3:
            myacc.smtp = "smtp.live.com";
            myacc.port = 587;
            myacc.isSSL = true;
            myacc.username = username;
            myacc.password = password;
            //return myacc;
            break;
            default:
            myacc.smtp = smtp;
            myacc.port = port;
            myacc.isSSL = isSSL;
            myacc.username = username;
            myacc.password = password;
            //return myacc;
            break;
        }
        return myacc;
    }

    }
}
