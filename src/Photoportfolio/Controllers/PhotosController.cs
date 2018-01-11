using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Photoportfolio.Entities;
using Photoportfolio.Infrastructure.Core;
using Photoportfolio.Infrastructure.Repositories.Abstract;
using Photoportfolio.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Photoportfolio.Controllers
{
    [Route("api/[controller]")]
    public class PhotosController : Controller
    {
        private readonly IPhotoRepository _photoRepository;
        private readonly IAlbumRepository _albumRepository;
        private readonly IFeedbackRepository _feedbackRepository;
        private readonly ILoggingRepository _loggingRepository;

        public PhotosController(IPhotoRepository photoRepository, IAlbumRepository albumRepository, IFeedbackRepository feedbackRepository, ILoggingRepository loggingRepository)
        {
            _photoRepository = photoRepository;
            _albumRepository = albumRepository;
            _feedbackRepository = feedbackRepository;
            _loggingRepository = loggingRepository;
        }

        [HttpGet("{page:int=0}/{pageSize=12}")]
        public PaginationSet<PhotoViewModel> Get(int? page, int? pageSize)
        {
            PaginationSet<PhotoViewModel> pagedSet = null;

            try
            {
                int currentPage = page.Value;
                int currentPageSize = pageSize.Value;

                List<Photo> _photos = null;
                int _totalPhotos = new int();

                _photos = _photoRepository
                    .AllIncluding(p => p.Album)
                    .OrderByDescending(p => p.Rating)
                    .Skip(currentPage * currentPageSize)
                    .Take(currentPageSize)
                    .ToList();

                var albums = _albumRepository.AllIncluding(a => a.User).ToList();
                foreach (var photo in _photos)
                    photo.Album.User = albums.FirstOrDefault(a => a.Id == photo.AlbumId).User;

                _totalPhotos = _photoRepository.GetAll().Count();

                IEnumerable<PhotoViewModel> _photosVM = Mapper.Map<IEnumerable<Photo>, IEnumerable<PhotoViewModel>>(_photos);

                pagedSet = new PaginationSet<PhotoViewModel>()
                {
                    Page = currentPage,
                    TotalCount = _totalPhotos,
                    TotalPages = (int)Math.Ceiling((decimal)_totalPhotos / currentPageSize),
                    Items = _photosVM
                };
            }
            catch (Exception ex)
            {
                _loggingRepository.Add(new Error() { Message = ex.Message, StackTrace = ex.StackTrace, DateCreated = DateTime.Now });
                _loggingRepository.Commit();
            }

            return pagedSet;
        }

        [HttpPost("vote")]
        public IActionResult Vote([FromBody] VoteViewModel model)
        {
            try
            {
                if (_feedbackRepository.GetSingle(f => f.UserId == model.UserId && f.PhotoId == model.PhotoId) != null)
                    throw new InvalidOperationException("You have been already voted");

                var newFeedback = new UserFeedback(model.UserId, model.PhotoId, model.Vote);

                _feedbackRepository.Add(newFeedback);
                _feedbackRepository.Commit();

                var allRelatedFeedBacks = _feedbackRepository.FindBy(f => f.PhotoId == model.PhotoId).ToList();
                var photo = _photoRepository.GetSingle(model.PhotoId);

                var newRating = (float)(allRelatedFeedBacks.Sum(x => x.Mark) / allRelatedFeedBacks.Count);
                photo.Rating = newRating;

                _photoRepository.Edit(photo);
                _photoRepository.Commit();

                return new ObjectResult(new GenericResult()
                {
                    Succeeded = true,
                    Message = "Your vote has been counted"
                });
            } catch (Exception e)
            {
                return new ObjectResult(new GenericResult()
                {
                    Succeeded = false,
                    Message = e.Message
                });
            }

        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            IActionResult _result = new ObjectResult(false);
            GenericResult _removeResult = null;

            try
            {
                Photo _photoToRemove = this._photoRepository.GetSingle(id);
                this._photoRepository.Delete(_photoToRemove);
                this._photoRepository.Commit();

                _removeResult = new GenericResult()
                {
                    Succeeded = true,
                    Message = "Photo removed."
                };
            }
            catch (Exception ex)
            {
                _removeResult = new GenericResult()
                {
                    Succeeded = false,
                    Message = ex.Message
                };

                _loggingRepository.Add(new Error() { Message = ex.Message, StackTrace = ex.StackTrace, DateCreated = DateTime.Now });
                _loggingRepository.Commit();
            }

            _result = new ObjectResult(_removeResult);
            return _result;
        }
    }
}
