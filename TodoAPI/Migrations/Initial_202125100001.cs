using FluentMigrator;

namespace TodoAPI.Migrations
{
    [Migration(202125100001)]
    public class Initial_202125100001 : Migration
    {
        public override void Down()
        {
            Delete.Table("Todos");
            Delete.Table("Users");
        }

        public override void Up()
        {
            Create.Table("Users")
                .WithColumn("Id").AsGuid().NotNullable().PrimaryKey()
                .WithColumn("Firstname").AsString(50).NotNullable()
                .WithColumn("Lastname").AsString(60).NotNullable()
                .WithColumn("Email").AsString(50).NotNullable();

            Create.Table("Todos")
                .WithColumn("Id").AsGuid().NotNullable().PrimaryKey()
                .WithColumn("Title").AsString(50).NotNullable()
                .WithColumn("Status").AsString(10).NotNullable()
                .WithColumn("Description").AsString().NotNullable()
                .WithColumn("UserId").AsGuid().NotNullable().ForeignKey("Users", "Id");
        }
    }
}