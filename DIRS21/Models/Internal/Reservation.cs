namespace DIRS21.Models.Internal
{
    public class Reservation
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AmountPaid { get; set; }
        public string RoomId { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
    }
}
