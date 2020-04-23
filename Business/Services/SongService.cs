using AutoMapper;
using Business.Interfaces;
using Business.Models;
using Data.Interfaces;
using System.Collections.Generic;

namespace Business.Services
{
   public  class SongService:ISongService
    {
        private readonly IUnitOfWork _unitOfWork;
        IMapper _mapper;

        public SongService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public IEnumerable<SongModel> GetSongs()
        {
            var songs = _unitOfWork.SongRepo.GetAll();
            var songModels = _mapper.Map<IEnumerable<SongModel>>(songs);
            return songModels;
        }
    }
}
