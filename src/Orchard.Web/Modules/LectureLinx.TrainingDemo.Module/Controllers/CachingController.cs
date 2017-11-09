using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Orchard.Caching;
using Orchard.Caching.Services;
using Orchard.Services;

namespace LectureLinx.TrainingDemo.Module.Controllers
{
    public class CachingController : Controller
    {
        private readonly ICacheService _cacheService;
        private readonly IClock _clock;
        private readonly ICacheManager _cacheManager;
        private readonly ISignals _signals;

        private const string CacheKey = "CurrentDateTime";


        public CachingController(ICacheService cacheService, IClock clock, ICacheManager cacheManager, ISignals signals)
        {
            _cacheService = cacheService;
            _clock = clock;
            _cacheManager = cacheManager;
            _signals = signals;
        }


        public string Store()
        {
            _cacheService.Put(CacheKey, _clock.UtcNow);

            return "OK";
        }

        public string Retrieve()
        {
            return ((DateTime)_cacheService.GetObject<DateTime>(CacheKey)).ToString();
        }

        public string Get()
        {
            return _cacheService.Get("CurrentDateTime2", () => _clock.UtcNow, TimeSpan.FromSeconds(5)).ToString();
        }

        public string CacheManagerGet()
        {
            return _cacheManager.Get("CurrentDateTime", context =>
            {
                //context.Monitor(_clock.When(TimeSpan.FromSeconds(5)));

                context.Monitor(_signals.When("MySignal"));

                return _clock.UtcNow;
            }).ToString();
        }

        public string TriggerSignal()
        {
            _signals.Trigger("MySignal");

            return "OK";
        }
    }
}