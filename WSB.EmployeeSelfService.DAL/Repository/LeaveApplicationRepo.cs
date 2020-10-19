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

        private  LeaveApplication Add(AddLeaveApplicationCommand addLeaveApplicationCommand)
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

        private  void Update(AddLeaveApplicationCommand addLeaveApplicationCommand, LeaveApplication leave)
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
