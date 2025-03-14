using Epreuve_WAD24_ASP.NET_MVC.Handlers.ActionFilters;
using Epreuve_WAD24_ASP.NET_MVC.Models.Jeux;
using System.Text.Json;
using System.Xml.Linq;

namespace Epreuve_WAD24_ASP.NET_MVC.Handlers
{
    public class SessionManager
    {
        private readonly ISession _session;

        public SessionManager(IHttpContextAccessor accessor)
        {
            _session = accessor.HttpContext.Session;
        }



        public ConnectedUser? ConnectedUser
        {
            get { return JsonSerializer.Deserialize<ConnectedUser?>(_session.GetString(nameof(ConnectedUser)) ?? "null"); }
            set
            {
                if (value is null)
                {
                    _session.Remove(nameof(ConnectedUser));
                }
                else
                {
                    _session.SetString(nameof(ConnectedUser), JsonSerializer.Serialize(value));
                }
            }
        }

        public IEnumerable<JeuxListItems> RecentlyVisitedJeux
        {
            get
            {
                string? json = _session.GetString(nameof(RecentlyVisitedJeux));
                if (json is null) return new JeuxListItems[0];
#pragma warning disable CS8603 // Possible null reference return.
                return JsonSerializer.Deserialize<JeuxListItems[]>(json);
#pragma warning restore CS8603 // Possible null reference return.
            }
            private set
            {
                string json = JsonSerializer.Serialize(value);
                _session.SetString(nameof(RecentlyVisitedJeux), json);
            }
        }

        public void Login(ConnectedUser user)
        {
            ConnectedUser = user;
        }

        public void Logout()
        {
            ConnectedUser = null;
        }

        //public void AddJeu(JeuxListItems jeu)
        //{
        //    // Ligne permettant d'insérer le cocktail
        //    List<JeuxListItems> jeux = new List<JeuxListItems>(RecentlyVisitedCocktails);
        //    CocktailListItemMin? cocktailInList = cocktails.Where(c => c.Cocktail_Id == cocktail.Cocktail_Id).SingleOrDefault();
        //    if (cocktailInList is not null)
        //    {
        //        cocktails.Remove(cocktailInList);
        //    }
        //    if (cocktails.Count == 5)
        //    {
        //        cocktails.Remove(cocktails[4]);
        //    }
        //    cocktails.Insert(0, cocktail);
        //    RecentlyVisitedCocktails = cocktails;
        //}
        public void AddVisitedCocktail(JeuxListItems jeu)
        {
            // Ligne permettant d'insérer le cocktail
            List<JeuxListItems> jeux = new List<JeuxListItems>(RecentlyVisitedJeux);
            JeuxListItems? jeuInList = jeux.Where(j => j.JeuId == jeu.JeuId).SingleOrDefault();
            if (jeuInList is not null)
            {
                jeux.Remove(jeuInList);
            }
            if (jeux.Count == 5)
            {
                jeux.Remove(jeux[4]);
            }
            jeux.Insert(0, jeu);
            RecentlyVisitedJeux = jeux;
        }

        public void AddVisitedJeux(Guid jeuId, string nom)
        {
            JeuxListItems jeu = new JeuxListItems()
            {
                JeuId = jeuId,
                Nom = nom
            };
            AddVisitedCocktail(jeu);
        }
    }
}
 
