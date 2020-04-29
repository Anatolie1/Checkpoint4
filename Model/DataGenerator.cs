using System;
using System.Collections.Generic;
using System.Linq;

namespace Checkpoint3
{
    public class DataGenerator
    {
        public List<Animal> animals => GetAnimals();
        public List<Show> shows => GetShows();
        public List<Comment> comments => GetComments();

        private List<Show> GetShows()
        {
            return new List<Show>
            {
                new Show{Id = 1, Name = "Animals", Price = new Price{Adult = 50}, Url = @"E:\Checkpoint3\Animal\ShowAnimals.png"},
                new Show{Id = 2, Name = "Acrobatic", Price = new Price{Adult = 42}, Url = @"E:\Checkpoint3\Animal\ShowAcrobatic.png"},
                new Show{Id = 3, Name = "Clown", Price = new Price{Adult = 35}, Url = @"E:\Checkpoint3\Animal\ShowClown.png"},
                new Show{Id = 4, Name = "Cabaret", Price = new Price{Adult = 75}, Url = @"E:\Checkpoint3\Animal\ShowCabaret.png"}
            };
        }
        private List<Animal> GetAnimals()
        {
            return new List<Animal>
            {
                new Animal{Id = 1, AnimalType = "Elephant", Name = "Magnus", Weight = 3000, Age = 23, Url = @"E:\Checkpoint3\Animal\elephantMother.png" },
                new Animal{Id = 2, AnimalType = "Elephant", Name = "Juissy", Weight = 750, Age = 3, Url = @"E:\Checkpoint3\Animal\elephant.png"},
                new Animal{Id = 3, AnimalType = "Horse", Name = "Jonny", Weight = 700, Age = 10, Url = @"E:\Checkpoint3\Animal\Horse.png" },
                new Animal{Id = 4, AnimalType = "Cat", Name = "Lisa", Weight = 2, Age = 5, Url = @"E:\Checkpoint3\Animal\Cat.png" },
                new Animal{Id = 5, AnimalType = "Tiger", Name = "Mac", Weight = 250, Age = 7, Url = @"E:\Checkpoint3\Animal\tiger.png" },
                new Animal{Id = 6, AnimalType = "Monkey", Name = "Curvy", Weight = 35, Age = 8, Url = @"E:\Checkpoint3\Animal\Monkey.png" },
                new Animal{Id = 7, AnimalType = "Lion", Name = "King", Weight = 200, Age = 13, Url = @"E:\Checkpoint3\Animal\Lion.png" },
                new Animal{Id = 8, AnimalType = "Ponny", Name = "Shura", Weight = 470, Age = 6, Url = @"E:\Checkpoint3\Animal\poney.png" }
            };
        }

        private List<Comment> GetComments()
        {
            using (var contex = new Context())
            {
                return contex.Comments.ToList();
            }
        }

        public void GetCommentsDB()
        {
            using (var context = new Context())
            {
                Random random = new Random();

                List<String> emails = new List<string> { "corine@yahoo.com", "szapozapoe@yahoo.com", "szaodjezop@yahoo.com", "zaidzaz@yahoo.com", "ezodpoezf@yahoo.com" };
                List<String> sms = new List<string> { "Nice", "Excellent", "Beautifull", "Wonderful", "Expensive" };
                List<String> name = new List<string> { "John", "Kevin", "Laura", "Lisa", "Alex" };
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                for (int i = 0; i < 5; i++)
                {
                    int nr = random.Next(200, 1000);
                    var item = new Comment { FullName = name[i], Email = emails[i], Message = sms[i], DateTime = DateTime.Now - TimeSpan.FromDays(nr) };
                    context.Add(item);
                }
                context.SaveChanges();
            }
        }
        public void PutMessage(string name, string email, string message)
        {
            using (var context = new Context())
            {
                var item = new Comment { FullName = name, Email = email, Message = message, DateTime = DateTime.Now };
                context.Add(item);
                context.SaveChanges();
            }
        }
    }
}
