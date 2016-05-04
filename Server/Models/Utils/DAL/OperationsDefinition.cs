namespace Server.Models.Utils.DAL.Common
{
    internal class OperationsDefinition
    {
        public static Operation[] Functions { get; set; } = new Operation[]
        {
            new Operation()
            {
                Name = "GetFilmsWithActors",
                Parameters = new Parameter[]
                {
                    new Parameter
                    {
                        Name = "releaseYear",
                        Type = "int",
                        Nullable = false
                    }
                },
                ReturnType = new ReturnType()
                {
                    Type = "Film",
                    IsEntity = true,
                    IsCollection = true,
                    Nullable = false
                }
            },
        };

        public static Operation[] Actions { get; set; } = new Operation[]
        {
            new Operation()
            {
                Name = "TestAction",
                Parameters = new Parameter[]
                {
                    new Parameter
                    {
                        Name = "param1",
                        Type = "int",
                        Nullable = false
                    }
                },
                ReturnType = null
            },
        };
    }
}
