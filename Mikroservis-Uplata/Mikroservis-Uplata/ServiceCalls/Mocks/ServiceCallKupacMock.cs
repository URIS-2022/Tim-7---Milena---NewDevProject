using Mikroservis_Uplata.DTO;

namespace Mikroservis_Uplata.ServiceCalls.Mocks
{
    public class ServiceCallKupacMock<T> : IServiceCall<T>
    {
        public async Task<T> SendGetRequestAsync(string url, string token)
        {
            var kupac = new KupacDTO
            {
                //KupacId = 'ff4',
                //OstvarenaPovrsina  = 4,
                //ImaZabranu  = false,
                //BrTelefona1 = "0652112121",
                //Email = "email@gmail.com",
                //BrRacuna = "232211212345"
            };

            return await Task.FromResult((T)Convert.ChangeType(kupac, typeof(T)));
        }
    }
}
