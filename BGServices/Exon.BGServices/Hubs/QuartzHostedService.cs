using Quartz.Spi;
using Quartz;

namespace Exon.BGServices.Hubs
{
    public class QuartzHostedService : IHostedService
    {
        private readonly ISchedulerFactory SchedulerFactory;
        private readonly IJobFactory JobFactory;
        private readonly IEnumerable<JobSchedule> JobSchedules;

        public QuartzHostedService(
            ISchedulerFactory schedulerFactory,
            IJobFactory jobFactory,
            IEnumerable<JobSchedule> jobSchedules)
        {
            SchedulerFactory = schedulerFactory;
            JobSchedules = jobSchedules;
            JobFactory = jobFactory;
        }
        public IScheduler Scheduler { get; set; }
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            Scheduler = await SchedulerFactory.GetScheduler(cancellationToken);
            Scheduler.JobFactory = JobFactory;

            foreach (var jobSchedule in JobSchedules)
            {
                var job = CreateJob(jobSchedule);
                var trigger = CreateTrigger(jobSchedule);

                await Scheduler.ScheduleJob(job, trigger, cancellationToken);
            }

            await Scheduler.Start(cancellationToken);
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            await Scheduler?.Shutdown(cancellationToken);
        }

        private static IJobDetail CreateJob(JobSchedule schedule)
        {
            var jobType = schedule.JobType;
            return JobBuilder
                .Create(jobType)
                .WithIdentity(jobType.FullName)
                .WithDescription(jobType.Name)
                .Build();
        }

        private static ITrigger CreateTrigger(JobSchedule schedule)
        {
            return TriggerBuilder
                .Create()
                .WithIdentity($"{schedule.JobType.FullName}.trigger")
                .WithCronSchedule(schedule.CronExpression)
                .WithDescription(schedule.CronExpression)
                .Build();
        }
    }
}
