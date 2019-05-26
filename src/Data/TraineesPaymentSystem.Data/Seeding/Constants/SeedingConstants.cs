using System.Collections.Generic;

namespace TraineesPaymentSystem.Data.Seeding.Constants
{
    public static class SeedingConstants
    {
        public static Dictionary<string, decimal> TaskTypes = new Dictionary<string, decimal>()
        {
            {"Update Presentation", 5},
            {"Create Presentation", 5},
            {"Review Presentation", 5},
            { "Create Exercise", 5},
            { "Review Exercise", 5},
            { "Create Exam", 5},
            { "Co-assistant", 3},
            { "Assistant", 5},
            { "Questor", 6},
            { "Co-lecturer", 10}
        };

        public const string RoleUser = "User";

        public const string RoleModerator = "Moderator";

        public const string RoleAdministration = "Administrator";
    }
}