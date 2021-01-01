using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSB.EmployeeSelfService.BLL.Infrastructure.Commands;
using WSB.EmployeeSelfService.BLL.Infrastructure.DTO;
using WSB.EmployeeSelfService.BLL.Infrastructure.Shared.Interfaces;
using WSB.EmployeeSelfService.DAL.DataContexts;
using WSB.EmployeeSelfService.Domain.Entities;
using static WSB.EmployeeSelfService.BLL.Infrastructure.Shared.Dictionary.Dictionary;

namespace WSB.EmployeeSelfService.DAL.Repository
{
    public class LeaveApplicationRepo : ILeaveApplicationRepo
    {
        private readonly WSBEmployeeSelfServiceDataContext _dbContext;
        private readonly IMapper _mapper;

        public LeaveApplicationRepo(WSBEmployeeSelfServiceDataContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<List<LeaveApplicationDTO>> GetActiveApplications()
        {
            var result = await _dbContext.LeaveApplications.Where(x => x.IsActive)?.ToListAsync();
            return _mapper.Map<List<LeaveApplicationDTO>>(result);
        }


        public async Task<List<LeaveApplicationDTO>> GetEmployeeApplications(int empCode)
        {
            var result = await _dbContext.LeaveApplications.Where(x => x.IsActive && x.EmployeeId == empCode)?.ToListAsync();
            return _mapper.Map<List<LeaveApplicationDTO>>(result);
        }

        public async Task<List<LeaveApproversDTO>> GetEmployeeApprovers(string empCode)
        {
            var result = await _dbContext.LeaveApprovers.Include(y => y.Employees)
                .Include(z => z.User)?.Where(u => u.Employees.Any(y => y.Empcode == empCode))?
                .Select(t => new LeaveApproversDTO
                {
                    Email = t.User.Email ?? string.Empty,
                    EmployeeCode = t.Employees.FirstOrDefault().Empcode,
                    FirstName = t.User.FirstName,
                    LastName = t.User.LastName,
                    LeaveApprovalLevel = t.User.LeaveApprovalLevel.Value,
                    UserId = t.User.Id
                })?.ToListAsync();
            return result;
        }

        public async Task<bool> UpdateStatus(LeaveStatus leaveStatus, int leaveId)
        {
            var result = await _dbContext.LeaveApplications.FirstOrDefaultAsync(x => x.Id == leaveId);
            if (result != null)
                result.LeaveStatus = leaveStatus;
            return await _dbContext.SaveChangesAsync() >= 0;
        }
        public async Task<LeaveApplicationDTO> AddOrUpdateLeave(AddLeaveApplicationCommand addLeaveApplicationCommand)
        {
            var leave = await _dbContext.LeaveApplications.FirstOrDefaultAsync(x => x.Id == addLeaveApplicationCommand.Id);
            if (leave != null)
            {
                Update(addLeaveApplicationCommand, leave);
            }
            else
            {
                leave = Add(addLeaveApplicationCommand);

            }
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<LeaveApplicationDTO>(leave);
        }

        private LeaveApplication Add(AddLeaveApplicationCommand addLeaveApplicationCommand)
        {
            return new LeaveApplication
            {
                LeaveType = addLeaveApplicationCommand.LeaveType,
                DateFrom = addLeaveApplicationCommand.DateFrom,
                DateTo = addLeaveApplicationCommand.DateTo,
                DaysTaken = addLeaveApplicationCommand.DaysTaken,
                LeaveStatus = addLeaveApplicationCommand.LeaveStatus,
                EmployeeId = addLeaveApplicationCommand.EmployeeId,
                Comment = addLeaveApplicationCommand.Comment
            };
        }

        private void Update(AddLeaveApplicationCommand addLeaveApplicationCommand, LeaveApplication leave)
        {
            leave.LeaveType = addLeaveApplicationCommand.LeaveType;
            leave.DateFrom = addLeaveApplicationCommand.DateFrom;
            leave.DateTo = addLeaveApplicationCommand.DateTo;
            leave.DaysTaken = addLeaveApplicationCommand.DaysTaken;
            leave.LeaveStatus = addLeaveApplicationCommand.LeaveStatus;
            leave.EmployeeId = addLeaveApplicationCommand.EmployeeId;
            leave.Comment = addLeaveApplicationCommand.Comment;
        }
    }
}
