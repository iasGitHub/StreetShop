using GestionStock.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GestionStock.Startup))]
namespace GestionStock
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            createRolesandUsers();
        }

        private void createRolesandUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            bdGesStockContext db = new bdGesStockContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
        
            if (!roleManager.RoleExists("Admin"))
            {
                //first we create admin role
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);
                
                //Here we create admin super user who will maintain the web app
                Profil p = new Profil();
                p.Code = role.Name;
                p.Libelle = "Administrateur";
                db.profils.Add(p);
                db.SaveChanges();
                
                //compte administrateur créé

                var user = new ApplicationUser();
                user.UserName = "iasr9";
                user.Email = "kalsjunior17@gmail.com";

                string userPWD = "@Passer2K21";

                var chkUser = UserManager.Create(user, userPWD);

                //le rôle par défaut est attribué à l'admin
                if (chkUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, "Admin");
                }
            }

            //création d'n compte invité
            if (!roleManager.RoleExists("Invité"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Invité";
                roleManager.Create(role);
                Profil p = new Profil();
                p.Code = role.Name;
                p.Libelle = "Invité";
                db.profils.Add(p);
                db.SaveChanges();
            }
        }
    }
}
