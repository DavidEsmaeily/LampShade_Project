using _0_Framework.Application;
using ShopManagement.Application.Contracts.Slide;
using ShopManagement.Domain.SlideAgg;
using System.Collections.Generic;

namespace ShopManagement.Application
{
    public class SlideApplication : ISlideApplication
    {
        private readonly ISlideRepository _slideRepository;

        public SlideApplication(ISlideRepository slideRepository)
        {
            _slideRepository = slideRepository;
        }

        public OperationResult Create(CreateSlide command)
        {
            var slide = new Slide(command.Picture, command.PictureAlt, command.PictureTitle, command.Heading, command.Title, command.Text, command.BtnText, command.Link);
            _slideRepository.Create(slide);
            _slideRepository.SaveChanges();

            return new OperationResult().Succeeded();
        }

        public OperationResult Edit(EditSlide command)
        {
            var operation = new OperationResult();

            var slide = _slideRepository.Get(command.Id);
            if (slide == null) return operation.Failed(ApplicationMessages.RecordNotFound);

            slide.Edit(command.Picture, command.PictureAlt, command.PictureTitle, command.Heading, command.Title, command.Text, command.BtnText, command.Link);

            _slideRepository.SaveChanges();

            return operation.Succeeded();
        }   

        public OperationResult Remove(long id)
        {
            var operation = new OperationResult();

            var slide = _slideRepository.Get(id);
            if (slide == null) return operation.Failed(ApplicationMessages.RecordNotFound);

            slide.Remove();

            _slideRepository.SaveChanges();

            return operation.Succeeded();
        }

        public OperationResult Restore(long id)
        {
            var operation = new OperationResult();

            var slide = _slideRepository.Get(id);
            if (slide == null) return operation.Failed(ApplicationMessages.RecordNotFound);

            slide.Restore();

            _slideRepository.SaveChanges();

            return operation.Succeeded();
        }

        public EditSlide GetDetails(long id)
        {
            return _slideRepository.GetDetails(id);
        }

        public List<SlideViewModel> GetSlides()
        {
            return _slideRepository.GetSlides();
        }
    }
}
