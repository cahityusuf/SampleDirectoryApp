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
        private readonly IRepository<ContactType> _contactTypes;

        public ContactTypeService(IMapper mapper, IRepository<ContactType> contactTypes)
        {
            _mapper = mapper;
            _contactTypes = contactTypes;
        }

        public async Task<IDataResult<ContactTypeDto>> GetByIdAsync(long id)
        {
            if (id == 0) return new ErrorDataResult<ContactTypeDto>(Messages.InvalidId);

            var result = await _contactTypes.FindAsync(id);

            if (result != null)
            {
                return new SuccessDataResult<ContactTypeDto>(_mapper.Map<ContactTypeDto>(result));
            }

            return new ErrorDataResult<ContactTypeDto>(Messages.Error);
        }

        public async Task<IDataResult<ContactTypeDto>> GetListAsync()
        {
            var result = await _contactTypes.GetAllAsync();

            if (result != null)
            {
                return new SuccessDataResult<ContactTypeDto>(_mapper.Map<ContactTypeDto>(result));
            }

            return new ErrorDataResult<ContactTypeDto>(Messages.Error);
        }

        public async Task<IDataResult<ContactTypeDto>> InsertAsync(ContactTypeDto contactType)
        {
            if (contactType == null) return new ErrorDataResult<ContactTypeDto>(Messages.InvalidId);

            var result = await _contactTypes.InsertAsync(_mapper.Map<ContactType>(contactType));

            if (result != null)
            {
                return new SuccessDataResult<ContactTypeDto>(_mapper.Map<ContactTypeDto>(result));
            }

            return new ErrorDataResult<ContactTypeDto>(Messages.Error);
        }

        public async Task<IDataResult<ContactTypeDto>> UpdateAsync(ContactTypeDto contactType)
        {
            if (contactType == null) return new ErrorDataResult<ContactTypeDto>(Messages.InvalidId);

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
