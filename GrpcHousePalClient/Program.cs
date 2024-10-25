using Grpc.Core;
using Grpc.Net.Client;
using GrpcHousePalClient;

using var channel = GrpcChannel.ForAddress("http://localhost:8080", new GrpcChannelOptions
{
    Credentials = ChannelCredentials.Insecure,
});


var client = new HouseOwnerService.HouseOwnerServiceClient(channel);
try
{
    Console.WriteLine("getting a house owner to confirm connection is working:");
    var reply = client.GetHouseOwner(new HouseOwnerRequest { OwnerId = 1 });
    Console.WriteLine($"ID: {reply.OwnerId} \nAddress: {reply.Address} \nBiography: {reply.Biography}");
    
    Console.WriteLine("\nCreating a new house owner:");
    reply = client.CreateHouseOwner(new CreateHouseOwnerRequest { Address = "Poop street", Biography = "I live on poop street the name says everything about what to expect from this listing."});
    Console.WriteLine($"ID: {reply.OwnerId} \nAddress: {reply.Address} \nBiography: {reply.Biography}");
    
    Console.WriteLine("\nUpdating the new house owner:");
    reply = client.UpdateHouseOwner(new UpdateHouseOwnerRequest { OwnerId = 5, Address = "piss street", Biography = "no this is not an upgrade from poop street"});
    Console.WriteLine($"ID: {reply.OwnerId} \nAddress: {reply.Address} \nBiography: {reply.Biography}");
    
    Console.WriteLine("\ngetting the new house owner to confirm updating is working:");
    reply = client.GetHouseOwner(new HouseOwnerRequest { OwnerId = 5 });
    Console.WriteLine($"ID: {reply.OwnerId} \nAddress: {reply.Address} \nBiography: {reply.Biography}");
    
    Console.WriteLine("\nDeleting the new house owner:");
    reply = client.DeleteHouseOwner(new HouseOwnerRequest { OwnerId = 5 });
    Console.WriteLine($"ID: {reply.OwnerId} \nAddress: {reply.Address} \nBiography: {reply.Biography}");
    
    Console.WriteLine("Press any key to exit...");
    Console.ReadKey();
}
catch (RpcException ex)
{
    Console.WriteLine($"gRPC call failed: {ex.Status}, {ex.Message}");
}
catch (Exception ex)
{
    Console.WriteLine($"An unexpected error occurred: {ex.Message}");
}