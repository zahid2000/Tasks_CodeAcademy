﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PYP_Day16_Task.Entities;

namespace PYP_Day16_Task.Services.Abstract
{
    public interface IClientService
    {
        Task<List<VCard>> GetAllAsyncFromUrl(string url);
    }
}