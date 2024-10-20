namespace Template.Api.Endpoints
{
    // Sustiuir controladores por https://www.youtube.com/watch?v=Zu_8CVc_Ozc
    public static class TemplateEndpoint
    {
        public static void MapTemplate(this WebApplication builder)
        {
            var groups = builder.MapGroup("/template");

            groups.MapGet("/", () =>
            {
                return Results.Ok("Hola");
            });

        }
    }
}
