using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Flurl.Http;
using Xunit;

namespace TestProject1
{
    public class UnitTest1
    {
        [Fact]
        public async Task Test1()
        {
            var url = "http://localhost:8060/";

            var listTask = new List<Task<IFlurlResponse>>();

            for (int i = 0; i < 100; i++)
            {
                listTask.Add((url + "?id=" + i).GetAsync());
            }

            var res = await Task.WhenAll(listTask);
        }
    }
}