using AuthomaticSendingEmail3;

using Quartz;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Net.Mail;
using System.Net;
using System.Data.SqlClient;
using NemeTschek.Data;
using Microsoft.EntityFrameworkCore;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
{
    // var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer("Server=SCHOOL2022;Database=EvenTschek;User Id=speeditup_spring_2022;password=nem58483572!;Trusted_Connection=False;MultipleActiveResultSets=true;"));

    services.AddQuartz(q =>
    {
        q.UseMicrosoftDependencyInjectionJobFactory();
        q.ScheduleJob<SendMailJob>(trigger => trigger
        .WithIdentity("SendRecurringMailTrigger")
        .WithSimpleSchedule(s =>
            s.WithIntervalInSeconds(10)
            .RepeatForever()
        )
        .WithDescription("This trigger will run every 1 day to send emails.")
    );
    });

    services.AddQuartzHostedService(options =>
    {
        // when shutting down we want jobs to complete gracefully
        options.WaitForJobsToComplete = true;
    });
})
    .Build();

await host.RunAsync();



class SendMailJob : IJob
{
    private readonly ApplicationDbContext dbContext;
    public int returnDays(DateTime date)
    {
        return date.Day + date.Month * 28 + (date.Year - 2020) * 365;
    }

    private readonly ILogger logger;

    public SendMailJob(ILogger<SendMailJob> logger, ApplicationDbContext dbContext)
    {

        this.logger = logger;
        this.dbContext = dbContext;
    }

    public async Task Execute(IJobExecutionContext context)
    {
        DateTime now = DateTime.Now;
        int nowDays = 0;
        int eventDays = 0;
        int checkDays = 0;
        try
        {
            foreach (var eventt in dbContext.Event)
            {

                nowDays = returnDays(now);
                eventDays = returnDays(eventt.StartDate);
                checkDays = eventDays - nowDays;
                if (checkDays == 30 || checkDays == 7 || checkDays == 3 || checkDays == 1)
                {
                    var smtpclient = new SmtpClient("smtp.gmail.com")
                    {
                        UseDefaultCredentials = false,
                        Port = 587,
                        Credentials = new NetworkCredential("eventschek@gmail.com", "jumngmaujnjbqjvj"),
                        EnableSsl = true,
                        DeliveryMethod = SmtpDeliveryMethod.Network
                    };
                    MailMessage message = new MailMessage();
                    MailAddress sender = new MailAddress("eventschek@gmail.com", "eventschek");
                    message.From = sender;
                    message.Subject = $"Event soon";
                    message.Body = $"Event {eventt.Name} in {checkDays} day/s!";
                    List<UsersEvents> usersEvents = dbContext.UsersEvents.Where(t => t.EventId == eventt.EventId).ToList();

                    foreach (UsersEvents ue in usersEvents)
                    {
                        string email = dbContext.Users.First(t => t.Id == ue.UserId).Email;
                        message.To.Add(email);
                    }
                    smtpclient.Send(message);
                    logger.LogInformation("Everything succ");

                }
            }
            //SqlConnection conn = new SqlConnection("Server=SCHOOL2022;Database=EvenTschek;User Id=speeditup_spring_2022;password=nem58483572!;Trusted_Connection=False;MultipleActiveResultSets=true;");
            //logger.LogInformation("Opening con");

            ////open connection
            //conn.Open();
            ////SqlCommand cmd = new SqlCommand(, conn);

            //SqlDataAdapter sda = new SqlDataAdapter("Select * from Event WHERE", conn);

            //logger.LogInformation("Con succ");
        }
        catch (Exception e)
        {
            logger.LogInformation("Con not succ");
            logger.LogInformation(e.Message);
        }



        //message.To.Add()
        //message.To.Add
        //            message.Subject = "event";
        //            message.Body = "event soon b!tch";


        //            var smtpclient = new SmtpClient("smtp.gmail.com")
        //            {

        //                UseDefaultCredentials = false,
        //                Port = 587,
        //                Credentials = new NetworkCredential("eventschek@gmail.com", "jumngmaujnjbqjvj"),
        //                EnableSsl = true,
        //                DeliveryMethod = SmtpDeliveryMethod.Network
        //            };
        //            smtpclient.Send(message);

        ////        }
        ////    }
        ////}
    }
}