using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.Forms.Services;
using Orchard.Localization;
using Orchard.UI.Notify;
using Orchard.Workflows.Models;
using Orchard.Workflows.Services;

namespace LectureLinx.TrainingDemo.Module.Activities
{
    public class WarningActivity : Task
    {
        private readonly INotifier _notifier;

        public Localizer T { get; set; }


        public WarningActivity(INotifier notifier)
        {
            _notifier = notifier;

            T = NullLocalizer.Instance;
        }


        public override LocalizedString Category { get { return T("Notification"); } }

        public override LocalizedString Description { get { return T("Displays a warning."); } }

        public override string Name { get { return "Warning"; } }

        public override string Form { get { return "WarningActivity"; } }

        public override IEnumerable<LocalizedString> Execute(WorkflowContext workflowContext, ActivityContext activityContext)
        {
            _notifier.Warning(T(activityContext.GetState<string>("Message")));

            yield return T("Done");

            //if (true)
            //{
            //    yield return T("Accept");
            //}
            //else
            //{
            //    yield return T("Reject");
            //}
        }

        public override IEnumerable<LocalizedString> GetPossibleOutcomes(WorkflowContext workflowContext, ActivityContext activityContext)
        {
            yield return T("Done");

            //return new[]
            //{
            //    T("Accept"),
            //    T("Reject")
            //};
        }
    }


    public class WarningActivityForm : IFormProvider
    {
        public Localizer T { get; set; }


        public WarningActivityForm()
        {
            T = NullLocalizer.Instance;
        }


        public void Describe(DescribeContext context)
        {
            context.Form("WarningActivity", shapeFactory =>
            {
                var shape = (dynamic)shapeFactory;
                return shape.Form(
                        Id: "WarningActivity",
                        _Message: shape.Textbox(
                            Id: "Message",
                            Name: "Message",
                            Title: T("Message"),
                            Description: T("The warning message to display."),
                            Classes: new[] { "tokenized", "text", "medium" }));
            });
        }
    }
}