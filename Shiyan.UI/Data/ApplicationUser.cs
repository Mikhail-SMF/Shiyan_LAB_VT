using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.StaticFiles;

namespace Shiyan.UI.Data
{
    public class ApplicationUser : IdentityUser
    {
        public byte[]? Avatar { get; set; }
        public string MimeType { get; set; } = string.Empty;
    }
}
