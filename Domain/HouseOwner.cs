namespace Domain;

public class HouseOwner (int ownerId, string address, string biography)
{
        public int OwnerId { get; set; } = ownerId;
        public String Address { get; set; } = address;
        public String Biography { get; set; } = biography;
}