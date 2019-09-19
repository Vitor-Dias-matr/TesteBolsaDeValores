using Domain.Aplication;
using Domain.Model;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Repository
{
    public class BolsaRepository : IRateRepository
    {
        public List<Rate> Query()
        {
            var json = File.ReadAllText(@"../Repository/Mock/rate.json", Encoding.GetEncoding("iso-8859-1"));

            var Rate = JsonConvert.DeserializeObject<List<Rate>>(json);

            return Rate;
        }
        
    }
}
