using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LectureLinx.TrainingDemo.Module.Models;
using Orchard.ContentManagement.MetaData;
using Orchard.Core.Contents.Extensions;
using Orchard.Data.Migration;

namespace LectureLinx.TrainingDemo.Module
{
    public class Migrations : DataMigrationImpl
    {
        public int Create()
        {
            SchemaBuilder
                .CreateTable(typeof(PersonRecord).Name,
                    table => table
                        .Column<int>("Id", column => column.PrimaryKey().Identity())
                        .Column<string>("Name", column => column.WithLength(255))
                        .Column<string>("Sex")
                        .Column<DateTime>("BirthDateUtc")
                        .Column<string>("Biography", column => column.Unlimited()))
                .AlterTable(typeof(PersonRecord).Name,
                    table => table
                        .CreateIndex("Sex", "Sex"));

            return 2;
        }

        public int UpdateFrom1()
        {
            SchemaBuilder.AlterTable(typeof(PersonRecord).Name,
                table => table
                    .CreateIndex("Sex", "Sex"));

            return 2;
        }
    }
}