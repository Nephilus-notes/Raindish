using Microsoft.EntityFrameworkCore;
using Raindish.Data;

namespace Raindish.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new RaindishSongContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<RaindishSongContext>>()))
            {
                if(context == null || context.Song == null) 
                {
                    throw new ArgumentNullException("Null RaindishContext");
                }
                if (context.Song.Any())
                {
                    return;
                }

                context.Song.AddRange(
                    new Song
                    {
                        Title = "Song Of The Champion",
                        Written = DateTime.Parse("2020-5-15"),
                        Genre = "Western",
                        Key = "A Minor",
                        OldNames = "None",
                        ProductionRecording = false
                    },
                     new Song
                     {
                         Title = "Lost/Found",
                         Written = DateTime.Parse("2022-7-20"),
                         Genre = "Atmospheric",
                         Key = "E Minor",
                         OldNames = "None",
                         ProductionRecording = true
                     },
                      new Song
                      {
                          Title = "Trouble You Can Borrow",
                          Written = DateTime.Parse("2021-5-15"),
                          Genre = "Blues",
                          Key = "A Minor",
                          OldNames = "For Today",
                          ProductionRecording = true
                      },
                       new Song
                       {
                           Title = "Better Than Sin",
                           Written = DateTime.Parse("2019-7-15"),
                           Genre = "Moody",
                           Key = "A Minor",
                           OldNames = "These Words",
                           ProductionRecording = true
                       }

                    );
                context.SaveChanges();
            }
        }
    }
}
