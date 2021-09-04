using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstractions.Data;
using Abstractions.Dtos;
using Abstractions.Results;
using Abstractions.Services;
using Application.Constants;
using AutoMapper;
using Domain.Entities;

namespace Application.Services
{
    public class ContactTypeService:IContactTypeService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ContactTypeService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IDataResult<ContactTypeDto>> GetByIdAsync(long id)
        {
            if (id == 0) return new ErrorDataResult<ContactTypeDto>(Messages.InvalidId);

            var _contactTypes = _unitOfWork.GetRepository<ContactType>();

            var result = await _contactTypes.FindAsync(id);

            if (result != null)
            {
                return new SuccessDataResult<ContactTypeDto>(_mapper.Map<ContactTypeDto>(result));
            }

            return new ErrorDataResult<ContactTypeDto>(Messages.Error);
        }

        public async Task<IDataResult<List<ContactTypeDto>>> GetListAsync()
        {
            var _contactTypes = _unitOfWork.GetRepository<ContactType>();

            var result = await _contactTypes.GetAllAsync();

            if (result != null)
            {
                return new SuccessDataResult<List<ContactTypeDto>>(_mapper.Map<List<ContactTypeDto>>(result));
            }

            return new ErrorDataResult<List<ContactTypeDto>>(Messages.Error);
        }

        public async Task<IDataResult<ContactTypeDto>> InsertAsync(ContactTypeDto contactType)
        {
            if (contactType == null) return new ErrorDataResult<ContactTypeDto>(Messages.InvalidId);

            var _users = _unitOfWork.GetRepository<ContactType>();

            var result = await _users.InsertAsync(_mapper.Map<ContactType>(contactType));

            if (result != null)
            {
                var save = await _users.SaveChangesAsync();

                if (save > 0)
                {
                    return new SuccessDataResult<ContactTypeDto>(_mapper.Map<ContactTypeDto>(result));
                }

            }

            return new ErrorDataResult<ContactTypeDto>(Messages.Error);
        }

        public async Task<IDataResult<ContactTypeDto>> UpdateAsync(ContactTypeDto contactType)
        {
            if (contactType == null) return new ErrorDataResult<ContactTypeDto>(Messages.InvalidId);

            var _contactTypes = _unitOfWork.GetRepository<ContactType>();

            _contactTypes.Update(_mapper.Map<ContactType>(contactType));

            var result = await _contactTypes.SaveChangesAsync();

            if (result != 0)
            {
                return new SuccessDataResult<ContactTypeDto>(_mapper.Map<ContactTypeDto>(result));
            }

            return new ErrorDataResult<ContactTypeDto>(Messages.Error);
        }

        public async Task<IResult> DeleteAsync(long id)
        {
            if (id == 0) return new ErrorResult(Messages.InvalidId);

            var _contactTypes = _unitOfWork.GetRepository<ContactType>();

            _contactTypes.Delete(id);

            var result = await _contactTypes.SaveChangesAsync();

            if (result != 0)
            {
                return new Result(true);
            }

            return new ErrorResult(Messages.Error);
        }
    }
}
