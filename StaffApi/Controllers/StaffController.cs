using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using StaffApi.Data;
using System;
using System.Linq.Expressions;

namespace StaffApi.Web.Controllers;

[Route("staff/api/v1.0/[controller]")]
[ApiController]
public class StaffController : ControllerBase
{
	private readonly IUnitOfWork _unitOfWork;
    private IValidator<Staff> _validator;
    public StaffController(IUnitOfWork unitOfWork, IValidator<Staff> validator)
	{
		_unitOfWork = unitOfWork;
		_validator = validator;
	}

	[HttpGet]
	public List<Staff> GetAll()
	{
		List<Staff> staffList = _unitOfWork.StaffRepository.GetAll();
		return staffList;
	}

	[HttpGet("{id}")]
	public Staff GetById(int id)
	{
		Staff staff = _unitOfWork.StaffRepository.GetById(id);
		return staff;
	}

	[HttpGet("Filter")]
	public List<Staff> WhereFilter([FromQuery] string firstName, string lastName)
	{
		List<Staff> staffList = GetAll();
		Expression<Func<Staff, bool>> exp = (x => x.FirstName.Contains(firstName) || x.LastName.Contains(lastName)); 
        List<Staff> filteredList = _unitOfWork.StaffRepository.WhereFilter(exp);
		return filteredList;
	}

	[HttpPost]
	public string Add([FromBody] Staff staff)
	{
        ValidationResult result = _validator.Validate(staff);
        if (result.IsValid)
        {
            _unitOfWork.StaffRepository.Add(staff);
            _unitOfWork.Complete();
			return "işlem başarılı";
        }
        else
        {
            return "yanlışsın böyle staff mı girilir " + result.ToString();
        }
	}

	[HttpPut("{id}")]
	public string Update([FromRoute] int id, [FromBody] Staff staff)
	{
        ValidationResult result = _validator.Validate(staff);
		if (result.IsValid)
		{
            staff.Id = id;
            _unitOfWork.StaffRepository.Update(staff);
            _unitOfWork.Complete();
			return "işlem başarılı";
        }
		else
		{
			return "yanlışsın böyle staff mı girilir " + result.ToString();
		}
	}

	[HttpDelete]
	public void Delete(int id)
	{
		_unitOfWork.StaffRepository.Remove(id);
		_unitOfWork.Complete();
	}
}
