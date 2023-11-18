using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;

namespace FoobleXSS.Pages;

public record PasswordHash(byte[] Hash, byte[] Salt);

public class LoginModel : PageModel
{
    private const int keySizeInBytes = 20;
    private const int saltSizeInBytes = 16;
    private const int iterations = 100_000;
    private const string invalidLoginMessage = "Invalid username or password";

    public string? ErrorMessage { get; set; }

    [Description("Username")]
    [Required]
    public string? Username { get; set; }

    [Description("Password")]
    [Required]
    public string? Password { get; set; }

    public void OnGet()
    {
    }

    public void OnPost(string username, string password)
    {
        var dbHash = getPasswordHashFromDb(username);
        if (dbHash is null)
        {
            ErrorMessage = invalidLoginMessage;
            return;
        }

        var inputHash = HashPassword(password, dbHash.Salt);
        if (CompareBytesSafe(dbHash.Hash, inputHash.Hash))
        {
            ErrorMessage = invalidLoginMessage;
            return;
        }

        // perform login successful operations here like setting
        // authorization cookie etc.
    }

    protected bool CompareBytes(byte[] a, byte[] b)
    {
        if (a.Length != b.Length)
        {
            return false;
        }
        for (int n = 0; n < a.Length; n++)
        {
            if (a[n] != b[n])
            {
                return false;
            }
        }
        return true;
    }

    protected byte[] GetRandomBytes(int length)
    {
        var result = new byte[length];
        using var generator = RandomNumberGenerator.Create();
        generator.GetBytes(result);
        return result;
    }

    protected bool CompareBytesSafe(byte[] a, byte[] b)
    {
        if (a.Length != b.Length)
        {
            // this should never be hit as hashes always have the
            // same length. so we keep this here.
            return false;
        }
        bool success = true;
        for (int n = 0; n < a.Length; n++)
        {
            success = success && (a[n] == b[n]);
        }
        return success;
    }

    private PasswordHash? getPasswordHashFromDb(string username)
    {
        return username == "beavis" ? HashPassword("butthead") : null;
    }

    protected PasswordHash HashPassword(string password)
    {
        using var pbkdf2 = new Rfc2898DeriveBytes(password,
          saltSizeInBytes, iterations, HashAlgorithmName.SHA256);
        var hash = pbkdf2.GetBytes(keySizeInBytes);
        return new PasswordHash(hash, pbkdf2.Salt);
    }

    protected static PasswordHash GetHash(Rfc2898DeriveBytes pbkdf2)
    {
        var hash = pbkdf2.GetBytes(keySizeInBytes);
        return new PasswordHash(hash, pbkdf2.Salt);
    }

    protected PasswordHash HashPassword(string password, byte[] salt)
    {
        using var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 
            iterations, HashAlgorithmName.SHA256);
        return GetHash(pbkdf2);
    }
}