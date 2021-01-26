﻿using System;
using System.Linq;
using Castle.DynamicProxy;
using Core.CrossCutting.Logging;
using Core.Utilities.Intercepters;

namespace Core.Aspects.AutoFac.Logging
{
    public class LogInterceptionAspect : MethodInterception
    {
        private readonly LoggerService _loggerService;

        public LogInterceptionAspect(Type loggerType)
        {
            if (loggerType.BaseType != typeof(LoggerService))
                throw new Exception("Wrong Logger Type");

            _loggerService = (LoggerService)Activator.CreateInstance(loggerType);
        }


        protected override void OnBefore(IInvocation invocation)
        {
            var logParameters = invocation.Method.GetParameters()
              .Select((t, i) => new LogParameter
              {
                  Name = t.Name,
                  Type = t.ParameterType.Name,
                  Value = invocation.Arguments[i]
              }).ToList();

            var logDetail = new LogDetail
            {
                FullName = invocation.Method.DeclaringType == null ? null : invocation.Method.DeclaringType.Name,
                MethodName = invocation.Method.Name,
                LogParameters = logParameters
            };

            _loggerService.Debug(logDetail);
        }
    }
}