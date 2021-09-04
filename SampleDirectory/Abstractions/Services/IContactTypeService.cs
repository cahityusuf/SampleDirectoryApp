using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstractions.Dtos;
using Abstractions.Results;

namespace Abstractions.Services
{
    public interface IContactTypeService:IBusinessService
    {
        Task<IDataResult<ContactTypeDto>> GetByIdAsync(long id);
        Task<IDataResult<ContactTypeDto>> GetListAsync();
        Task<IDataResult<ContactTypeDto>> InsertAsync(ContactTypeDto contactType);

        Task<IDataResult<ContactTypeDto>> UpdateAsync(ContactTypeDto contactType);

        Task<IResult> DeleteAsync(long id);
    }
}
