using AutoMapper;
using HomeworkApi.Data;
using HomeworkApi.Dto;

namespace HomeworkApi.Service
{
    public class FolderService : BaseService<FolderDto, Folder>, IFolderService
    {
        public FolderService(IFolderRepository folderRepository, IMapper mapper, IUnitOfWork unitOfWork) : base(folderRepository, mapper, unitOfWork)
        {
            
        }

    }
}
