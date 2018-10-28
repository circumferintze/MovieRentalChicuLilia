namespace BestMovies.Models
{
    public class MembershipType
    {
        public int MembershipTypeId { get; set; }
        public string Type { get; set; }
        public byte Duration { get; set; }
        public int SignUpFee { get; set; }
        public byte DiscountRate { get; set; }
     }
}