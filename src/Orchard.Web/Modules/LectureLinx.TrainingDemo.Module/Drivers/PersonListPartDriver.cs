using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LectureLinx.TrainingDemo.Module.Models;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Drivers;
using Orchard.Environment.Extensions;

namespace LectureLinx.TrainingDemo.Module.Drivers
{
    [OrchardFeature("LectureLinx.TrainingDemo.Module.Contents")]
    public class PersonListPartDriver : ContentPartDriver<PersonListPart>
    {
        protected override DriverResult Display(PersonListPart part, string displayType, dynamic shapeHelper)
        {
            return ContentShape("Parts_PersonList",
                () => shapeHelper.Parts_PersonList());
        }

        protected override DriverResult Editor(PersonListPart part, dynamic shapeHelper)
        {
            return ContentShape("Parts_PersonList_Edit",
                () => shapeHelper.EditorTemplate(
                    TemplateName: "Parts.PersonList",
                    Model: part,
                    Prefix: Prefix));
        }

        protected override DriverResult Editor(PersonListPart part, IUpdateModel updater, dynamic shapeHelper)
        {
            updater.TryUpdateModel(part, Prefix, null, null);
            return Editor(part, shapeHelper);
        }

        //protected override void Exporting(PersonListPart part, ExportContentContext context)
        //{
        //    var element = context.Element(part.PartDefinition.Name);

        //    element.SetAttributeValue("MyProperty", part.MyProperty);
        //}

        //protected override void Importing(PersonListPart part, ImportContentContext context)
        //{
        //    var partName = part.PartDefinition.Name;

        //    context.ImportAttribute(partName, "MyProperty", value => part.MyProperty = value);
        //}
    }
}