using AutoMapper;
using KupacServis.Entities;
using KupacServis.Models;
using Microsoft.EntityFrameworkCore;

namespace KupacServis.Data
{  
        public class OvlascenoLiceRepository : IOvlascenoLiceRepository
        {
            public KupacContext _context;
        private readonly IMapper _mapper;
        public OvlascenoLiceRepository(KupacContext context,IMapper mapper)
            {
                _context = context;
                _mapper= mapper;
            }

        public List<OvlascenoLice> GetOvlascenoLices()
        {
            var ovlascenaLica = _context.OvlascenoLices.OrderBy(p => p.OvlascenoLiceId).ToList();
            foreach (var ol in ovlascenaLica)
            {
                ol.Kupci = _context.KupacOvlascenoLices.Where(ku => ku.OvlascenoLiceId == ol.OvlascenoLiceId).Select(pk => pk.KupacId).ToList();

            }
            return (ovlascenaLica);
        }

            public bool SaveChanges()
            {
                return _context.SaveChanges() > 0;
            }

            public OvlascenoLice CreateOvlascenoLice(OvlascenoLice ovlascenoLice)
            {
                ovlascenoLice.OvlascenoLiceId = Guid.NewGuid();
                var created=_context.OvlascenoLices.Add(ovlascenoLice);
                if(ovlascenoLice.Kupci != null)
                 {
                    foreach(var kupacID in ovlascenoLice.Kupci)
                    {
                        KupacOvlascenoLice kupacOvlascenoLice = new KupacOvlascenoLice
                        {
                            OvlascenoLiceId = ovlascenoLice.OvlascenoLiceId,
                            KupacId = kupacID
                        };
                         _context.KupacOvlascenoLices.Add(kupacOvlascenoLice);
                    }
                 }
                 _context.SaveChanges();
                return _mapper.Map<OvlascenoLice>(created.Entity);


       
             }

            public void DeleteOvlascenoLice(Guid ovlascenoLiceId)
            {
                _context.OvlascenoLices.Remove(_context.OvlascenoLices.FirstOrDefault(l => l.OvlascenoLiceId == ovlascenoLiceId));
            }

            public OvlascenoLice GetOvlascenoLiceById(Guid ovlascenoLiceId)
            {
                var ol= _context.OvlascenoLices.Where(p => p.OvlascenoLiceId == ovlascenoLiceId).FirstOrDefault();
                 ol.Kupci = _context.KupacOvlascenoLices.Where(ku => ku.OvlascenoLiceId == ovlascenoLiceId).Select(pk => pk.KupacId).ToList();
                return ol;
            }

            public void UpdateOvlascenoLice(OvlascenoLice staroOvlascenoLice,OvlascenoLice novoOvlascenoLice)
            {
           
                
                _context.KupacOvlascenoLices.Where(j => j.OvlascenoLiceId == staroOvlascenoLice.OvlascenoLiceId).ExecuteDelete();
                
                _context.Remove(staroOvlascenoLice);
                _context.SaveChanges();
                _context.Add(novoOvlascenoLice);



                if (novoOvlascenoLice.Kupci != null)
                {
                    foreach (var KupacID in novoOvlascenoLice.Kupci)
                    {
                        KupacOvlascenoLice kupacOvlasceno = new KupacOvlascenoLice
                        {
                            OvlascenoLiceId = novoOvlascenoLice.OvlascenoLiceId,
                            KupacId = KupacID
                        };
                        _context.KupacOvlascenoLices.Add(kupacOvlasceno);
                    }
                }
           
           

                _context.SaveChanges();
             }

            public OvlascenoLice GetOvlascenoLiceByIdVO(Guid ovlascenoLiceId)
            {
                return _context.OvlascenoLices.Where(p => p.OvlascenoLiceId == ovlascenoLiceId).FirstOrDefault();
            }





    }

}

