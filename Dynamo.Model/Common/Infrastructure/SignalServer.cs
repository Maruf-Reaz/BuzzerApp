using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dynamo.Model.Common.Infrastructure
{
    public class SignalServer : Hub
    {

        public async Task Send()
        {
          
            await Clients.All.SendAsync("Receive");
        }
        public async Task EnableBuzzers()
        {

            await Clients.All.SendAsync("EnableBuzzer");
        }
        public async Task PressBuzzers()
        {
            await Clients.All.SendAsync("PressBuzzer");
        }

        public async Task DisableBuzzers()
        {
            await Clients.All.SendAsync("DisableBuzzer");
        }


        public async Task StartMcqs(int id)
        {

            await Clients.All.SendAsync("StartMcq", id);
        }
        public async Task StopMcqs(int id)
        {

            await Clients.All.SendAsync("StopMcq", id);
        }

        public async Task GetMcqResults(int id)
        {

            await Clients.All.SendAsync("GetMcqResult", id);
        }

    }
}
