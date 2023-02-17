using AutoMapper;
using LicitacijaServis.Entities;
using Microsoft.EntityFrameworkCore;

namespace LicitacijaServis.Data
{
    public class LicitacijaRepository:ILicitacijaRepository
    {
        public LicitacijaContext _context;
        private readonly IMapper _mapper;
        public LicitacijaRepository(LicitacijaContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<Licitacija> GetLicitacijas()
        {
            var licitacije= _context.Licitacijas.OrderBy(p => p.LicitacijaId).ToList();
            foreach (var l in licitacije)
            {
                l.JavnaNadmetanja = _context.LicitacijaJavnoNadmetanjes.Where(ku => ku.LicitacijaId == l.LicitacijaId).Select(pk => pk.JavnoNadmetanjeId).ToList();
                
            }

            return (licitacije);
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() > 0;
        }

        public Licitacija CreateLicitacija(Licitacija licitacija)
        {
            licitacija.LicitacijaId = Guid.NewGuid();
            var created =_context.Licitacijas.Add(licitacija);
     
            if (licitacija.JavnaNadmetanja != null)
            {
                foreach (var jnID in licitacija.JavnaNadmetanja)
                {
                    LicitacijaJavnoNadmetanje licJn = new LicitacijaJavnoNadmetanje
                    {
                        LicitacijaId = licitacija.LicitacijaId,
                        JavnoNadmetanjeId = jnID
                    };
                    _context.LicitacijaJavnoNadmetanjes.Add(licJn);
                }
            }
            _context.SaveChanges();
            return _mapper.Map<Licitacija>(created.Entity);
        }

        public void DeleteLicitacija(Guid licitacijaId)
        {
            _context.Licitacijas.Remove(_context.Licitacijas.FirstOrDefault(l => l.LicitacijaId == licitacijaId));
        }

        public Licitacija GetLicitacijaById(Guid licitacijaId)
        {
            Licitacija? licitacija= _context.Licitacijas.Where(p => p.LicitacijaId == licitacijaId).FirstOrDefault();
            if (licitacija is not  null)
                licitacija.JavnaNadmetanja = _context.LicitacijaJavnoNadmetanjes.Where(ku => ku.LicitacijaId == licitacija.LicitacijaId).Select(pk => pk.JavnoNadmetanjeId).ToList(); 
            return licitacija;
            
        }

        public void UpdateLicitacija(Licitacija staraLicitacija,Licitacija novaLicitacija)
        {
            _context.LicitacijaJavnoNadmetanjes.Where(j => j.LicitacijaId == staraLicitacija.LicitacijaId).ExecuteDelete();
         
            _context.Remove(staraLicitacija);
            _context.SaveChanges();
            _context.Add(novaLicitacija);



            if (novaLicitacija.JavnaNadmetanja != null)
            {
                foreach (var jnID in novaLicitacija.JavnaNadmetanja)
                {
                    LicitacijaJavnoNadmetanje licitacijaJavnoNadmetanje = new LicitacijaJavnoNadmetanje
                    {
                        LicitacijaId = novaLicitacija.LicitacijaId,
                        JavnoNadmetanjeId = jnID
                    };
                    _context.LicitacijaJavnoNadmetanjes.Add(licitacijaJavnoNadmetanje);
                }
            }

            _context.SaveChanges();
        }



        
    }
}
