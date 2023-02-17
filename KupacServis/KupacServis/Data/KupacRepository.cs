using AutoMapper;
using KupacServis.Entities;
using KupacServis.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace KupacServis.Data
{
    public class KupacRepository:IKupacRepository
    {
        public KupacContext _context;
        private readonly IMapper _mapper;
        private readonly IFizickoLiceRepository _fizickoLiceRepository;
        private readonly IPravnoLiceRepository _pravnoLiceRepository;
        public KupacRepository(KupacContext context,IMapper mapper,IFizickoLiceRepository fizickoLiceRepository,IPravnoLiceRepository pravnoLiceRepository)
        {
            _context = context;
            _mapper = mapper;
            _fizickoLiceRepository = fizickoLiceRepository;
            _pravnoLiceRepository = pravnoLiceRepository;
        }
        
        public Kupac CreateKupac(Kupac kupac)
        {

            kupac.KupacId = Guid.NewGuid();
            var created = _context.Kupacs.Add(kupac);

            if(kupac.OvlascenaLica != null)
            {
                foreach(var ovlascenoLiceID in kupac.OvlascenaLica)
                {
                    KupacOvlascenoLice kupacOL = new KupacOvlascenoLice
                    {
                        KupacId = kupac.KupacId,
                        OvlascenoLiceId = ovlascenoLiceID
                    };
                    _context.KupacOvlascenoLices.Add(kupacOL);
                }
            }
            if (kupac.JavnaNadmetanja != null)
            {
                foreach (var javnoNadmetanjeId in kupac.JavnaNadmetanja)
                {
                    KupacJavnoNadmetanje kupacJn = new KupacJavnoNadmetanje
                    {
                        KupacId = kupac.KupacId,
                        JavnoNadmetanjeId = javnoNadmetanjeId
                    };
                    _context.KupacJavnoNadmetanjes.Add(kupacJn);
                }
            }
           

            _context.SaveChanges();
            return _mapper.Map<Kupac>(created.Entity);
        }

        public void DeleteKupac(Guid kupacId)
        {
            _context.Kupacs.Remove(_context.Kupacs.FirstOrDefault(l => l.KupacId == kupacId));
        }

        public Kupac GetKupacById(Guid kupacId)
        {
           
            var kupac = _context.Kupacs.Include(i => i.FizickoLice).Include(i => i.PravnoLice).Where(i => i.KupacId == kupacId).Include(i=>i.Prioritet).FirstOrDefault();
            if (kupac is not null)
            {
                kupac.OvlascenaLica = _context.KupacOvlascenoLices.Where(ku => ku.KupacId == kupacId).Select(pk => pk.OvlascenoLiceId).ToList();
                kupac.JavnaNadmetanja = _context.KupacJavnoNadmetanjes.Where(ku => ku.KupacId == kupacId).Select(pk => pk.JavnoNadmetanjeId).ToList();
            } 
            return kupac;
        }

        public List<Kupac> GetKupacs()
        {
            var kupci= _context.Kupacs.Include(i => i.FizickoLice)
                .Include(i => i.PravnoLice).Include(i=>i.Prioritet).ToList();

            foreach (var k in kupci)
            {
                k.OvlascenaLica = _context.KupacOvlascenoLices.Where(ku => ku.KupacId == k.KupacId).Select(pk => pk.OvlascenoLiceId).ToList();
                k.JavnaNadmetanja = _context.KupacJavnoNadmetanjes.Where(ku => ku.KupacId == k.KupacId).Select(pk => pk.JavnoNadmetanjeId).ToList();
              

            }


            return (kupci);

        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() > 0;
        }

        public void UpdateKupac(Kupac stariKupac,Kupac noviKupac)
        {
            FizickoLice? fizickoLice = stariKupac.FizickoLice;
            PravnoLice? pravnoLice = stariKupac.PravnoLice;
            Console.WriteLine(fizickoLice);
            Console.WriteLine(pravnoLice);

            _context.KupacOvlascenoLices.Where(j => j.KupacId == stariKupac.KupacId).ExecuteDelete();
            _context.KupacJavnoNadmetanjes.Where(j => j.KupacId == stariKupac.KupacId).ExecuteDelete();

            _context.Remove(stariKupac);

           
          
            _context.SaveChanges();
            _context.Add(noviKupac);

            if (fizickoLice != null)
                _context.FizickoLices.Add(fizickoLice);
            if (pravnoLice != null)
                _context.PravnoLices.Add(pravnoLice);
            _context.SaveChanges();

            if (noviKupac.FizickoLiceId != null)
            {
                noviKupac.FizickoLice = _fizickoLiceRepository.GetFizickoLiceById((Guid)noviKupac.FizickoLiceId);
            }
            if (noviKupac.PravnoLiceId != null)
            {
                noviKupac.PravnoLice = _pravnoLiceRepository.GetPravnoLiceById((Guid)noviKupac.PravnoLiceId);
            }

            if (noviKupac.OvlascenaLica != null)
            {
                foreach (var olId in noviKupac.OvlascenaLica)
                {
                    KupacOvlascenoLice kupacOvlascenaLica = new KupacOvlascenoLice
                    {
                        KupacId = noviKupac.KupacId,
                        OvlascenoLiceId = olId
                    };
                    _context.KupacOvlascenoLices.Add(kupacOvlascenaLica);
                }
            }

            if (noviKupac.JavnaNadmetanja != null)
            {
                foreach (var jnId in noviKupac.JavnaNadmetanja)
                {
                    KupacJavnoNadmetanje kupacJavnoNadmetanje = new KupacJavnoNadmetanje
                    {
                        KupacId = noviKupac.KupacId,
                        JavnoNadmetanjeId = jnId
                    };
                    _context.KupacJavnoNadmetanjes.Add(kupacJavnoNadmetanje);
                }
            }
           
            _context.SaveChanges();

        }

    

        public  List<KupacOvlascenoLice> GetKupacByOvlascenoLiceId(Guid ovlascenoLiceId)
        {
            return  _context.KupacOvlascenoLices.Where(ko => ko.OvlascenoLiceId == ovlascenoLiceId).ToList<KupacOvlascenoLice>();
        }

        public Kupac GetKupacByIdVO(Guid kupacId)
        {
            return _context.Kupacs.Where(p => p.KupacId == kupacId).FirstOrDefault();
        }
    }
}
