using CryptoCraft;
using System.Security.Cryptography;
using System.Text;

using Aes myCrypto = Aes.Create();

myCrypto.KeySize = 256;
myCrypto.BlockSize = 128;
myCrypto.Mode = CipherMode.CBC;
myCrypto.Padding = PaddingMode.PKCS7;

myCrypto.GenerateKey();
myCrypto.GenerateIV();

myCrypto.Key = Encoding.UTF8.GetBytes("12345678901234567890123456789012"); //32bit
myCrypto.IV = Encoding.UTF8.GetBytes("1234567890123456"); //16bit

string anahtar = "SANA SITEM ETTIYSEM SITEM SEVGIDEN DOGAR";

CryptoService cryptoService = new(myCrypto);

string encryptedText = cryptoService.Encrypt(anahtar);
Console.WriteLine(encryptedText);

string decryptedText = cryptoService.Decrypt(encryptedText);
Console.WriteLine(decryptedText);


Console.Read();