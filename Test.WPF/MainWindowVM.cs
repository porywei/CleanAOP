﻿using CleanAOP;
using CleanAOP.AOP.AOPAttrubutes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Test.WPF
{
    public class MainWindowVM:Notice
    {
        public virtual string Name
        {
            set; get;
        }

        
        [TryCatchAttrubute]
        [LogAopAttrubute]
        [TimeAop]
        public virtual async Task DoWord()
        {
            await GetValueAsync(1234.5123, 1.01);
            throw new Exception("错误测试");
            Debug.WriteLine("123");
            Debug.WriteLine("123");
        }


        public Task<double> GetValueAsync(double num1, double num2)
        {
            return Task.Run(() =>
            {
                for (int i = 0; i < 1000000; i++)
                {
                    num1 = num1 / num2;
                }
                return num1;
            });
        }
    }
}
