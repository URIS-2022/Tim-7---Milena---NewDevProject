using Application.Repositories.Interfaces;
using Domain.Entities;
using Infrastructure.DataContext;

namespace Infrastructure.Repositories.Implementations
{
    public class TipKorisnikaRepository : Repository<TipKorisnika>, ITipKorisnikaRepository
    {
        private readonly ApplicationDbContext _db;

        public TipKorisnikaRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(TipKorisnika tipKorisnika)
        {
            _db.TipoviKorisnika.Update(tipKorisnika);
        }
    }
}
