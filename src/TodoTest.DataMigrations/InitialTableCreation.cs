using FluentMigrator;

namespace TodoTest.DataMigrations
{
    [Migration(1)]
    public class InitialTableCreation : Migration
    {
        public override void Up()
        {
            Create.Table("TodoItems")
                .WithColumn("TodoItemId").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("Title").AsString(1024).NotNullable()
                .WithColumn("IsCompleted").AsBoolean().NotNullable();
        }

        public override void Down()
        {
            Delete.Table("TodoItems");
        }
    }
}
