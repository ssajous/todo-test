using FluentMigrator;

namespace TodoTest.DataMigrations
{
    [Migration(1)]
    public class InitialTableCreation : Migration
    {
        public override void Up()
        {
            Create.Table("TodoItem")
                .WithColumn("TodoId").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("Title").AsString(1024).NotNullable()
                .WithColumn("IsCompleted").AsBinary().NotNullable();
        }

        public override void Down()
        {
            Delete.Table("TodoItem");
        }
    }
}
