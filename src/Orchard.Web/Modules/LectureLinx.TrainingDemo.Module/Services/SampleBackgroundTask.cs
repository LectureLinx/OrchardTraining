using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard;
using Orchard.Logging;
using Orchard.Tasks;

namespace LectureLinx.TrainingDemo.Module.Services
{
    public class SampleBackgroundTask : Component, IBackgroundTask
    {
        public void Sweep()
        {
            Logger.Error("This is just a test.");
        }
    }
}