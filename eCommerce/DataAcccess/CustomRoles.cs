using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eCommerce.DataAcccess
{
    public static class CustomRoles
    {
        public const string Admin = "Admin";
        public const string Assistant = "Assistant";
        public const string Client = "Client";
        public const string Moderateur = "Moderateur";
        public const string AdminOrAssistant = Admin + "," + Assistant;
        public const string AdminOrModerateur = Admin + "," + Moderateur;
    }
}