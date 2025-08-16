using Libralgo.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace Libralgo.Models
{
    public class LibraryMember
    {
        [Required]
        public int LibraryId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public LibraryMemberRole Role { get; set; } = LibraryMemberRole.Member;

        [Required]
        public LibraryMemberStatus Status { get; set; } = LibraryMemberStatus.Pending;

        [Required]
        public int InvitedByUserId { get; set; }

        [Required]
        public DateTime InvitedAt { get; set; } = DateTime.UtcNow;

        public DateTime? AcceptedAt { get; set; }
        public DateTime? RevokedAt { get; set; }

        public virtual Library Library { get; set; } = null!;
        public virtual User User { get; set; } = null!;
        public virtual User InvitedByUser { get; set; } = null!;
    }
}
