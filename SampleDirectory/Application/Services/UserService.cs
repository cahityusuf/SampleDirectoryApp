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
    public class UserService:IUserService
    {
        private readonly IRepository<User> _users;
        private readonly IMapper _mapper;

        public UserService(IRepository<User> users, IMapper mapper)
        {
            _users = users;
            _mapper = mapper;
        }

        public async Task<IDataResult<UserDto>> GetByIdAsync(long id)
        {
            if (id == 0) return new ErrorDataResult<UserDto>(Messages.InvalidId);

            var result = await _users.FindAsync(id);

            if (result!=null)
            {
                return new SuccessDataResult<UserDto>(_mapper.Map<UserDto>(result));
            }

            return new ErrorDataResult<UserDto>(Messages.Error);
        }

        public async Task<IDataResult<UserDto>> GetListAsync()
        {

            var result = await _users.GetAllAsync();

            if (result != null)
            {
                return new SuccessDataResult<UserDto>(_mapper.Map<UserDto>(result));
            }

            return new ErrorDataResult<UserDto>(Messages.Error);
        }

        public async Task<IDataResult<UserDto>> InsertAsync(UserDto user)
        {
            if (user == null) return new ErrorDataResult<UserDto>(Messages.InvalidId);

            var result = await _users.InsertAsync(_mapper.Map<User>(user));

            if (result != null)
            {
                return new SuccessDataResult<UserDto>(_mapper.Map<UserDto>(result));
            }

            return new ErrorDataResult<UserDto>(Messages.Error);
        }

        public async Task<IDataResult<UserDto>> UpdateAsync(UserDto user)
        {
            if (user == null) return new ErrorDataResult<UserDto>(Messages.InvalidId);

            _users.Update(_mapper.Map<User>(user));

            var result = await _users.SaveChangesAsync();

            if (result != 0)
            {
                return new SuccessDataResult<UserDto>(_mapper.Map<UserDto>(result));
            }

            return new ErrorDataResult<UserDto>(Messages.Error);
        }

        public async Task<IResult> Delete(long id)
        {
            if (id == 0) return new ErrorResult(Messages.InvalidId);

            _users.Delete(id);

            var result = await _users.SaveChangesAsync();

            if (result != 0)
            {
                return new Result(true);
            }

            return new ErrorResult(Messages.Error);
        }
    }
}
