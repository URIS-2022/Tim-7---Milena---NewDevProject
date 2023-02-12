using Application.Repositories.Interfaces;
using Domain.Entities;
using Infrastructure.DataContext;

namespace Infrastructure.Repositories.Implementations
{
    public class KorisnikRepository : Repository<Korisnik>, IKorisnikRepository
    {
        private readonly ApplicationDbContext _db;
        public KorisnikRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Korisnik korisnik)
        {
            _db.Korisnici.Update(korisnik);
        }
    }
}
