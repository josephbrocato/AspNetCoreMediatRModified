using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace RazorPagesLab.Pages.AddressBook;

public class UpdateAddressHandler
	: IRequestHandler<UpdateAddressRequest, Guid>
{
	private readonly IRepo<AddressBookEntry> _repo;

	public UpdateAddressHandler(IRepo<AddressBookEntry> repo)
	{
		_repo = repo;
	}

	public async Task<Guid> Handle(UpdateAddressRequest request, CancellationToken cancellationToken)
	{
        // grab address by Id 
		var specification = new EntryByIdSpecification(request.Id);
		var addresses = _repo.Find(specification);
		var entry = addresses.FirstOrDefault();

        // error handling if entry is null
        if (entry == null)
        {
            throw new InvalidOperationException("Address entry not found.");
        }

        // perform update on address entry
        entry.Update(request.Line1, request.Line2, request.City, request.State, request.PostalCode);
		_repo.Update(entry);

		return await Task.FromResult(entry.Id);
	}
}