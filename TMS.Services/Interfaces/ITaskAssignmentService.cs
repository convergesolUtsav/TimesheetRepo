﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Core;

namespace TMS.Services.Interfaces
{
    public interface ITaskAssignmentService
    {
        Task<IEnumerable<TaskAssignment>> GetAll();
        Task<TaskAssignment> GetById(int id);
        Task<int> Add(TaskAssignment taskAssignment);
        Task<int> Update(TaskAssignment taskAssignment);
        Task<int> Delete(int id);
    }
}