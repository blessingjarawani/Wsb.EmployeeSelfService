using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WSB.EmployeeSelfService.BLL.Infrastructure.Commands;
using WSB.EmployeeSelfService.BLL.Infrastructure.DTO;
using WSB.EmployeeSelfService.BLL.Infrastructure.Shared.Interfaces;
using static WSB.EmployeeSelfService.BLL.Infrastructure.Shared.Dictionary.Dictionary;

namespace WSB.EmployeeSelfService.BLL.Infrastructure.Shared.Process
{
    public abstract class LeaveBaseProcess : ILeaveApplicationBaseProcess
    {
        protected LeaveApplicationDTO _leaveApplication;
        protected LeaveStatus _nextStatus;
        protected readonly ILeaveApplicationRepo _leaveApplicationRepo;
        protected List<LeaveApproversDTO> _leaveApprovers;
        public LeaveBaseProcess(ILeaveApplicationRepo leaveApplicationRepo)
        {
            _leaveApplicationRepo = leaveApplicationRepo;
        }
        public async Task Execute()
        {
            await GetApprovers();
            await UpdateStatus();
            await SendNotification();
        }

        protected virtual async Task UpdateStatus()
        {
            await _leaveApplicationRepo.UpdateStatus( _nextStatus, _leaveApplication.Id);
        }

        protected void Init(LeaveApplicationDTO leaveApplication, LeaveStatus leaveStatus)
        {
            _leaveApplication = leaveApplication;
            _nextStatus = leaveStatus;
        }

        protected virtual async Task GetApprovers()
        {
            _leaveApprovers = await _leaveApplicationRepo.GetEmployeeApprovers(_leaveApplication.EmployeeCode);
        }

        protected virtual async Task<bool> SendNotification()
        {
            return await Task.Run(() => true);
        }
    }
}
