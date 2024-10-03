using System;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.VisualBasic;

namespace RazorPagesLab.Pages.AddressBook;

public class EditModel : PageModel
{
	private readonly IMediator _mediator;
	private readonly IRepo<AddressBookEntry> _repo;

	public EditModel(IRepo<AddressBookEntry> repo, IMediator mediator)
	{
		_repo = repo;
		_mediator = mediator;
	}

	[BindProperty]
	public UpdateAddressRequest UpdateAddressRequest { get; set; }

	public void OnGet(Guid id)
	{
		// Todo: Use repo to get address book entry, set UpdateAddressRequest fields.
		
		// Grab current Address object
		var specification = new EntryByIdSpecification(id);
		var addresses = _repo.Find(specification);
		var currentAddress = addresses.FirstOrDefault();

		// In case there is a null value loaded into currentAddress
		if (currentAddress == null)
		{
			RedirectToPage("Error");
			return;
		}
		
		// Set the UpdateAddressRequest's fields
		UpdateAddressRequest = new UpdateAddressRequest 
		{
			Id = currentAddress.Id,
			Line1 = currentAddress.Line1,
			Line2 = currentAddress.Line2,
			City = currentAddress.City,
			State = currentAddress.State,
			PostalCode = currentAddress.PostalCode
		};
	}

	public async Task<ActionResult> OnPost()
	{
		// Todo: Use mediator to send a "command" to update the address book entry, redirect to entry list.
		if (ModelState.IsValid)
		{
			_ = await _mediator.Send(UpdateAddressRequest);
			return RedirectToPage("Index");
		}

		return Page();
	}
}