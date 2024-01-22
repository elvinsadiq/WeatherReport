    namespace Domain.Entities
    {
        public class LoginFailureTracker : BaseEntity
        {
            public AppUser AppUser{ get; set; }
            public int AppUserId { get; set; }
            public int LoginTryCount { get; set; }
            public DateTime BlockLoginExpireTime { get; set; } = DateTime.UtcNow;
            public bool IsBlocked { get; set; }
     
            public void SetDetails(int appUserId, int loginTryCount, bool isBlocked)
            {
                this.AppUserId = appUserId;
                this.LoginTryCount = loginTryCount;
                this.IsBlocked = isBlocked;
            }
            public void IncreaseLoginTryCount()
            {
                LoginTryCount++;
            }
            public void BlockUser()
            {
                LoginTryCount = 0;
                IsBlocked = true;
                BlockLoginExpireTime = DateTime.Now.AddHours(2).ToUniversalTime();
            }
        }
    }