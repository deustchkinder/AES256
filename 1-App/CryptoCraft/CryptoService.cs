using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace CryptoCraft;

public class CryptoService(System.Security.Cryptography.Aes myCrypto) : ICryptoService
{
     public string Encrypt(string textToEncrypt)
    {
        ICryptoTransform encryptor = myCrypto.CreateEncryptor(myCrypto.Key, myCrypto.IV);
        using MemoryStream msEncrypt = new();
        using CryptoStream csEncrypt = new(msEncrypt, encryptor, CryptoStreamMode.Write);
        using (StreamWriter swEncrypt = new(csEncrypt))
        {
            swEncrypt.Write(textToEncrypt);
        }
        return Convert.ToBase64String(msEncrypt.ToArray());
    }
    
    public string Decrypt(string encryptedText)
    {
        ICryptoTransform decryptor = myCrypto.CreateDecryptor(myCrypto.Key, myCrypto.IV);
        using MemoryStream msDecrypt = new(Convert.FromBase64String(encryptedText));
        using CryptoStream csDecrypt = new(msDecrypt, decryptor, CryptoStreamMode.Read);
        using StreamReader srDecrypt = new(csDecrypt);
        return srDecrypt.ReadToEnd();
    }
}
