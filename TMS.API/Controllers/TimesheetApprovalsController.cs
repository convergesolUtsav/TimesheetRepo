using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TMS.API.DTOs;
using TMS.Core;
using TMS.Infrastructure.Interfaces;
using TMS.Infrastructure.Repository;

namespace TMS.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TimesheetApprovalsController : ControllerBase
	{
		private readonly ITimesheetApprovalsRepository _timesheetApprovalsRepository;
		private readonly ILogger _logger;

		public TimesheetApprovalsController(ITimesheetApprovalsRepository timesheetApprovalsRepository, ILogger<TimesheetApprovalsController> logger)
		{
			_timesheetApprovalsRepository = timesheetApprovalsRepository;
			_logger = logger;
		}
		[HttpGet("{id}")]
		public async Task<ResponseDTO<TimeSheetApprovals>> GetTimeSheetApproval(int id)
		{
			ResponseDTO<TimeSheetApprovals> response = new ResponseDTO<TimeSheetApprovals>();
			int StatusCode = 0;
			bool isSuccess = false;
			TimeSheetApprovals Response = null;
			string Message = "";
			string ExceptionMessage = "";
			try
			{
				var result = await _timesheetApprovalsRepository.GetTimesheetApproval(id);
				if (result == null)
				{
					isSuccess = false;
					StatusCode = 400;
					Message = "Invalid data";
				}
				else
				{
					StatusCode = 200;
					isSuccess = true;
					Message = "Valid data";
					Response = result;
				}

			}
			catch (Exception ex)
			{

				isSuccess = false;
				StatusCode = 500;
				Message = "Failed while fetching data.";
				ExceptionMessage = ex.Message.ToString();
				_logger.LogError(ex.ToString(), ex);
			}
			response.StatusCode = StatusCode;
			response.IsSuccess = isSuccess;
			response.Response = Response;
			response.Message = Message;
			response.ExceptionMessage = ExceptionMessage;

			return response;
		}
		[HttpGet("getallApproval")]
		public async Task<ResponseDTO<IEnumerable<TimeSheetApprovals>>> GetTimesheetApproval()
		{
			ResponseDTO<IEnumerable<TimeSheetApprovals>> response = new ResponseDTO<IEnumerable<TimeSheetApprovals>>();
			int StatusCode = 0;
			bool isSuccess = false;
			IEnumerable<TimeSheetApprovals> Response = null;
			string Message = "";
			string ExceptionMessage = "";

			try
			{
				var result = await _timesheetApprovalsRepository.GetTimesheetApprovals();
				if (result == null)
				{
					isSuccess = false;
					StatusCode = 400;
					Message = "Invalid data";
				}
				else
				{
					StatusCode = 200;
					isSuccess = true;
					Message = "Valid data";
					Response = result;
				}
			}
			catch (Exception ex)
			{
				isSuccess = false;
				StatusCode = 500;
				Message = "Failed while fetching data.";
				ExceptionMessage = ex.Message.ToString();
				_logger.LogError(ex.ToString(), ex);
			}
			response.StatusCode = StatusCode;
			response.IsSuccess = isSuccess;
			response.Response = Response;
			response.Message = Message;
			response.ExceptionMessage = ExceptionMessage;
			return response;
		}
		[HttpPost("createApprovals")]
		public async Task<ResponseDTO<int>> CreateTimesheetApproval(TimeSheetApprovals timeSheetApprovals)
		{
			ResponseDTO<int> response = new ResponseDTO<int>();
			int StatusCode = 0;
			bool isSuccess = false;
			int Response = 0;
			string Message = "";
			string ExceptionMessage = "";
			try
			{
				var result = await _timesheetApprovalsRepository.CreateTimesheetApproval(timeSheetApprovals);
				if (result == null)
				{
					isSuccess = false;
					StatusCode = 400;
					Message = "Invalid data";
				}
				else
				{
					StatusCode = 200;
					isSuccess = true;
					Message = "Data has been created";
					Response = result;
				}
			}
			catch (Exception ex)
			{
				isSuccess = false;
				StatusCode = 500;
				Message = "Failed while fetching data.";
				ExceptionMessage = ex.Message.ToString();
				_logger.LogError(ex.ToString(), ex);
			}
			response.StatusCode = StatusCode;
			response.IsSuccess = isSuccess;
			response.Response = Response;
			response.Message = Message;
			response.ExceptionMessage = ExceptionMessage;
			return response;
		}

		[HttpPut]
		public async Task<ResponseDTO<int>> UpdateTimesheetMaster(TimeSheetApprovals timeSheetApprovals)
		{
			ResponseDTO<int> response = new ResponseDTO<int>();
			int StatusCode = 0;
			bool isSuccess = false;
			int Response = 0;
			string Message = "";
			string ExceptionMessage = "";
			try
			{
				int entry = await _timesheetApprovalsRepository.UpdateTimesheetApproval(timeSheetApprovals);
				if (entry == null)
				{
					isSuccess = false;
					StatusCode = 400;
					Message = "Invalid data enter in filds ";
				}
				else
				{
					StatusCode = 200;
					isSuccess = true;
					Message = "Data has been successfully..!!";
					Response = entry;
				}
			}
			catch (Exception ex)
			{

				isSuccess = false;
				StatusCode = 500;
				Message = "Failed while fetching data.";
				ExceptionMessage = ex.Message.ToString();
				_logger.LogError(ex.ToString(), ex);
			}
			response.StatusCode = StatusCode;
			response.IsSuccess = isSuccess;
			response.Response = Response;
			response.Message = Message;
			response.ExceptionMessage = ExceptionMessage;
			return response;
		}

		[HttpDelete("{id}")]
		public async Task<ResponseDTO<int>> DeleteTimesheetMaster(int id)
		{
			ResponseDTO<int> response = new ResponseDTO<int>();
			int StatusCode = 0;
			bool isSuccess = false;
			int Response = 0;
			string Message = "";
			string ExceptionMessage = "";
			try
			{
				var data = await _timesheetApprovalsRepository.DeleteTimesheetApproval(id);
				if (data == null)
				{
					isSuccess = false;
					StatusCode = 400;
					Message = "Invalid data";
				}
				else
				{
					StatusCode = 200;
					isSuccess = true;
					Message = "Data has been deleted successfully";
					Response = data;
				}
			}
			catch (Exception ex)
			{
				isSuccess = false;
				StatusCode = 500;
				Message = "Failed while fetching data.";
				ExceptionMessage = ex.Message.ToString();
				_logger.LogError(ex.ToString(), ex);
			}
			response.StatusCode = StatusCode;
			response.IsSuccess = isSuccess;
			response.Response = Response;
			response.Message = Message;
			response.ExceptionMessage = ExceptionMessage;
			return response;
		}
	}
}
