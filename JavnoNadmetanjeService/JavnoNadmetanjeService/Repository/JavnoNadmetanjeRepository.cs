using AutoMapper;
using JavnoNadmetanjeService.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System.Reflection.Metadata;

namespace JavnoNadmetanjeService.Repository
{
    public class JavnoNadmetanjeRepository :IJavnoNadmetanjeRepository
    {
        private readonly DataContext context;
        private readonly IMapper mapper;
        public JavnoNadmetanjeRepository(DataContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public JavnoNadmetanje CreateJavnoNadmetanje(JavnoNadmetanje javnoNadmetanje)
        {
            javnoNadmetanje.JavnoNadmetanjeID = Guid.NewGuid();
            var createdEntity = context.JavnoNadmetanje.Add(javnoNadmetanje);
            if (javnoNadmetanje.PrijavljeniKupciID != null)
            {
                foreach (var KupacID in javnoNadmetanje.PrijavljeniKupciID)
                {
                    JavnoNadmetanjePrijavljeniKupci javnoNadmetanjePrijavljeniKupci = new JavnoNadmetanjePrijavljeniKupci
                    {
                        JavnoNadmetanjeID = javnoNadmetanje.JavnoNadmetanjeID,
                        KupacID = KupacID
                    };
                    context.JavnoNadmetanjePrijavljeniKupci.Add(javnoNadmetanjePrijavljeniKupci);
                }
            }
            if (javnoNadmetanje.LicitantiID != null)
            {
                foreach (var OvlascenoLiceID in javnoNadmetanje.LicitantiID)
                {
                    JavnoNadmetanjeOvlascenaLica javnoNadmetanjeOvlascenaLica = new JavnoNadmetanjeOvlascenaLica
                    {
                        JavnoNadmetanjeID = javnoNadmetanje.JavnoNadmetanjeID,
                        OvlascenoLiceID = OvlascenoLiceID
                    };
                    context.JavnoNadmetanjeOvlascenaLica.Add(javnoNadmetanjeOvlascenaLica);
                }
            }
            if (javnoNadmetanje.ParceleID != null)
            {
                foreach (var ParcelaID in javnoNadmetanje.ParceleID)
                {
                    JavnoNadmetanjeParcele javnoNadmetanjeParcele = new JavnoNadmetanjeParcele
                    {
                        JavnoNadmetanjeID = javnoNadmetanje.JavnoNadmetanjeID,
                        ParcelaID = ParcelaID
                    };
                    context.JavnoNadmetanjeParcele.Add(javnoNadmetanjeParcele);
                }
            }
            context.SaveChanges();
            return mapper.Map<JavnoNadmetanje>(createdEntity.Entity);
        }

        public void DeleteJavnoNadmetanje(Guid JavnoNadmetanjeID)
        {
            var javnoNadmetanje = GetJavnoNadmetanje(JavnoNadmetanjeID);
            context.Remove(javnoNadmetanje);
            context.SaveChanges();
        }

        public JavnoNadmetanje GetJavnoNadmetanje(Guid JavnoNadmetanjeID)
        {
            JavnoNadmetanje javnoNadmetanje = context.JavnoNadmetanje.Include(t => t.TipJavnogNadmetanja).Include(s => s.StatusJavnogNadmetanja).FirstOrDefault(e => e.JavnoNadmetanjeID == JavnoNadmetanjeID);

            javnoNadmetanje.PrijavljeniKupciID = context.JavnoNadmetanjePrijavljeniKupci.Where(j => j.JavnoNadmetanjeID == javnoNadmetanje.JavnoNadmetanjeID).Select(pk => pk.KupacID).ToList();
            javnoNadmetanje.LicitantiID = context.JavnoNadmetanjeOvlascenaLica.Where(j => j.JavnoNadmetanjeID == javnoNadmetanje.JavnoNadmetanjeID).Select(ol => ol.OvlascenoLiceID).ToList();
            javnoNadmetanje.ParceleID = context.JavnoNadmetanjeParcele.Where(j => j.JavnoNadmetanjeID == javnoNadmetanje.JavnoNadmetanjeID).Select(p => p.ParcelaID).ToList();
            
            return javnoNadmetanje;
        }

        public List<JavnoNadmetanje> GetJavnaNadmetanja(string status = null, string tip = null)
        {
            var javnaNadmetanja = context.JavnoNadmetanje.Include(t => t.TipJavnogNadmetanja).Include(s => s.StatusJavnogNadmetanja)
                .OrderByDescending(jn => jn.Datum).
                Where(e => (status == null || e.StatusJavnogNadmetanja.NazivStatusaJavnogNadmetanja == status) &&
                           (tip == null || e.TipJavnogNadmetanja.NazivTipaJavnogNadmetanja == tip))
                .ToList();
            
            foreach (var jn in javnaNadmetanja)
            {
                jn.PrijavljeniKupciID =  context.JavnoNadmetanjePrijavljeniKupci.Where(j => j.JavnoNadmetanjeID == jn.JavnoNadmetanjeID).Select(pk => pk.KupacID).ToList();
                jn.LicitantiID = context.JavnoNadmetanjeOvlascenaLica.Where(j => j.JavnoNadmetanjeID == jn.JavnoNadmetanjeID).Select(ol => ol.OvlascenoLiceID).ToList();
                jn.ParceleID = context.JavnoNadmetanjeParcele.Where(j => j.JavnoNadmetanjeID == jn.JavnoNadmetanjeID).Select(p => p.ParcelaID).ToList();
            }

            return javnaNadmetanja;
        }

        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }

        public void UpdateJavnoNadmetanje(JavnoNadmetanje staroJavnoNadmetanje, JavnoNadmetanje novoJavnoNadmetanje)
        {
            context.JavnoNadmetanjePrijavljeniKupci.Where(j => j.JavnoNadmetanjeID == staroJavnoNadmetanje.JavnoNadmetanjeID).ExecuteDelete();
            context.JavnoNadmetanjeOvlascenaLica.Where(j => j.JavnoNadmetanjeID == staroJavnoNadmetanje.JavnoNadmetanjeID).ExecuteDelete();
            context.JavnoNadmetanjeParcele.Where(j => j.JavnoNadmetanjeID == staroJavnoNadmetanje.JavnoNadmetanjeID).ExecuteDelete();
            context.Remove(staroJavnoNadmetanje);
            context.SaveChanges();
            context.Add(novoJavnoNadmetanje);



            if (novoJavnoNadmetanje.PrijavljeniKupciID != null)
            {
                foreach (var KupacID in novoJavnoNadmetanje.PrijavljeniKupciID)
                {
                    JavnoNadmetanjePrijavljeniKupci javnoNadmetanjePrijavljeniKupci = new JavnoNadmetanjePrijavljeniKupci
                    {
                        JavnoNadmetanjeID = novoJavnoNadmetanje.JavnoNadmetanjeID,
                        KupacID = KupacID
                    };
                    context.JavnoNadmetanjePrijavljeniKupci.Add(javnoNadmetanjePrijavljeniKupci);
                }
            }
            if (novoJavnoNadmetanje.LicitantiID != null)
            {
                foreach (var OvlascenoLiceID in novoJavnoNadmetanje.LicitantiID)
                {
                    JavnoNadmetanjeOvlascenaLica javnoNadmetanjeOvlascenaLica = new JavnoNadmetanjeOvlascenaLica
                    {
                        JavnoNadmetanjeID = novoJavnoNadmetanje.JavnoNadmetanjeID,
                        OvlascenoLiceID = OvlascenoLiceID
                    };
                    context.JavnoNadmetanjeOvlascenaLica.Add(javnoNadmetanjeOvlascenaLica);
                }
            }
            if (novoJavnoNadmetanje.ParceleID != null)
            {
                foreach (var ParcelaID in novoJavnoNadmetanje.ParceleID)
                {
                    JavnoNadmetanjeParcele javnoNadmetanjeParcele = new JavnoNadmetanjeParcele
                    {
                        JavnoNadmetanjeID = novoJavnoNadmetanje.JavnoNadmetanjeID,
                        ParcelaID = ParcelaID
                    };
                    context.JavnoNadmetanjeParcele.Add(javnoNadmetanjeParcele);
                }
            }

            context.SaveChanges();
        }
        public JavnoNadmetanje GetJavnoNadmetanjeByIdVO(Guid javnoNadmetanjeId)
        {
            return context.JavnoNadmetanje.Include(t => t.TipJavnogNadmetanja).Include(s => s.StatusJavnogNadmetanja).FirstOrDefault(e => e.JavnoNadmetanjeID == javnoNadmetanjeId);
        }
    }
}
