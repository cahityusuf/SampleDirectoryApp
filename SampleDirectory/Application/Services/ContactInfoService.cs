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

            var result = await _contactInfo.FindAsync(id);

            if (result != null)
            {
                return new SuccessDataResult<ContactInfoDto>(_mapper.Map<ContactInfoDto>(result));
            }

            return new ErrorDataResult<ContactInfoDto>(Messages.Error);
        }

        public async Task<IDataResult<List<ContactInfoDto>>> GetListAsync()
        {
            var _contactInfo = _unitOfWork.GetRepository<ContactInfo>();

            var result = await _contactInfo.GetAllAsync();

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

            var result = await _users.InsertAsync(_mapper.Map<ContactInfo>(contactInfo));

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

            var _contactInfo = _unitOfWork.GetRepository<ContactInfo>();

            _contactInfo.Delete(id);

            var result = await _contactInfo.SaveChangesAsync();

            if (result != 0)
            {
                return new Result(true);
            }

            return new ErrorResult(Messages.Error);
        }

        public IDataResult<List<RaporDto>> Rapor()
        {
            var _contactInfo = _unitOfWork.GetRepository<ContactInfo>();

            var res = _contactInfo.GetAll(p => p.ContactTypeId == 3).ToList();//ContactType Konum Seçilenler

            if (res != null)
            {
                var result = res.GroupBy(x => new { x.Description })
                   .Select(b => new RaporDto()
                   {
                       kisisayisi = b.Select(bn => bn.UserId).ToList().Count(),
                       konum = b.Where(s => s.Description == b.Key.Description).FirstOrDefault().Description,
                       UserId = b.Where(s => s.Description == b.Key.Description).Select(s => s.UserId).ToList(),
                   }).ToList();

                if (result.Count != 0)
                {
                    var telefonListesi = _contactInfo.GetAll(p => p.ContactTypeId == 1).ToList();

                    if (telefonListesi.Count != 0)
                    {
                        foreach (var item in telefonListesi)
                        {
                            foreach (var group in result)
                            {
                                var telefonuVarmi = group.UserId.Exists(p => p == item.UserId);

                                if (telefonuVarmi)
                                {
                                    group.telefonsayisi += 1;
                                }
                            }
                        }
                    }

                }
                return new SuccessDataResult<List<RaporDto>>(result.ToList());

            }

            return new ErrorDataResult<List<RaporDto>>(Messages.Error);

        }
    }
}
