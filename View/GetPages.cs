using Nancy;
using Newtonsoft.Json;
using System.Linq;

namespace Checkpoint3
{
    public class GetPages : NancyModule
    {
        public GetPages()
        {
            DataGenerator dataGenerator = new DataGenerator();

            Get("/", _ => "Wild Circus Welcome");
            Get("/animals", _ => JsonConvert.SerializeObject(dataGenerator.animals));
            
            Get("/animals/{id}", p =>
            {
                var item = dataGenerator.animals.Where(i => i.Id == p.id);
                return JsonConvert.SerializeObject(item);
            });
            Get("/shows", _ => JsonConvert.SerializeObject(dataGenerator.shows));
            
            Get("/shows/{id}", p =>
            {
                var item = dataGenerator.shows.Where(i => i.Id == p.id);
                return JsonConvert.SerializeObject(item);
            });

            Get("/shows/{id}/price", p =>
            {
                var item = dataGenerator.shows.Where(i => i.Id == p.id).Select(p => p.Price);
                return JsonConvert.SerializeObject(item);
            });

            Get("/shows/{id}/price", p =>
            {
                var item = dataGenerator.shows.Where(i => i.Id == p.id).Select(p => p.Price);
                return JsonConvert.SerializeObject(item);
            });

            Get("/comments", p =>
            {
                var item = dataGenerator.comments;
                return JsonConvert.SerializeObject(item);
            });

            Get("/comments/{id}", p =>
            {
                var item = dataGenerator.comments.Where(i => i.Id == p.id);
                return JsonConvert.SerializeObject(item);
            });
        }
    }
}
