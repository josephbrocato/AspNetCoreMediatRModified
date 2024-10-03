using System;
using System.Linq.Expressions;

namespace RazorPagesLab.Pages.AddressBook;

public class AllEntriesSpecification : Specification<AddressBookEntry>
{
	public override Expression<Func<AddressBookEntry, bool>> ToExpression()
	{
		return entry => true; // For all, there is currently nothing to filter on. It's just... all of them.
	}
}