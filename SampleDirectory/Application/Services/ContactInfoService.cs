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
    public class ContactInfoService: IContactInfoService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<ContactInfo> _contactInfo;

        public ContactInfoService(IMapper mapper, IRepository<ContactInfo> contactInfo)
        {
            _mapper = mapper;
            _contactInfo = contactInfo;
        }

        public async Task<IDataResult<ContactInfoDto>> GetByIdAsync(long id)
        {
            if (id == 0) return new ErrorDataResult<ContactInfoDto>(Messages.InvalidId);

            var result = await _contactInfo.FindAsync(id);

            if (result != null)
            {
                return new SuccessDataResult<ContactInfoDto>(_mapper.Map<ContactInfoDto>(result));
            }

            return new ErrorDataResult<ContactInfoDto>(Messages.Error);
        }

        public async Task<IDataResult<ContactInfoDto>> GetListAsync()
        {

            var result = await _contactInfo.GetAllAsync();

            if (result != null)
            {
                return new SuccessDataResult<ContactInfoDto>(_mapper.Map<ContactInfoDto>(result));
            }

            return new ErrorDataResult<ContactInfoDto>(Messages.Error);
        }

        public async Task<IDataResult<ContactInfoDto>> InsertAsync(ContactInfoDto contactInfo)
        {
            if (contactInfo == null) return new ErrorDataResult<ContactInfoDto>(Messages.InvalidId);

            var result = await _contactInfo.InsertAsync(_mapper.Map<ContactInfo>(contactInfo));

            if (result != null)
            {
                return new SuccessDataResult<ContactInfoDto>(_mapper.Map<ContactInfoDto>(result));
            }

            return new ErrorDataResult<ContactInfoDto>(Messages.Error);
        }

        public async Task<IDataResult<ContactInfoDto>> UpdateAsync(ContactInfoDto contactInfo)
        {
            if (contactInfo == null) return new ErrorDataResult<ContactInfoDto>(Messages.InvalidId);

            _contactInfo.Update(_mapper.Map<ContactInfo>(contactInfo));

            var result = await _contactInfo.SaveChangesAsync();

            if (result != 0)
            {
                return new SuccessDataResult<ContactInfoDto>(_mapper.Map<ContactInfoDto>(result));
            }

            return new ErrorDataResult<ContactInfoDto>(Messages.Error);
        }

        public async Task<IResult> DeleteAsync(long id)
        {
            if (id == 0) return new ErrorResult(Messages.InvalidId);

            _contactInfo.Delete(id);

            var result = await _contactInfo.SaveChangesAsync();

            if (result != 0)
            {
                return new Result(true);
            }

            return new ErrorResult(Messages.Error);
        }
    }
}
