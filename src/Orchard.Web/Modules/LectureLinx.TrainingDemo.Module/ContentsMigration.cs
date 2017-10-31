using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LectureLinx.TrainingDemo.Module.Models;
using Orchard.ContentManagement.MetaData;
using Orchard.Core.Contents.Extensions;
using Orchard.Data.Migration;
using Orchard.Environment.Extensions;

namespace LectureLinx.TrainingDemo.Module
{
    [OrchardFeature("LectureLinx.TrainingDemo.Module.Contents")]
    public class ContentsMigrations : DataMigrationImpl
    {
        public int Create()
        {
            SchemaBuilder
                .CreateTable(typeof(PersonListPartRecord).Name,
                    table => table
                        .ContentPartRecord()
                        .Column<string>("Sex"));

            ContentDefinitionManager
                .AlterPartDefinition(typeof(PersonListPart).Name,
                    part => part.Attachable());

            return 1;
        }

        public int UpdateFrom1()
        {
            ContentDefinitionManager
                .AlterTypeDefinition("PersonListContainer2",
                type => type
                    .DisplayedAs("Person List Container 2")
                    .Creatable()
                    .Listable()
                    .WithPart(typeof(PersonListPart).Name)
                    .WithPart("TitlePart")
                    .WithPart("CommonPart", builder => builder
                        .WithSetting("OwnerEditorSettings.ShowOwnerEditor", "True")));

            return 2;
        }
    }
}