using Quartz;
using Quartz.Spi;

namespace Exon.BGServices.Hubs
{
    public class SingletonJobFactory : IJobFactory
    {
        private readonly IServiceProvider ServiceProvider;

        public SingletonJobFactory(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
        }

        public IJob NewJob(TriggerFiredBundle bundle, IScheduler scheduler)
        {
            return ServiceProvider.GetRequiredService(bundle.JobDetail.JobType) as IJob;
        }

        public void ReturnJob(IJob job)
        {
        }
    }
}
