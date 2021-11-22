#nullable enable
using System.Collections.Generic;
using LBPUnion.ProjectLighthouse.Types;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LBPUnion.ProjectLighthouse.Pages.Layouts
{
    public class BaseLayout : PageModel
    {
        public readonly Database Database;

        private User? user;

        public new User? User {
            get {
                if (this.user != null) return this.user;

                return user = Database.UserFromWebRequest(this.Request);
            }
            set => this.user = value;
        }

        public BaseLayout(Database database)
        {
            this.Database = database;
        }

        public readonly List<PageNavigationItem> NavigationItems = new()
        {
            new PageNavigationItem("Home", "/", "home"),
            new PageNavigationItem("Photos", "/photos", "camera"),
        };

    }
}