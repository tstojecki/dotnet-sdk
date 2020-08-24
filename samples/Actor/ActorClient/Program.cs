// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.
// ------------------------------------------------------------

namespace ActorClient
{
    using System;
    using System.Threading.Tasks;
    using Dapr.Actors;
    using Dapr.Actors.Client;
    using IDemoActorInterface;

    /// <summary>
    /// Actor Client class.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Entry point.
        /// </summary>
        /// <param name="args">Arguments.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public static async Task Main(string[] args)
        {
            var data = new MyData()
            {
                PropertyA = "ValueA",
                PropertyB = "ValueB",
            };

            // Create an actor Id.
            var actorId1 = new ActorId("abc");
            var actorId2 = new ActorId("def");

            // Make strongly typed Actor calls with Remoting.
            // DemoActor is the type registered with Dapr runtime in the service.
            var proxy1 = ActorProxy.Create<IDemoActor>(actorId1, "DemoActor");
            var proxy2 = ActorProxy.Create<IDemoActor>(actorId2, "DemoActor");

            Console.WriteLine("Making call using actor proxy 1 to long running task.");
            await proxy1.RunLongTask();

            Console.WriteLine("Making call using actor proxy 2 to long running task.");
            await proxy2.RunLongTask();

            Console.WriteLine("Called actors 1 and 2");
        }
    }
}
