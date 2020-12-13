using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Serialization;
using test_notissimus.Data;

namespace test_notissimus.Network {
    public class Service {

        public static async Task<List<Offer>> GetOffers() {

            try {

                using (var client = new HttpClient()) {
                    var result = await client.GetAsync("https://yastatic.net/market-export/_/partner/help/YML.xml").ConfigureAwait(false);
                    if (result.IsSuccessStatusCode && result.StatusCode == System.Net.HttpStatusCode.OK) {

                        StreamReader reader = new StreamReader(await result.Content.ReadAsStreamAsync(), System.Text.Encoding.GetEncoding(1251));
                        XmlSerializer serializer = new XmlSerializer(typeof(Yml_catalog));
                        Yml_catalog offers = (Yml_catalog)serializer.Deserialize(reader);
                        return offers.Shop.Offers;
                    }
                }

            }
            catch (Exception e) {
                return null;
            }
            return null;
        }
    }
}