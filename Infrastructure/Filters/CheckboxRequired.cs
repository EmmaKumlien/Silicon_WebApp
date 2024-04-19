using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;

namespace Infrastructure.Filters;

public class CheckboxRequired : ValidationAttribute
{
	public override bool IsValid(object? value) => value is bool b && b;
	

}
