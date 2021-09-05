using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstractions.Dtos;
using Abstractions.Results;

namespace Abstractions.Services
{
    public interface IContactInfoService:IBusinessService
    {
        Task<IDataResult<ContactInfoDto>> GetByIdAsync(long id);
        Task<IDataResult<List<ContactInfoDto>>> GetListAsync();
        Task<IDataResult<ContactInfoDto>> InsertAsync(ContactInfoDto contactInfo);

        Task<IDataResult<ContactInfoDto>> UpdateAsync(ContactInfoDto contactInfo);

        Task<IResult> DeleteAsync(long id);



    }
}
