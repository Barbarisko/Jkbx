using Business.Models;
using System.Collections.Generic;

namespace Business.Interfaces
{
    public interface IMachineService
    {
        void JukeboxFill(AlbumModel album, MachineModel jukebox);
        //List<string> NamesOfMaterials(MachineModel jukeebox);
        List<AlbumModel> GetAlbums(MachineModel jukebox);

        List<SongModel> findSortedListOfSongs(MachineModel jukebox, 
                                              string albumname, 
                                              string singer, 
                                              string genre, 
                                              int currentamount);

        MachineModel loadFromFile(string path);
        void saveToFile(string path);



    }
}
