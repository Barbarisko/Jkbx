using Business.Models;
using System.Collections.Generic;

namespace Business.Interfaces
{
   public interface ISongService
    {
        IEnumerable<SongModel> GetSongs();

    }
}
