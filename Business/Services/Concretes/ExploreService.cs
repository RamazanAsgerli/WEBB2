using Business.CustomExceptions;
using Business.Services.Abstracts;
using Core.Models;
using Core.RepositoryAbstracts;
using Data.RepositoryConcretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Concretes
{
    public class ExploreService : IExploreService
    {
        private readonly IExploreRepository _exploreRepository;

        public ExploreService(IExploreRepository exploreRepository)
        {
            _exploreRepository = exploreRepository;
        }

    
        public void AddExplore(Explore explore)
        {
            if (explore == null)
            {
                throw new NotFoundException("", "Explore is null!");
            }
           
            if (!explore.PhotoFile.ContentType.Contains("image/"))
            {
                throw new PhotoFileFormatException("PhotoFile", "Photo File format is not valid!");
            }
            string path = "C:\\Users\\ll novbe\\Desktop\\MVC_Doorang\\MVC_Doorang\\wwwroot\\Upload\\Explore\\" + explore.PhotoFile.FileName;
            using(FileStream stream=new FileStream(path,FileMode.Create))
            {
                explore.PhotoFile.CopyTo(stream);
            }
            explore.ImgUrl = explore.PhotoFile.FileName;
            _exploreRepository.Add(explore);
            _exploreRepository.Commit();

        }

        public void DeleteExplore(int id)
        {
            Explore oldExplore = _exploreRepository.Get(x => x.Id==id);
            if (oldExplore == null)
            {
                throw new NotFoundException("", "Explore is null!");
            }
            string path = "C:\\Users\\ll novbe\\Desktop\\MVC_Doorang\\MVC_Doorang\\wwwroot\\Upload\\Explore\\" + oldExplore.ImgUrl;
            FileInfo fileInfo = new FileInfo(path);

            fileInfo.Delete();
            _exploreRepository.Delete(oldExplore);
            _exploreRepository.Commit();

        }

        public List<Explore> GetAllExplore(Func<Explore, bool>? func = null)
        {
            return _exploreRepository.GetAll(func);
        }

        public Explore GetExplore(Func<Explore, bool>? func = null)
        {
            return _exploreRepository.Get(func);
        }

        public void UpdateExplore(int id, Explore explore)
        {
            Explore oldExplore = _exploreRepository.Get(x => x.Id == id);
            if (oldExplore == null) { throw new NotFoundException("","Explore is not nul!!!!"); }
            if(oldExplore != null)
            {
                string path = "C:\\Users\\ll novbe\\Desktop\\MVC_Doorang\\MVC_Doorang\\wwwroot\\Upload\\Explore\\" + explore.PhotoFile.FileName;
                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    explore.PhotoFile.CopyTo(stream);
                }
                string path1 = "C:\\Users\\ll novbe\\Desktop\\MVC_Doorang\\MVC_Doorang\\wwwroot\\Upload\\Explore\\" + oldExplore.ImgUrl;
                FileInfo fileInfo = new FileInfo(path1);
                fileInfo.Delete();
                oldExplore.ImgUrl = explore.PhotoFile.FileName;
                

            }

            oldExplore.Title=explore.Title;
            oldExplore.Subtitle = explore.Subtitle;
            oldExplore.Description=explore.Description;
            _exploreRepository.Commit();
        }
    }
}
