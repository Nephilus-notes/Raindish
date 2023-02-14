using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Raindish.Data;
using Raindish.Models;

namespace Raindish.Pages.Songs
{
    public class IndexModel : PageModel
    {
        private readonly Raindish.Data.RaindishSongContext _context;

        public IndexModel(Raindish.Data.RaindishSongContext context)
        {
            _context = context;
        }

        public IList<Song> Song { get;set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        public SelectList? Genres { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? SongGenre { get; set; }

        public async Task OnGetAsync()
        {
            IQueryable<string> genreQuery = from m in _context.Song
                                            orderby m.Genre
                                            select m.Genre;

            var songs = from s in _context.Song
                       select s;
            if (!string.IsNullOrEmpty(SearchString))
            {
                songs = songs.Where(search => search.Title.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(SongGenre))
            {
                songs = songs.Where(x => x.Genre == SongGenre);
            }
            Genres = new SelectList(await genreQuery.Distinct().ToListAsync());
            Song = await songs.ToListAsync();
        }
    }
}
