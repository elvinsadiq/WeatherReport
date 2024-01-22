using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.IRepositories;

namespace Core.Helpers
{
    public class LoginFailureCleanupService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILoginFailureTrackerRepository _loginFailureTrackerRepository;

        public LoginFailureCleanupService(IServiceProvider serviceProvider, ILoginFailureTrackerRepository loginFailureTrackerRepository)
        {
            _serviceProvider = serviceProvider;
            _loginFailureTrackerRepository = loginFailureTrackerRepository;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(TimeSpan.FromHours(12), stoppingToken);

                try
                {
                    using (var scope = _serviceProvider.CreateScope())
                    {
                        var loginFailureTrackers = _loginFailureTrackerRepository.GetAll(x => true).ToList();

                        foreach (var loginFailureTracker in loginFailureTrackers)
                        {
                            TimeSpan timeDifference = DateTime.UtcNow - loginFailureTracker.BlockLoginExpireTime;

                            if (timeDifference.TotalHours > 24)
                            {
                                _loginFailureTrackerRepository.Remove(loginFailureTracker);
                            }

                            _loginFailureTrackerRepository.Commit();
                        }
                    }
                }
                catch (Exception ex)
                {
                    await Console.Out.WriteLineAsync(ex.Message); ;
                }
            }
        }
    }
}
