﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.BLL.Interfaces
{
    public interface IParseCSVService
    {
        List<dynamic> ParseCsv(Stream fileStream);
    }
}
