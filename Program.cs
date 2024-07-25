using System;
using System.Security.Cryptography;

public class Program
{
    public static void Main()
    {
        // Độ dài của salt bạn muốn tạo
        int saltLength = 7;
        
        // Tạo salt ngẫu nhiên
        string salt = GenerateSalt(saltLength);
        
        // In ra salt đã tạo
        Console.WriteLine("Randomly generated salt: " + salt);
    }
    
    // Hàm để tạo salt ngẫu nhiên
    private static string GenerateSalt(int length)
    {
        const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        RNGCryptoServiceProvider cryptoServiceProvider = new RNGCryptoServiceProvider();
        byte[] data = new byte[length];
        cryptoServiceProvider.GetBytes(data);
        
        // Chuyển byte thành chuỗi salt
        string salt = string.Join("", data.Select(b => chars[b % chars.Length]));
        
        return salt;
    }
}