using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstractions.Data;
using Abstractions.Dtos;
using Abstractions.Enums;
using Abstractions.Results;
using Abstractions.Services;
using Application.Constants;
using AutoMapper;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    public class ContactInfoService : IContactInfoService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ContactInfoService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IDataResult<ContactInfoDto>> GetByIdAsync(long id)
        {
            if (id == 0) return new ErrorDataResult<ContactInfoDto>(Messages.InvalidId);

            var _contactInfo = _unitOfWork.GetRepository<ContactInfo>();

            var result = await _contactInfo.GetAllAsync(predicate:p=>p.Id==id,include:i=>i.Include(c=>c.ContactType));

            if (result != null)
            {
                return new SuccessDataResult<ContactInfoDto>(_mapper.Map<ContactInfoDto>(result));
            }

            return new ErrorDataResult<ContactInfoDto>(Messages.Error);
        }

        public async Task<IDataResult<List<ContactInfoDto>>> GetListAsync()
        {
            var _contactInfo = _unitOfWork.GetRepository<ContactInfo>();

            var result = await _contactInfo.GetAllAsync(include: i => i.Include(c => c.ContactType));

            if (result != null)
            {
                return new SuccessDataResult<List<ContactInfoDto>>(_mapper.Map<List<ContactInfoDto>>(result));
            }

            return new ErrorDataResult<List<ContactInfoDto>>(Messages.Error);
        }

        public async Task<IDataResult<ContactInfoDto>> InsertAsync(ContactInfoDto contactInfo)
        {
            if (contactInfo == null) return new ErrorDataResult<ContactInfoDto>(Messages.InvalidId);

            var _users = _unitOfWork.GetRepository<ContactInfo>();

            var result = _users.Insert(_mapper.Map<ContactInfo>(contactInfo),InsertStrategy.OnlytMain);

            if (result != null)
            {
                var save = await _users.SaveChangesAsync();

                if (save > 0)
                {
                    return new SuccessDataResult<ContactInfoDto>(_mapper.Map<ContactInfoDto>(result));
                }

            }

            return new ErrorDataResult<ContactInfoDto>(Messages.Error);
        }

        public async Task<IDataResult<ContactInfoDto>> UpdateAsync(ContactInfoDto contactInfo)
        {
            if (contactInfo == null) return new ErrorDataResult<ContactInfoDto>(Messages.InvalidId);

            var _contactInfo = _unitOfWork.GetRepository<ContactInfo>();

            _contactInfo.Update(_mapper.Map<ContactInfo>(contactInfo),UpdateStrategy.OnlyMain);

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

            var _contactInfo = _unitOfWork.GetRepository<ContactInfo>();

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
