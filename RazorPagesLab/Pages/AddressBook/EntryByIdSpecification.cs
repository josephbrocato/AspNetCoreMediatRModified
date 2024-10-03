using System;
using System.Linq.Expressions;

namespace RazorPagesLab.Pages.AddressBook;

public class EntryByIdSpecification : Specification<AddressBookEntry>
{
	private readonly Guid _id;

	public EntryByIdSpecification(Guid id)
	{
		_id = id;
	}

	public override Expression<Func<AddressBookEntry, bool>> ToExpression()
	{
		return entry => entry.Id == _id;
	}
}