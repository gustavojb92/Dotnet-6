using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentResults;

namespace Dotnet_6.Exceptions.Interface
{
    public interface IDriverException
    {
        Result NoRepeatDriverException(string drivverNmae);
    }
}